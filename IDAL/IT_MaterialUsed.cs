﻿using System;
using System.Data;
namespace MesWeb.IDAL
{
	/// <summary>
	/// 接口层T_MaterialUsed
	/// </summary>
	public interface IT_MaterialUsed
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int MaterialUsedID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(MesWeb.Model.T_MaterialUsed model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(MesWeb.Model.T_MaterialUsed model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int MaterialUsedID);
		bool DeleteList(string MaterialUsedIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MesWeb.Model.T_MaterialUsed GetModel(int MaterialUsedID);
		MesWeb.Model.T_MaterialUsed DataRowToModel(DataRow row);
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
