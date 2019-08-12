using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChattTechBank
{
    public class Accounts
    {
        private String acctNO, cID, type;
        private float balance;

        public Accounts() { }

        public Accounts(String a, String b, String c, float x)
        {
            acctNO = a;
            cID = b;
            type = c;
            balance = x;
        }

        public Accounts(String a) { acctNO = a; }

        public String getAcctNo() { return acctNO; }
        public void setAcctNo(String a) { acctNO = a; }

        public String getCID() { return cID; }
        public void setCID(String b) { cID = b; }

        public String getType() { return type; }
        public void setType(String c) { type = c; }

        public float getBAL() { return balance; }
        public void setBAL(float x) { balance = x; }

        public float WAcct(float amt)
        {
            
            float bal = getBAL()- amt;
            return bal;
        }

        public float DAcct(float amt)
        {
            
            float bal = getBAL() + amt;
            return bal;
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


        public void InsertDB()
        {
            DBSetup();
            
            cmd = "INSERT into Accounts values('" + getAcctNo() + "', '" + getCID() + "', '" +
                getType() + "', '" + decimal.Parse(getBAL()+"") +"')";
            OleDbDataAdapter2.InsertCommand.CommandText = cmd;
            OleDbDataAdapter2.InsertCommand.Connection = OleDbConnection2;

            try {
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


    }
}