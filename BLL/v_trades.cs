using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Expense.Model;
using System.Web.UI;
using System.Web;
using Newtonsoft.Json;
using Message;

namespace Expense.BLL
{
	/// <summary>
	/// v_trades
	/// </summary>
	public partial class v_trades
	{
		private readonly Expense.DAL.v_trades dal=new Expense.DAL.v_trades();
		public v_trades()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Expense.Model.v_trades model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Get(HttpRequest request) {
            Message.Message message = new Message.Message();
            if (!string.IsNullOrEmpty(request["ftoken"]))
            {
                var ftoken = request["ftoken"];
                var fid = request["fid"];
                var b = new Expense.BLL.users();
                if (b.CheckLogin(ftoken))
                {
                    /// 已登录成功
                    /// 构建Tags对象
                    message.Code = 200;
                    var t = new Expense.BLL.v_trades();
                    var v_trades = new Expense.Model.v_trades();
                    v_trades.fuid = b.GetModelByToken(ftoken).fuid;
                    v_trades.ftrades_id = fid;
                    if (!string.IsNullOrEmpty(request["fid"]))
                    {
                        // 通过fid获取交易记录信息
                        message.Body = t.GetModelList("fuid='" + v_trades.fuid + "' AND ftrades_id='" + fid + "'");
                    }
                    else if (!string.IsNullOrEmpty(request["fpage"]))
                    {
                        // 分页显示交易记录信息
                        message.Body = t.GetModelList("fuid=\"" + v_trades.fuid + "\"", Convert.ToInt32(request["fpage"]), 10);
                    }
                    else if (!string.IsNullOrEmpty(request["fget"]))
                    {
                        string count_type = "";
                        try
                        {
                            count_type = request["ftype"].ToString() == "year" ? "year" : "month";
                        }
                        catch
                        {
                            count_type = "month";
                        }

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
                message.Msg = request.HttpMethod + " : " + request.FilePath + "?ftoken=[<string>]&fid=[<string>]< br/><br />";
                message.Msg += request.HttpMethod + " : " + request.FilePath + "?ftoken=[<string>]&fpage=[<string>]<br/><br/>";
                message.Msg += request.HttpMethod + " : " + request.FilePath + "?ftoken=[<string>]&fget=count&ftype=<year,month><br/><br/>";
            }
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Expense.Model.v_trades model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Expense.Model.v_trades GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Expense.Model.v_trades GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "v_tradesModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Expense.Model.v_trades)objModel;
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
		public List<Expense.Model.v_trades> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// 获得数据列表,sinsen
        /// </summary>
        public List<Expense.Model.v_trades> GetModelList(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = dal.GetListByPage(strWhere, startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Expense.Model.v_trades> DataTableToList(DataTable dt)
		{
			List<Expense.Model.v_trades> modelList = new List<Expense.Model.v_trades>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Expense.Model.v_trades model;
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
			return dal.GetListByPage( strWhere, startIndex,  endIndex);
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

