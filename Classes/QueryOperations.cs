using KeyBit_ID.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyBit_ID.Classes
{
    class QueryOperations
    {
        public int webCount, bankCount, cardCount, otherCount, totalCount;
      
        queryResult qr = new queryResult();
        DataGrid dg = new DataGrid();
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=KeyStore.accdb");

        public int queryWebCount(DataSet dataSet, DataTable dataTable)
        {
            DataTable table = dataSet.Tables["Websites"];
            
            return webCount = (int)table.Rows.Count;
        }
        public void queryWeb()
        {

            var da = new OleDbDataAdapter("Select * FROM Websites", con);
            var ds = new DataSet();
            con.Open();
            da.Fill(ds, "Websites");
            dg.DataSource = ds.Tables["Websites"];
            con.Close();
            qr.Show();
            qr.Controls.Add(dg);
            dg.Dock = DockStyle.Fill;
        }
        public int queryBankCount(DataSet dataSet, DataTable dataTable)
        {
            DataTable table = dataSet.Tables["Banks"];

            return bankCount = (int)table.Rows.Count;
        }
        public void queryBank()
        {
            var da = new OleDbDataAdapter("Select * FROM Banks", con);
            var ds = new DataSet();
            con.Open();
            da.Fill(ds, "Banks");
            dg.DataSource = ds.Tables["Banks"];
            con.Close();
            qr.Show();
            qr.Controls.Add(dg);
            dg.Dock = DockStyle.Fill;
        }
        public int queryCardCount(DataSet dataSet, DataTable dataTable)
        {
            DataTable table = dataSet.Tables["Cards"];

            return cardCount = (int)table.Rows.Count;
        }
        public void queryCard()
        {
            var da = new OleDbDataAdapter("Select * FROM Cards", con);
            var ds = new DataSet();
            con.Open();
            da.Fill(ds, "Cards");
            dg.DataSource = ds.Tables["Cards"];
            con.Close();
            qr.Show();
            qr.Controls.Add(dg);
            dg.Dock = DockStyle.Fill;
        }
        public int queryOtherCount(DataSet dataSet, DataTable dataTable)
        {
            DataTable table = dataSet.Tables["Other"];

            return otherCount = (int)table.Rows.Count;
        }
        public void queryOther()
        {
            var da = new OleDbDataAdapter("Select * FROM Other", con);
            var ds = new DataSet();
            con.Open();
            da.Fill(ds, "Other");
            dg.DataSource = ds.Tables["Other"];
            con.Close();
            qr.Show();
            qr.Controls.Add(dg);
            dg.Dock = DockStyle.Fill;
        }
        public int TotalCount()
        {
            return totalCount = totalCount + webCount + bankCount + cardCount + otherCount;
        }

    }
}
