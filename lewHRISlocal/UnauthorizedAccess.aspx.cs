﻿using System;
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
    
    public partial class UnauthorizedAccess : System.Web.UI.Page
    {
        private int _authenticationAttempts = 0;
        public int AuthenticationAttempts
        {
            get
            {
                if (!string.IsNullOrEmpty(string.Format("{0}", Session["AuthenticationAttempts"])))
                {
                    int.TryParse(Session["AuthenticationAttempts"].ToString(), out _authenticationAttempts);
                }

                return _authenticationAttempts;
            }
            set
            {
                _authenticationAttempts = value;
                Session["AuthenticationAttempts"] = _authenticationAttempts;
            }
        }
        private string _currentUser = string.Empty;
        public string CurrentUser
        {
            get
            {
                _currentUser = Request.LogonUserIdentity.Name;
                Session["CurrentUser"] = _currentUser;
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                Session["CurrentUser"] = _currentUser;
            }
        }
        private string _previousUser = string.Empty;
        public string PreviousUser
        {
            get
            {
                _previousUser = string.Format("{0}", Session["PreviousUser"]);
                return _previousUser;
            }
            set
            {
                _previousUser = value;
                Session["PreviousUser"] = _previousUser;
            }
        }

        /// <summary>
        /// This event fires on every page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Make sure the browser does not cache this page
            //this.DisablePageCaching();

            //// Increase authentication attempts
            ////this.AuthenticationAttempts = this.AuthenticationAttempts + 1;
            //this.AuthenticationAttempts =  this.AuthenticationAttempts + 1;


            //if (this.AuthenticationAttempts == 1)
            //{

            //    // Change previous user to current user
            //    this.PreviousUser = this.CurrentUser;       //ORIGINAL--- Try changing this

            //    // Send the first 401 response

            //    this.Send401();
            //    Response.Redirect("UnauthorizedAccess.aspx");
            //}
            //else
            //{
            //    // When a browser is set to "automaticaly sign in with current credentials", we have to send two 401 responses to let the browser re-authenticate itself.
            //    // I don't know how to determine if a browser is set to "automaticaly sign in with current credentials", so two 401 responses are always send when the user
            //    // does not switch accounts. In Micrososft Office sharepoint the user has to supply the credentials 3 times, when the user does not switch accounts,
            //    // so it think this is not a problem.
            //    if (this.AuthenticationAttempts == 2 && this.CurrentUser.Equals(this.PreviousUser))
            //    {


            //        // Send the second 401 response
            //        this.Send401();
            //        Response.Redirect("UnauthorizedAccess.aspx");
            //    }
            //    else
            //    {
            //this.PreviousUser = this.CurrentUser;
            this.Send401();

            //ClientScript.RegisterStartupScript
            //(GetType(), Guid.NewGuid().ToString(), "logout();", true);

            


            // Clear the session of the current user. This will clear all sessions objects including the "AuthenticationAttempts"
                    Session.Abandon();
                    Session.Clear();
                    //HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                    //HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
                    //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                    //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    //HttpContext.Current.Response.Cache.SetNoStore();
                    //HttpContext.Current.Response.ExpiresAbsolute = DateTime.UtcNow.Subtract(new TimeSpan(1, 0, 0, 0));
                    //HttpContext.Current.Response.Expires = 0;
                    //HttpContext.Current.Response.Cache.AppendCacheExtension("no-store, no-cache, must-revalidate, proxy-revalidate, post-check=0, pre-check=0");

                    FormsAuthentication.SignOut();


            //// Redirect back to the main page
            Response.Redirect("Default.aspx");
            //this.PreviousUser = this.CurrentUser;
            //    }
            //}
        }

        /// <summary>
        /// Make sure the browser does not cache this page
        /// </summary>
        public void DisablePageCaching()
        {
            Response.Expires = 0;
            Response.Cache.SetNoStore();
            Response.AppendHeader("Pragma", "no-cache");
        }
        /// <summary>
        /// Send a 401 response
        /// </summary>
        public void Send401()
        {
            //// Create a 401 response, the browser will show the log-in dialogbox, asking the user to supply new credentials, 
            //// if browser is not set to "automaticaly sign in with current credentials"
            Response.Buffer = true;
            Response.StatusCode = 401;
            Response.StatusDescription = "Unauthorized";



            // A authentication header must be supplied. This header can be changed to Negotiate when using keberos authentication
            Response.AddHeader("WWW-Authenticate", "NTLM");

            // Send the 401 response
            Response.End();

            
        }
    }
}