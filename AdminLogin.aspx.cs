using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattTechBank;


/********************************************************************************************************** 
 * Custmer objects are created to verify correct user input
 * if information is correct then user is routed to new page
 * *********************************************************************************************************/

namespace masterpage
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        Customers c1 = new Customers();

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

       

        protected void submitBT_Click(object sender, EventArgs e)
        {
            c1.SelectAdminDB(userNameTB.Text);
            if (c1.getCustPW() == passWordTB.Text)
            {
                Page.Server.Transfer("Admin.aspx");

            }
            else
            {
                Response.Write("<script> alert('Incorrect Member information!')</script>");
            }
        }
    }
}