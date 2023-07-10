using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lewHRISlocal
{
    
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisablePageCaching();

            IIdentity id = HttpContext.Current.User.Identity;
            TextBox1.Text =  id.GetLogin();


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
    }
}