using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Message.Message message = new Message.Message();
        Expense.BLL.users users = new Expense.BLL.users();
        if (users.CheckLogin(Request["ftoken"]))
        {

        }
    }
}