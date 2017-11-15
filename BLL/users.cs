using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Expense.Model;
using System.Web;
using Newtonsoft.Json;

namespace Expense.BLL
{
    /// <summary>
    /// users
    /// </summary>
    public partial class users
    {
        private readonly Expense.DAL.users dal = new Expense.DAL.users();
        public users()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string fusers_name)
        {
            return dal.Exists(fusers_name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Expense.Model.users model)
        {
            /// 创建默认分类
            Model.categories categories = new Model.categories();
            categories.fuid = model.fuid;
            categories.fdate = model.fdate;
            categories.fcategories_name = "默认分类";
            categories.fcategories_id = Guid.NewGuid().ToString();
            categories.fcategories_color = "ff981f";
            BLL.categories c = new BLL.categories();
            c.Add(categories);
            return dal.Add(model);
        }

        public string Register(HttpRequest Request)
        {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["username"]) && !string.IsNullOrEmpty(Request["passwd"]) && !string.IsNullOrEmpty(Request["email"]))
            {
                string fuid = Guid.NewGuid().ToString();
                string fusers_name = Request["username"];
                string fusers_email = Request["email"];
                string fusers_passwd = Request["passwd"];
                if (fusers_name.Length < 5)
                {
                    message.Code = 202;
                    message.Msg = "用户名长度必须大于等于5个字符长度";
                }
                else if (fusers_passwd.Length < 6)
                {
                    message.Code = 202;
                    message.Msg = "密码长度必须大于等于6个字符长度";
                }
                else
                {
                    Expense.Model.users model = new Expense.Model.users();
                    model.fuid = fuid;
                    model.fusers_name = fusers_name;
                    model.fusers_email = fusers_email;
                    model.fusers_passwd = BCrypt.Net.BCrypt.HashPassword(fusers_passwd);// 加密密码
                    model.fusers_stat = 1;
                    model.fnote = null;
                    model.fdate = DateTime.Now;
                    /// 先检测用户名是否已注册
                    if (Exists(fusers_name))
                    {
                        message.Msg = "用户名已存在！";
                        message.Code = 203;
                    }
                    else if (Add(model))
                    {
                        message.Code = 200;
                        message.Msg = "注册成功！";
                    }
                    else
                    {
                        message.Code = 500;
                        message.Msg = "注册失败！";
                    }
                }

                System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?");//实例化一个Regex对象
                if (fusers_email.Length < 5 || !re.IsMatch(fusers_name))
                {
                    message.Code = 202;
                    message.Msg = "邮箱格式不正确！";
                }
            }
            else
            {
                message.Code = 200;
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?username=[string]&passwd=[string]&email=[string]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="fusers_name">用户名</param>
        /// <param name="passwd">密码</param>
        /// <returns></returns>
        public Model.users Login(string fusers_name, string passwd)
        {
            if (dal.Exists(fusers_name))
            {
                var user = dal.GetModel(fusers_name);
                if (BCrypt.Net.BCrypt.Verify(passwd, user.fusers_passwd))
                {
                    /// 创建token
                    user.ftoken = Guid.NewGuid().ToString();
                    dal.Update(user);
                    /// 清除密码和用户GUID
                    user.fusers_passwd = null;
                    user.fuid = null;
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public string Login(HttpRequest Request)
        {
            Message.Message message = new Message.Message();
            if (Request["username"] != null && Request["passwd"] != null)
            {
                var uname = Request["username"];
                var passwd = Request["passwd"];// 密码
                var u = Login(uname, passwd);
                if (u != null)
                {
                    /// 登录成功
                    message.Code = 200;
                    message.Msg = "登陆成功！";
                    message.Body = u;
                }
                else
                {
                    /// 登录失败
                    message.Code = 203;
                    message.Msg = "用户名或密码错误！";
                }
            }
            else
            {
                message.Code = 200;
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?username=[string]&passwd=[string]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

        /// <summary>
        /// 登录检查
        /// </summary>
        /// <param name="ftoken">token</param>
        /// <returns></returns>
        public bool CheckLogin(string ftoken)
        {
            return dal.CheckToken(ftoken);
        }

        /// <summary>
        /// 通过Token得到一个对象实体
        /// </summary>
        public Expense.Model.users GetModelByToken(string ftoken)
        {

            return dal.GetModelByToken(ftoken);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Expense.Model.users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string fusers_name)
        {

            return dal.Delete(fusers_name);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string fusers_namelist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(fusers_namelist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Expense.Model.users GetModel(string fusers_name)
        {

            return dal.GetModel(fusers_name);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Expense.Model.users GetModelByCache(string fusers_name)
        {

            string CacheKey = "usersModel-" + fusers_name;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(fusers_name);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Expense.Model.users)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Expense.Model.users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Expense.Model.users> DataTableToList(DataTable dt)
        {
            List<Expense.Model.users> modelList = new List<Expense.Model.users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Expense.Model.users model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

