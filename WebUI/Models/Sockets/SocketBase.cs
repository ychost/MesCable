﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace WebUI.Models.Sockets {
    public class SocketBase:ISocket, IDisposable {
        protected Socket Socket { get; private set; }
        protected Stream Stream { get; set; }

        /// <summary>
        /// 实例化TCP客户端。
        /// </summary>
        public SocketBase(Socket socket,ISocketHandler socketHandler) {
            if(socket == null)
                throw new ArgumentNullException("socket");
            if(socketHandler == null)
                throw new ArgumentNullException("socketHandler");
            Socket = socket;
            Handler = socketHandler;
        }

        /// <summary>
        /// Socket处理程序
        /// </summary>
        public ISocketHandler Handler { get; set; }

        /// <summary>
        /// 获取是否已连接。
        /// </summary>
        public bool IsConnected { get { return Socket.Connected; } }

        #region 断开连接

        /// <summary>
        /// 断开与服务器的连接。
        /// </summary>
        public void Disconnect() {
            //判断是否已连接
            if(!IsConnected)
                throw new SocketException(10057);
            lock(this) {
                //Socket异步断开并等待完成
                Socket.BeginDisconnect(true,EndDisconnect,true).AsyncWaitHandle.WaitOne();
            }
        }

        /// <summary>
        /// 异步断开与服务器的连接。
        /// </summary>
        public void DisconnectAsync() {
            //判断是否已连接
            if(!IsConnected)
                throw new SocketException(10057);
            lock(this) {
                //Socket异步断开
                Socket.BeginDisconnect(true,EndDisconnect,false);
            }
        }

        private void EndDisconnect(IAsyncResult result) {
            try {
                Socket.EndDisconnect(result);
            } catch {

            }
            //是否同步
            bool sync = (bool)result.AsyncState;

            if(!sync && DisconnectCompleted != null) {
                DisconnectCompleted(this,new SocketEventArgs(this,SocketAsyncOperation.Disconnect));
            }
        }

        //这是一个给收发异常准备的断开引发事件方法
        private void Disconnected(bool raiseEvent) {
            if(raiseEvent && DisconnectCompleted != null)
                DisconnectCompleted(this,new SocketEventArgs(this,SocketAsyncOperation.Disconnect));
        }

        #endregion

        #region 发送数据

        /// <summary>
        /// 发送数据。
        /// </summary>
        /// <param name="data">要发送的数据。</param>
        public void Send(byte[] data) {
            //是否已连接
            if(!IsConnected)
                throw new SocketException(10057);
            //发送的数据不能为null
            if(data == null)
                throw new ArgumentNullException("data");
            //发送的数据长度不能为0
            if(data.Length == 0)
                throw new ArgumentException("data的长度不能为0");

            //设置异步状态
            SocketAsyncState state = new SocketAsyncState();
            state.IsAsync = false;
            state.Data = data;
            try {
                //开始发送数据
                Handler.BeginSend(data,0,data.Length,Stream,EndSend,state).AsyncWaitHandle.WaitOne();
            } catch {
                //出现异常则断开Socket连接
                Disconnected(true);
            }
        }

        /// <summary>
        /// 异步发送数据。
        /// </summary>
        /// <param name="data">要发送的数据。</param>
        public void SendAsync(byte[] data) {
            //是否已连接
            if(!IsConnected)
                throw new SocketException(10057);
            //发送的数据不能为null
            if(data == null)
                throw new ArgumentNullException("data");
            //发送的数据长度不能为0
            if(data.Length == 0)
                throw new ArgumentException("data的长度不能为0");

            //设置异步状态
            SocketAsyncState state = new SocketAsyncState();
            state.IsAsync = true;
            state.Data = data;
            try {
                //开始发送数据并等待完成
                Handler.BeginSend(data,0,data.Length,Stream,EndSend,state);
            } catch {
                //出现异常则断开Socket连接
                Disconnected(true);
            }
        }

        private void EndSend(IAsyncResult result) {
            SocketAsyncState state = (SocketAsyncState)result.AsyncState;

            //是否完成
            state.Completed = Handler.EndSend(result);
            //没有完成则断开Socket连接
            if(!state.Completed)
                Disconnected(true);
            //引发发送结束事件
            if(state.IsAsync && SendCompleted != null) {
                SendCompleted(this,new SocketEventArgs(this,SocketAsyncOperation.Send) { Data = state.Data });
            }
        }

        #endregion

        #region 接收数据

        protected void EndReceive(IAsyncResult result) {
            SocketAsyncState state = (SocketAsyncState)result.AsyncState;
            //接收到的数据
            byte[] data = Handler.EndReceive(result);
            //如果数据长度为0，则断开Socket连接
            if(data.Length == 0) {
                Disconnected(true);
                return;
            }

            //再次开始接收数据
            Handler.BeginReceive(Stream,EndReceive,state);

            //引发接收完成事件
            if(ReceiveCompleted != null)
                ReceiveCompleted(this,new SocketEventArgs(this,SocketAsyncOperation.Receive) { Data = data });
        }

        #endregion

        #region 事件

        ///// <summary>
        ///// 断开完成时引发事件。
        ///// </summary>
        public event EventHandler<SocketEventArgs> DisconnectCompleted;
        ///// <summary>
        ///// 接收完成时引发事件。
        ///// </summary>
        public event EventHandler<SocketEventArgs> ReceiveCompleted;
        ///// <summary>
        ///// 发送完成时引发事件。
        ///// </summary>
        public event EventHandler<SocketEventArgs> SendCompleted;

        #endregion

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose() {
            lock(this) {
                if(IsConnected)
                    Socket.Disconnect(false);
                Socket.Close();
            }
        }


        internal class SocketAsyncState {
            /// <summary>
            /// 是否完成。
            /// </summary>
            public bool Completed { get; set; }

            /// <summary>
            /// 数据
            /// </summary>
            public byte[] Data { get; set; }
            /// <summary>
            /// 是否异步
            /// </summary>
            public bool IsAsync { get; set; }
        }
    }
}