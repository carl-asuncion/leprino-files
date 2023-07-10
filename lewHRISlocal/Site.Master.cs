using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Providers.Entities;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace lewHRISlocal
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
    public partial class SiteMaster : MasterPage
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
            //Added
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

      
    }
}