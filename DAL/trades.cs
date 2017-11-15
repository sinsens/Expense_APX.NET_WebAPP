using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Expense.DAL
{
	/// <summary>
	/// 数据访问类:trades
	/// </summary>
	public partial class trades
	{
		public trades()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ftrades_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_trades");
			strSql.Append(" where ftrades_id=@ftrades_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ftrades_id", MySqlDbType.VarChar,40)			};
			parameters[0].Value = ftrades_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Expense.Model.trades model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_trades(");
			strSql.Append("fuid,ftrades_id,fincome,fcategories_id,ftags,fwallets_id,fmoney,fnote,fconfirm,freport,fdate)");
			strSql.Append(" values (");
			strSql.Append("@fuid,@ftrades_id,@fincome,@fcategories_id,@ftags,@fwallets_id,@fmoney,@fnote,@fconfirm,@freport,@fdate)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fuid", MySqlDbType.VarChar,40),
					new MySqlParameter("@ftrades_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@fincome", MySqlDbType.Int32,1),
					new MySqlParameter("@fcategories_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@ftags", MySqlDbType.VarChar,40),
					new MySqlParameter("@fwallets_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@fmoney", MySqlDbType.Int32,11),
					new MySqlParameter("@fnote", MySqlDbType.VarChar,128),
					new MySqlParameter("@fconfirm", MySqlDbType.Int32,1),
					new MySqlParameter("@freport", MySqlDbType.Int32,1),
					new MySqlParameter("@fdate", MySqlDbType.DateTime)};
			parameters[0].Value = model.fuid;
			parameters[1].Value = model.ftrades_id;
			parameters[2].Value = model.fincome;
			parameters[3].Value = model.fcategories_id;
			parameters[4].Value = model.ftags;
			parameters[5].Value = model.fwallets_id;
			parameters[6].Value = model.fmoney;
			parameters[7].Value = model.fnote;
			parameters[8].Value = model.fconfirm;
			parameters[9].Value = model.freport;
			parameters[10].Value = model.fdate;

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
		public bool Update(Expense.Model.trades model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_trades set ");
			strSql.Append("fuid=@fuid,");
			strSql.Append("fincome=@fincome,");
			strSql.Append("fcategories_id=@fcategories_id,");
			strSql.Append("ftags=@ftags,");
			strSql.Append("fwallets_id=@fwallets_id,");
			strSql.Append("fmoney=@fmoney,");
			strSql.Append("fnote=@fnote,");
			strSql.Append("fconfirm=@fconfirm,");
			strSql.Append("freport=@freport,");
			strSql.Append("fdate=@fdate");
			strSql.Append(" where ftrades_id=@ftrades_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fuid", MySqlDbType.VarChar,40),
					new MySqlParameter("@fincome", MySqlDbType.Int32,1),
					new MySqlParameter("@fcategories_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@ftags", MySqlDbType.VarChar,40),
					new MySqlParameter("@fwallets_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@fmoney", MySqlDbType.Int32,11),
					new MySqlParameter("@fnote", MySqlDbType.VarChar,128),
					new MySqlParameter("@fconfirm", MySqlDbType.Int32,1),
					new MySqlParameter("@freport", MySqlDbType.Int32,1),
					new MySqlParameter("@fdate", MySqlDbType.DateTime),
					new MySqlParameter("@ftrades_id", MySqlDbType.VarChar,40)};
			parameters[0].Value = model.fuid;
			parameters[1].Value = model.fincome;
			parameters[2].Value = model.fcategories_id;
			parameters[3].Value = model.ftags;
			parameters[4].Value = model.fwallets_id;
			parameters[5].Value = model.fmoney;
			parameters[6].Value = model.fnote;
			parameters[7].Value = model.fconfirm;
			parameters[8].Value = model.freport;
			parameters[9].Value = model.fdate;
			parameters[10].Value = model.ftrades_id;

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
		public bool Delete(string ftrades_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_trades ");
			strSql.Append(" where ftrades_id=@ftrades_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ftrades_id", MySqlDbType.VarChar,40)			};
			parameters[0].Value = ftrades_id;

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
		public bool DeleteList(string ftrades_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_trades ");
			strSql.Append(" where ftrades_id in ("+ftrades_idlist + ")  ");
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
		public Expense.Model.trades GetModel(string ftrades_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select fuid,ftrades_id,fincome,fcategories_id,ftags,fwallets_id,fmoney,fnote,fconfirm,freport,fdate from t_trades ");
			strSql.Append(" where ftrades_id=@ftrades_id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ftrades_id", MySqlDbType.VarChar,40)			};
			parameters[0].Value = ftrades_id;

			Expense.Model.trades model=new Expense.Model.trades();
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
		public Expense.Model.trades DataRowToModel(DataRow row)
		{
			Expense.Model.trades model=new Expense.Model.trades();
			if (row != null)
			{
				if(row["fuid"]!=null)
				{
					model.fuid=row["fuid"].ToString();
				}
				if(row["ftrades_id"]!=null)
				{
					model.ftrades_id=row["ftrades_id"].ToString();
				}
				if(row["fincome"]!=null && row["fincome"].ToString()!="")
				{
					model.fincome=int.Parse(row["fincome"].ToString());
				}
				if(row["fcategories_id"]!=null)
				{
					model.fcategories_id=row["fcategories_id"].ToString();
				}
				if(row["ftags"]!=null)
				{
					model.ftags=row["ftags"].ToString();
				}
				if(row["fwallets_id"]!=null)
				{
					model.fwallets_id=row["fwallets_id"].ToString();
				}
				if(row["fmoney"]!=null && row["fmoney"].ToString()!="")
				{
					model.fmoney=int.Parse(row["fmoney"].ToString());
				}
				if(row["fnote"]!=null)
				{
					model.fnote=row["fnote"].ToString();
				}
				if(row["fconfirm"]!=null && row["fconfirm"].ToString()!="")
				{
					model.fconfirm=int.Parse(row["fconfirm"].ToString());
				}
				if(row["freport"]!=null && row["freport"].ToString()!="")
				{
					model.freport=int.Parse(row["freport"].ToString());
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
			strSql.Append("select fuid,ftrades_id,fincome,fcategories_id,ftags,fwallets_id,fmoney,fnote,fconfirm,freport,fdate ");
			strSql.Append(" FROM t_trades ");
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
			strSql.Append("select count(1) FROM t_trades ");
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
				strSql.Append("order by T.ftrades_id desc");
			}
			strSql.Append(")AS Row, T.*  from t_trades T ");
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
			parameters[0].Value = "t_trades";
			parameters[1].Value = "ftrades_id";
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

