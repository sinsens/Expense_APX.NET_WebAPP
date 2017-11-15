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
    /// trades
    /// </summary>
    public partial class trades
    {
        private readonly Expense.DAL.trades dal = new Expense.DAL.trades();
        public trades()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ftrades_id)
        {
            return dal.Exists(ftrades_id);
        }

        public string Add(HttpRequest Request) {
            Message.Message message = new Message.Message();
            
            if (!string.IsNullOrEmpty(Request["ftoken"]) && Request["fcategories_id"] != null)
            {
                var ftoken = Request["ftoken"];
                var fcategories_id = Request["fcategories_id"];
                var ftags = Request["ftags"];
                var fwallets_id = Request["fwallets_id"];
                var fincome = Convert.ToInt32(Request["fincome"]);
                var fnote = Request["fnote"];
                var fbalence = Convert.ToInt32(Request["fbalance"]);
                var fdate = Convert.ToDateTime(Request["fdate"]); // 日期和时间
                var freport = Convert.ToInt32(Request["freport"]);
                var fconfirm = Convert.ToInt32(Request["fconfirm"]);

                var b = new Expense.BLL.users();

                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建trades对象
                    Expense.Model.trades trades = new Expense.Model.trades();
                    trades.fcategories_id = fcategories_id; // 类型id
                    trades.fincome = fincome; // 收入/支出标记
                    trades.ftrades_id = Guid.NewGuid().ToString();
                    trades.fwallets_id = fwallets_id;// 钱包编号
                    trades.ftags = ftags;
                    trades.fmoney = fbalence;
                    trades.fdate = fdate;
                    trades.fnote = fnote;
                    trades.freport = freport;
                    trades.fconfirm = fconfirm;
                    trades.fuid = b.GetModelByToken(ftoken).fuid;
                    if (Add(trades))
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
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?ftoken=[<string>]&fcategories_id=[<string>]&fwallets_id=[<string>]&ftags=[<string,string,...>]&fnote=[<string>]&fbalence=[<int>]&fdate=[<string>]&fincomee=[0,1]&freport=[0,1]&fconfirm=[0,1]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Expense.Model.trades model, bool automake = false)
        {
            /// 更改账户自动生成的交易记录
            if (automake)
            {
                return dal.Add(model);
            }
            /// 处理钱包余额
            DAL.wallets wallets = new DAL.wallets();
            try
            {
                var w = wallets.GetModel(model.fwallets_id);
                if (model.fincome.Equals(0))
                    w.fbalance -= model.fmoney;
                else
                    w.fbalance += model.fmoney;
                wallets.Update(w); /// 更新钱包信息
                return dal.Add(model);
            }
            catch
            {
                return false;
            }
        }

        public string Update(HttpRequest Request) {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]) && !string.IsNullOrEmpty(Request["fid"]))
            {
                var fid = Request["fid"];
                var ftoken = Request["ftoken"];
                var fcategories_id = Request["fcategories_id"];
                var ftags = Request["ftags"];
                var fwallets_id = Request["fwallets_id"];
                var fincome = Convert.ToInt32(Request["fincome"]);
                var fnote = Request["fnote"];
                var fbalence = Convert.ToInt32(Request["fbalance"]);
                var fdate = Convert.ToDateTime(Request["fdate"]); // 日期和时间
                var freport = Convert.ToInt32(Request["freport"]);
                var fconfirm = Convert.ToInt32(Request["fconfirm"]);

                var b = new Expense.BLL.users();

                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建trades对象
                    Expense.Model.trades trades = new Expense.Model.trades();

                    trades.fcategories_id = fcategories_id; // 类型id
                    trades.fincome = fincome; // 收入/支出标记
                    trades.ftrades_id = fid;
                    trades.ftags = ftags;
                    trades.fwallets_id = fwallets_id;// 钱包编号
                    trades.fmoney = fbalence;
                    trades.fdate = fdate;
                    trades.fnote = fnote;
                    trades.freport = freport;
                    trades.fconfirm = fconfirm;
                    trades.fuid = b.GetModelByToken(ftoken).fuid;
                    if (Update(trades))
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
                message.Msg = Request.HttpMethod + " : " + Request.FilePath + "?ftoken=[<string>]&fid=[<string>]&fcategories_id=[<string>]&fwallets_id=[<string>]&ftags=[<string,string,...>]&fnote=[<string>]&fbalence=[<int>]&fdate=[<string>]&fincomee=[0,1]&freport=[0,1]&fconfirm=[0,1]";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Expense.Model.trades model)
        {
            DAL.wallets wallets = new DAL.wallets();
            DAL.trades trades = new DAL.trades();
            try
            {
                /// 获取先前的金额
                var t = trades.GetModel(model.ftrades_id); // 获取旧记录信息
                /// 钱包先和旧记录计算再加入新记录
                /// 处理钱包余额    
                var w = wallets.GetModel(model.fwallets_id);
                if (t.fincome.Equals(0))
                    w.fbalance += t.fmoney;
                else
                    w.fbalance -= t.fmoney;

                /// 计算新纪录
                if (model.fincome.Equals(0))
                    w.fbalance -= model.fmoney;
                else
                    w.fbalance += model.fmoney;
                wallets.Update(w); // 更新钱包信息
                return dal.Update(model);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 处理页面请求
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public object Delete(HttpRequest Request)
        {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(Request["ftoken"]) && !string.IsNullOrEmpty(Request["fid"]))
            {
                var ftoken = Request["ftoken"];
                var fid = Request["fid"]; // fid 是每个条数据的唯一id
                var b = new Expense.BLL.users();
                if (b.CheckLogin(ftoken))
                {
                    try
                    {
                        Delete(fid);
                        message.Code = 203;
                        message.Msg = "删除成功！";
                    }
                    catch
                    {
                        /// 出错
                        message.Code = 201;
                        message.Msg = "发生错误！";
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
        /// 通过id删除交易记录
        /// </summary>
        /// <param name="ftrades_id"></param>
        /// <returns></returns>
        public bool Delete(string ftrades_id) {
            DAL.wallets wallets = new DAL.wallets();
            DAL.trades trades = new DAL.trades();
            try
            {
                /// 获取先前的金额
                var t = trades.GetModel(ftrades_id); // 获取旧记录信息
                                                     /// 钱包先和旧记录计算再加入新记录
                                                     /// 处理钱包余额    
                var w = wallets.GetModel(t.fwallets_id);

                /// 计算新纪录
                if (t.fincome.Equals(0))
                    w.fbalance += t.fmoney;
                else
                    w.fbalance -= t.fmoney;
                wallets.Update(w); // 更新钱包信息
                return dal.Delete(ftrades_id);
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// 通过条件删除交易记录
        /// </summary>
        /// <param name="ftrades_id"></param>
        /// <returns></returns>
        public bool DeleteBy(string strWhere)
        {
            DAL.trades trades = new DAL.trades();
            try
            {
                /// 获取先前的金额
                var t = DataTableToList(trades.GetListByPage(strWhere, "", 0, 100000).Tables[0]); // 获取旧记录信息                                                                      /// 处理钱包余额    
                foreach (var item in t)
                {
                    Delete(item.ftrades_id);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ftrades_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(ftrades_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Expense.Model.trades GetModel(string ftrades_id)
        {

            return dal.GetModel(ftrades_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Expense.Model.trades GetModelByCache(string ftrades_id)
        {

            string CacheKey = "tradesModel-" + ftrades_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ftrades_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Expense.Model.trades)objModel;
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
        public List<Expense.Model.trades> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Expense.Model.trades> DataTableToList(DataTable dt)
        {
            List<Expense.Model.trades> modelList = new List<Expense.Model.trades>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Expense.Model.trades model;
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

