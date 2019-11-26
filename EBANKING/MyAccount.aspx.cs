using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EBANKING
{
    
    public partial class MyAccount : System.Web.UI.Page
    {
        private Holders holders;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session ["Login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                holders = this.GetHolders();
                txtaccnum.Text = holders.ACCOUNT_NUMBER.ToString();
                txtfname.Text = holders.FIRSTNAME;
                txtlname.Text = holders.LASTNAME;
                txtemail.Text = holders.EMAIL;
                txtpassword.Text = holders.HOLDERPWD;
                lblusername.Text = holders.FIRSTNAME;

            }

        }

        private Holders GetHolders()
        {
            DataView itemtable = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            itemtable.RowFilter = "EMAIL = '" +Session["Login"]+ "'";
            DataRowView row = (DataRowView)itemtable[0];
            Holders o = new Holders();
            o.FIRSTNAME = row["FIRSTNAME"].ToString();
            o.LASTNAME = row["LASTNAME"].ToString();
            o.EMAIL = row["EMAIL"].ToString();
            o.HOLDERPWD = row["HOLDERPWD"].ToString();
            o.ACCOUNT_NUMBER = (int)row["ACCOUNT_NUMBER"];
            return o;

        }

        private class Holders
        {
            public string FIRSTNAME { get; set; }
            public string LASTNAME { get; set; }
            public string EMAIL { get; set; }
            public string HOLDERPWD { get; set; }
            public int ACCOUNT_NUMBER { get; set; }

        }
    }

    
}