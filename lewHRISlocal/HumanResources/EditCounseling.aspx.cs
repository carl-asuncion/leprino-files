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
using System.Net.Mail;
using System.Data;

namespace lewHRISlocal.HumanResources
{
    
    public static class MessageBox
    {
        public static void ShowMessage(string MessageText, Page MyPage)
        {
            MyPage.ClientScript.RegisterStartupScript(MyPage.GetType(),
                "MessageBox", "alert('" + MessageText.Replace("'", "\'") + "');", true);
        }
    }
    public partial class EditCounseling : System.Web.UI.Page
    {
        string newStatus;
        string udpateSupComments;

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

        public static string GetUserEmailwID(string userID)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + userID + ")",
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
                txtEEStatus.Text = dataReader.GetString(25);
                txtEmployeeName.Text = dataReader.GetString(4);
                txtDepartment.Text = dataReader.GetString(5);
                txtCategory.Text = dataReader.GetString(6);
                txtSubCategory.Text = dataReader.GetString(7);
                txtEmpID.Text = "" + dataReader.GetInt32(1);
                txtPosition.Text = dataReader.GetString(36);
                txtSupEmail.Text = dataReader.GetString(39);
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

                if (!dataReader.IsDBNull(13))
                {
                    txtFollowUp.Text = dataReader.GetString(13);
                }
                else txtFollowUp.Text = "";

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

            if (txtOverallStatus.Text == "Sent to HR for Review")
            {
                btnApprove.Visible= true;
                btnDismiss.Visible = true;
                //btnRevise.Visible = true;
                btnAck.Visible = false;
                btnClose.Visible = false;
                btnInitialize.Visible = false;
            }
            else if (txtOverallStatus.Text == "Sent to HR for Final Review")
            {
                btnApprove.Visible= false;
                btnDismiss.Visible = false;
                //btnRevise.Visible = false;
                btnAck.Visible = true;
                btnClose.Visible = true;
                btnInitialize.Visible = true;
            }
            else if (txtOverallStatus.Text == "Waiting for HR Decision")
            {
                btnApprove.Visible= false;
                btnDismiss.Visible = false;
                //btnRevise.Visible = false;
                btnAck.Visible = false;
                btnClose.Visible = true;
                btnInitialize.Visible = true;
            }
            else
            {
                btnApprove.Visible= false;
                btnDismiss.Visible = false;
                //btnRevise.Visible = false;
                btnAck.Visible = false;
                btnClose.Visible = false;
                btnInitialize.Visible = false;
                pagelabel.Text = "No available actions for this record.";
            }
        }

        protected void btnAck_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            string currHR = id2.GetLogin();


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

            //EMAIL NOTIFICATION
            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Counseling Report Received</h1></div>";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td><strong>Counseling Report Received</strong></td><td></td></tr>";
            html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
            html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
            html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
            html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Status: </td><td>HR Received Counseling Report - Waiting for decision</td></tr>";
            html = html + "<tr><td>Go to your dashboard: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
            html = html + "</table></div>";
            html = html + "<br /><br />";
            html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            html = html + "<br /><br />";
            html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";

            //Retrieve all other Supervisors
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(
           "SELECT EE from MasterList WHERE [EE_Subgrp] LIKE '%salaried%' AND Status = 'Active' AND [Organizational_unit_Desc] = '" + txtDepartment.Text + "'", cnn);
            cmd.CommandType = CommandType.Text;
            ListBox1.DataSource = cmd.ExecuteReader();
            ListBox1.DataTextField = "EE";
            ListBox1.DataValueField = "EE";
            ListBox1.DataBind();
            cnn.Close();

            var items = new List<string>();
            foreach (ListItem li in ListBox1.Items)
            {
                items.Add(GetUserEmailwID(li.Text));
                //if (li.Selected)
                //{
                //    items.Add(li.Text);
                //}
            }
            string ListSalaried = string.Join(", ", items);


            //smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
            //System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            newReport.To.Add(ListSalaried); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
            //newReport.To.Add("carlamae.asuncion@gmail.com");
            //newReport.Subject = txtSubject.Text;
            newReport.Subject = "HR Approved Submitted Counseling Report";
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);

            Response.Redirect("~/HumanResources/HRDash", false);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [HR_Status] = 'HR Closed', [Processing_HR_Clerk] = '" + id2.GetLogin() + 
                "', [Date_HR_Finalized] = '" + System.DateTime.Now.ToString() + "' WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);

            cnn.Open();
            command.ExecuteNonQuery();
            MessageBox.ShowMessage("Counseling Record successfully received.", this.Page);
            cnn.Close();

            //EMAIL NOTIFICATION
            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Counseling Report Closed</h1></div>";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td><strong>Counseling Report Closed</strong></td><td></td></tr>";
            html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
            html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
            html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
            html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Status: </td><td>HR Closed Counseling Report - Report added to employee record</td></tr>";
            html = html + "<tr><td>Go to your dashboard: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
            html = html + "</table></div>";
            html = html + "<br /><br />";
            html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            html = html + "<br /><br />";
            html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";



            //smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
            //System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            newReport.To.Add(txtSupEmail.Text); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
            //newReport.To.Add("carlamae.asuncion@gmail.com");
            newReport.Subject = txtSubject.Text;
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);

            Response.Redirect("~/HumanResources/HRDash", false);
        }

        
        //protected void txtSupComments_TextChanged(object sender, EventArgs e)
        //{
        //    udpateSupComments = txtSupComments.Text;
        //}
        
        protected void btnInitialize_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCounselingID.Text);
            Response.Redirect("~/HumanResources/InitializeDA.aspx?id=" + id + "", false);
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = 'EE Sent', [Sup_Status] = 'Sup Sent', [HR_Status] = 'HR Approved', " +
                "[Approved_By] = '" + id2.GetLogin() + "', [Date_Approved] = '" + System.DateTime.Now.ToString() + "'" +
                " WHERE [Counseling_ID] = "
                + txtCounselingID.Text + "", cnn);

            cnn.Open();
            command.ExecuteNonQuery();
            MessageBox.ShowMessage("Counseling Record successfully received.", this.Page);
            cnn.Close();

            //EMAIL NOTIFICATION
            string siteLink = "http://bit.ly/LEWHRISLocal";
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "LEW Database Coordinator");

            ////MessageBox.Show(newStatus);
            //Response.Redirect("~/Supervisors/SupervisorDash", false);
            ////MessageBox.Show(currEmail + " | " + currUsername + " | " + txtDateToday.Text + " | " + DateTime.Today.ToString("yyyy-MM-dd") + " | " + txtEmpID.Text + " | " + txtDepartment.Text + " | " + myCategory.SelectedItem.Text + " | " + mySubcategory.SelectedItem.Text + " | " + txtSubject.Text + " | " + txtLevel.Text + " | " + txtNotes.Text + " | " + actValue);
            //SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Counseling Report Approved</h1></div>";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td><strong>Counseling Report Approved</strong></td><td></td></tr>";
            html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
            html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
            html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
            html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Status: </td><td>HR Approved Counseling Report - Counseling Report was approved.<br />Proceed to one-on-one with employee</td></tr>";
            html = html + "<tr><td>Go to your dashboard: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
            html = html + "</table></div>";
            html = html + "<br /><br />";
            html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            html = html + "<br /><br />";
            html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";



            //smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
            //System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            newReport.To.Add(txtSupEmail.Text); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
            //newReport.To.Add("carlamae.asuncion@gmail.com");
            newReport.Subject = txtSubject.Text;
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);


            Response.Redirect("~/HumanResources/HRDash", false);
        }

        //protected void btnRevise_Click(object sender, EventArgs e)
        //{
        //    IIdentity id2 = HttpContext.Current.User.Identity;

        //    string myConnection;
        //    SqlConnection cnn;
        //    myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
        //    cnn = new SqlConnection(myConnection);

        //    SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = 'EE Sent', [Sup_Status] = 'Sup Sent', [HR_Status] = 'HR Approved', " +
        //        "[Approved_By] = " + id2.GetLogin() + " [Date_Approved] = '" + System.DateTime.Now.ToString() + "'" +
        //        " WHERE [Counseling_ID] = "
        //        + txtCounselingID.Text + "", cnn);

        //    cnn.Open();
        //    command.ExecuteNonQuery();
        //    MessageBox.ShowMessage("Counseling Record successfully received.", this.Page);
        //    cnn.Close();
        //    //MessageBox.ShowMessage(newStatus, this.Page);
        //    Response.Redirect("~/HumanResources/HRDash", false);
        //}

        protected void btnDismiss_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = 'Unavailable', [Sup_Status] = 'Sup Open', [HR_Status] = 'HR Dismissed', " +
                "[Date_Voided] = '" + System.DateTime.Now.ToString() + "'" +
                " WHERE [Counseling_ID] = "
                + txtCounselingID.Text + "", cnn);
            command.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("INSERT INTO [VoidedCounseling] SELECT * FROM [CounselingReport] WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            command2.ExecuteNonQuery();

            SqlCommand command3 = new SqlCommand("DELETE FROM [CounselingReport] WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            command3.ExecuteNonQuery();

            SqlCommand command4 = new SqlCommand("UPDATE [VoidedCounseling] SET [Date_Voided] = '" + System.DateTime.Now.ToString() + "' WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            command4.ExecuteNonQuery();

            command.Dispose();
            command2.Dispose();
            command3.Dispose();
            command4.Dispose();
            cnn.Close();

            MessageBox.ShowMessage("Counseling Record successfully received.", this.Page);

            //EMAIL NOTIFICATION
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "LEW Database Coordinator");

            ////MessageBox.Show(newStatus);
            //Response.Redirect("~/Supervisors/SupervisorDash", false);
            ////MessageBox.Show(currEmail + " | " + currUsername + " | " + txtDateToday.Text + " | " + DateTime.Today.ToString("yyyy-MM-dd") + " | " + txtEmpID.Text + " | " + txtDepartment.Text + " | " + myCategory.SelectedItem.Text + " | " + mySubcategory.SelectedItem.Text + " | " + txtSubject.Text + " | " + txtLevel.Text + " | " + txtNotes.Text + " | " + actValue);
            //SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Counseling Report Voided</h1></div>";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td><strong>Counseling Report Voided</strong></td><td></td></tr>";
            html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
            html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
            html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
            html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Status: </td><td>HR Voided Counseling Report - Contact HR for more details</td></tr>";
            html = html + "<tr><td>Go to your dashboard: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
            html = html + "</table></div>";
            html = html + "<br /><br />";
            html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            html = html + "<br /><br />";
            html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";



            //smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
            //System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            newReport.To.Add(txtSupEmail.Text); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
            //newReport.To.Add("carlamae.asuncion@gmail.com");
            newReport.Subject = txtSubject.Text;
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);
            //MessageBox.ShowMessage(newStatus, this.Page);
            Response.Redirect("~/HumanResources/HRDash", false);

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
    }
}