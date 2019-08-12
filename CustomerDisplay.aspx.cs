using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChattTechBank;
/***************************************************************************
 * int index is used to capture the postion of the click event on the datatable when the user 
 * chooses an account to modify.
 * int x is use as an incremter to loop through data 
 * dataTable holds the data from the sql database 
 * 
 * ******************************************************************************/
namespace masterpage
{
    public partial class CustomerDisplay : System.Web.UI.Page

        
    {
        // Global fields that will be need across mulitple scopes
        Customers c1 = new Customers();
       
        int index;
        int x = 0;
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";

            //method to verify is this is pages first time rendering, to identify where to get the session variable

            if (!IsPostBack)
            {
                id = ((TextBox)Page.PreviousPage.FindControl("mName")).Text;
            }
            else
            {
                id = Session["memberID"] + "";
            }
            c1.SelectDB(id);
            cName.Text = "Welcome Back!  " + c1.getCustFN() +" "+ c1.getCustLN();

            cID.Text ="Member ID: "+ c1.getCustID();

            // creates the data table that will visually represent  customers accounts
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Account Number", typeof(String)) ,
                new DataColumn("Type", typeof(String)) , new DataColumn("Balance" , typeof(float))  });
            
            foreach (Accounts ac in c1.acct)
            {
                dt.Rows.Add(c1.acct[x].getAcctNo(), c1.acct[x].getType(), c1.acct[x].getBAL());
                x++;
            }

            gridView1.DataSource = dt;
           
            gridView1.DataBind();
            
            

           
            
            
           

        }
        // provide the redirect to create a new account
        protected void newAcctBT_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewAccount.aspx");
        }


        // withdraw method that verifys account balance befor the money is debited from the account
        protected void withdrawBT_Click(object sender, EventArgs e)
        {
            float amount = float.Parse(withdrawTB.Text);
            
            index = gridView1.SelectedIndex;
            x = 0;
            if (amount > c1.acct[index].getBAL())
            {
                Response.Write("<script> alert('Insufficient Funds!')</script>");

            }
            else {
                c1.acct[index].setBAL(c1.acct[index].WAcct(amount));
              
                c1.UpdateDB(c1.getCustID(), index);

                dt.Clear();
               

                foreach (Accounts ac in c1.acct)
                {
                    dt.Rows.Add(c1.acct[x].getAcctNo(), c1.acct[x].getType(), c1.acct[x].getBAL());
                    x++;
                }

                gridView1.DataSource = dt;

                gridView1.DataBind();

            }
        }

        protected void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // Hiding the Select Button Cell in Header Row.
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Hiding the Select Button Cells showing for each Data Row. 
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");

                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] =
                  ClientScript.GetPostBackClientHyperlink(this.gridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            

        }
        // method that deposites the money into selected account 
        protected void depositeBT_Click(object sender, EventArgs e)
        {
            float amount = float.Parse(depositeTB.Text);
            index = gridView1.SelectedIndex;
            x = 0;
            c1.acct[index].setBAL(c1.acct[index].DAcct(amount));

            c1.UpdateDB(c1.getCustID(), index);

            dt.Clear();

            foreach (Accounts ac in c1.acct)
            {
                dt.Rows.Add(c1.acct[x].getAcctNo(), c1.acct[x].getType(), c1.acct[x].getBAL());
                x++;
            }

            gridView1.DataSource = dt;

            gridView1.DataBind();
        }
    }
}