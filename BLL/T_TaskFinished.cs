﻿using System;
using System.Data;
using System.Collections.Generic;
using MES.Common;
using MesWeb.Model;
using MesWeb.DALFactory;
using MesWeb.IDAL;
namespace MesWeb.BLL
{
	/// <summary>
	/// T_TaskFinished
	/// </summary>
	public partial class T_TaskFinished
	{
		private readonly IT_TaskFinished dal=DataAccess.CreateT_TaskFinished();
		public T_TaskFinished()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TaskFinishedID)
		{
			return dal.Exists(TaskFinishedID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MesWeb.Model.T_TaskFinished model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_TaskFinished model)
		{
			 dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TaskFinishedID)
		{
			
			return dal.Delete(TaskFinishedID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TaskFinishedIDlist )
		{
			return dal.DeleteList(TaskFinishedIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_TaskFinished GetModel(int TaskFinishedID)
		{
			
			return dal.GetModel(TaskFinishedID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MesWeb.Model.T_TaskFinished GetModelByCache(int TaskFinishedID)
		{
			
			string CacheKey = "T_TaskFinishedModel-" + TaskFinishedID;
			object objModel = MES.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TaskFinishedID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
						MES.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MesWeb.Model.T_TaskFinished)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MesWeb.Model.T_TaskFinished> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MesWeb.Model.T_TaskFinished> DataTableToList(DataTable dt)
		{
			List<MesWeb.Model.T_TaskFinished> modelList = new List<MesWeb.Model.T_TaskFinished>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MesWeb.Model.T_TaskFinished model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

