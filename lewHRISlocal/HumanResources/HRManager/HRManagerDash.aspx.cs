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
using System.Web.Providers.Entities;

namespace lewHRISlocal.HumanResources.HRManager
{
    
    public partial class HRManagerDash : System.Web.UI.Page
    {
        //private PrincipalContext ctx;
        //public static string GetUserFullName(string domain, string userName)
        public static string GetUserFullName(string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("LDAP://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["fullname"].Value;
            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + userName + ")",
                    PropertiesToLoad = { "name" },
                })
                {
                    return (string)search.FindOne().Properties["name"][0];
                }
            }
            // set up domain context
            //PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);

            //// find a user
            //UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);

            //return user.GivenName + " " + user.Surname + " " + user.EmailAddress;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = HttpContext.Current.User.Identity;
            //TextBox1.Text =  id.GetLogin();
            //TextBox1.Text =  GetUserFullName(id.GetDomain(), id.GetLogin());
            Label1.Text =  "Welcome, " + GetUserFullName(id.GetLogin()) + "!";
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

            Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView2.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView3.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView4.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/Supervisors/DisciplinaryDetail.aspx?id=" + id + "", false);    // SHOW SUPERVISOR LEVEL DISCIPLINARY ACTION
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
            SqlCommand command2 = new SqlCommand("SELECT * FROM [View_3] " +
                "WHERE [Overall Status] = 'Initiated Disciplinary Action'", cnn);
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
            SqlCommand command = new SqlCommand("SELECT * FROM [View_3] " +
                "WHERE ([Overall Status] = 'Ready to Close Disciplinary Action')", cnn);
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
            SqlCommand command = new SqlCommand("SELECT * FROM [View_3] " +
                "WHERE ([Overall Status] = 'Disciplinary Action Sent to Department' OR [Overall Status] = 'Waiting for Sup Acknowledgement Disciplinary' OR [Overall Status] = 'Waiting for EE Acknowledgement Disciplinary')", cnn);
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
                    txtPendingCounseling.Text = "No records available.";
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
            SqlCommand command = new SqlCommand("SELECT * FROM [View_3] " +
                "WHERE [Overall Status] = 'Disciplinary Action Closed'", cnn);
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
                    txtClosedRecord.Text = "No records available.";
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
            SqlCommand command = new SqlCommand("SELECT * FROM [View_3] " +
                "WHERE [Overall Status] = 'Disciplinary Action Pending Meeting'", cnn);
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
                    txtPendingMeeting.Text = "No records available.";
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
                txtPendingCounseling.Text = (GridView2.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtPendingCounseling.Text = "No record(s) returned.";
        }

        protected void GridView3_DataBound(object sender, EventArgs e)
        {
            if ((GridView3.DataSource as DataTable).Rows.Count>0)
            {
                txtClosedRecord.Text = (GridView3.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtClosedRecord.Text = "No record(s) returned.";
        }

        protected void GridView4_DataBound(object sender, EventArgs e)
        {
            if ((GridView4.DataSource as DataTable).Rows.Count>0)
            {
                txtPendingMeeting.Text = (GridView4.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtPendingMeeting.Text = "No record(s) returned.";
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