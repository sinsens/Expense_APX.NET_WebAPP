using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /// 检查Cookie
        if (HttpContext.Current.Request.Cookies["ftoken"] != null)
        {
            var b = new Expense.BLL.users();
            Response.Write(HttpContext.Current.Request.Cookies["ftoken"].Value);
            Response.Redirect(b.CheckLogin(HttpContext.Current.Request.Cookies["ftoken"].Value) ? "/App/index.html" : "/App/login.html"); // 登录成功则跳到首页
        }
        /// 检查Request
        else if (Request["ftoken"] != null)
        {
            var b = new Expense.BLL.users();
            Response.Redirect(b.CheckLogin(Request["ftoken"]) ? "/App/index.html" : "/App/login.html"); // 登录成功则跳到首页
        }
        else
        {
            Response.Redirect("/App/login.html");
        }
    }
}