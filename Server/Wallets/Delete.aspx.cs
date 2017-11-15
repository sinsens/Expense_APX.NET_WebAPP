using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Wallets_Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Expense.BLL.wallets wallets = new Expense.BLL.wallets();
        Response.Write(wallets.Delete(Request));
        Response.End();
    }
}