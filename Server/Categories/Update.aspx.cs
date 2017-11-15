using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categories_Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        var c = new Expense.BLL.categories();
        Response.Write(c.Update(Request));
        Response.End();
    }
}