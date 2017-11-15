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
    /// categories
    /// </summary>
    public partial class categories
    {
        private readonly Expense.DAL.categories dal = new Expense.DAL.categories();
        public categories()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string fcategories_id)
        {
            return dal.Exists(fcategories_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Expense.Model.categories model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public string Add(HttpRequest Request)
        {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]) && Request["fname"] != null)
            {
                var ftoken = Request["ftoken"];
                var fname = Request["fname"];
                var fcolor = Request["fcolor"];
                var fdate = DateTime.Now;
                var b = new Expense.BLL.users();
                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建Tags对象
                    Expense.Model.categories categories = new Expense.Model.categories();
                    categories.fcategories_name = fname;
                    categories.fcategories_id = Guid.NewGuid().ToString();
                    categories.fdate = fdate;
                    categories.fcategories_color = fcolor;
                    categories.fuid = b.GetModelByToken(ftoken).fuid;
                    if (Add(categories))
                    {
                        message.Code = 200;
                        message.Msg = "添加成功！";
                    }
                    else
                    {
                        message.Code = 201;
                        message.Msg = "添加失败！";
                    }
                }
                else
                {
                    /// 未登录
                    message.Code = 401;
                    message.Msg = "请先登录！";
                }

            }
            else
            {
                message.Code = 1;
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?ftoken=[string]&fname=[string]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

        public string Get(HttpRequest Request)
        {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]))
            {
                var ftoken = Request["ftoken"];
                var b = new Expense.BLL.users();
                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建Tags对象
                    var t = new Expense.BLL.categories();
                    var tag = new Expense.Model.categories();
                    tag.fuid = b.GetModelByToken(ftoken).fuid;
                    message.Body = t.GetModelList("fuid='" + tag.fuid + "'");
                    message.Code = 200;
                }
                else
                {
                    /// 未登录
                    message.Code = 401;
                    message.Msg = "请先登录！";
                }
            }
            else
            {
                message.Code = 400;
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?ftoken=[string]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

            /// <summary>
            /// 更新一条数据
            /// </summary>
            public bool Update(Expense.Model.categories model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(HttpRequest Request)
        {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]) && !string.IsNullOrEmpty(Request["fid"]) && !string.IsNullOrEmpty(Request["fname"]))
            {
                var ftoken = Request["ftoken"];
                var fname = Request["fname"];
                var fcolor = Request["fcolor"];
                var fid = Request["fid"]; // fid 是每个条数据的唯一id
                var b = new Expense.BLL.users();
                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建Tags对象
                    var t = new Expense.BLL.categories();
                    var tag = t.GetModel(fid);
                    tag.fcategories_name = fname;
                    tag.fcategories_color = fcolor;
                    if (Update(tag))
                    {
                        message.Code = 201;
                        message.Msg = "保存成功！";
                    }
                    else
                    {
                        message.Code = 400;
                        message.Msg = "保存失败！";
                    }
                }
                else
                {
                    /// 未登录
                    message.Code = 401;
                    message.Msg = "请先登录！";
                }
            }
            else
            {
                message.Code = 400;
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?ftoken=[string]&fid=[string]&fname=[fname]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string fcategories_id)
        {

            /// 删除所有该分类下的交易
            BLL.trades trades = new BLL.trades();
            var t = trades.GetList("fcategories_id='" + fcategories_id + "'");
            trades.DeleteBy("fcategories_id='" + fcategories_id + "'");
            return dal.Delete(fcategories_id);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public string Delete(HttpRequest Request)
        {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]) && !string.IsNullOrEmpty(Request["fid"]))
            {
                var ftoken = Request["ftoken"];
                var fid = Request["fid"]; // fid 是每个条数据的唯一id
                var b = new Expense.BLL.users();
                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建Tags对象
                    if (Delete(fid))
                    {
                        message.Code = 204;
                        message.Msg = "删除成功！";
                    }
                    else
                    {
                        message.Code = 400;
                        message.Msg = "删除失败！";
                    }
                }
                else
                {
                    /// 未登录
                    message.Code = 401;
                    message.Msg = "请先登录！";
                }
            }
            else
            {
                message.Code = 400;
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?ftoken=[string]&fid=[string]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string fcategories_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(fcategories_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Expense.Model.categories GetModel(string fcategories_id)
        {

            return dal.GetModel(fcategories_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Expense.Model.categories GetModelByCache(string fcategories_id)
        {

            string CacheKey = "categoriesModel-" + fcategories_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(fcategories_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Expense.Model.categories)objModel;
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
        public List<Expense.Model.categories> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Expense.Model.categories> DataTableToList(DataTable dt)
        {
            List<Expense.Model.categories> modelList = new List<Expense.Model.categories>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Expense.Model.categories model;
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

