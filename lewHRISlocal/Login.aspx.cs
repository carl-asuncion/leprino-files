using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lewHRISlocal.Employees;
using Microsoft.Ajax.Utilities;
using System.Configuration;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.DirectoryServices;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Windows;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Windows.Controls;
using Page = System.Web.UI.Page;

namespace lewHRISlocal
{
    public static class MessageBox
    {
        public static void ShowMessage(string MessageText, System.Web.UI.Page MyPage)
        {
            MyPage.ClientScript.RegisterStartupScript(MyPage.GetType(),
                "MessageBox", "alert('" + MessageText.Replace("'", "\'") + "');", true);
        }
    }
    public partial class Login : System.Web.UI.Page
    {
        private bool AuthenticateUser(string userName, string password)
        {
            bool ret = false;

            try
            {
                DirectoryEntry de = new DirectoryEntry("LDAP://leprino.local", uName.Text, uPassword.Text);
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
            if (this.IsPostBack)
            {
                uPassword.Attributes["value"] = uPassword.Text;
            }

            Label1.Visible = false;
        }

        //private void mybutton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (AuthenticateUser(uName.Text, uPassword.Text))
        //    {
        //        //DialogResult = true;
        //        MessageBox.ShowMessage("Success Using the Supplied Credentials", this.Page);
        //    }


        //    else
        //        MessageBox.ShowMessage("Unable to Authenticate Using the Supplied Credentials", this.Page);
        //}

        protected void mybutton_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(uName.Text, uPassword.Text))
            {
                //DialogResult = true;
                MessageBox.ShowMessage("Success Using the Supplied Credentials", this.Page);
                //FormsAuthentication.RedirectFromLoginPage(uName.Text, true);
                FormsAuthentication.RedirectFromLoginPage(uName.Text, true);
                
            }


            else
            {
                Label1.Text = "Incorrect credentials";
                MessageBox.ShowMessage("Unable to Authenticate Using the Supplied Credentials", this.Page);
            }
                
        }
    }

}
