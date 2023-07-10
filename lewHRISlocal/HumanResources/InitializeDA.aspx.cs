using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Text;
using System.EnterpriseServices.Internal;
using Microsoft.Identity.Client;
using System.Security.Principal;
using System.DirectoryServices;
using AjaxControlToolkit;
//using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;
using System.Data;
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
using System.Data.Entity;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Windows.Controls;
using System.Web.Providers.Entities;
using System.Net.Mail;
using System.Net;
using Org.BouncyCastle.Cms;
using System.Diagnostics;
using System.Web.Mail;
using iTextSharp.text.pdf.parser.clipper;
using ListItem = System.Web.UI.WebControls.ListItem;
using DocumentFormat.OpenXml.Spreadsheet;

namespace lewHRISlocal.HumanResources
{
    
    
    public partial class InitializeDA : System.Web.UI.Page
    {

        string newStatus;
        string udpateSupComments;

        private DataSet ds;

        public static string GetUserFullName(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }

        public static string GetUserEmail(string user)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + user + ")",
                    PropertiesToLoad = { "mail" },
                })
                {
                    return (string)search.FindOne().Properties["mail"][0];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            string id = Request.QueryString["id"];

            txtCounselingID.Text = id;
            //timedateAck.Text = "Acknowledging on " + System.DateTime.Now.ToString();
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
                txtDateIncident.Text = dataReader.GetDateTime(3).ToString();
                txtPosition.Text = dataReader.GetString(36);
                txtEmpID.Text = "" + dataReader.GetInt32(1);
                txtEEStatus.Text = dataReader.GetString(25);
                txtEmployeeName.Text = dataReader.GetString(4);
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
                    txtEmployeeComments.Text = dataReader.GetString(11);
                }
                else txtEmployeeComments.Text = "";

                //if (!dataReader.IsDBNull(13))
                //{
                //    txtFollowUp.Text = dataReader.GetString(13);
                //}
                //else txtFollowUp.Text = "";

                ////Bottom Data
                //if (!dataReader.IsDBNull(26))
                //{
                //    txtEEAck.Text = dataReader.GetString(26);
                //}
                //else txtEEAck.Text = "";
                //if (!dataReader.IsDBNull(32))
                //{
                //    txtEESigned.Text = dataReader.GetString(32);
                //}
                //else txtEESigned.Text = "";
                //if (!dataReader.IsDBNull(27))
                //{
                //    txtSupFin.Text = dataReader.GetString(27);
                //}
                //else txtSupFin.Text = "";
                //if (!dataReader.IsDBNull(34))
                //{
                //    txtSupSigned.Text = dataReader.GetString(34);
                //}
                //else txtSupSigned.Text = "";
                //if (!dataReader.IsDBNull(28))
                //{
                //    txtHRCSigned.Text = dataReader.GetString(28);
                //}
                //else txtHRCSigned.Text = "";
                //if (!dataReader.IsDBNull(30))
                //{
                //    txtHRMSigned.Text = dataReader.GetString(30);
                //}
                //else txtHRMSigned.Text = "";

                //if (!dataReader.IsDBNull(12))
                //{
                //    txtEEAckDate.Text = dataReader.GetDateTime(12).ToString();
                //}
                //else txtEEAckDate.Text = "";
                //if (!dataReader.IsDBNull(33))
                //{
                //    txtEEDate.Text = dataReader.GetDateTime(33).ToString();
                //}
                //else txtEEDate.Text = "";
                //if (!dataReader.IsDBNull(14))
                //{
                //    txtSupFinDate.Text = dataReader.GetDateTime(14).ToString();
                //}
                //else txtSupFinDate.Text = "";
                //if (!dataReader.IsDBNull(35))
                //{
                //    txtSupDate.Text = dataReader.GetDateTime(35).ToString();
                //}
                //else txtSupDate.Text = "";
                //if (!dataReader.IsDBNull(29))
                //{
                //    txtHRCDate.Text = dataReader.GetDateTime(29).ToString();
                //}
                //else txtHRCDate.Text = "";
                if (!dataReader.IsDBNull(22))
                {
                    txtSupervisor.Text = dataReader.GetString(22);
                }
                else txtSupervisor.Text = "";
            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

            //String columns = "{0, -55}{1, -35}";
            using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, "LEW - HRIS"))
                {
                    if (group == null)
                    {
                        //MessageBox.Show("Group does not exist");
                    }
                    else
                    {
                        var users = group.GetMembers(true);
                        foreach (UserPrincipal user in users)
                        {
                            //ListBox1.Items.Add(String.Format(columns, user.Name.ToString(), user.EmailAddress.ToString()));
                            ListBox1.Items.Add(user.EmailAddress.ToString());
                            //ListBox1.Items.AddRange(new object[] { user.EmailAddress.ToString(), user.Name.ToString() });
                        }
                    }
                    
                }
            }
        }

        protected void btnAck_Click(object sender, EventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [HR_Status] = 'HR Received', [Date_HR_Received] = '" + System.DateTime.Now.ToString() + "'" +
                " WHERE [Counseling_ID] = "
                + txtCounselingID.Text + "", cnn);

            cnn.Open();
            command.ExecuteNonQuery();
            MessageBox.ShowMessage("Counseling Record successfully received.", this.Page);
            cnn.Close();
            //MessageBox.ShowMessage(newStatus, this.Page);
            Response.Redirect("~/HumanResources/HRDash", false);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [HR_Status] = 'HR Complete', [Processing_HR_Clerk] = '" + id2.GetLogin() + 
                "', [Date_HR_Finalized] = '" + System.DateTime.Now.ToString() + "' WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);

            cnn.Open();
            command.ExecuteNonQuery();
            MessageBox.ShowMessage("Counseling Record successfully received.", this.Page);
            cnn.Close();
            //MessageBox.ShowMessage(newStatus, this.Page);
            Response.Redirect("~/HumanResources/HRDash", false);
        }

        
        protected void txtSupComments_TextChanged(object sender, EventArgs e)
        {
            udpateSupComments = txtSupComments.Text;
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HumanResources/HRDash", false);
        }

        //protected void DropDownList1_TextChanged(object sender, EventArgs e)
        //{
        //    txtHRMEmail.Text = DropDownList1.SelectedValue;
        //}

        protected void btnInitialize_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            string currEmail = GetUserEmail(id2.GetLogin());

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [HR_Status] = 'HRM Sent', [Processing_HR_Clerk] = '" + id2.GetLogin() +
                "', [Date_HRM_Forwarded] = '" + System.DateTime.Now.ToString() +  "', [Date_HR_Finalized] = '" + System.DateTime.Now.ToString() + "' " + //[Assigned_HR_Manager] = '" + DropDownList1.SelectedItem.Text + 
                " WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            SqlCommand command2 = new SqlCommand("INSERT INTO dbo.DisciplinaryRecords SELECT * FROM dbo.CounselingReport WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            SqlCommand command3 = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [EE_Status] = 'Unavailable', [Sup_Status] = 'Unavailable' WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);

            cnn.Open();
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            //MessageBox.ShowMessage("Counseling Record successfully received.", this.Page);
            cnn.Close();

            //EMAIL NOTIFICATION
            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Corrective Action Initialized</h1></div>";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td><strong>New Corrective Action Initialized</strong></td><td></td></tr>";
            html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
            html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
            html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
            html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>To review corrective action: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/HumanResources/HRManager/HRManagerDash'>LEW HRIS CAS Human Resources Dashboard</a></td></tr>";
            html = html + "</table></div>";
            html = html + "<br /><br />";
            html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            html = html + "<br /><br />";
            html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";


            var items = new List<string>();
            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected)
                {
                    items.Add(li.Text);
                }
            }
            string ListHRM = string.Join(", ", items);

            //smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
            //System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            //newReport.To.Add("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
            newReport.To.Add(ListHRM);
            newReport.Subject = txtSubject.Text;
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);

            Response.Redirect("~/HumanResources/HRDash", false);
        }

        public void sendEmail(string hrEmail, string supEmail, string subject, string bodyMessage)
        {
            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("lewiss@leprinofoods.com", "LEW Corrective Action System");
            newReport.To.Add(hrEmail);
            newReport.To.Add(supEmail);
            newReport.Subject = subject;
            newReport.Body = bodyMessage;
            newReport.IsBodyHtml = true;

            smtpClient.Send(newReport);
        }

        public class HRISList
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //string selectedItem = "";
            //if (ListBox1.Items.Count > 0)
            //{
            //    for (int i = 0; i < ListBox1.Items.Count; i++)
            //    {
            //        if (ListBox1.Items[i].Selected)
            //        {
            //            if (selectedItem != "")
            //            {
            //                selectedItem = ListBox1.Items[i].Text;
            //                break;
            //            }
            //            else
            //            {

            //            }
            //            MessageBox.ShowMessage(selectedItem, this.Page);
            //        }

            //    }
            //}
            var items = new List<string>();
            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected)
                {
                    items.Add(li.Text);
                }
            }
            MessageBox.ShowMessage(string.Join(", ", items), this.Page);

            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                MessageBox.ShowMessage(ListBox1.Items[i].Text, this.Page);
            }
            
        }
    }
}