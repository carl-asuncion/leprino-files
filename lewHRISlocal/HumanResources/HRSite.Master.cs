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
       

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisablePageCaching();
            //string userNow = Page.User(wraps, HttpContext.Current.User.Identity.Name);
            IIdentity id = HttpContext.Current.User.Identity;

            //TextBox1.Text =  id.GetLogin();
            //TextBox1.Text =  id.GetDomain();
            TextBox1.Text =  id.GetLogin();


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
                    //Response.Redirect("~/Supervisors/SupervisorDash", false);
                    //MessageBox.ShowMessage("User is a member of LEW - Admins", this.Page);
                    //return;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Access granted.'); window.location.replace('HRManager/HRManagerDash');", true);
                }
                else Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('You do not have the appropriate access.');", true);
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string empName = txtSearch.Text;
            Response.Redirect("~/HumanResources/EmployeeSearch.aspx?empName=" + empName, false);
            //Label1.Text = Server.UrlDecode(Request.QueryString["Parameter"].ToString());
        }
    }
}