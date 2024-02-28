using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lewHRISlocal
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // string myConnection;
           // SqlConnection cnn;
           // myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
           // cnn = new SqlConnection(myConnection);
           // cnn.Open();
           // DataSet ds = new DataSet();
           // SqlCommand cmd = new SqlCommand(
           //"SELECT EE from MasterList WHERE [EE_Subgrp] LIKE '%salaried%' AND Status = 'Active' AND [Organizational_unit_Desc] = 'LEW Process Systems'", cnn);
           // cmd.CommandType = CommandType.Text;
           // ListBox1.DataSource = cmd.ExecuteReader();
           // ListBox1.DataTextField = "EE";
           // ListBox1.DataValueField = "EE";
           // ListBox1.DataBind();
           // cnn.Close();
        }
    }
}