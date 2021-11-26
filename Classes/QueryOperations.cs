#region Header Block
//  About this Program
//  
//  Programmer:     Jacob Brookhouse
//  Class:          CITP 280 - 70591
//  Application:    KeyBit ID - Password Manager
//  Description:    KeyBit ID is a password manager that allows a user to save sensitive
//                  information, such as passwords and account information.
//
#endregion
#region About this file
//
// This class contains the logic to do query operations on the stored tables, to get things like total row counts, and simple query to return the tables contents.
//
#endregion
using KeyBit_ID.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace KeyBit_ID.Classes
{
    class QueryOperations
    {
        // variables to store number of items in each table
        public int webCount, bankCount, cardCount, otherCount, totalCount;
        // create a new instance of the queryResult form
        queryResult qr = new queryResult();
        // create a new data grid to store results
        DataGrid dg = new DataGrid();
        // create a new connections string and point to the KeyStore file
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=KeyStore.accdb");

        public int queryWebCount(DataSet dataSet, DataTable dataTable)
        {
            // assign the input DataTable to the Websites table
            DataTable table = dataSet.Tables["Websites"];
            // return the row count
            return webCount = (int)table.Rows.Count;
        }
        public void queryWeb()
        {
            // create some variables for the adapter and new DataSet
            var da = new OleDbDataAdapter("Select * FROM Websites", con);
            var ds = new DataSet();
            // open the connection
            con.Open();
            // fill the dataset with the table
            da.Fill(ds, "Websites");
            dg.DataSource = ds.Tables["Websites"];
            // close the connection
            con.Close();
            // set start position of the queryResult Form
            qr.StartPosition = FormStartPosition.CenterScreen;
            qr.Text = "Websites Table";
            // show the form
            qr.Show();
            // add the datagrid to the form
            qr.Controls.Add(dg);
            // set dockstyle to fill the form
            dg.Dock = DockStyle.Fill;

        }
        public int queryBankCount(DataSet dataSet, DataTable dataTable)
        {
            // assign the input DataTable to the Banks table
            DataTable table = dataSet.Tables["Banks"];
            // return the row count
            return bankCount = (int)table.Rows.Count;
        }
        public void queryBank()
        {
            // create some variables for the adapter and new DataSet
            var da = new OleDbDataAdapter("Select * FROM Banks", con);
            var ds = new DataSet();
            // open the connection
            con.Open();
            // fill the dataset with the table
            da.Fill(ds, "Banks");
            dg.DataSource = ds.Tables["Banks"];
            // close the connection
            con.Close();
            // set start position of the queryResult Form
            qr.StartPosition = FormStartPosition.CenterScreen;
            qr.Text = "Banks Table";
            // show the form
            qr.Show();
            // add the datagrid to the form
            qr.Controls.Add(dg);
            // set dockstyle to fill the form
            dg.Dock = DockStyle.Fill;

        }
        public int queryCardCount(DataSet dataSet, DataTable dataTable)
        {
            // assign the input DataTable to the Cards table
            DataTable table = dataSet.Tables["Cards"];
            // return the row count
            return cardCount = (int)table.Rows.Count;
        }
        public void queryCard()
        {
            // create some variables for the adapter and new DataSet
            var da = new OleDbDataAdapter("Select * FROM Cards", con);
            var ds = new DataSet();
            // open the connection
            con.Open();
            // fill the dataset with the table
            da.Fill(ds, "Cards");
            dg.DataSource = ds.Tables["Cards"];
            // close the connection
            con.Close();
            // set start position of the queryResult Form
            qr.StartPosition = FormStartPosition.CenterScreen;
            qr.Text = "Cards Table";
            // show the form
            qr.Show();
            // add the datagrid to the form
            qr.Controls.Add(dg);
            // set dockstyle to fill the form
            dg.Dock = DockStyle.Fill;

        }
        public int queryOtherCount(DataSet dataSet, DataTable dataTable)
        {
            // assign the input DataTable to the Other table
            DataTable table = dataSet.Tables["Other"];
            // return the row count
            return otherCount = (int)table.Rows.Count;
        }
        public void queryOther()
        {
            // create some variables for the adapter and new DataSet
            var da = new OleDbDataAdapter("Select * FROM Other", con);
            var ds = new DataSet();
            // open the connection
            con.Open();
            // fill the dataset with the table
            da.Fill(ds, "Other");
            dg.DataSource = ds.Tables["Other"];
            // close the connection
            con.Close();
            // set start position of the queryResult Form
            qr.StartPosition = FormStartPosition.CenterScreen;
            qr.Text = "Other Table";
            // show the form
            qr.Show();
            // add the datagrid to the form
            qr.Controls.Add(dg);
            // set dockstyle to fill the form
            dg.Dock = DockStyle.Fill;

        }
        // method to get total count of all items in each table
        // generic method, uses interface IEnumerable<int>
        public int TotalCount()
        {
            // use of LINQ
            // reset totalCount to 0
            totalCount = 0;
            // data source is number of counts that each table has.
            int[] counts = new int[] { webCount, bankCount, cardCount, otherCount };
            // define the expression
            // use of generic
            IEnumerable<int> countQuery =
            from count in counts
            select count;

            // Execute the query.
            foreach (int i in countQuery)
            {
                // set totalCount = tot total + I
                totalCount = totalCount + i;
            }
            // return the total count of rows of all tables.
            return totalCount;
        }

    }
}
