using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services.Description;
//using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.UI.WebControls.WebParts;
//using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Common;
using System.Security.Policy;
using System.DirectoryServices.ActiveDirectory;
using DocumentFormat.OpenXml.Spreadsheet;

namespace lewHRISlocal.Employees
{
    public static class Extensions
    {

        public static string GetDomain(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(0, stop) : string.Empty;
        }

        public static string GetLogin(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : string.Empty;
        }
    }
    public partial class EmployeeDash : System.Web.UI.Page
    {
        public static string GetUserFullName(string domain, string userName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);



            return user.GivenName + " " + user.Surname;
        }

        public static string GetUserDepartmentEmployee(string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + userName + ")",
                    PropertiesToLoad = { "department" },
                })
                {
                    return (string)search.FindOne().Properties["department"][0];
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = HttpContext.Current.User.Identity;
            WelcomeLabel.Text = "Welcome, " + GetUserFullName(id.GetDomain(), id.GetLogin()) + "!";

            if (!this.IsPostBack)
            {
                //this.BindGrid1();
                this.BindGrid2();
                this.BindGrid3();
                //this.BindGrid4();
            }
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Employees/Detail.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DetailOnly.aspx?id=" + id + "", false);
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

        //protected void LinkButton4_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView3.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Employees/DisciplinaryDetail.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        //private void BindGrid1()
        //{
        //    IIdentity id = HttpContext.Current.User.Identity;

        //    string myConnection;
        //    SqlConnection cnn;
        //    myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
        //    cnn = new SqlConnection(myConnection);
        //    cnn.Open();
        //    //Response.Write("Connection Made");

        //    DataSet ds2 = new DataSet();
        //    SqlDataAdapter sda2 = new SqlDataAdapter();
        //    SqlCommand command2 = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
        //        "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_1] " +
        //        "WHERE ([Overall Status] = 'Waiting for EE Acknowledgement' OR [Overall Status] = 'Waiting for Department/Employee Acknowledgement') AND " +
        //        "[EE_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
        //    sda2.SelectCommand = command2;
        //    using (DataTable dt2 = new DataTable())
        //    {
        //        sda2.Fill(dt2);
        //        if (dt2.Rows.Count>0)
        //        {
        //            //NeedAttn.Text = dt2.Rows.Count.ToString() + " record(s) returned.";
        //            mydatagrid.DataSource = dt2;
        //            mydatagrid.DataBind();
        //        }
        //        else
        //        {
        //            ReqAck.Text = "No records available.";
        //        }
        //    }
        //    command2.Dispose();
        //    cnn.Close();
        //}

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
            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_1] " +
                "WHERE [Overall Status] NOT IN  ('Requires Employee Acknowledgment', 'Waiting for Department/Employee Acknowledgement', 'HR Dismissed Report') AND " +
                "[EE_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
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
                    CounselingRecords.Text = "No records available.";
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
            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_3] " +
                "WHERE [Overall Status] NOT IN ('Disciplinary Action Sent to Department', 'Waiting for Sup Acknowledgement Disciplinary', 'Waiting for EE Acknowledgement Disciplinary') AND " +
                "[EE_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
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
                    DARecords.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        //private void BindGrid4()
        //{
        //    IIdentity id = HttpContext.Current.User.Identity;

        //    string myConnection;
        //    SqlConnection cnn;
        //    myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
        //    cnn = new SqlConnection(myConnection);
        //    cnn.Open();
        //    //Response.Write("Connection Made");
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    SqlCommand command = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
        //        "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_3] " +
        //        "WHERE [Overall Status] IN ('Disciplinary Action Sent to Department', 'Waiting for Sup Acknowledgement Disciplinary', 'Waiting for EE Acknowledgement Disciplinary') AND " +
        //        "[EE_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
        //    sda.SelectCommand = command;
        //    using (DataTable dt = new DataTable())
        //    {
        //        sda.Fill(dt);
        //        if (dt.Rows.Count>0)
        //        {
        //            //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
        //            GridView3.DataSource = dt;
        //            GridView3.DataBind();
        //        }
        //        else
        //        {
        //            txtReqAckDA.Text = "No records available.";
        //        }
        //    }

        //    command.Dispose();
        //    cnn.Close();
        //}

        //protected void mydatagrid_DataBound(object sender, EventArgs e)
        //{
        //    if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
        //    {
        //        ReqAck.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else ReqAck.Text = "No record(s) returned.";

        //}

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if ((GridView1.DataSource as DataTable).Rows.Count>0)
            {
                CounselingRecords.Text = (GridView1.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else CounselingRecords.Text = "No record(s) returned.";
        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            if ((GridView2.DataSource as DataTable).Rows.Count>0)
            {
                DARecords.Text = (GridView2.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else DARecords.Text = "No record(s) returned.";
        }
        //protected void GridView3_DataBound(object sender, EventArgs e)
        //{
        //    if ((GridView3.DataSource as DataTable).Rows.Count>0)
        //    {
        //        txtReqAckDA.Text = (GridView3.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else txtReqAckDA.Text = "No record(s) returned.";
        //}
        //protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    mydatagrid.PageIndex = e.NewPageIndex;
        //    this.BindGrid1();
        //}
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

        //protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView3.PageIndex = e.NewPageIndex;
        //    this.BindGrid4();
        //}

    }
}