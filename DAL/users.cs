using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Expense.DAL
{
	/// <summary>
	/// 数据访问类:users
	/// </summary>
	public partial class users
	{
		public users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string fusers_name)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_users");
			strSql.Append(" where fusers_name=@fusers_name ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fusers_name", MySqlDbType.VarChar,40)			};
			parameters[0].Value = fusers_name;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否已登录
        /// </summary>
        public bool CheckToken(string ftoken)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_users");
            strSql.Append(" where ftoken=@fusers_name ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fusers_name", MySqlDbType.VarChar,32)          };
            parameters[0].Value = ftoken;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 实现登录检查
        /// </summary>
        /// <param name="fusers_name"></param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public bool Login(string fusers_name, string passwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_users");
            strSql.Append(" where fusers_name=@fusers_name ");
            strSql.Append(" and fusers_passwd=@passwd ");
            strSql.Append(" and fusers_stat=1 ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fusers_name", MySqlDbType.VarChar,32),new MySqlParameter("@passwd", MySqlDbType.VarChar,32)          };
            parameters[0].Value = fusers_name;
            parameters[1].Value = passwd;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 通过Token得到一个对象实体
        /// </summary>
        public Expense.Model.users GetModelByToken(string ftoken)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fuid,fusers_name,fusers_email,fusers_passwd,fusers_stat,fnote,fdate,ftoken from t_users ");
            strSql.Append(" where ftoken=@fusers_name ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fusers_name", MySqlDbType.VarChar,32)          };
            parameters[0].Value = ftoken;

            Expense.Model.users model = new Expense.Model.users();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Expense.Model.users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_users(");
			strSql.Append("fuid,fusers_name,fusers_email,fusers_passwd,fusers_stat,fnote,fdate,ftoken)");
			strSql.Append(" values (");
			strSql.Append("@fuid,@fusers_name,@fusers_email,@fusers_passwd,@fusers_stat,@fnote,@fdate,@ftoken)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fuid", MySqlDbType.VarChar,40),
					new MySqlParameter("@fusers_name", MySqlDbType.VarChar,40),
					new MySqlParameter("@fusers_email", MySqlDbType.VarChar,40),
					new MySqlParameter("@fusers_passwd", MySqlDbType.VarChar,60),
					new MySqlParameter("@fusers_stat", MySqlDbType.Int32,1),
					new MySqlParameter("@fnote", MySqlDbType.VarChar,128),
					new MySqlParameter("@fdate", MySqlDbType.DateTime),
					new MySqlParameter("@ftoken", MySqlDbType.VarChar,40)};
			parameters[0].Value = model.fuid;
			parameters[1].Value = model.fusers_name;
			parameters[2].Value = model.fusers_email;
			parameters[3].Value = model.fusers_passwd;
			parameters[4].Value = model.fusers_stat;
			parameters[5].Value = model.fnote;
			parameters[6].Value = model.fdate;
			parameters[7].Value = model.ftoken;

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
		public bool Update(Expense.Model.users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_users set ");
			strSql.Append("fuid=@fuid,");
			strSql.Append("fusers_email=@fusers_email,");
			strSql.Append("fusers_passwd=@fusers_passwd,");
			strSql.Append("fusers_stat=@fusers_stat,");
			strSql.Append("fnote=@fnote,");
			strSql.Append("fdate=@fdate,");
			strSql.Append("ftoken=@ftoken");
			strSql.Append(" where fusers_name=@fusers_name ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fuid", MySqlDbType.VarChar,40),
					new MySqlParameter("@fusers_email", MySqlDbType.VarChar,40),
					new MySqlParameter("@fusers_passwd", MySqlDbType.VarChar,60),
					new MySqlParameter("@fusers_stat", MySqlDbType.Int32,1),
					new MySqlParameter("@fnote", MySqlDbType.VarChar,128),
					new MySqlParameter("@fdate", MySqlDbType.DateTime),
					new MySqlParameter("@ftoken", MySqlDbType.VarChar,40),
					new MySqlParameter("@fusers_name", MySqlDbType.VarChar,40)};
			parameters[0].Value = model.fuid;
			parameters[1].Value = model.fusers_email;
			parameters[2].Value = model.fusers_passwd;
			parameters[3].Value = model.fusers_stat;
			parameters[4].Value = model.fnote;
			parameters[5].Value = model.fdate;
			parameters[6].Value = model.ftoken;
			parameters[7].Value = model.fusers_name;

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
		public bool Delete(string fusers_name)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_users ");
			strSql.Append(" where fusers_name=@fusers_name ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fusers_name", MySqlDbType.VarChar,40)			};
			parameters[0].Value = fusers_name;

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
		public bool DeleteList(string fusers_namelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_users ");
			strSql.Append(" where fusers_name in ("+fusers_namelist + ")  ");
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
		public Expense.Model.users GetModel(string fusers_name)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select fuid,fusers_name,fusers_email,fusers_passwd,fusers_stat,fnote,fdate,ftoken from t_users ");
			strSql.Append(" where fusers_name=@fusers_name ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fusers_name", MySqlDbType.VarChar,40)			};
			parameters[0].Value = fusers_name;

			Expense.Model.users model=new Expense.Model.users();
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
		public Expense.Model.users DataRowToModel(DataRow row)
		{
			Expense.Model.users model=new Expense.Model.users();
			if (row != null)
			{
				if(row["fuid"]!=null)
				{
					model.fuid=row["fuid"].ToString();
				}
				if(row["fusers_name"]!=null)
				{
					model.fusers_name=row["fusers_name"].ToString();
				}
				if(row["fusers_email"]!=null)
				{
					model.fusers_email=row["fusers_email"].ToString();
				}
				if(row["fusers_passwd"]!=null)
				{
					model.fusers_passwd=row["fusers_passwd"].ToString();
				}
				if(row["fusers_stat"]!=null && row["fusers_stat"].ToString()!="")
				{
					model.fusers_stat=int.Parse(row["fusers_stat"].ToString());
				}
				if(row["fnote"]!=null)
				{
					model.fnote=row["fnote"].ToString();
				}
				if(row["fdate"]!=null && row["fdate"].ToString()!="")
				{
					model.fdate=DateTime.Parse(row["fdate"].ToString());
				}
				if(row["ftoken"]!=null)
				{
					model.ftoken=row["ftoken"].ToString();
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
			strSql.Append("select fuid,fusers_name,fusers_email,fusers_passwd,fusers_stat,fnote,fdate,ftoken ");
			strSql.Append(" FROM t_users ");
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
			strSql.Append("select count(1) FROM t_users ");
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
				strSql.Append("order by T.fusers_name desc");
			}
			strSql.Append(")AS Row, T.*  from t_users T ");
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
			parameters[0].Value = "t_users";
			parameters[1].Value = "fusers_name";
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

