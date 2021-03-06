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
	/// 数据访问类:T_JobSheet
	/// </summary>
	public partial class T_JobSheet:IT_JobSheet
	{
		public T_JobSheet()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(JobSheetID)+1 from T_JobSheet";
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
		public bool Exists(int JobSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheet_Exists");
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32,JobSheetID);
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
		public bool Add(MesWeb.Model.T_JobSheet model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheet_ADD");
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "JobSheetName", DbType.String, model.JobSheetName);
			db.AddInParameter(dbCommand, "JobSheetCode", DbType.String, model.JobSheetCode);
			db.AddInParameter(dbCommand, "JobSheetDate", DbType.String, model.JobSheetDate);
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, model.MaterialID);
			db.AddInParameter(dbCommand, "UnitLength", DbType.Int32, model.UnitLength);
			db.AddInParameter(dbCommand, "Numer", DbType.Int32, model.Numer);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
            return true;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_JobSheet model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheet_Update");
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "JobSheetName", DbType.String, model.JobSheetName);
			db.AddInParameter(dbCommand, "JobSheetCode", DbType.String, model.JobSheetCode);
			db.AddInParameter(dbCommand, "JobSheetDate", DbType.String, model.JobSheetDate);
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, model.MaterialID);
			db.AddInParameter(dbCommand, "UnitLength", DbType.Int32, model.UnitLength);
			db.AddInParameter(dbCommand, "Numer", DbType.Int32, model.Numer);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int JobSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheet_Delete");
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32,JobSheetID);

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
		public bool DeleteList(string JobSheetIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_JobSheet ");
			strSql.Append(" where JobSheetID in ("+JobSheetIDlist + ")  ");
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
		public MesWeb.Model.T_JobSheet GetModel(int JobSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheet_GetModel");
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32,JobSheetID);

			MesWeb.Model.T_JobSheet model=null;
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
		public MesWeb.Model.T_JobSheet DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_JobSheet model=new MesWeb.Model.T_JobSheet();
			if (row != null)
			{
				if(row["JobSheetID"]!=null && row["JobSheetID"].ToString()!="")
				{
					model.JobSheetID=int.Parse(row["JobSheetID"].ToString());
				}
				if(row["JobSheetName"]!=null)
				{
					model.JobSheetName=row["JobSheetName"].ToString();
				}
				if(row["JobSheetCode"]!=null)
				{
					model.JobSheetCode=row["JobSheetCode"].ToString();
				}
				if(row["JobSheetDate"]!=null && row["JobSheetDate"].ToString()!="")
				{
					model.JobSheetDate=DateTime.Parse(row["JobSheetDate"].ToString());
				}
				if(row["MaterialID"]!=null && row["MaterialID"].ToString()!="")
				{
					model.MaterialID=int.Parse(row["MaterialID"].ToString());
				}
				if(row["UnitLength"]!=null && row["UnitLength"].ToString()!="")
				{
					model.UnitLength=int.Parse(row["UnitLength"].ToString());
				}
				if(row["Numer"]!=null && row["Numer"].ToString()!="")
				{
					model.Numer=int.Parse(row["Numer"].ToString());
				}
				if(row["Comment"]!=null)
				{
					model.Comment=row["Comment"].ToString();
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
			strSql.Append("select JobSheetID,JobSheetName,JobSheetCode,JobSheetDate,MaterialID,UnitLength,Numer,Comment ");
			strSql.Append(" FROM T_JobSheet ");
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
			strSql.Append(" JobSheetID,JobSheetName,JobSheetCode,JobSheetDate,MaterialID,UnitLength,Numer,Comment ");
			strSql.Append(" FROM T_JobSheet ");
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
			strSql.Append("select count(1) FROM T_JobSheet ");
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
				strSql.Append("order by T.JobSheetID desc");
			}
			strSql.Append(")AS Row, T.*  from T_JobSheet T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_JobSheet");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "JobSheetID");
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
		public List<MesWeb.Model.T_JobSheet> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select JobSheetID,JobSheetName,JobSheetCode,JobSheetDate,MaterialID,UnitLength,Numer,Comment ");
			strSql.Append(" FROM T_JobSheet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_JobSheet> list = new List<MesWeb.Model.T_JobSheet>();
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
		public MesWeb.Model.T_JobSheet ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_JobSheet model=new MesWeb.Model.T_JobSheet();
			object ojb; 
			ojb = dataReader["JobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetID=(int)ojb;
			}
			model.JobSheetName=dataReader["JobSheetName"].ToString();
			model.JobSheetCode=dataReader["JobSheetCode"].ToString();
			ojb = dataReader["JobSheetDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetDate=(DateTime)ojb;
			}
			ojb = dataReader["MaterialID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaterialID=(int)ojb;
			}
			ojb = dataReader["UnitLength"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UnitLength=(int)ojb;
			}
			ojb = dataReader["Numer"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Numer=(int)ojb;
			}
			model.Comment=dataReader["Comment"].ToString();
			return model;
		}

		#endregion  Method
	}
}

