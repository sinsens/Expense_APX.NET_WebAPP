using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Categories_Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var categories = new Expense.BLL.categories();
        Response.Write(categories.Delete(Request));
        Response.End();
    }
}