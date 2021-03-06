﻿/**  版本信息模板在安装目录下，可自行修改。
* T_ParameterCode.cs
*
* 功 能： N/A
* 类 名： T_ParameterCode
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 11:15:23   N/A    初版
*
* Copyright (c) 2012 MES Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_ParameterCode
	/// </summary>
	public partial class T_ParameterCode:IT_ParameterCode
	{
		public T_ParameterCode()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ParameterCodeID", "T_ParameterCode"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ParameterCodeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_ParameterCode");
			strSql.Append(" where ParameterCodeID=@ParameterCodeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParameterCodeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_ParameterCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_ParameterCode(");
			strSql.Append("ParameterCode,ParameterType,ParameterName,ParameterUnitID,ParameterBit,Type)");
			strSql.Append(" values (");
			strSql.Append("@ParameterCode,@ParameterType,@ParameterName,@ParameterUnitID,@ParameterBit,@Type)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterCode", SqlDbType.Int,4),
					new SqlParameter("@ParameterType", SqlDbType.Int,4),
					new SqlParameter("@ParameterName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4),
					new SqlParameter("@ParameterBit", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.Int,4)};
			parameters[0].Value = model.ParameterCode;
			parameters[1].Value = model.ParameterType;
			parameters[2].Value = model.ParameterName;
			parameters[3].Value = model.ParameterUnitID;
			parameters[4].Value = model.ParameterBit;
			parameters[5].Value = model.Type;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_ParameterCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_ParameterCode set ");
			strSql.Append("ParameterCode=@ParameterCode,");
			strSql.Append("ParameterType=@ParameterType,");
			strSql.Append("ParameterName=@ParameterName,");
			strSql.Append("ParameterUnitID=@ParameterUnitID,");
			strSql.Append("ParameterBit=@ParameterBit,");
			strSql.Append("Type=@Type");
			strSql.Append(" where ParameterCodeID=@ParameterCodeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterCode", SqlDbType.Int,4),
					new SqlParameter("@ParameterType", SqlDbType.Int,4),
					new SqlParameter("@ParameterName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4),
					new SqlParameter("@ParameterBit", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4)};
			parameters[0].Value = model.ParameterCode;
			parameters[1].Value = model.ParameterType;
			parameters[2].Value = model.ParameterName;
			parameters[3].Value = model.ParameterUnitID;
			parameters[4].Value = model.ParameterBit;
			parameters[5].Value = model.Type;
			parameters[6].Value = model.ParameterCodeID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ParameterCodeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ParameterCode ");
			strSql.Append(" where ParameterCodeID=@ParameterCodeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParameterCodeID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ParameterCodeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ParameterCode ");
			strSql.Append(" where ParameterCodeID in ("+ParameterCodeIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_ParameterCode GetModel(int ParameterCodeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ParameterCodeID,ParameterCode,ParameterType,ParameterName,ParameterUnitID,ParameterBit,Type from T_ParameterCode ");
			strSql.Append(" where ParameterCodeID=@ParameterCodeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParameterCodeID;

			MesWeb.Model.T_ParameterCode model=new MesWeb.Model.T_ParameterCode();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_ParameterCode DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_ParameterCode model=new MesWeb.Model.T_ParameterCode();
			if (row != null)
			{
				if(row["ParameterCodeID"]!=null && row["ParameterCodeID"].ToString()!="")
				{
					model.ParameterCodeID=int.Parse(row["ParameterCodeID"].ToString());
				}
				if(row["ParameterCode"]!=null && row["ParameterCode"].ToString()!="")
				{
					model.ParameterCode=int.Parse(row["ParameterCode"].ToString());
				}
				if(row["ParameterType"]!=null && row["ParameterType"].ToString()!="")
				{
					model.ParameterType=int.Parse(row["ParameterType"].ToString());
				}
				if(row["ParameterName"]!=null)
				{
					model.ParameterName=row["ParameterName"].ToString();
				}
				if(row["ParameterUnitID"]!=null && row["ParameterUnitID"].ToString()!="")
				{
					model.ParameterUnitID=int.Parse(row["ParameterUnitID"].ToString());
				}
				if(row["ParameterBit"]!=null && row["ParameterBit"].ToString()!="")
				{
					model.ParameterBit=int.Parse(row["ParameterBit"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ParameterCodeID,ParameterCode,ParameterType,ParameterName,ParameterUnitID,ParameterBit,Type ");
			strSql.Append(" FROM T_ParameterCode ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ParameterCodeID,ParameterCode,ParameterType,ParameterName,ParameterUnitID,ParameterBit,Type ");
			strSql.Append(" FROM T_ParameterCode ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_ParameterCode ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ParameterCodeID desc");
			}
			strSql.Append(")AS Row, T.*  from T_ParameterCode T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_ParameterCode";
			parameters[1].Value = "ParameterCodeID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

