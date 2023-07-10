using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.UI.WebControls.WebParts;
//using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Common;
using System.Security.Policy;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.DirectoryServices;
using System.Windows.Controls;

namespace lewHRISlocal.HumanResources.PartTime
{
    
    public partial class PartTimeDash : System.Web.UI.Page
    {
        //private PrincipalContext ctx;
        public static string GetUserFullName(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = HttpContext.Current.User.Identity;
            //TextBox1.Text =  id.GetLogin();
            //TextBox1.Text =  GetUserFullName(id.GetDomain(), id.GetLogin());
            //txtNewRecord.Text = mydatagrid.Rows.Count.ToString() + " record(s)";
            //txtReceivedRecord.Text = GridView1.Rows.Count.ToString() + " record(s)";
            //txtClosedCounseling.Text = GridView2.Rows.Count.ToString() + " record(s)";
            //txtDisciplinaryRecord.Text = GridView3.Rows.Count.ToString() + " record(s)";
            if (!this.IsPostBack)
            {
                this.BindGrid1();
                this.BindGrid2();
                this.BindGrid3();
                this.BindGrid4();
                this.BindGrid5();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/HumanResources/DetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/HumanResources/DetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView2.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/HumanResources/DetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView3.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/HumanResources/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView4.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/HumanResources/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }
        private void BindGrid1()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            DataSet ds2 = new DataSet();
            SqlDataAdapter sda2 = new SqlDataAdapter();
            SqlCommand command2 = new SqlCommand("SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Cost_Center_Description] FROM [View_1] " +
                "WHERE [Overall Status] = 'Sent to HR for Processing'" +
                " AND [Employee_Status] = 'Part-Time'", cnn);
            sda2.SelectCommand = command2;
            using (DataTable dt2 = new DataTable())
            {
                sda2.Fill(dt2);
                if (dt2.Rows.Count>0)
                {
                    //NeedAttn.Text = dt2.Rows.Count.ToString() + " record(s) returned.";
                    mydatagrid.DataSource = dt2;
                    mydatagrid.DataBind();
                }
                else
                {
                    txtNewRecord.Text = "No records available.";
                }
            }
            command2.Dispose();
            cnn.Close();
        }

        private void BindGrid2()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Cost_Center_Description] FROM [View_1] " +
                "WHERE [Overall Status] = 'Requires HR Clerk Decision'" +
                " AND [Employee_Status] = 'Part-Time'", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    txtReceivedRecord.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        private void BindGrid3()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Cost_Center_Description] FROM [View_1] " +
                "WHERE [Overall Status] = 'Counseling Closed'" +
                " AND [Employee_Status] = 'Part-Time'", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {
                    txtClosedCounseling.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        private void BindGrid4()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Cost_Center_Description] FROM [View_1] " +
                "WHERE [Overall Status] IN ('Requires HR Manager Decision', 'HRM Review for Disciplinary Action', 'Sent to Department for Finalization', " +
                "'HRM Sent')" +
                " AND [Employee_Status] = 'Part-Time'", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                else
                {
                    txtDisciplinaryRecord.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        private void BindGrid5()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Cost_Center_Description] FROM [View_1] " +
                "WHERE [Overall Status] IN ('HRM Closed')" +
                " AND [Employee_Status] = 'Part-Time'", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
                    GridView4.DataSource = dt;
                    GridView4.DataBind();
                }
                else
                {
                    txtClosedDisciplinaryRecord.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        protected void mydatagrid_DataBound(object sender, EventArgs e)
        {
            if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
            {
                txtNewRecord.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtNewRecord.Text = "No record(s) returned.";

        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if ((GridView1.DataSource as DataTable).Rows.Count>0)
            {
                txtReceivedRecord.Text = (GridView1.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtReceivedRecord.Text = "No record(s) returned.";
        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            if ((GridView2.DataSource as DataTable).Rows.Count>0)
            {
                txtClosedCounseling.Text = (GridView2.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtClosedCounseling.Text = "No record(s) returned.";
        }

        protected void GridView3_DataBound(object sender, EventArgs e)
        {
            if ((GridView3.DataSource as DataTable).Rows.Count>0)
            {
                txtDisciplinaryRecord.Text = (GridView3.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtDisciplinaryRecord.Text = "No record(s) returned.";
        }

        protected void GridView4_DataBound(object sender, EventArgs e)
        {
            if ((GridView4.DataSource as DataTable).Rows.Count>0)
            {
                txtClosedDisciplinaryRecord.Text = (GridView4.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtClosedDisciplinaryRecord.Text = "No record(s) returned.";
        }

        protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            mydatagrid.PageIndex = e.NewPageIndex;
            this.BindGrid1();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid2();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindGrid3();
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.BindGrid4();
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            this.BindGrid5();
        }

    }
}