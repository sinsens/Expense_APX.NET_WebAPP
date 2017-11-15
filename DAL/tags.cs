﻿using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Expense.DAL
{
	/// <summary>
	/// 数据访问类:tags
	/// </summary>
	public partial class tags
	{
		public tags()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ftags_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_tags");
			strSql.Append(" where ftags_id=@ftags_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ftags_id", MySqlDbType.VarChar,40)			};
			parameters[0].Value = ftags_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Expense.Model.tags model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_tags(");
			strSql.Append("ftags_id,ftags_name,fuid,fdate)");
			strSql.Append(" values (");
			strSql.Append("@ftags_id,@ftags_name,@fuid,@fdate)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ftags_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@ftags_name", MySqlDbType.VarChar,20),
					new MySqlParameter("@fuid", MySqlDbType.VarChar,32),
					new MySqlParameter("@fdate", MySqlDbType.DateTime)};
			parameters[0].Value = model.ftags_id;
			parameters[1].Value = model.ftags_name;
			parameters[2].Value = model.fuid;
			parameters[3].Value = model.fdate;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Expense.Model.tags model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_tags set ");
			strSql.Append("ftags_name=@ftags_name,");
			strSql.Append("fuid=@fuid,");
			strSql.Append("fdate=@fdate");
			strSql.Append(" where ftags_id=@ftags_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ftags_name", MySqlDbType.VarChar,20),
					new MySqlParameter("@fuid", MySqlDbType.VarChar,32),
					new MySqlParameter("@fdate", MySqlDbType.DateTime),
					new MySqlParameter("@ftags_id", MySqlDbType.VarChar,40)};
			parameters[0].Value = model.ftags_name;
			parameters[1].Value = model.fuid;
			parameters[2].Value = model.fdate;
			parameters[3].Value = model.ftags_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string ftags_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_tags ");
			strSql.Append(" where ftags_id=@ftags_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ftags_id", MySqlDbType.VarChar,40)			};
			parameters[0].Value = ftags_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string ftags_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_tags ");
			strSql.Append(" where ftags_id in ("+ftags_idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public Expense.Model.tags GetModel(string ftags_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ftags_id,ftags_name,fuid,fdate from t_tags ");
			strSql.Append(" where ftags_id=@ftags_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ftags_id", MySqlDbType.VarChar,40)			};
			parameters[0].Value = ftags_id;

			Expense.Model.tags model=new Expense.Model.tags();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
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
		public Expense.Model.tags DataRowToModel(DataRow row)
		{
			Expense.Model.tags model=new Expense.Model.tags();
			if (row != null)
			{
				if(row["ftags_id"]!=null)
				{
					model.ftags_id=row["ftags_id"].ToString();
				}
				if(row["ftags_name"]!=null)
				{
					model.ftags_name=row["ftags_name"].ToString();
				}
				if(row["fuid"]!=null)
				{
					model.fuid=row["fuid"].ToString();
				}
				if(row["fdate"]!=null && row["fdate"].ToString()!="")
				{
					model.fdate=DateTime.Parse(row["fdate"].ToString());
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
			strSql.Append("select ftags_id,ftags_name,fuid,fdate ");
			strSql.Append(" FROM t_tags ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_tags ");
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
				strSql.Append("order by T.ftags_id desc");
			}
			strSql.Append(")AS Row, T.*  from t_tags T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_tags";
			parameters[1].Value = "ftags_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

