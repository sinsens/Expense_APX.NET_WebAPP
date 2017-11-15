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
    /// wallets
    /// </summary>
    public partial class wallets
    {
        private readonly Expense.DAL.wallets dal = new Expense.DAL.wallets();
        public wallets()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string fwallets_id)
        {
            return dal.Exists(fwallets_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Expense.Model.wallets model)
        {
            return dal.Add(model);
        }

        public string Get(HttpRequest Request) {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]))
            {
                var ftoken = Request["ftoken"];
                var b = new Expense.BLL.users();
                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建Tags对象
                    message.Code = 200;
                    var t = new Expense.BLL.wallets();
                    var tag = new Expense.Model.wallets();
                    tag.fuid = b.GetModelByToken(ftoken).fuid;
                    message.Body = t.GetModelList("fuid='" + tag.fuid + "'");
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
        /// 增加一条数据
        /// </summary>
        public string Add(HttpRequest Request)
        {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]) && Request["fname"] != null)
            {
                var ftoken = Request["ftoken"];
                var fname = Request["fname"];
                var fnote = Request["fnote"];
                var fbalance = 0;
                /* 2017年11月14日 修复用户输入钱包余额为空时的异常处理 */
                try
                {
                    fbalance = Convert.ToInt32(Request["fbalance"]);
                }
                catch
                {
                    fbalance = 0;
                }
                var fdate = DateTime.Now;
                var freport = Convert.ToInt32(Request["freport"]);
                var b = new Expense.BLL.users();

                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建Wallets对象
                    Expense.Model.wallets wallets = new Expense.Model.wallets();
                    wallets.fwallets_name = fname;
                    wallets.fwallets_id = Guid.NewGuid().ToString();
                    wallets.fbalance = fbalance;
                    wallets.fdate = fdate;
                    wallets.fnote = fnote;
                    wallets.freport = freport;
                    wallets.fuid = b.GetModelByToken(ftoken).fuid;
                    if (Add(wallets))
                    {
                        message.Code = 201;
                        message.Msg = "添加成功！";
                    }
                    else
                    {
                        message.Code = 400;
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
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?ftoken=[string]&fname=[string]&fbalence=[int]&fnote=[string]&freport=[int]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

        public string Update(HttpRequest Request) {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]) && Request["fname"] != null && !string.IsNullOrEmpty(Request["fid"]))
            {
                var fid = Request["fid"];
                var ftoken = Request["ftoken"];
                var fname = Request["fname"];
                var fnote = Request["fnote"];
                var fbalance = 0;
                /* 2017年11月14日 修复用户输入钱包余额为空时的异常处理 */
                try
                {
                    fbalance = Convert.ToInt32(Request["fbalance"]);
                }
                catch
                {
                    fbalance = 0;
                }
                var fdate = DateTime.Now;
                var freport = Convert.ToInt32(Request["freport"]);
                var b = new Expense.BLL.users();

                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建Wallets对象
                    Expense.Model.wallets wallets = new Expense.Model.wallets();

                    wallets.fwallets_name = fname;
                    wallets.fwallets_id = fid;
                    wallets.fbalance = fbalance;
                    wallets.fdate = fdate;
                    wallets.fnote = fnote;
                    wallets.freport = freport;
                    wallets.fuid = b.GetModelByToken(ftoken).fuid;
                    if (Update(wallets))
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
                    message.Msg = "请先登录！";
                    message.Code = 401;
                }
            }
            else
            {
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?ftoken=[string]&fid=[string]&fname=[string]&fbalance=[int]&fnote=[string]&freport=[int]";
            }
           return JsonConvert.SerializeObject(message, Formatting.Indented);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Expense.Model.wallets model)
        {
            /// 获取当前钱包余额
            BLL.wallets wallets = new wallets();
            var w = wallets.GetModel(model.fwallets_id);
            /// 如果新余额等于旧余额，直接保存
            if (model.fbalance.Equals(w.fbalance))
            {
                return dal.Update(model);
            }
            else {
                /// 获取一个最新的分类
                BLL.categories categories = new categories();
                var c = categories.GetModelList("fuid='"+model.fuid+"'");
                /// 否则自动生成交易记录
                Model.trades trades = new Model.trades();
                trades.fuid = model.fuid;
                trades.ftrades_id = Guid.NewGuid().ToString();
                trades.fcategories_id = c[0].fcategories_id;
                trades.fwallets_id = model.fwallets_id;
                trades.fconfirm = 1; // 交易已确认
                trades.fdate = DateTime.Now;
                trades.freport = 1; // 包含在报表中
                trades.fincome = model.fbalance > w.fbalance ? 1 : 0;// 通过
                trades.fmoney = Math.Abs(model.fbalance - w.fbalance); // 交易金额为新余额-旧余额的绝对值
                BLL.trades t = new BLL.trades();
                t.Add(trades,true);
                return dal.Update(model);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string fwallets_id)
        {
            /// 自动删除相关记录
            BLL.trades trades = new BLL.trades();
            trades.DeleteBy("fwallets_id='"+fwallets_id+"'");
            return dal.Delete(fwallets_id);
        }

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
                    var t = new Expense.BLL.categories();
                    if (Delete(fid))
                    {
                        message.Code = 204;
                        message.Msg = "删除成功！";
                        message.Body = "";
                    }
                    else
                    {
                        message.Code = 400;
                        message.Msg = "删除失败！";
                        message.Body = "";
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
            public bool DeleteList(string fwallets_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(fwallets_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Expense.Model.wallets GetModel(string fwallets_id)
        {

            return dal.GetModel(fwallets_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Expense.Model.wallets GetModelByCache(string fwallets_id)
        {

            string CacheKey = "walletsModel-" + fwallets_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(fwallets_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Expense.Model.wallets)objModel;
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
        public List<Expense.Model.wallets> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Expense.Model.wallets> DataTableToList(DataTable dt)
        {
            List<Expense.Model.wallets> modelList = new List<Expense.Model.wallets>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Expense.Model.wallets model;
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

        /// <summary>
        /// 获取钱包余额
        /// </summary>
        public int Sum(string strWhere)
        {
            return dal.Sum(strWhere);
        }
        #endregion  ExtensionMethod
    }
}

