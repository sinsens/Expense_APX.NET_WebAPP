using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Trades_Get : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var t = new Expense.BLL.v_trades();
        Response.Write(t.Get(Request));
        Response.End();
    }

}