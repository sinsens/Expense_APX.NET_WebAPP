using System;
using Newtonsoft.Json;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Expense.BLL.users users = new Expense.BLL.users();
        Response.Write(users.Login(Request));
        Response.End();
    }
}