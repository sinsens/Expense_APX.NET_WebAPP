using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Expense.DAL
{
	/// <summary>
	/// 数据访问类:v_trades
	/// </summary>
	public partial class v_trades
	{
		public v_trades()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Expense.Model.v_trades model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into v_trades(");
			strSql.Append("fuid,ftrades_id,fincome,fcategories_id,ftags,fwallets_id,fmoney,fnote,fconfirm,freport,fdate,fcategories_name,fwallets_name,fcategories_color)");
			strSql.Append(" values (");
			strSql.Append("@fuid,@ftrades_id,@fincome,@fcategories_id,@ftags,@fwallets_id,@fmoney,@fnote,@fconfirm,@freport,@fdate,@fcategories_name,@fwallets_name,@fcategories_color)");
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
					new MySqlParameter("@fdate", MySqlDbType.DateTime),
					new MySqlParameter("@fcategories_name", MySqlDbType.VarChar,20),
					new MySqlParameter("@fwallets_name", MySqlDbType.VarChar,32),
					new MySqlParameter("@fcategories_color", MySqlDbType.VarChar,6)};
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
			parameters[11].Value = model.fcategories_name;
			parameters[12].Value = model.fwallets_name;
			parameters[13].Value = model.fcategories_color;

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
		public bool Update(Expense.Model.v_trades model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_trades set ");
			strSql.Append("fuid=@fuid,");
			strSql.Append("ftrades_id=@ftrades_id,");
			strSql.Append("fincome=@fincome,");
			strSql.Append("fcategories_id=@fcategories_id,");
			strSql.Append("ftags=@ftags,");
			strSql.Append("fwallets_id=@fwallets_id,");
			strSql.Append("fmoney=@fmoney,");
			strSql.Append("fnote=@fnote,");
			strSql.Append("fconfirm=@fconfirm,");
			strSql.Append("freport=@freport,");
			strSql.Append("fdate=@fdate,");
			strSql.Append("fcategories_name=@fcategories_name,");
			strSql.Append("fwallets_name=@fwallets_name,");
			strSql.Append("fcategories_color=@fcategories_color");
			strSql.Append(" where ");
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
					new MySqlParameter("@fdate", MySqlDbType.DateTime),
					new MySqlParameter("@fcategories_name", MySqlDbType.VarChar,20),
					new MySqlParameter("@fwallets_name", MySqlDbType.VarChar,32),
					new MySqlParameter("@fcategories_color", MySqlDbType.VarChar,6)};
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
			parameters[11].Value = model.fcategories_name;
			parameters[12].Value = model.fwallets_name;
			parameters[13].Value = model.fcategories_color;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from v_trades ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Expense.Model.v_trades GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select fuid,ftrades_id,fincome,fcategories_id,ftags,fwallets_id,fmoney,fnote,fconfirm,freport,fdate,fcategories_name,fwallets_name,fcategories_color from v_trades ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Expense.Model.v_trades model=new Expense.Model.v_trades();
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
		public Expense.Model.v_trades DataRowToModel(DataRow row)
		{
			Expense.Model.v_trades model=new Expense.Model.v_trades();
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
				if(row["fcategories_name"]!=null)
				{
					model.fcategories_name=row["fcategories_name"].ToString();
				}
				if(row["fwallets_name"]!=null)
				{
					model.fwallets_name=row["fwallets_name"].ToString();
				}
				if(row["fcategories_color"]!=null)
				{
					model.fcategories_color=row["fcategories_color"].ToString();
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
			strSql.Append("select fuid,ftrades_id,fincome,fcategories_id,ftags,fwallets_id,fmoney,fnote,fconfirm,freport,fdate,fcategories_name,fwallets_name,fcategories_color ");
			strSql.Append(" FROM v_trades ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 分页获取数据列表，Sinsen
        /// </summary>
        public DataSet GetListByPage(string strWhere,  int startIndex, int endIndex)
        {
            /* 查询视图 */
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct * FROM v_trades");
            strSql.Append(" where " + strWhere);
            //strSql.Append(" GROUP BY ftrades_id");
            strSql.Append(" ORDER BY fdate DESC");
            if (startIndex<1)
            {
                strSql.AppendFormat(" LIMIT {0},{1}", 0, endIndex);
            }
            else
            {
                strSql.AppendFormat(" LIMIT {0},{1}", (startIndex - 1) * endIndex, endIndex);
            }
            
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM v_trades ");
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
			parameters[0].Value = "v_trades";
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

