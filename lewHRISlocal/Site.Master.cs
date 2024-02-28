using Azure.Identity;
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
using System.Net.Mail;
using System.Security.Principal;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Providers.Entities;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

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
            if (!IsPostBack)
            {
                this.DisablePageCaching();

                //string userNow = Page.User(wraps, HttpContext.Current.User.Identity.Name);
                IIdentity id = HttpContext.Current.User.Identity;

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
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            //////Response.Redirect("~/AccessDenied.aspx");
            Response.Redirect("~/UnauthorizedAccess.aspx");


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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx");
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