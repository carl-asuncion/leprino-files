using Azure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.DirectoryServices.AccountManagement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Text.RegularExpressions;
using iTextSharp.text.html.simpleparser;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Data.Entity;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.DirectoryServices;
using System.Windows.Controls;
using System.Web.Providers.Entities;
using System.Net.Mail;
using System.Net;
using Org.BouncyCastle.Cms;
using System.Diagnostics;
using System.Web.Mail;
using iTextSharp.text.pdf.parser.clipper;
using DocumentFormat.OpenXml.Office.Word;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Win32;

namespace lewHRISlocal
{
    public partial class AddBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit(object sender, EventArgs e)
        {
            string query = "INSERT INTO [Blogs] VALUES (@Title, @Date_Entered, @Body)";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Date_Entered", System.DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@Body", txtBody.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Dispose();
                    con.Close();
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        public static string GetUsername(string empID)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + empID + ")",
                    PropertiesToLoad = { "samaccountname" },
                })
                {
                    return (string)search.FindOne().Properties["samaccountname"][0];
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty("asuncica"))
                {
                    MessageBox.ShowMessage("Unable to Authenticate Using the Supplied Credentials 1", this.Page);
                }
                //else if ((GetUserFullName(id2.GetDomain(), txtUserName.Text) != txtEmployeeName.Text) || (txtUserName.Text != GetUsername(txtEmpID.Text))) //User not empty but Incorrect user trying to sign
                //else if ((GetUserFullName(id2.GetDomain(), txtUserName.Text) != txtEmployeeName.Text)) //User not empty but Incorrect user trying to sign
                //{
                //    Authenticated.Visible= true;
                //    Authenticated.Text = "Incorrect Employee trying to Authenticate";
                //    btnEmployeeSign.Visible = true;

                //}
                else if (("asuncica" != GetUsername("104040"))) //User not empty but Incorrect user trying to sign
                {

                    MessageBox.ShowMessage("Unable to Authenticate Using the Supplied Credentials 2", this.Page);
                }
                else //Correct user - but check credentials
                {
                    if (AuthenticateUser("asuncica", "Executor2018!"))
                    {
                        //CORRECT CREDENTIALS
                        //DialogResult = true;
                        //MessageBox.ShowMessage("Success Using the Supplied Credentials", this.Page);
                        //FormsAuthentication.RedirectFromLoginPage(uName.Text, true);
                        //FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);
                        MessageBox.ShowMessage("Unable to Authenticate Using the Supplied Credentials 3", this.Page);
                        txtTitle.Text = GetUsername("104040");
                        if ("leonj" == "leonj")
                        {
                            txtBody.Text = "EQUAL";
                        }
                        else txtBody.Text = "NOT EQUAL";
                    }


                    else
                    {
                        //INCORRECT CREDENTIALS
                        
                        MessageBox.ShowMessage("Unable to Authenticate Using the Supplied Credentials 4", this.Page);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.ShowMessage("Username entered is not a valid entry. Please check the username and try again.", this.Page);
                
            }
            finally
            {

            }
        }

        private bool AuthenticateUser(string userName, string password)
        {
            bool ret = false;

            try
            {
                DirectoryEntry de = new DirectoryEntry("LDAP://leprino.local", userName, password);
                DirectorySearcher dsearch = new DirectorySearcher(de);
                SearchResult results = null;

                results = dsearch.FindOne();

                ret = true;
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
    }
}