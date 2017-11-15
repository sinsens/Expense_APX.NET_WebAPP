using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Trades_Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var trades = new Expense.BLL.trades();
        Response.Write(trades.Delete(Request));
        Response.End();
    }
}