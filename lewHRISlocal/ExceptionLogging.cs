using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using context = System.Web.HttpContext;
using System.DirectoryServices;
using Microsoft.Ajax.Utilities;
using System.Data.Entity.Core.Common.CommandTrees;

namespace lewHRISlocal
{
    public static class ExceptionLogging
    {
        // ############# ERROR LOGGING START #########################################################
        public static String ErrorlineNo, Errormsg, ErrorLocation, extype, exurl, Frommail, ToMail, Sub, HostAdd, EmailHead, EmailSing;
        public static void SendErrorTomail(Exception exmail, string getID, string getCase) //, string getID
        {
            IIdentity id = HttpContext.Current.User.Identity;
            try
            {
                var newline = "<br/>";
                ErrorlineNo = exmail.StackTrace.Substring(exmail.StackTrace.Length - 8, 8);
                Errormsg = exmail.GetType().Name.ToString();
                extype = exmail.GetType().ToString();
                exurl = HttpContext.Current.Request.Url.AbsolutePath.ToString();
                ErrorLocation = exmail.Message.ToString();
                EmailHead = "<b>Dear Team,</b>" + "<br/>" + "An exception occurred in a Application Url" + " " + exurl + " " + "With following Details" + "<br/>" + "<br/>";
                EmailSing = newline + "Thanks and Regards" + newline + "    " + "     " + "<b>Application Admin </b>" + "</br>";
                Sub = "Exception occurred" + " " + "in Application" + " " + exurl;
                string errortomail = EmailHead + "<b>Log Written Date: </b>" + " " + DateTime.Now.ToString() + newline + "<b>Error Line No :</b>" + " " +
                    ErrorlineNo + "\t\n" + " " + newline + "<b>Error Message:</b>" + " " + Errormsg + newline + "<b>Exception Type:</b>" + " " + extype +
                    newline + "<b> Error Details :</b>" + " " + ErrorLocation + newline + "<b>Error Page Url:</b>" + " " + exurl + newline +
                    "<b>Username that received error:</b>" + " " + getID + newline +
                    "<b>Case number affected:</b>" + " " + getCase + newline + newline + newline +
                    newline + newline + EmailSing;

                System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
                //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
                //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
                newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Error Notification");
                //newReport.To.Add("" + string.Join(", ", items).ToString() + ""); //HRIS Group
                newReport.To.Add(new MailAddress("casuncion@leprinofoods.com")); //HRIS Group
                newReport.Subject = Sub;
                newReport.IsBodyHtml = true;
                newReport.Body = errortomail;

                smtpClient.Send(newReport);
            }
            catch (Exception em)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                em.ToString();
                //ScriptManager.RegisterStartupScript(exurl, "myalert", "alert('We apologize. An error occured and an email was sent to the team. '); window.location.replace('http://10.40.80.28:150/lewHRISlocal/Default.aspx');", true);
                MessageBox.ShowMessage("User is not a member of LEW - Human Resource Department. Please contact your local HR.", page);
            }
        }
        // ############# ERROR LOGGING END #########################################################
    }
}