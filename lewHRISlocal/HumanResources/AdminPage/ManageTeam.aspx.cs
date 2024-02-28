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
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Web.UI.HtmlControls;
using DocumentFormat.OpenXml.Office.Word;
using Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace lewHRISlocal.HumanResources.AdminPage
{
    
    public partial class ManageTeam : System.Web.UI.Page
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
                this.PopulateTeam();
            }

        }

        private void PopulateTeam()
        {
            //string query = "SELECT [Blog_ID], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body], [Date_Entered] FROM [Blogs]";
            string query = "SELECT DISTINCT [Assigned_UserName], [Assigned_Name]  FROM [View_GeneralistGrouped] " +
                " WHERE NOT [Assigned_UserName] IS NULL ORDER BY [Assigned_UserName]";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            ListBox1.DataTextField = "Assigned_UserName";
                            ListBox1.DataValueField = "Assigned_Name";
                            ListBox1.DataSource = dt;
                            ListBox1.DataBind();
                            
                        }
                    }
                }

                int listcount = ListBox1.Rows;
                
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 0)
                    {
                        if (i == 0 && i <= listcount)
                        {
                            i1.Attributes["src"] = ResolveUrl("/Images/Personnel/" + ListBox1.Items[i].Text.ToString() + ".jpg");
                            this.PopulateList1(ListBox1.Items[i].Text.ToString());
                            L1.Text = ListBox1.Items[i].Value.ToString();
                        }
                        else
                        {
                            L1.Visible =   false;
                            i1.Visible = false;
                            Rpt1.Visible = false;
                        }    
                    }
                    if (i == 1)
                    {
                        if (i == 1 && i <= listcount)
                        {
                            i2.Attributes["src"] = ResolveUrl("/Images/Personnel/" + ListBox1.Items[i].Text.ToString() + ".jpg");
                            this.PopulateList2(ListBox1.Items[i].Text.ToString());
                            L2.Text = ListBox1.Items[i].Value.ToString();
                        }
                        else
                        {
                            L2.Visible = false;
                            Rpt2.Visible = false;
                            i2.Visible = false;
                        }
                    }
                    if (i == 2)
                    {
                        if (i == 2 && i <= listcount)
                        {
                            i3.Attributes["src"] = ResolveUrl("/Images/Personnel/" + ListBox1.Items[i].Text.ToString() + ".jpg");
                            this.PopulateList3(ListBox1.Items[i].Text.ToString());
                            L3.Text = ListBox1.Items[i].Value.ToString();
                        }
                        else
                        {
                            L3.Visible = false; 
                            Rpt3.Visible = false;
                            i3.Visible = false;
                        }
                    }
                    if (i == 3)
                    {
                        if (i == 3 && i <= listcount)
                        {
                            i4.Attributes["src"] = ResolveUrl("/Images/Personnel/" + ListBox1.Items[i].Text.ToString() + ".jpg");
                            this.PopulateList4(ListBox1.Items[i].Text.ToString());
                            L4.Text = ListBox1.Items[i].Value.ToString();
                        }
                        else
                        {
                            L4.Visible = false;
                            Rpt4.Visible = false;
                            i4.Visible = false;
                        }
                    }
                    if (i == 4)
                    {
                        if (i == 4 && i <= listcount)
                        {
                            i5.Attributes["src"] = ResolveUrl("/Images/Personnel/" + ListBox1.Items[i].Text.ToString() + ".jpg");
                            this.PopulateList5(ListBox1.Items[i].Text.ToString());
                            L5.Text = ListBox1.Items[i].Value.ToString();
                        }
                        else
                        {
                            L5.Visible = false;
                            Rpt5.Visible = false;
                            i5.Visible = false;
                        }
                    }
                    if (i == 5)
                    {
                        if (i == 5 && i <= listcount)
                        {
                            i6.Attributes["src"] = ResolveUrl("/Images/Personnel/" + ListBox1.Items[i].Text.ToString() + ".jpg");
                            this.PopulateList6(ListBox1.Items[i].Text.ToString());
                            L6.Text = ListBox1.Items[i].Value.ToString();
                        }
                        else
                        {
                            L6.Visible = false; 
                            Rpt6.Visible = false;
                            i6.Visible = false;
                        }
                    }
                }
            }
        

            //for (int i = 1; i <= count; i++)
            //{
            //HtmlImage imgs = new HtmlImage();
            ////string id = "Img" + i.ToString();
            //string id = "Img" + 1;
            //imgs.Attributes["id"] = id;
            //imgs.Attributes["src"] = ResolveUrl("/Images/" + dataReader.GetString(0) + ".jpg");
            //}

            //string myConnection;
            //SqlConnection cnn;
            //myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            //cnn = new SqlConnection(myConnection);
            //cnn.Open();
            ////Response.Write("Connection Made");

            //SqlCommand command = new SqlCommand("SELECT DISTINCT [Assigned_UserName] FROM [View_GeneralistGrouped] " +
            //    " WHERE NOT [Assigned_UserName] IS NULL", cnn);
            //SqlDataReader dataReader;
            //String Output = " ";
            //dataReader = command.ExecuteReader();

            //while (dataReader.Read())
            //{

            //}
            //Response.Write(Output);
            //dataReader.Close();
            //command.Dispose();
            //cnn.Close();
        }

        private void PopulateList1(string userName)
        {
            //string query = "SELECT [Blog_ID], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body], [Date_Entered] FROM [Blogs]";
            string query = "SELECT [Department_Group] FROM [View_GeneralistGrouped] WHERE [Assigned_UserName] = '" + userName + "'" ;
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            Rpt1.DataSource = dt;
                            Rpt1.DataBind();
                        }
                    }
                }
            }
        }

        private void PopulateList2(string userName)
        {
            //string query = "SELECT [Blog_ID], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body], [Date_Entered] FROM [Blogs]";
            string query = "SELECT [Department_Group] FROM [View_GeneralistGrouped] WHERE [Assigned_UserName] = '" + userName + "'";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            Rpt2.DataSource = dt;
                            Rpt2.DataBind();
                        }
                    }
                }
            }
        }



        private void PopulateList3(string userName)
        {
            //string query = "SELECT [Blog_ID], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body], [Date_Entered] FROM [Blogs]";
            string query = "SELECT [Department_Group] FROM [View_GeneralistGrouped] WHERE [Assigned_UserName] = '" + userName + "'";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            Rpt3.DataSource = dt;
                            Rpt3.DataBind();
                        }
                    }
                }
            }
        }

        private void PopulateList4(string userName)
        {
            //string query = "SELECT [Blog_ID], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body], [Date_Entered] FROM [Blogs]";
            string query = "SELECT [Department_Group] FROM [View_GeneralistGrouped] WHERE [Assigned_UserName] = '" + userName + "'";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            Rpt4.DataSource = dt;
                            Rpt4.DataBind();
                        }
                    }
                }
            }
        }

        private void PopulateList5(string userName)
        {
            //string query = "SELECT [Blog_ID], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body], [Date_Entered] FROM [Blogs]";
            string query = "SELECT [Department_Group] FROM [View_GeneralistGrouped] WHERE [Assigned_UserName] = '" + userName + "'";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            Rpt5.DataSource = dt;
                            Rpt5.DataBind();
                        }
                    }
                }
            }
        }

        private void PopulateList6(string userName)
        {
            //string query = "SELECT [Blog_ID], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body], [Date_Entered] FROM [Blogs]";
            string query = "SELECT [Department_Group] FROM [View_GeneralistGrouped] WHERE [Assigned_UserName] = '" + userName + "'";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);
                            Rpt6.DataSource = dt;
                            Rpt6.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnModifyTeam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/AdminPage/ModifyAssignment.aspx", false);
        }

        

        protected void btnModifyMembers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/AdminPage/AddTeamMember.aspx", false);
        }
        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        //protected void LinkButton3_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView2.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        //protected void LinkButton4_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView3.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
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
        //    SqlCommand command2 = new SqlCommand("SELECT * FROM [View_3] " +
        //        "WHERE [Overall Status] = 'Initiated Disciplinary Action'", cnn);
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
        //            txtNewRecord.Text = "No records available.";
        //        }
        //    }
        //    command2.Dispose();
        //    cnn.Close();
        //}

        //private void BindGrid2()
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
        //    SqlCommand command = new SqlCommand("SELECT * FROM [View_3] " +
        //        "WHERE ([Overall Status] = 'Sent to HRM for Final Review')", cnn);
        //    sda.SelectCommand = command;
        //    using (DataTable dt = new DataTable())
        //    {
        //        sda.Fill(dt);
        //        if (dt.Rows.Count>0)
        //        {
        //            //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //        else
        //        {
        //            txtReceivedRecord.Text = "No records available.";
        //        }
        //    }

        //    command.Dispose();
        //    cnn.Close();
        //}

        //private void BindGrid3()
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
        //    SqlCommand command = new SqlCommand("SELECT * FROM [View_3] " +
        //        "WHERE ([Overall Status] = 'Disciplinary Action Sent to Department' OR [Overall Status] = 'Waiting for Sup Acknowledgement Disciplinary' OR [Overall Status] = 'Waiting for EE Acknowledgement Disciplinary')", cnn);
        //    sda.SelectCommand = command;
        //    using (DataTable dt = new DataTable())
        //    {
        //        sda.Fill(dt);
        //        if (dt.Rows.Count>0)
        //        {
        //            //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
        //            GridView2.DataSource = dt;
        //            GridView2.DataBind();
        //        }
        //        else
        //        {
        //            txtPendingCounseling.Text = "No records available.";
        //        }
        //    }

        //    command.Dispose();
        //    cnn.Close();
        //}

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
        //    SqlCommand command = new SqlCommand("SELECT * FROM [View_3] " +
        //        "WHERE [Overall Status] = 'Disciplinary Action Closed'", cnn);
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
        //            txtClosedRecord.Text = "No records available.";
        //        }
        //    }

        //    command.Dispose();
        //    cnn.Close();
        //}


        //protected void mydatagrid_DataBound(object sender, EventArgs e)
        //{
        //    if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
        //    {
        //        txtNewRecord.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else txtNewRecord.Text = "No record(s) returned.";

        //}

        //protected void GridView1_DataBound(object sender, EventArgs e)
        //{
        //    if ((GridView1.DataSource as DataTable).Rows.Count>0)
        //    {
        //        txtReceivedRecord.Text = (GridView1.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else txtReceivedRecord.Text = "No record(s) returned.";
        //}

        //protected void GridView2_DataBound(object sender, EventArgs e)
        //{
        //    if ((GridView2.DataSource as DataTable).Rows.Count>0)
        //    {
        //        txtPendingCounseling.Text = (GridView2.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else txtPendingCounseling.Text = "No record(s) returned.";
        //}

        //protected void GridView3_DataBound(object sender, EventArgs e)
        //{
        //    if ((GridView3.DataSource as DataTable).Rows.Count>0)
        //    {
        //        txtClosedRecord.Text = (GridView3.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else txtClosedRecord.Text = "No record(s) returned.";
        //}

        //protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    mydatagrid.PageIndex = e.NewPageIndex;
        //    this.BindGrid1();
        //}
        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    this.BindGrid2();
        //}

        //protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView2.PageIndex = e.NewPageIndex;
        //    this.BindGrid3();
        //}

        //protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView3.PageIndex = e.NewPageIndex;
        //    this.BindGrid4();
        //}
    }
}