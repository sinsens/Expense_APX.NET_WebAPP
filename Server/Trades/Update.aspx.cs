using System;
using Newtonsoft.Json;

public partial class Trades_Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Expense.BLL.trades trades = new Expense.BLL.trades();
        Response.Write(trades.Update(Request));
        Response.End();
    }
}