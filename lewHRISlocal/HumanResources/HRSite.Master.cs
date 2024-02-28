using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using lewHRISlocal.Employees;
using Microsoft.Ajax.Utilities;
using System.DirectoryServices;
using System.Net.Mail;
using Microsoft.AspNet.FriendlyUrls;

namespace lewHRISlocal.HumanResources
{
    /*public static class Extensions
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
    }*/

    public partial class HRSiteMaster : MasterPage
    {
        public static string GetUserGiven(string user)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + user + ")",
                    PropertiesToLoad = { "givenName" },
                })
                {
                    return (string)search.FindOne().Properties["givenName"][0];
                }
            }
        }
        //GET USER FULLNAME
        public static string GetUserGivenName(string userName)
        {
            SearchResult results;
            List<string> termsList = new List<string>();
            //SearchResultCollection results;
            string user = "Lemoore West";
            string distinguishedName;
            using (var connection = new DirectoryEntry())
            {
                //DirectorySearcher search = new DirectorySearcher(connection);
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(&(objectCategory=User)(objectClass=user)(l=" + user + ")(!(userAccountControl:1.2.840.113556.1.4.803:=2))(samaccountname="+userName+"))",
                    //Filter = "(&(objectCategory=User)(objectClass=user)(l=" + user + ")(samaccountname="+userName+"))",
                    //Filter = "(&(objectCategory=User)(l=" + user + ")(!(userAccountControl:1.2.840.113556.1.4.803:=2))(memberof=CN=LEW - Exempt,OU=GROUPS,OU=LEMOORE WEST,OU=SITES,DC=leprino,DC=local))",
                    //Filter = "(&(samaccountname=" + user + ")(l=Lemoore West)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))",
                    PropertiesToLoad = { "givenname" },
                })
                {
                    results = search.FindOne();
                    DirectoryEntry user2 = results.GetDirectoryEntry();
                    distinguishedName = user2.Properties["givenname"][0].ToString();
                }
            }
            return distinguishedName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                        //Response.Redirect("~/HumanResources/HRDash", false);
                        ////MessageBox.ShowMessage("User is a member of LEW - Admins", this.Page);
                        ////return;
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User is a member of LEW - Human Resource Department.'); window.location.replace('HumanResources/HRDash');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('User is not a member of LEW - Human Resource Department. Please contact your local HR.');" +
                            "window.location.replace('http://10.40.80.28:150/lewHRISlocal/');", true);
                        //MessageBox.ShowMessage("User is not a member of LEW - Human Resource Department. Please contact your local HR.", this.Page);
                        //Response.Redirect("~/Default.aspx", false);
                    }
                }

                this.DisablePageCaching();
                ////string userNow = Page.User(wraps, HttpContext.Current.User.Identity.Name);
                //IIdentity id = HttpContext.Current.User.Identity;

                //TextBox1.Text =  id.GetLogin();
                //TextBox1.Text =  id.GetDomain();
                txtID1.Text =  "Logged in as " + id.GetLogin();
                TextBox1.Text = "Logged in as " + id.GetLogin();


                //string currUsername = System.Security.Principal.WindowsIdentity.GetCurrent().;
                //string currUsername = Environment.UserName;
                //string currUsername = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                //string currName = UserPrincipal.Current.GivenName + " " + UserPrincipal.Current.Surname;
                //string currEmail = UserPrincipal.Current.EmailAddress;
                //TextBox1.Text = currUsername;
                //TextBox1.Text = currName + "(" + currEmail + ")";


                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();
                //Response.Write("Connection Made");

                SqlCommand command = new SqlCommand("Select * from dbo.MasterList ", cnn);
                SqlDataReader dataReader;
                String Output = " ";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                }
                Response.Write(Output);
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                DateTime timeOfDay = DateTime.Now;

                if (timeOfDay.Hour >= 5 && timeOfDay.Hour < 12)
                {
                    currentTimeOfDay.Text = "Good Morning";
                    hiddenTimeOfDay.Text = "Good Morning";
                }
                else if (timeOfDay.Hour >= 12 && timeOfDay.Hour < 18)
                {
                    currentTimeOfDay.Text = "Good Afternoon";
                    hiddenTimeOfDay.Text = "Good Afternoon";
                }
                else
                {
                    currentTimeOfDay.Text = "Good Evening";
                    hiddenTimeOfDay.Text = "Good Evening";
                }

                currentUser.Text = GetUserGiven(id.GetLogin());
                hiddenUser.Text = GetUserGiven(id.GetLogin());

                try
                {
                    image1a.Attributes["src"] = ResolveUrl("~/Images/Personnel/" + id.GetLogin() + ".jpg");
                    image2a.Attributes["src"] = ResolveUrl("~/Images/Personnel/" + id.GetLogin() + ".jpg");   
                }
                catch (Exception ex) {
                    image1a.Attributes["src"] = ResolveUrl("~/Images/femalepng.png");
                    image2a.Attributes["src"] = ResolveUrl("~/Images/femalepng.png"); 
                }
                finally { }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/UnauthorizedAccess", false);
            }
            finally { }


        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccessDenied.aspx");
        }

        public void DisablePageCaching()
        {
            Response.Expires = 0;
            Response.Cache.SetNoStore();
            Response.AppendHeader("Pragma", "no-cache");
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string empName = txtSearch.Text;
            Session["empName"] = empName;
            Response.Redirect("~/HumanResources/EmployeeSearch.aspx?empName=" + empName, false);
            //Label1.Text = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
        }


        protected void btnHRMDash_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/HumanResources/HRManager/HRManagerDash", false);
            IIdentity id = HttpContext.Current.User.Identity;
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, id.GetDomain());

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, id.GetLogin());

            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - HRIS CAS");

            if (user != null)
            {
                // check if user is member of that group
                if (user.IsMemberOf(group))
                {
                    Response.Redirect("~/HumanResources/HRManager/HRManagerDash", false);
                    ////MessageBox.ShowMessage("User is a member of LEW - Admins", this.Page);
                    ////return;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Access granted.'); window.location.replace('/HumanResources/HRManager/HRManagerDash');", true);
                }
                else Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('You do not have the appropriate access.');", true);
            }
        }

        protected void btnAdminPanel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/HumanResources/HRManager/HRManagerDash", false);
            IIdentity id = HttpContext.Current.User.Identity;
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, id.GetDomain());

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, id.GetLogin());

            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - HRIS CAS");

            if (user != null)
            {
                // check if user is member of that group
                if (user.IsMemberOf(group))
                {
                    Response.Redirect("~/HumanResources/AdminPage/AdminPanel", false);
                    ////MessageBox.ShowMessage("User is a member of LEW - Admins", this.Page);
                    ////return;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Access granted.'); window.location.replace('/HumanResources/AdminPage/AdminPanel');", true);
                }
                else Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('You do not have the appropriate access.');", true);
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                Response.Redirect("~/HumanResources/EmployeeSearch.aspx?empName=" + txtSearch.Text, false);
                //Label1.Text = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
            }
            else if (!string.IsNullOrEmpty(TextBox2.Text))
            {
                Response.Redirect("~/HumanResources/EmployeeSearch.aspx?empName=" + TextBox2.Text, false);
                //Label1.Text = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
            }
            else
            {
                Response.Redirect("~/HumanResources/EmployeeSearch.aspx?empName=" + "", false);
                //Label1.Text = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
            }

        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/HRDash.aspx", false);
        }

        protected void btnPrintRequests_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/PrintRequests.aspx", false);
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            string currentUrl;
            currentUrl = HttpContext.Current.Request.Url.AbsolutePath.ToString();

            //EMAIL NOTIFICATION
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h2>LEW HRIS Corrective Action - New Message</h2></div>";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td><strong>New Message for the Team</strong></td><td></td></tr>";
            html = html + "<tr><td>Submitted by: </td><td>" + userName.Value.ToString() + " (" + userEmail.Value.ToString() + ")</td></tr>";
            html = html + "<tr><td>Submitted on: </td><td>" + formattedDateTime + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Message: </td><td>" + userMessage.Value.ToString() + "</td></tr>";
            html = html + "<tr><td>Feedback URL: </td><td>" + currentUrl + "</td></tr>";
            html = html + "</table></div>";
            html = html + "<br /><br />";


            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Plant Systems West");
            newReport.To.Add("casuncion@leprinofoods.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
            newReport.Subject = "LEW HRIS Corrective Action - New Message";
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);


            userEmail.Value = null;
            userMessage.Value = null;
            userName.Value = null;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                          "showThanks();", true);
        }
    }
}