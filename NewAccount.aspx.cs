using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattTechBank;


/***************************************************************************
 * c1 is global customer object
 * a dataTable is used to transfer my data from my database using my business objects
 * session variables are used again to save the members ID
 *  use get methods to extract the data from account objects
 *  **************************************************************************/

namespace masterpage
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        /*
         * Created global variables  
         * */
        Customers c1 = new Customers();
        String id = "";
        DataTable dt = new DataTable();
        int x = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["memberID"] + "";

            gridView1.Visible = false;



        }
        // Submit the informantion by customer for  new account 
        protected void submitBT_Click(object sender, EventArgs e)
        {
            String acctNum;
            String acctType = "";

            float acctBal;

            if (savingsRB.Checked)
            { acctType = "SAV"; }
            else if (checkingRB.Checked)
            {
                acctType = "CHK";
            }
            else if (MMARB.Checked)
                    {
                acctType = "MMA";
            }

            acctNum = AccNoTB.Text;
            acctBal = float.Parse(BALTB.Text);

            Accounts a1 = new Accounts(acctNum, id, acctType, acctBal);
            a1.InsertDB();
            
            c1.SelectDB(id);

            //creates the header and expected type for each column in the accounts table
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Account Number", typeof(String)) ,
                new DataColumn("Type", typeof(String)) , new DataColumn("Balance" , typeof(float))  });


            // adds values for each row 
            foreach (Accounts ac in c1.acct)
            {
                dt.Rows.Add(c1.acct[x].getAcctNo(), c1.acct[x].getType(), c1.acct[x].getBAL());
                x++;
            }

            gridView1.DataSource = dt;

            gridView1.DataBind();
            gridView1.Visible = true;






        }
    }
}