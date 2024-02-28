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

namespace lewHRISlocal.HumanResources.AdminPage
{
    
    public partial class AdminPanel : System.Web.UI.Page
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
                
            }
        }

        protected void btnCorrectiveActionMatrix_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/AdminPage/CorrectiveActionMatrix.aspx", false);
        }

        protected void btnManuallyAddCA_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/AdminPage/Create.aspx", false);
        }

        protected void btnManageTeam_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/AdminPage/ManageTeam.aspx", false);
        }

    }
}