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
using System.DirectoryServices.ActiveDirectory;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

namespace lewHRISlocal.Supervisors
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
    public partial class SupervisorDash : System.Web.UI.Page
    {
        
        //private PrincipalContext ctx;
        //public static string GetUserFullName(string domain, string userName)
        public static string GetUserFullName(string domain, string userName)
        {

            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            ////DirectorySearcher myDirectorySearcher = new DirectorySearcher(mySearchRoot);
            //return (string)userEntry.Properties["fullname"].Value;
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);



            return user.GivenName + " " + user.Surname;

            //// find the group in question
            //GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - Budget Users");

            //if (user != null)
            //{
            //    // check if user is member of that group
            //    if (user.IsMemberOf(group))
            //    {
            //        //Response.Redirect("~/Supervisors/SupervisorDash", false);
            //        //MessageBox.ShowMessage("User is a member of LEW - Admins", this.Page);
            //        //return;
            //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User is a member of LEW - Budget Users'); window.location.replace('Supervisors/SupervisorDash');", true);
            //    }
            //    else MessageBox.ShowMessage("User not a member of LEW - Budget Users", this.Page);
            //}
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
                    PropertiesToLoad = { "employeeID" },
                })
                {
                    return (string)search.FindOne().Properties["employeeID"][0];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = HttpContext.Current.User.Identity;
            //TextBox1.Text =  id.GetLogin();
            //TextBox1.Text =  GetUserFullName(id.GetDomain(), id.GetLogin());
            WelcomeLabel.Text =  "Welcome, " + GetUserFullName(id.GetDomain(), id.GetLogin()) + "!";

            searchName.Text = String.Format("{0}", Request.Form["myCountry"]);


            if (!IsPostBack)
            {
                var items = new List<string>();
                PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);

                // find your user
                UserPrincipal user = UserPrincipal.FindByIdentity(yourDomain, id.GetLogin());

                // if found - grab its groups
                if (user != null)
                {
                    PrincipalSearchResult<Principal> groups = user.GetGroups();

                    // iterate over all groups
                    foreach (Principal p in groups)
                    {
                        // make sure to add only group principals
                        if (p is GroupPrincipal)
                        {
                            if (p.ToString().Contains("LEW - HRIS "))
                            {
                                items.Add(p.ToString().Replace("LEW - HRIS ", ""));
                            }

                        }
                    }
                }
                AllHRISGroup.Text = string.Join(", ", items).ToString();
            }


            try
            {
                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();
                //Response.Write("Connection Made");

                //SqlCommand command = new SqlCommand("Select [Organizational_unit_Desc] from dbo.MasterList WHERE [EE] = " + GetUserDepartmentEmployee(id.GetLogin()) + "", cnn);
                SqlCommand command = new SqlCommand("Select vmd.[Department_Group] " +
                    "from dbo.MasterList AS ml LEFT OUTER JOIN dbo.View_MainDepartment AS vmd " +
                    " ON ml.[Organizational_unit_Desc] = vmd.[Department_Name] WHERE [EE] = " + GetUserDepartmentEmployee(id.GetLogin()) + "", cnn);
                SqlDataReader dataReader;
                String Output = " ";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Department.Text = dataReader.GetString(0);
                    //txtEmpEmail.Text = dataReader.GetString(13);
                }
                Response.Write(Output);
                dataReader.Close();
                dataReader.Dispose();
            }
            catch
            {

            }

            try
            {
                if (!this.IsPostBack)
                {
                    this.BindGrid1("");
                    this.BindGrid2("");
                    this.BindGrid3("");
                    this.BindGrid4("");
                }
            }
            catch (Exception ex)
            {

            }
            
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/Supervisors/Detail.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

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

            Response.Redirect("~/General/DetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView3.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/Supervisors/DisciplinaryDetail.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }
        private void BindGrid1(string empName)
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
            //SqlCommand command2 = new SqlCommand("SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
            //    "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Department_Unit] FROM [View_1] WHERE ([Overall Status] = 'Waiting for Department/Employee Acknowledgement'" +
            //    " OR [Overall Status] = 'Waiting for Sup Acknowledgement') AND [Department_Group] = '" + Department.Text + "' OR [Supervisor_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
            SqlCommand command2 = new SqlCommand("SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Department_Unit] FROM [View_1] WHERE [Overall Status] IN ('Waiting for Department/Employee Acknowledgement'" +
                ", 'Waiting for Sup Acknowledgement') AND " +
                "([Department_Group] IN ('" + AllHRISGroup.Text.Replace(", ", "', '") + "') OR [Supervisor_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "')" +
                " AND [EE_Name] LIKE '%" + empName + "%'", cnn);
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
                    mydatagrid.DataSource = dt2;
                    mydatagrid.DataBind();
                    NeedAttn.Text = "No records available.";
                }
            }
            command2.Dispose();
            cnn.Close();
        }

        private void BindGrid2(string empName)
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
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Department_Unit] FROM [View_1] WHERE " +
                " [Overall Status] NOT IN ('Waiting for Sup Acknowledgement', 'Waiting for EE Acknowledgement', 'Waiting for Department/Employee Acknowledgement', 'Counseling Closed', 'Disciplinary Action Closed', 'HR Dismissed Report') " +
                "AND [Department_Group] IN ('" + AllHRISGroup.Text.Replace(", ", "', '") + "') AND [Date_Incident] > DATEADD(d, -180, GETDATE())" +
                " AND [EE_Name] LIKE '%" + empName + "%' UNION " +
                "SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Department_Unit] FROM [View_3] WHERE " +
                " [Overall Status] NOT IN ('Disciplinary Action Sent to Department', 'Waiting for Department/Employee Acknowledgement', " +
                "'Counseling Closed', 'Disciplinary Action Closed', 'HR Dismissed Report') " +
                "AND [Department_Group] IN ('" + AllHRISGroup.Text.Replace(", ", "', '") + "') AND [Date_Incident] > DATEADD(d, -180, GETDATE())" +
                " AND [EE_Name] LIKE '%" + empName + "%'", cnn);
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
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    RecentSubs.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        private void BindGrid3(string empName)
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
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Department_Unit] FROM [View_1] WHERE " +
                " [Overall Status] IN ('Counseling Closed', 'Disciplinary Action Closed', 'HR Dismissed Report') AND " +
                " [Department_Group] IN ('" + AllHRISGroup.Text.Replace(", ", "', '") + "') AND [Date_Incident] > DATEADD(d, -180, GETDATE())" +
                " AND [EE_Name] LIKE '%" + empName + "%' UNION " +
                "SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [Department_Unit] FROM [View_3] WHERE " +
                " [Overall Status] IN ('Counseling Closed', 'Disciplinary Action Closed', 'HR Dismissed Report') AND " +
                " [Department_Group] IN ('" + AllHRISGroup.Text.Replace(", ", "', '") + "') AND [Date_Incident] > DATEADD(d, -180, GETDATE())" +
                " AND [EE_Name] LIKE '%" + empName + "%'", cnn);
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
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    HRReview.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        private void BindGrid4(string empName)
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
                "WHERE ([Overall Status] IN  ('Disciplinary Action Sent to Department', 'Waiting for Sup Acknowledgement Disciplinary', 'Missing Employee Response' )) AND " +
                " [Department_Group] IN ('" + AllHRISGroup.Text.Replace(", ", "', '") + "') " +
                "AND [EE_Name] LIKE '%" + empName + "%'", cnn);
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
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    txtReqAckDA.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
        }
        protected void mydatagrid_DataBound(object sender, EventArgs e)
        {
            if((mydatagrid.DataSource as DataTable).Rows.Count>0)
            {
                NeedAttn.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else NeedAttn.Text = "No record(s) returned.";

        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if((GridView1.DataSource as DataTable).Rows.Count>0)
            {
                RecentSubs.Text = (GridView1.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else RecentSubs.Text = "No record(s) returned.";
        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            if((GridView2.DataSource as DataTable).Rows.Count>0)
            {
                HRReview.Text = (GridView2.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else HRReview.Text = "No record(s) returned.";
        }

        protected void GridView3_DataBound(object sender, EventArgs e)
        {
            if ((GridView3.DataSource as DataTable).Rows.Count>0)
            {
                txtReqAckDA.Text = (GridView3.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else txtReqAckDA.Text = "No record(s) returned.";
        }
        protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            mydatagrid.PageIndex = e.NewPageIndex;
            this.BindGrid1(searchName.Text);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid2(searchName.Text);
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindGrid3(searchName.Text);
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.BindGrid4(searchName.Text);
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            this.BindGrid1(searchName.Text);
            this.BindGrid2(searchName.Text);
            this.BindGrid3(searchName.Text);    
            this.BindGrid4(searchName.Text);    


        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            //Page_Load(sender, e);

            this.BindGrid1("");
            this.BindGrid2("");
            this.BindGrid3("");
            this.BindGrid4("");
        }
    }

    
}