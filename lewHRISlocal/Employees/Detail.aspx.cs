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
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Principal;
using System.Data.Entity;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.DirectoryServices;
using System.Web.Providers.Entities;
using System.Net.Mail;
using System.Net;
using Org.BouncyCastle.Cms;
using System.Diagnostics;
using System.Web.Mail;
using iTextSharp.text.pdf.parser.clipper;
//using EASendMail;

namespace lewHRISlocal.Employees
{
    public static class MessageBox
    {
        public static void ShowMessage(string MessageText, System.Web.UI.Page MyPage)
        {
            MyPage.ClientScript.RegisterStartupScript(MyPage.GetType(),
                "MessageBox", "alert('" + MessageText.Replace("'", "\'") + "');", true);
        }
    }

    public partial class Detail : System.Web.UI.Page
    {
        public string currUser;
        public string updatedComment;
        public static string GetUserFullName(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                IIdentity id2 = HttpContext.Current.User.Identity;
                currUser = id2.GetLogin();
                timedateAck.Text = "Acknowledging on " + System.DateTime.Now.ToString() + " under " +  currUser + ".";
                TextBox2.Text = "Refusing to acknowledge on " + System.DateTime.Now.ToString() + " under " +  currUser + ".";
                string id = Request.QueryString["id"];

                txtCounselingID.Text = id;

                Context.ApplicationInstance.CompleteRequest();


                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();
                //Response.Write("Connection Made");

                SqlCommand command = new SqlCommand("Select * from dbo.View_1 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
                SqlDataReader dataReader;
                //String Output = " ";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    txtDateEntered.Text = dataReader.GetDateTime(2).ToString();
                    txtEmpID.Text = "" + dataReader.GetInt32(1);
                    txtDateIncident.Text = dataReader.GetDateTime(3).ToString();
                    txtEmployeeName.Text = dataReader.GetString(4);
                    txtPosition.Text = dataReader.GetString(36);
                    txtEEStatus.Text = dataReader.GetString(25);
                    txtDepartment.Text = dataReader.GetString(5);
                    txtCategory.Text = dataReader.GetString(6);
                    txtSubCategory.Text = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8))
                    {
                        txtSubject.Text = dataReader.GetString(8);
                    }
                    else txtSubject.Text = "";

                    if (!dataReader.IsDBNull(9))
                    {
                        txtLevel.Text = dataReader.GetString(9);
                    }
                    else txtLevel.Text = "";

                    if (!dataReader.IsDBNull(10))
                    {
                        txtSupComments.Text = dataReader.GetString(10);
                    }
                    else txtSupComments.Text = "";

                    if (!dataReader.IsDBNull(21))
                    {
                        txtOverallStatus.Text = dataReader.GetString(21);
                        //cboStatus.Text = dataReader.GetString(9);
                    }
                    else txtOverallStatus.Text = "";


                    if (!dataReader.IsDBNull(11))
                    {
                        updatedComment = dataReader.GetString(11);
                    }
                    else updatedComment = "";

                    TextBox6.Text = dataReader.GetString(16);
                }
                //Response.Write(Output);
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                txtEmployeeComments.Text = updatedComment;
            }
             
        }

        protected void btnAck_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            currUser = id2.GetLogin();
            //MessageBox.ShowMessage(txtEmployeeComments.Text, this.Page);
            string myConnection;
            string SupStatus;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);



            SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = 'EE Acknowledged', [HR_Status] = 'HR Sent'" +
            ", [EE_Comments] = '" + txtEmployeeComments.Text + "', [EE_Acknowledge_Date] = '" + System.DateTime.Now.ToString() + "', [EE_Signed] = '" + currUser.ToString() + "' WHERE [Counseling_ID] = "
            + txtCounselingID.Text + "", cnn);

            cnn.Open();
            command.ExecuteNonQuery();

            //MessageBox.ShowMessage(newStatus, this.Page);
            SqlCommand command2 = new SqlCommand("Select [Overall Status] from dbo.View_1 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command2.ExecuteReader();
            while (dataReader.Read())
            {
                txtNewStatus.Text = dataReader.GetString(0);
            }
            dataReader.Close();
            command2.Dispose();
            cnn.Close();

            if (txtNewStatus.Text == "Sent to HR for Final Review")
            {
                string subject = "New Counseling Report - " + txtCounselingID.Text + "";
                string bodyMessage = "<h3>New Counseling Report</h3>" +
                                        "<br />New counseling Report for " + txtEmployeeName.Text + " has been submitted. <br />Please review.";

                sendEmail("casuncion@leprinofoods.com", "casuncion@leprinofoods.com", subject, bodyMessage);
            }
            else
            {
                //Nothing
            }
            Response.Redirect("~/Employees/EmployeeDash", false);
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employees/EmployeeDash", false);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            currUser = id2.GetLogin();
            //MessageBox.ShowMessage(txtEmployeeComments.Text, this.Page);
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = 'EE Reject', [HR_Status] = 'HR Sent'" +
                ", [EE_Comments] = '" + txtEmployeeComments.Text + "', [EE_Acknowledge_Date] = '" + System.DateTime.Now.ToString() + "', [EE_Signed] = '" + currUser.ToString() + "' WHERE [Counseling_ID] = "
                + txtCounselingID.Text + "", cnn);

            cnn.Open();
            command.ExecuteNonQuery();

            //MessageBox.ShowMessage(newStatus, this.Page);
            SqlCommand command2 = new SqlCommand("Select [Overall Status] from dbo.View_1 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command2.ExecuteReader();
            while (dataReader.Read())
            {
                txtNewStatus.Text = dataReader.GetString(0);
            }
            dataReader.Close();
            command2.Dispose();
            cnn.Close();

            if (txtNewStatus.Text == "Sent to HR for Final Review")
            {
                string subject = "New Counseling Report - " + txtCounselingID.Text + "";
                string bodyMessage = "<h3>New Counseling Report</h3>" +
                                        "<br />New counseling Report for " + txtEmployeeName.Text + " has been submitted. <br />Please review.";

                sendEmail("casuncion@leprinofoods.com", "casuncion@leprinofoods.com", subject, bodyMessage);
            }
            else
            {
                //Nothing
            }
            Response.Redirect("~/Employees/EmployeeDash", false);
        }

        public void sendEmail(string hrEmail, string supEmail, string subject, string bodyMessage)
        {
            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("lewiss@leprinofoods.com", "LEW Counseling System");
            newReport.To.Add(hrEmail);
            newReport.To.Add(supEmail);
            newReport.Subject = subject;
            newReport.Body = bodyMessage;
            newReport.IsBodyHtml = true;

            smtpClient.Send(newReport);
        }
        //protected void txtEmployeeComments_TextChanged(object sender, EventArgs e)
        //{
        //    updatedComment = txtEmployeeComments.Text;
        //}
    }
}