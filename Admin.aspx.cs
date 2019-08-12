using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattTechBank;

/*******************************************************************
 * information from the provided text boxex are set to the appropriate value
 * **********************************************************************/

namespace masterpage
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // information from the provided text boxex are set to the appropri
        protected void custSubmitBT_Click(object sender, EventArgs e)
        {
            Customers c1 = new Customers();
            c1.setCustID(customerIDTB.Text);
            c1.setCustPW(customerPWTB.Text);
            c1.setCustFN(customerFNTB.Text);
            c1.setCustLN(customerLNTB.Text);
            c1.setCustADD(customerADDTB.Text);
            c1.setCustEM(customerEMTB.Text);
            c1.InsertDB();

        }

        protected void deleteBT_Click(object sender, EventArgs e)
        {
            Customers c1 = new Customers();
            c1.setCustID(deleteTB.Text);
            c1.DeleteDB();
        }
    }
}
