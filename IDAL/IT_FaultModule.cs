﻿
using System;
using System.Data;
namespace MesWeb.IDAL
{
	/// <summary>
	/// 接口层T_FaultModule
	/// </summary>
	public interface IT_FaultModule
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int FaultModuleID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(MesWeb.Model.T_FaultModule model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(MesWeb.Model.T_FaultModule model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int FaultModuleID);
		bool DeleteList(string FaultModuleIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MesWeb.Model.T_FaultModule GetModel(int FaultModuleID);
		MesWeb.Model.T_FaultModule DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	} 
}
