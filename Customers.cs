using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChattTechBank
{
    public class Customers
    {
        private String custID, custPW, custFN, custLN, custADD, custEM;
        public List<Accounts> acct;

        public Customers()
        {
            custID = "";
            custPW = "";
            custFN = "";
            custLN = "";
            custADD = "";
            custEM = "";
            acct = new List<Accounts>();

        }

        public Customers(String id, String pw, String fn, String ln, String add, String em)
        {
            custID = id;
            custPW = pw;
            custFN = fn;
            custLN = ln;
            custADD = add;
            custEM = em;
            acct = new List<Accounts>();


        }

        public String getCustID() { return custID; }
        public void setCustID(String id) { custID = id; }

        public String getCustPW() { return custPW; }
        public void setCustPW(String pw) { custPW = pw; }

        public String getCustFN() { return custFN; }
        public void setCustFN(String fn) { custFN = fn; }

        public String getCustLN() { return custLN; }
        public void setCustLN(String ln) { custLN = ln; }

        public String getCustADD() { return custADD; }
        public void setCustADD(String add) { custADD = add; }

        public String getCustEM() { return custEM; }
        public void setCustEM(String em) { custEM = em; }

        public void AddAcount(Accounts a)
        {
            acct.Add(a);

        }

        public void Display()
        {
            foreach (Accounts accounts in acct)
            {
                Console.WriteLine(accounts.getAcctNo());
                Console.WriteLine(accounts.getCID());
                Console.WriteLine(accounts.getType());
                Console.WriteLine(accounts.getBAL());
            }
        }



        // Database connection methods

        public System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter2;
        public System.Data.OleDb.OleDbCommand OleDbSelectCommand2;
        public System.Data.OleDb.OleDbCommand OleDbInsertCommand2;
        public System.Data.OleDb.OleDbCommand OleDbUpdateCommand2;
        public System.Data.OleDb.OleDbCommand OleDbDeleteCommand2;
        public System.Data.OleDb.OleDbConnection OleDbConnection2;
        public String cmd;

        public void DBSetup()
        {
            OleDbDataAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
            OleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbConnection2 = new System.Data.OleDb.OleDbConnection();

            OleDbDataAdapter2.DeleteCommand = OleDbDeleteCommand2;
            OleDbDataAdapter2.InsertCommand = OleDbInsertCommand2;
            OleDbDataAdapter2.SelectCommand = OleDbSelectCommand2;
            OleDbDataAdapter2.UpdateCommand = OleDbUpdateCommand2;

            OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path =; Jet OLEDB:Database L" +
               "ocking Mode=1;Data Source=c:\\Users\\dmoxl\\Downloads\\ChattBankMDB.mdb;J" +
               "et OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System datab" +
               "ase=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=S" +
               "hare Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet " +
               "OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repai" +
               "r=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
        }

        public void SelectDB(String n)
        {
            DBSetup();
            cmd = "Select * from Customers where CustID = '" + n + "'";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();
                dr.Read();
                custID = (n);
                setCustPW(dr.GetValue(1) + "");
                setCustFN(dr.GetValue(2) + "");
                setCustLN(dr.GetValue(3) + "");
                setCustADD(dr.GetValue(4) + "");
                setCustEM(dr.GetValue(5) + "");

                dr.Close();


                OleDbConnection2.Close();
                cmd = "Select * from Accounts where Cid = '" + getCustID() + "'";
                OleDbDataAdapter2.SelectCommand.CommandText = cmd;
                OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
                Console.WriteLine(cmd);
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr1;
                dr1 = OleDbDataAdapter2.SelectCommand.ExecuteReader();



                while (dr1.Read())
                {
                    Accounts ant;
                    String a = dr1.GetValue(0) + "";
                    String b = dr1.GetValue(1) + "";
                    String c = dr1.GetValue(2) + "";
                    float x = float.Parse(dr1.GetValue(3) + "");

                    ant = new Accounts(a, b, c, x);
                    AddAcount(ant);
                    

                }












            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        }

        public void UpdateDB(String id, int index)
        {
            DBSetup();
            cmd = "Update Accounts set Balance = '" + acct[index].getBAL() +
                "' Where AcctNo = '" + acct[index].getAcctNo() + "';";

            OleDbDataAdapter2.UpdateCommand.CommandText = cmd;
            OleDbDataAdapter2.UpdateCommand.Connection = OleDbConnection2;

            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.UpdateCommand.ExecuteNonQuery();
                if (n == 1)
                { Console.WriteLine("Data Updated"); }
                else { Console.WriteLine("ERROR: Updating Data"); }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { OleDbConnection2.Close(); }
        }


        public void InsertDB()
        {
            DBSetup();
            cmd = "INSERT into Customers values('" +
                getCustID() + "' ,'" + getCustPW() +
                "', '" + getCustFN() + "', '" +
                getCustLN() + "', '" + getCustADD() +
                "' , '" + getCustEM() + "')";

            OleDbDataAdapter2.InsertCommand.CommandText = cmd;
            OleDbDataAdapter2.InsertCommand.Connection = OleDbConnection2;

            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.InsertCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Inserted");
                else
                    Console.WriteLine("ERROR: Inserting Data");


            }

            catch (Exception ex)
            {
                Console.Write(ex);
            }

            finally
            {
                OleDbConnection2.Close();

            }

        }

        public void DeleteDB()
        {
            DBSetup();
            cmd = "Delete from Customers where CustID = '" + getCustID() +"'" ;

            OleDbDataAdapter2.DeleteCommand.CommandText = cmd;
            OleDbDataAdapter2.DeleteCommand.Connection = OleDbConnection2;

            try
            {

                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.DeleteCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Deleted");
                else
                    Console.WriteLine("ERROR: Deleting Data");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }

        }


        public void SelectAdminDB(String n)
        {
            DBSetup();
            cmd = "Select * from Administration where ID = '" + n + "'";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();
                dr.Read();
                custID = (n);
                setCustPW(dr.GetValue(1) + "");
                

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        }


    }


    
    
}