using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using lewHRISlocal.Employees;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Net.PeerToPeer;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


namespace lewHRISlocal
{
    public partial class _Default : Page
    {
        [System.Web.Services.WebMethod]
        public static List<string> GetEmployee()
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            List<string> termsList = new List<string>();
            //Grab All Employees
            using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, "LEW - Employees"))
                {
                    if (group == null)
                    {
                        //MessageBox.Show("Group does not exist");
                    }
                    else
                    {
                        var users = group.GetMembers(true);
                        foreach (UserPrincipal user in users)
                        {
                                termsList.Add(user.Name.ToString());
                            //ListBox1.Items.Add(String.Format(columns, user.Name.ToString(), user.EmailAddress.ToString()));
                            //termsList.Add(user.Name.ToString());
                            //ListBox1.Items.AddRange(new object[] { user.EmailAddress.ToString(), user.Name.ToString() });
                        }
                    }
                    
                }
                
            }

            return termsList;
            //var ListHRM = string.Join(", ", termsList);
            //string[] array = termsList.ToArray();

            ////TextBox1.Text = array.Length + "";
            ////TextBox1.Text =  string.Join(", ", array);
            ////return string.Join(", ", array);
            //return array;

        }

        public static class MessageBox
        {
            public static void ShowMessage(string MessageText, Page MyPage)
            {
                MyPage.ClientScript.RegisterStartupScript(MyPage.GetType(),
                    "MessageBox", "alert('" + MessageText.Replace("'", "\'") + "');", true);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.PopulateBlogs();
            }

        }

        private void PopulateBlogs()
        {
            string query = "SELECT [Blog_ID], [Title], REPLACE([Title], ' ', '-') [SLUG], [Body], [Date_Entered] FROM [Blogs] ORDER BY [Blog_ID] DESC";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            rptPages.DataSource = dt;
                            rptPages.DataBind();
                        }
                    }
                }

                con.Dispose();
                con.Close();
            }

            
        }

        protected void btnSupervisor_Click(object sender, EventArgs e)
        {

            //Response.Redirect("~/Supervisors/SupervisorDash", false);
            IIdentity id = HttpContext.Current.User.Identity;
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, id.GetDomain());

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, id.GetLogin());

            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - Exempt");

            if (user != null)
            {
                // check if user is member of that group
                if (user.IsMemberOf(group))
                {
                    Response.Redirect("~/Supervisors/SupervisorDash", false);
                    ////MessageBox.ShowMessage("User is a member of LEW - Admins", this.Page);
                    ////return;
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User is a member of LEW - Exempt.'); window.location.replace('Supervisors/SupervisorDash');", true);
                }
                else MessageBox.ShowMessage("User is not a member of LEW - Exempt. Please contact your local HR.", this.Page);
            }
        }

        protected void btnHumanResources_Click(object sender, EventArgs e)
        {

            //Response.Redirect("~/HumanResources/HRDash", false);
            IIdentity id = HttpContext.Current.User.Identity;
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, id.GetDomain());

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, id.GetLogin());

            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - Human Resource Department");

            if (user != null)
            {
                // check if user is member of that group
                if (user.IsMemberOf(group))
                {
                    Response.Redirect("~/HumanResources/HRDash", false);
                    ////MessageBox.ShowMessage("User is a member of LEW - Admins", this.Page);
                    ////return;
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User is a member of LEW - Human Resource Department.'); window.location.replace('HumanResources/HRDash');", true);
                }
                else MessageBox.ShowMessage("User is not a member of LEW - Human Resource Department. Please contact your local HR.", this.Page);
            }

            //Response.Redirect("~/HumanResources/HRDash", false);
        }

        //protected void btnTest_Click(object sender, EventArgs e)
        //{
        //    IIdentity id = HttpContext.Current.User.Identity;
        //    var wbook = new XLWorkbook("C:\\Users\\Public\\Documents\\Corrective Action Introductory.xlsx");

        //    var ws = wbook.AddWorksheet("Sheet1");

        //    ws.FirstCell().Value = 150;

        //    ws.Cell(3, 2).Value = "Hello there!";
        //    ws.Cell("A6").SetValue("falcon").SetActive();

        //    ws.Column(2).AdjustToContents();

        //    wbook.SaveAs("\\\\lew-nas1\\CIFS_Users\\Users\\" + id.GetLogin()  + "\\myExcel.xlsx");
        //}

        protected void btnEmployees_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employees/EmployeeDash", false);
        }

        protected void HyperLink2_Click(object source, RepeaterCommandEventArgs e)
        {
            int hotelId;
            
            if (int.TryParse((string)e.CommandArgument, out hotelId))
            {
                Response.Redirect("~/DisplayBlog.aspx?hotelId=" + hotelId + "", false);
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    IIdentity id2 = HttpContext.Current.User.Identity;
        //    List<string> termsList = new List<string>();
        //    //Grab All Employees

        //    //MessageBox.ShowMessage(id2.GetDomain(), this.Page);
        //    using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
        //    {
        //        using (var group = GroupPrincipal.FindByIdentity(context, "LEW - Employees"))
        //        {
        //            if (group == null)
        //            {
        //                //MessageBox.Show("Group does not exist");
        //            }
        //            else
        //            {
        //                var users = group.GetMembers(true);
        //                foreach (UserPrincipal user in users)
        //                {
        //                    //ListBox1.Items.Add(String.Format(columns, user.Name.ToString(), user.EmailAddress.ToString()));
        //                    termsList.Add(user.Name.ToString());
        //                    //ListBox1.Items.AddRange(new object[] { user.EmailAddress.ToString(), user.Name.ToString() });
        //                }
        //            }
        //        }
        //    }

        //    var ListHRM = string.Join(", ", termsList);
        //    string[] array = termsList.ToArray();

        //    //TextBox1.Text = array.Length + "";
        //    TextBox1.Text =  string.Join(", ", array);
        //    string strValue = Page.Request.Form["name of the textarea HTML control"].ToString();
        //    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ListHRM); window.location.replace('HumanResources/HRDash');", true);
        //    //MessageBox.ShowMessage(ListHRM, this.Page);

        //    //return terms.ToString();
        //}


        //public bool ValidateCredentials(string pUsername, string pPassword, string pDomain)
        //{
        //    bool blnValid = false;
        //    try
        //    {
        //        using (PrincipalContext context = new PrincipalContext(ContextType.Domain, pDomain))
        //        {
        //            blnValid = context.ValidateCredentials(pUsername, pPassword, ContextOptions.Negotiate);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.ShowMessage($"An exception occured: {ex.Message}", this.Page);
        //    }
        //    return blnValid;
        //}

        //public static string GetDepartment(string user)           //(string domain, string userName)
        //{
        //    //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
        //    //return (string)userEntry.Properties["mail"][0];

        //    using (var connection = new DirectoryEntry())
        //    {
        //        using (var search = new DirectorySearcher(connection)
        //        {
        //            Filter = "(samaccountname=" + user + ")",
        //            PropertiesToLoad = { "department" },
        //        })
        //        {
        //            return (string)search.FindOne().Properties["department"][0];
        //        }
        //    }
        //}


    }
}