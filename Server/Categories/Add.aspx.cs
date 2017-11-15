using System;
using Newtonsoft.Json;

public partial class Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var c = new Expense.BLL.categories();
        Response.Write(c.Add(Request));
        Response.End();
    }
}