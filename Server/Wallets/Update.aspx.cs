using System;
using Newtonsoft.Json;

public partial class Walllets_Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Expense.BLL.wallets wallets = new Expense.BLL.wallets();
        Response.Write(wallets.Delete(Request));
        Response.End();
    }
}