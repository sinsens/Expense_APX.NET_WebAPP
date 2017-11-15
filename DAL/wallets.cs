using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Expense.DAL
{
    /// <summary>
    /// 数据访问类:wallets
    /// </summary>
    public partial class wallets
    {
        public wallets()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string fwallets_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_wallets");
            strSql.Append(" where fwallets_id=@fwallets_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fwallets_id", MySqlDbType.VarChar,40)          };
            parameters[0].Value = fwallets_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Expense.Model.wallets model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_wallets(");
            strSql.Append("fwallets_id,fwallets_name,fuid,fbalance,freport,fnote,fdate)");
            strSql.Append(" values (");
            strSql.Append("@fwallets_id,@fwallets_name,@fuid,@fbalance,@freport,@fnote,@fdate)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fwallets_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@fwallets_name", MySqlDbType.VarChar,32),
                    new MySqlParameter("@fuid", MySqlDbType.VarChar,40),
                    new MySqlParameter("@fbalance", MySqlDbType.Int32,11),
                    new MySqlParameter("@freport", MySqlDbType.Int32,1),
                    new MySqlParameter("@fnote", MySqlDbType.VarChar,128),
                    new MySqlParameter("@fdate", MySqlDbType.DateTime)};
            parameters[0].Value = model.fwallets_id;
            parameters[1].Value = model.fwallets_name;
            parameters[2].Value = model.fuid;
            parameters[3].Value = model.fbalance;
            parameters[4].Value = model.freport;
            parameters[5].Value = model.fnote;
            parameters[6].Value = model.fdate;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Expense.Model.wallets model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_wallets set ");
            strSql.Append("fwallets_name=@fwallets_name,");
            strSql.Append("fuid=@fuid,");
            strSql.Append("fbalance=@fbalance,");
            strSql.Append("freport=@freport,");
            strSql.Append("fnote=@fnote,");
            strSql.Append("fdate=@fdate");
            strSql.Append(" where fwallets_id=@fwallets_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fwallets_name", MySqlDbType.VarChar,32),
                    new MySqlParameter("@fuid", MySqlDbType.VarChar,40),
                    new MySqlParameter("@fbalance", MySqlDbType.Int32,11),
                    new MySqlParameter("@freport", MySqlDbType.Int32,1),
                    new MySqlParameter("@fnote", MySqlDbType.VarChar,128),
                    new MySqlParameter("@fdate", MySqlDbType.DateTime),
                    new MySqlParameter("@fwallets_id", MySqlDbType.VarChar,40)};
            parameters[0].Value = model.fwallets_name;
            parameters[1].Value = model.fuid;
            parameters[2].Value = model.fbalance;
            parameters[3].Value = model.freport;
            parameters[4].Value = model.fnote;
            parameters[5].Value = model.fdate;
            parameters[6].Value = model.fwallets_id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string fwallets_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_wallets ");
            strSql.Append(" where fwallets_id=@fwallets_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fwallets_id", MySqlDbType.VarChar,40)          };
            parameters[0].Value = fwallets_id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string fwallets_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_wallets ");
            strSql.Append(" where fwallets_id in (" + fwallets_idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public Expense.Model.wallets GetModel(string fwallets_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fwallets_id,fwallets_name,fuid,fbalance,freport,fnote,fdate from t_wallets ");
            strSql.Append(" where fwallets_id=@fwallets_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fwallets_id", MySqlDbType.VarChar,40)          };
            parameters[0].Value = fwallets_id;

            Expense.Model.wallets model = new Expense.Model.wallets();
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
        /// 得到一个对象实体
        /// </summary>
        public Expense.Model.wallets DataRowToModel(DataRow row)
        {
            Expense.Model.wallets model = new Expense.Model.wallets();
            if (row != null)
            {
                if (row["fwallets_id"] != null)
                {
                    model.fwallets_id = row["fwallets_id"].ToString();
                }
                if (row["fwallets_name"] != null)
                {
                    model.fwallets_name = row["fwallets_name"].ToString();
                }
                if (row["fuid"] != null)
                {
                    model.fuid = row["fuid"].ToString();
                }
                if (row["fbalance"] != null && row["fbalance"].ToString() != "")
                {
                    model.fbalance = int.Parse(row["fbalance"].ToString());
                }
                if (row["freport"] != null && row["freport"].ToString() != "")
                {
                    model.freport = int.Parse(row["freport"].ToString());
                }
                if (row["fnote"] != null)
                {
                    model.fnote = row["fnote"].ToString();
                }
                if (row["fdate"] != null && row["fdate"].ToString() != "")
                {
                    model.fdate = DateTime.Parse(row["fdate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fwallets_id,fwallets_name,fuid,fbalance,freport,fnote,fdate ");
            strSql.Append(" FROM t_wallets ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_wallets ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.fwallets_id desc");
            }
            strSql.Append(")AS Row, T.*  from t_wallets T ");
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
			parameters[0].Value = "t_wallets";
			parameters[1].Value = "fwallets_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 计算钱包余额
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public int Sum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(fbalance) FROM t_wallets ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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

        #endregion  ExtensionMethod
    }
}

