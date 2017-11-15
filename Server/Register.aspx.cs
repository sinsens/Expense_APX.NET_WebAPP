using Maticsoft.DBUtility;
using Newtonsoft.Json;
using System;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Expense.BLL.users users = new Expense.BLL.users();
        Response.Write(users.Register(Request));
        Response.End();
    }
}