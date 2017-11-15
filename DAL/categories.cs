using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Expense.DAL
{
    /// <summary>
    /// 数据访问类:categories
    /// </summary>
    public partial class categories
    {
        public categories()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string fcategories_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_categories");
            strSql.Append(" where fcategories_id=@fcategories_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fcategories_id", MySqlDbType.VarChar,40)           };
            parameters[0].Value = fcategories_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Expense.Model.categories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_categories(");
            strSql.Append("fcategories_id,fcategories_name,fcategories_color,fuid,fdate)");
            strSql.Append(" values (");
            strSql.Append("@fcategories_id,@fcategories_name,@fcategories_color,@fuid,@fdate)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fcategories_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@fcategories_name", MySqlDbType.VarChar,20),
                    new MySqlParameter("@fcategories_color", MySqlDbType.VarChar,6),
                    new MySqlParameter("@fuid", MySqlDbType.VarChar,40),
                    new MySqlParameter("@fdate", MySqlDbType.DateTime)};
            parameters[0].Value = model.fcategories_id;
            parameters[1].Value = model.fcategories_name;
            parameters[2].Value = model.fcategories_color;
            parameters[3].Value = model.fuid;
            parameters[4].Value = model.fdate;

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
        public bool Update(Expense.Model.categories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_categories set ");
            strSql.Append("fcategories_name=@fcategories_name,");
            strSql.Append("fcategories_color=@fcategories_color,");
            strSql.Append("fuid=@fuid,");
            strSql.Append("fdate=@fdate");
            strSql.Append(" where fcategories_id=@fcategories_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fcategories_name", MySqlDbType.VarChar,20),
                    new MySqlParameter("@fcategories_color", MySqlDbType.VarChar,6),
                    new MySqlParameter("@fuid", MySqlDbType.VarChar,40),
                    new MySqlParameter("@fdate", MySqlDbType.DateTime),
                    new MySqlParameter("@fcategories_id", MySqlDbType.VarChar,40)};
            parameters[0].Value = model.fcategories_name;
            parameters[1].Value = model.fcategories_color;
            parameters[2].Value = model.fuid;
            parameters[3].Value = model.fdate;
            parameters[4].Value = model.fcategories_id;

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
        public bool Delete(string t_categories_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_categories ");
            strSql.Append(" where fcategories_id=@fcategories_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fcategories_id", MySqlDbType.VarChar,40)           };
            parameters[0].Value = t_categories_id;

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
        public bool DeleteList(string fcategories_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_categories ");
            strSql.Append(" where fcategories_id in (" + fcategories_idlist + ")  ");
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
        public Expense.Model.categories GetModel(string fcategories_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fcategories_id,fcategories_name,fcategories_color,fuid,fdate from t_categories ");
            strSql.Append(" where fcategories_id=@fcategories_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fcategories_id", MySqlDbType.VarChar,40)           };
            parameters[0].Value = fcategories_id;

            Expense.Model.categories model = new Expense.Model.categories();
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
        public Expense.Model.categories DataRowToModel(DataRow row)
        {
            Expense.Model.categories model = new Expense.Model.categories();
            if (row != null)
            {
                if (row["fcategories_id"] != null)
                {
                    model.fcategories_id = row["fcategories_id"].ToString();
                }
                if (row["fcategories_name"] != null)
                {
                    model.fcategories_name = row["fcategories_name"].ToString();
                }
                if (row["fcategories_color"] != null)
                {
                    model.fcategories_color = row["fcategories_color"].ToString();
                }
                if (row["fuid"] != null)
                {
                    model.fuid = row["fuid"].ToString();
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
            strSql.Append("select fcategories_id,fcategories_name,fcategories_color,fuid,fdate ");
            strSql.Append(" FROM t_categories ");
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
            strSql.Append("select count(1) FROM t_categories ");
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
                strSql.Append("order by T.fcategories_id desc");
            }
            strSql.Append(")AS Row, T.*  from t_categories T ");
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
			parameters[0].Value = "t_categories";
			parameters[1].Value = "fcategories_id";
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

