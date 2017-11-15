using System;
using Newtonsoft.Json;

public partial class Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Expense.BLL.wallets wallets = new Expense.BLL.wallets();
        Response.Write(wallets.Add(Request));
        Response.End();
    }
}