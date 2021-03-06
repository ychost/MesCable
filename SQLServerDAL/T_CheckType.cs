﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_CheckType
	/// </summary>
	public partial class T_CheckType:IT_CheckType
	{
		public T_CheckType()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CheckTypeID)+1 from T_CheckType";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CheckTypeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckType_Exists");
			db.AddInParameter(dbCommand, "CheckTypeID", DbType.Int32,CheckTypeID);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			int.TryParse(obj.ToString(),out result);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(MesWeb.Model.T_CheckType model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckType_ADD");
			db.AddInParameter(dbCommand, "CheckTypeID", DbType.Int32, model.CheckTypeID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "CheckTypeName", DbType.String, model.CheckTypeName);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_CheckType model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckType_Update");
			db.AddInParameter(dbCommand, "CheckTypeID", DbType.Int32, model.CheckTypeID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "CheckTypeName", DbType.String, model.CheckTypeName);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CheckTypeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckType_Delete");
			db.AddInParameter(dbCommand, "CheckTypeID", DbType.Int32,CheckTypeID);

			int rows=db.ExecuteNonQuery(dbCommand);
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
		public bool DeleteList(string CheckTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CheckType ");
			strSql.Append(" where CheckTypeID in ("+CheckTypeIDlist + ")  ");
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
		public MesWeb.Model.T_CheckType GetModel(int CheckTypeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckType_GetModel");
			db.AddInParameter(dbCommand, "CheckTypeID", DbType.Int32,CheckTypeID);

			MesWeb.Model.T_CheckType model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_CheckType DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CheckType model=new MesWeb.Model.T_CheckType();
			if (row != null)
			{
				if(row["CheckTypeID"]!=null && row["CheckTypeID"].ToString()!="")
				{
					model.CheckTypeID=int.Parse(row["CheckTypeID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["CheckTypeName"]!=null)
				{
					model.CheckTypeName=row["CheckTypeName"].ToString();
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
			strSql.Append("select CheckTypeID,SpecificationID,CheckTypeName ");
			strSql.Append(" FROM T_CheckType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
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
			strSql.Append(" CheckTypeID,SpecificationID,CheckTypeName ");
			strSql.Append(" FROM T_CheckType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_CheckType ");
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
				strSql.Append("order by T.CheckTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CheckType T ");
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
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_CheckType");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CheckTypeID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<MesWeb.Model.T_CheckType> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CheckTypeID,SpecificationID,CheckTypeName ");
			strSql.Append(" FROM T_CheckType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_CheckType> list = new List<MesWeb.Model.T_CheckType>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public MesWeb.Model.T_CheckType ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_CheckType model=new MesWeb.Model.T_CheckType();
			object ojb; 
			ojb = dataReader["CheckTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CheckTypeID=(int)ojb;
			}
			ojb = dataReader["SpecificationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpecificationID=(int)ojb;
			}
			model.CheckTypeName=dataReader["CheckTypeName"].ToString();
			return model;
		}

		#endregion  Method
	}
}

