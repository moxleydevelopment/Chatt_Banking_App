using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattTechBank;


/***************************************************************************************************************************
 * session variable to save member ID across multilpe pages 
 * Custmer objects are created to verify correct user input
 * if information is correct then user is routed to new page
 * *********************************************************************************************************/
namespace masterpage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            // session variable to save member ID 
            Session["memberID"] = mName.Text;





        }

        protected void submitBT_Click(object sender, EventArgs e)
        {
            Customers c1 = new Customers();

            // Member verification  at login screen 
            c1.SelectDB(mName.Text);
            if(c1.getCustPW() == pWord.Text)
            {
                Page.Server.Transfer("CustomerDisplay.aspx");

            }
            else
            {
                Response.Write("<script> alert('Incorrect Member information!')</script>");
            }
            


        }
    }
}
