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
using DocumentFormat.OpenXml.Office2010.Excel;
using System.DirectoryServices.AccountManagement;

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

            if (!IsPostBack)
            {
                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();
                
                SqlCommand command = new SqlCommand("Select * from dbo.View_1 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    txtDateEntered.Text = dataReader.GetDateTime(2).ToString();
                    txtDateToday.Text = dataReader.GetDateTime(3).ToString("MM/dd/yyyy");
                    txtTime.Text = dataReader.GetDateTime(3).ToString("HH:mm tt");
                    txtEEStatus.Text = dataReader.GetString(25);
                    txtEmployeeName.Text = dataReader.GetString(4);
                    txtDepartment.Text = dataReader.GetString(5);
                    txtCategory.Text = dataReader.GetString(6);
                    txtEmpID.Text = "" + dataReader.GetInt32(1);
                    txtPosition.Text = dataReader.GetString(36);
                    txtSupEmail.Text = dataReader.GetString(39);
                    if (!dataReader.IsDBNull(8))
                    {
                        txtSubject.Text = dataReader.GetString(8);
                    }
                    else txtSubject.Text = "";

                    if (!dataReader.IsDBNull(7))
                    {
                        txtSubCategory.Text = dataReader.GetString(7);
                        currentSubCategory.Text = dataReader.GetString(7);
                        ddSubCategory.Text = dataReader.GetString(7);
                        ddSubCategory.Visible = false;
                    }
                    else txtSubCategory.Text = "";

                    if (!dataReader.IsDBNull(9))
                    {
                        ddLevel.Text = dataReader.GetString(9);
                        currentLevel.Text = dataReader.GetString(9);
                    }
                    else ddLevel.Text = "";

                    if (!dataReader.IsDBNull(10))
                    {
                        txtSupComments.Text = dataReader.GetString(10);
                    }
                    else txtSupComments.Text = "";

                    if (!dataReader.IsDBNull(21))
                    {
                        txtOverallStatus.Text = dataReader.GetString(21);
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

                    if (!dataReader.IsDBNull(22))
                    {
                        txtSupervisor.Text = dataReader.GetString(22);
                    }
                    else txtSupervisor.Text = "";

                    subGroup.Text = dataReader.GetString(46); //GROUP
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();
            }

            if (txtOverallStatus.Text == "Sent to HR for Review")
            {
                btnApprove.Enabled= true;
                btnDismiss.Enabled = true;
                btnClose.Enabled = false;
                btnClose.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnInitialize.Enabled = true;
            }
            else if (txtOverallStatus.Text == "Ready to Close")
            {
                btnApprove.Enabled= false;
                btnApprove.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnDismiss.Enabled = false;
                btnDismiss.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnClose.Enabled = true;
                btnInitialize.Enabled = true;
            }
            else if (txtOverallStatus.Text == "Waiting for HR Decision")
            {
                btnApprove.Enabled= false;
                btnApprove.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnDismiss.Enabled = false;
                btnDismiss.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnClose.Enabled = true;
                btnInitialize.Enabled = true;
            }
            else
            {
                btnApprove.Enabled= false;
                btnApprove.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnDismiss.Enabled = false;
                btnDismiss.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnClose.Enabled = false;
                btnClose.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnInitialize.Enabled = false;
                btnInitialize.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                pagelabel.Text = "No available actions for this record.";
            }

            List<string> items = new List<string>();
            using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, "LEW - HRIS " + subGroup.Text.Trim()))
                {
                    if (group == null)
                    {
                        // Skip
                    }
                    else
                    {
                        var users = group.GetMembers(true);
                        foreach (UserPrincipal user in users)
                        {
                            try
                            {
                                if (user.EmailAddress.ToString() == null)
                                {
                                    // Skip
                                }
                                else
                                {
                                    items.Add(user.EmailAddress.ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                // Skip
                            }
                            finally
                            {
                                // Skip
                            }
                        }
                        listofEmails.Text = string.Join(", ", items);
                    }
                }
            }
        }

        /*--- APPROVE ---*/
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            try
            {
                string actualSubCategory = "";

                if (!txtSubCategory.Text.Equals(currentSubCategory.Text))
                {
                    actualSubCategory = txtSubCategory.Text;
                }
                else if (txtSubCategory.Text == currentSubCategory.Text)
                {
                    actualSubCategory = currentSubCategory.Text;
                }
                else 
                {
                    actualSubCategory = ddSubCategory.SelectedValue;
                }

                string newLevel = "";
                int newCount = 0;
                if (currentLevel.Text != ddLevel.SelectedItem.Text)
                {
                    newLevel = ddLevel.SelectedItem.Text;
                    if (ddLevel.SelectedItem.Text == "Level 1") { newCount = 1; }
                    if (ddLevel.SelectedItem.Text == "Level 2") { newCount = 2; }
                    if (ddLevel.SelectedItem.Text == "Level 3") { newCount = 3; }
                    if (ddLevel.SelectedItem.Text == "Level 4") { newCount = 4; }
                    if (ddLevel.SelectedItem.Text == "Termination") { newCount = 5; }
                }
                else
                {   
                    newLevel = currentLevel.Text;
                }

                DateTime dt; //Incident Date
                DateTime ti; //Incident Time
                DateTime.TryParse(txtDateToday.Text, out dt);
                DateTime.TryParse(txtTime.Text, out ti);

                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);

                SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = @eeStatus, [Sup_Status] = @supStatus, [HR_Status] = @hrStatus, " +
                    "[Approved_By] = @approvedBy, [Date_Approved] = @approvedDate, [Processing_HR_Clerk] = @hrClerk, [Counseling_Level] = @counselingLevel, " +
                    "[Counseling_Subject] = @counselingSubject, [Supervisor_Notes] = @supNotes, [EE_Comments] = @eeNotes, [Supervisor_FollowUp] = @supFollowUp, " +
                    "[Actual_Level] = @actLevel, [Counseling_Category] = @counselingCat, [Counseling_SubCategory] = @counselingSubCat, [Date_Incident] = @incidentDate " + 
                    "WHERE [Counseling_ID] = @counselingID", cnn);

                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@eeStatus", "EE Sent");
                param[1] = new SqlParameter("@supStatus", "Sup Sent");
                param[2] = new SqlParameter("@hrStatus", "HR Approved");
                param[3] = new SqlParameter("@approvedBy", id2.GetLogin());
                param[4] = new SqlParameter("@approvedDate", System.DateTime.Now.ToString());
                param[5] = new SqlParameter("@hrClerk", id2.GetLogin());
                param[6] = new SqlParameter("@counselingLevel", newLevel);   //ddLevel.SelectedItem.Text);
                param[7] = new SqlParameter("@counselingSubject", txtSubject.Text.Replace("'", "''"));
                param[8] = new SqlParameter("@supNotes", txtSupComments.Text.Replace("'", "''"));
                param[9] = new SqlParameter("@eeNotes", txtEmployeeComments.Text.Replace("'", "''"));
                param[10] = new SqlParameter("@supFollowUp", txtFollowUp.Text.Replace("'", "''"));
                param[11] = new SqlParameter("@actLevel", newCount);
                param[12] = new SqlParameter("@counselingCat", txtCategory.SelectedItem.Text);
                param[13] = new SqlParameter("@counselingSubCat", actualSubCategory.ToString());
                param[14] = new SqlParameter("@incidentDate", dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss"));
                param[15] = new SqlParameter("@counselingID", txtCounselingID.Text);

                command.Parameters.Add(param[0]);
                command.Parameters.Add(param[1]);
                command.Parameters.Add(param[2]);
                command.Parameters.Add(param[3]);
                command.Parameters.Add(param[4]);
                command.Parameters.Add(param[5]);
                command.Parameters.Add(param[6]);
                command.Parameters.Add(param[7]);
                command.Parameters.Add(param[8]);
                command.Parameters.Add(param[9]);
                command.Parameters.Add(param[10]);
                command.Parameters.Add(param[11]);
                command.Parameters.Add(param[12]);
                command.Parameters.Add(param[13]);
                command.Parameters.Add(param[14]);
                command.Parameters.Add(param[15]);



                cnn.Open();
                object res = command.ExecuteNonQuery();

                MessageBox.ShowMessage("Counseling Record successfully received.", this.Page);
                cnn.Close();

                //EMAIL NOTIFICATION
                string html = "<!DOCTYPE html><html><body>";
                html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Counseling Report Approved</h1></div>";
                html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                html = html + "";
                html = html + "<tr width='50px'><td><strong>Counseling Report Approved</strong></td><td></td></tr>";
                html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
                html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
                html = html + "<tr><td>Incident Date/Time: </td><td>" + dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss") + "</td></tr>";
                html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>Status: </td><td>HR Approved Counseling Report - Counseling Report was approved.<br />Proceed to one-on-one with employee</td></tr>";
                html = html + "<tr><td>Go to your dashboard: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
                html = html + "</table></div>";
                html = html + "<br /><br />";
                html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
                html = html + "<br /><br />";
                html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";



                System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                newReport.To.Add(listofEmails.Text); 
                newReport.Subject = "CASE Approved - " + txtSubject.Text;
                newReport.IsBodyHtml = true;
                newReport.Body = html;

                smtpClient.Send(newReport);


                Response.Redirect("~/HumanResources/HRDash", false);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), txtCounselingID.Text + " - HR Counseling Issuance Error");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was " +
                    "sent to the development team.'); window.location.replace('HRDash.aspx');", true); //Removed Supervisors/
            }
            finally { }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            try
            {
                string actualSubCategory = "";

                if (!txtSubCategory.Text.Equals(currentSubCategory.Text))
                {
                    actualSubCategory = txtSubCategory.Text;
                }
                else if (txtSubCategory.Text == currentSubCategory.Text)
                {
                    actualSubCategory = currentSubCategory.Text;
                }
                else //if (!ddSubCategory.SelectedValue.Equals(currentSubCategory.Text))
                {
                    actualSubCategory = ddSubCategory.SelectedValue;
                }

                string newLevel = "";
                int newCount = 0;
                if (currentLevel.Text != ddLevel.SelectedItem.Text)
                {
                    newLevel = ddLevel.SelectedItem.Text;
                    if (ddLevel.SelectedItem.Text == "Level 1") { newCount = 1; }
                    if (ddLevel.SelectedItem.Text == "Level 2") { newCount = 2; }
                    if (ddLevel.SelectedItem.Text == "Level 3") { newCount = 3; }
                    if (ddLevel.SelectedItem.Text == "Level 4") { newCount = 4; }
                    if (ddLevel.SelectedItem.Text == "Termination") { newCount = 5; }
                }
                else
                {
                    newLevel = currentLevel.Text;
                }

                DateTime dt; //Incident Date
                DateTime ti; //Incident Time
                DateTime.TryParse(txtDateToday.Text, out dt);
                DateTime.TryParse(txtTime.Text, out ti);

                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);

                SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [HR_Status] = @hrStatus, " +
                    "[Processing_HR_Clerk] = @hrClerk, [Date_HR_Finalized] = @hrFinalized, [Counseling_Level] = @counselingLevel, " +
                    "[Counseling_Subject] = @counselingSubject, [Supervisor_Notes] = @supNotes, [EE_Comments] = @eeNotes, [Supervisor_FollowUp] = @supFollowUp, " +
                    "[Actual_Level] = @actLevel, [Counseling_Category] = @counselingCat, [Counseling_SubCategory] = @counselingSubCat, [Date_Incident] = @incidentDate " +
                    "WHERE [Counseling_ID] = @counselingID", cnn);

                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@hrStatus", "HR Closed");
                param[1] = new SqlParameter("@hrClerk", id2.GetLogin());
                param[2] = new SqlParameter("@hrFinalized", System.DateTime.Now.ToString());
                param[3] = new SqlParameter("@counselingLevel", newLevel);
                param[4] = new SqlParameter("@counselingSubject", txtSubject.Text.Replace("'", "''"));
                param[5] = new SqlParameter("@supNotes", txtSupComments.Text.Replace("'", "''"));
                param[6] = new SqlParameter("@eeNotes", txtEmployeeComments.Text.Replace("'", "''"));
                param[7] = new SqlParameter("@supFollowUp", txtFollowUp.Text.Replace("'", "''"));
                param[8] = new SqlParameter("@actLevel", newCount);
                param[9] = new SqlParameter("@counselingCat", txtCategory.SelectedItem.Text);
                param[10] = new SqlParameter("@counselingSubCat", actualSubCategory.ToString());
                param[11] = new SqlParameter("@incidentDate", dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss"));
                param[12] = new SqlParameter("@counselingID", txtCounselingID.Text);

                command.Parameters.Add(param[0]);
                command.Parameters.Add(param[1]);
                command.Parameters.Add(param[2]);
                command.Parameters.Add(param[3]);
                command.Parameters.Add(param[4]);
                command.Parameters.Add(param[5]);
                command.Parameters.Add(param[6]);
                command.Parameters.Add(param[7]);
                command.Parameters.Add(param[8]);
                command.Parameters.Add(param[9]);
                command.Parameters.Add(param[10]);
                command.Parameters.Add(param[11]);
                command.Parameters.Add(param[12]);


                cnn.Open();
                object res = command.ExecuteNonQuery();

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
                html = html + "<tr><td>Incident Date/Time: </td><td>" + dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss") + "</td></tr>";
                html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>Status: </td><td>HR Closed Counseling Report - Report added to employee record</td></tr>";
                html = html + "<tr><td>Go to your dashboard: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
                html = html + "</table></div>";
                html = html + "<br /><br />";
                html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
                html = html + "<br /><br />";
                html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";



                System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                newReport.To.Add(txtSupEmail.Text);
                newReport.Subject = "CASE Closed - " + txtSubject.Text;
                newReport.IsBodyHtml = true;
                newReport.Body = html;

                smtpClient.Send(newReport);

                Response.Redirect("~/HumanResources/HRDash", false);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), txtCounselingID.Text + " - HR Close Case Issue");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was " +
                    "sent to the development team.'); window.location.replace('HRDash.aspx');", true); //Removed Supervisors/
            }
            finally
            {
                // Skip
            }
        }

        protected void btnInitialize_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCounselingID.Text);
            Response.Redirect("~/HumanResources/InitializeDA.aspx?id=" + id + "", false);
        }

        
        protected void btnDismiss_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            try
            {
                string actualSubCategory = "";

                if (!txtSubCategory.Text.Equals(currentSubCategory.Text))
                {
                    actualSubCategory = txtSubCategory.Text;
                }
                else if (txtSubCategory.Text == currentSubCategory.Text)
                {
                    actualSubCategory = currentSubCategory.Text;
                }
                else
                {
                    actualSubCategory = ddSubCategory.SelectedValue;
                }

                string newLevel = "";
                int newCount = 0;
                if (currentLevel.Text != ddLevel.SelectedItem.Text)
                {
                    newLevel = ddLevel.SelectedItem.Text;
                    if (ddLevel.SelectedItem.Text == "Level 1") { newCount = 1; }
                    if (ddLevel.SelectedItem.Text == "Level 2") { newCount = 2; }
                    if (ddLevel.SelectedItem.Text == "Level 3") { newCount = 3; }
                    if (ddLevel.SelectedItem.Text == "Level 4") { newCount = 4; }
                    if (ddLevel.SelectedItem.Text == "Termination") { newCount = 5; }
                }
                else
                {
                    newLevel = currentLevel.Text;
                }

                DateTime dt; //Incident Date
                DateTime ti; //Incident Time
                DateTime.TryParse(txtDateToday.Text, out dt);
                DateTime.TryParse(txtTime.Text, out ti);

                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                
                SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = @eeStatus, [Sup_Status] = @supStatus, [HR_Status] = @hrStatus, " +
                "[Date_Voided] = @dateVoided, [Counseling_Level] = @counselingLevel, [Counseling_Subject] = @counselingSubject, " +
                "[Supervisor_Notes] = @supNotes, [EE_Comments] = @eeNotes, [Supervisor_FollowUp] = @supFollowUp, " +
                "[Actual_Level] = @actLevel, [Counseling_Category] = @counselingCat, [Counseling_SubCategory] = @counselingSubCat, " +
                "[Date_Incident] = @incidentDate WHERE [Counseling_ID] = @counselingID", cnn);


                            SqlParameter[] param = new SqlParameter[14];
                            param[0] = new SqlParameter("@eeStatus", "Unavailable");
                            param[1] = new SqlParameter("@supStatus", "Sup Open");
                            param[2] = new SqlParameter("@hrStatus", "HR Dismissed");
                            param[3] = new SqlParameter("@dateVoided", System.DateTime.Now.ToString());
                            param[4] = new SqlParameter("@counselingLevel", newLevel);
                            param[5] = new SqlParameter("@counselingSubject", txtSubject.Text.Replace("'", "''"));
                            param[6] = new SqlParameter("@supNotes", txtSupComments.Text.Replace("'", "''"));
                            param[7] = new SqlParameter("@eeNotes", txtEmployeeComments.Text.Replace("'", "''"));
                            param[8] = new SqlParameter("@supFollowUp", txtFollowUp.Text.Replace("'", "''"));
                            param[9] = new SqlParameter("@actLevel", newCount);
                            param[10] = new SqlParameter("@counselingCat", txtCategory.SelectedItem.Text);
                            param[11] = new SqlParameter("@counselingSubCat", actualSubCategory.ToString());
                            param[12] = new SqlParameter("@incidentDate", dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss"));
                            param[13] = new SqlParameter("@counselingID", txtCounselingID.Text);


                            command.Parameters.Add(param[0]);
                            command.Parameters.Add(param[1]);
                            command.Parameters.Add(param[2]);
                            command.Parameters.Add(param[3]);
                            command.Parameters.Add(param[4]);
                            command.Parameters.Add(param[5]);
                            command.Parameters.Add(param[6]);
                            command.Parameters.Add(param[7]);
                            command.Parameters.Add(param[8]);
                            command.Parameters.Add(param[9]);
                            command.Parameters.Add(param[10]);
                            command.Parameters.Add(param[11]);
                            command.Parameters.Add(param[12]);
                            command.Parameters.Add(param[13]);

                            cnn.Open();
                            object res = command.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand("INSERT INTO [VoidedCounseling] SELECT * FROM [CounselingReport] WHERE [Counseling_ID] = @counselingID", cnn);
                SqlParameter[] param2 = new SqlParameter[1];
                param2[0] = new SqlParameter("@counselingID", txtCounselingID.Text);
                command2.Parameters.Add(param2[0]);
                object res2 = command2.ExecuteNonQuery();

                SqlCommand command3 = new SqlCommand("DELETE FROM [CounselingReport] WHERE [Counseling_ID] = @counselingID", cnn);
                SqlParameter[] param3 = new SqlParameter[1];
                param3[0] = new SqlParameter("@counselingID", txtCounselingID.Text);
                command3.Parameters.Add(param3[0]);
                object res3 = command3.ExecuteNonQuery();

                SqlCommand command4 = new SqlCommand("UPDATE [VoidedCounseling] SET [Date_Voided] = @dateVoided WHERE [Counseling_ID] = @counselingID", cnn);
                SqlParameter[] param4 = new SqlParameter[2];
                param4[0] = new SqlParameter("@dateVoided", txtCounselingID.Text);
                param4[1] = new SqlParameter("@counselingID", txtCounselingID.Text);
                command4.Parameters.Add(param4[0]);
                command4.Parameters.Add(param4[1]);
                object res4 = command4.ExecuteNonQuery();

                command.Dispose();
                command2.Dispose();
                command3.Dispose();
                command4.Dispose();
                cnn.Close();

                
                //EMAIL NOTIFICATION
                
                string html = "<!DOCTYPE html><html><body>";
                html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Counseling Report Voided</h1></div>";
                html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                html = html + "";
                html = html + "<tr width='50px'><td><strong>Counseling Report Dismissed</strong></td><td></td></tr>";
                html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
                html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
                html = html + "<tr><td>Incident Date/Time: </td><td>" + dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss") + "</td></tr>";
                html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>Status: </td><td>HR Voided Counseling Report - Contact HR for more details</td></tr>";
                html = html + "<tr><td>Go to your dashboard: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
                html = html + "</table></div>";
                html = html + "<br /><br />";
                html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
                html = html + "<br /><br />";
                html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";



                System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                newReport.To.Add(listofEmails.Text);
                newReport.Subject = "CASE Dismissed - " + txtSubject.Text;
                newReport.IsBodyHtml = true;
                newReport.Body = html;

                smtpClient.Send(newReport);
                Response.Redirect("~/HumanResources/HRDash", false);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), txtCounselingID.Text + " - HR Dismissal Issue");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was " +
                    "sent to the development team.'); window.location.replace('HRDash.aspx');", true); //Removed Supervisors/
            }
            finally
            {

            }
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
            txtSubCategory.Visible = false;
            ddSubCategory.Visible = true;
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT SubCategory, Level, Sub_Category FROM SubCategory WHERE Category = '" + txtCategory.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

ddSubCategory.DataSource = ds;
            ddSubCategory.DataBind();
            ddSubCategory.DataTextField = "SubCategory";
            ddSubCategory.DataValueField = "SubCategory";
            ddSubCategory.DataBind();

            cmd.Dispose();
            con.Close();
        }

        protected void ddSubCategory_TextChanged(object sender, EventArgs e)
        {
            txtSubCategory.Text = ddSubCategory.SelectedValue;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                      "showAlert();", true);
        }

        protected void btnSendAlert_Click(object sender, EventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            
            SqlCommand command = new SqlCommand("Select * from dbo.View_Counts WHERE TRIM([Department_Group]) = TRIM('" + subGroup.Text + "')", cnn);
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                counselingCount.Text = "" + dataReader.GetInt32(1);
                disciplinaryCount.Text = "" + dataReader.GetInt32(2);
                openCasesCount.Text = "" + dataReader.GetInt32(3);
            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Dispose();
            cnn.Close();


            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>Corrective Action Alert</h1></div>";
            html = html + "<div><strong>Your team is receiving this alert as a reminder that there are open corrective action cases requiring the attention of the department supervisor.</strong></div><br />";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td></td><td></td></tr>";
            html = html + "<tr><td><strong></strong></td><td></td></tr>";
            html = html + "<tr><td>Open Counselings: </td><td>" + counselingCount.Text + "</td></tr>";
            html = html + "<tr><td>Open Disciplinary: </td><td>" + disciplinaryCount.Text + "</td></tr>";
            html = html + "<tr><td>Total Open Cases: </td><td>" + openCasesCount.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Go to the Supervisor Dashboard: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS Corrective Action System Supervisor Dashboard</a></td></tr>";
            html = html + "</table></div>";
            html = html + "<br /><br />";
            html = html + "<div>If you have questions or experience issues accessing the website, please let us know, at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            html = html + "<div>If you have questions or concerns regarding a case, please let us know, at 559-925-7393 or dlooney@leprinofoods.com.</div>";
            html = html + "<br /><br />";
            html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";



            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
            newReport.To.Add(listofEmails.Text); 
            newReport.Subject = "Open Corrective Action Cases";
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);
            Response.Redirect("~/", false);
        }

    }
}