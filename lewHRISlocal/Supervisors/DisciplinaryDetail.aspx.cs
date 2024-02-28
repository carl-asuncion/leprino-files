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
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Web.Providers.Entities;
using System.Windows.Controls;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.DirectoryServices;
using System.Net.Mail;
using System.DirectoryServices.ActiveDirectory;
using com.itextpdf.text.pdf;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace lewHRISlocal.Supervisors
{
   
    public partial class DisciplinaryDetail : System.Web.UI.Page
    {
        //string newStatus;
        string udpateSupComments;
        public string currUser;

        public static string ConvertFirstChar(string userName)
        {
            string str = userName;

            if (str.Length == 0)
                return null;
            else if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();
            else
                return char.ToUpper(str[0]) + str.Substring(1);
        }

        public static string GetUsername(string empID)           //(string domain, string userName)
        {
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
        public static string GetUserFullName(string domain, string userName)
        {

            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);



            return user.GivenName + " " + user.Surname;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            currUser = id2.GetLogin();                              //Grabs the username of the Supervisor currently handling the incident


            timedateAck.Text = "Acknowledging on " + System.DateTime.Now.ToString() + " under " +  currUser + ".";
            TextBox2.Text = "Refusing to acknowledge on " + System.DateTime.Now.ToString() + " under " +  currUser + ".";


            //Grab the Counseling ID selected from the Supervisor Dashboard
            string id = Request.QueryString["id"];
            txtCounselingID.Text = id;
            Context.ApplicationInstance.CompleteRequest();

            //Employee Section
            Label15.Visible = false;
            txtUserName.Visible = false;  
            Label16.Visible = false;
            txtPassWord.Visible = false;
            Authenticated.Visible = false;
            Label17.Visible = false;
            Label19.Visible = false;
            btnAuthenticate.Visible = false;
            btnReject.Visible = true;
            btnUpdate.Visible = false;


            if (this.IsPostBack)
            {
                txtPassWord.Attributes["value"] = txtPassWord.Text;
            }

            //Supervisor Section
            Label14.Visible = false;
            txtFollowUp.Visible = false;    
            ackstatement.Visible = false;
            timedateAck.Visible = false;
            Label20.Text = "Employee authentication needed to continue.";
            ListBox1.Visible = false;
            btnSubmit.Visible = false;
            Label18.Visible = false;
            Button2.Visible = false;


            //Populate all fields of the Disciplinary Action form
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            SqlCommand command = new SqlCommand("Select * from dbo.View_3 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtDisciplinaryID.Text = dataReader.GetInt32(36).ToString();
                txtDateEntered.Text = dataReader.GetDateTime(2).ToString();
                txtDateIncident.Text = dataReader.GetDateTime(3).ToString();
                txtEmpID.Text = "" + dataReader.GetInt32(1);
                if (!dataReader.IsDBNull(42))
                {
                    txtPosition.Text = dataReader.GetString(42);
                }
                else txtPosition.Text = "";
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


                //if (!dataReader.IsDBNull(11))
                //{
                //    txtEmployeeComments.Text = dataReader.GetString(11);
                //}
                //else txtEmployeeComments.Text = "";

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
                if (!dataReader.IsDBNull(32))
                {
                    Authenticated.Visible = false;
                    Label17.Visible = false;
                    btnReject.Visible = true;
                    btnUpdate.Visible = false;
                    Label19.Visible = true;
                    btnEmployeeSign.Visible = false;
                    txtEmployeeComments.ReadOnly = true;
                    btnReject.Visible = false;
                    
                }
                else //employee entry is null
                {
                    btnEmployeeSign.Visible = true;

                    //Supervisor Section added - 2/5/24
                    Label14.Visible = false;
                    txtFollowUp.Visible = false;
                    ackstatement.Visible = false;
                    timedateAck.Visible = false;

                    //Label20.Text = "Employee authentication needed to continue.";
                    ListBox1.Visible = false;
                    btnSubmit.Visible = false;
                    Label18.Visible = false;
                    Button2.Visible = false;
                }

                if (!dataReader.IsDBNull(34))
                {
                    //Label19.Visible = true;
                    ackstatement.Visible = false;
                    timedateAck.Visible = false;
                    btnSubmit.Visible = false;
                    Label20.Text = "Supervisor Acknowledged corrective action.";

                    txtSupComments.ReadOnly = true;
                    Label18.Visible = false;
                    ListBox1.Visible = false;
                    Button2.Visible = false;
                }
                else //supervisor entry is null
                {
                    ackstatement.Visible = true;        //corrected to true 1.24.2024 / 2.12.2024
                    timedateAck.Visible = true;
                    btnSubmit.Visible = true;
                    Label20.Visible = false;

                    Label18.Visible = false;
                    ListBox1.Visible = false;
                    Button2.Visible = false;
                }

                if (!dataReader.IsDBNull(37))
                {
                    txtDamageValue.Text = dataReader.GetString(37);
                }
                else txtDamageValue.Text = "";
                if (!dataReader.IsDBNull(38))
                {
                    txtSuspensionDate.Text = dataReader.GetDateTime(38).ToString();
                }
                else txtSuspensionDate.Text = "";
                if (!dataReader.IsDBNull(39))
                {
                    txtRTW.Text = dataReader.GetDateTime(39).ToString();
                }
                else txtRTW.Text = "";
                if (!dataReader.IsDBNull(19))
                {
                    txtCounselingCount.Text = "" + dataReader.GetInt32(19);
                }
                else txtCounselingCount.Text = "";

                if (!dataReader.IsDBNull(32))
                {
                    txtEmployeeSigned.Text = dataReader.GetString(32);
                }
                else txtEmployeeSigned.Text = "";
                if (!dataReader.IsDBNull(22))
                {
                    txtSupervisor.Text = dataReader.GetString(22);
                }
                else txtSupervisor.Text = "";

                //if (!dataReader.IsDBNull(41)) //Already sent
                //{
                //    Label18.Visible = true;
                //    ListBox1.Visible = true;
                //    Button2.Visible = true;

                //    Label20.Visible = true;
                //    Label20.Text = "Should no longer show up here.";
                //}
                //else //if still not sent to HRM then....
                //{
                //    Label18.Visible = true;
                //    ListBox1.Visible = true;
                //    Button2.Visible = true;

                //    Label20.Visible = true;
                //    Label20.Text = "Supervisor Acknowledged corrective action.";
                //}


            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();


            using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, "LEW - HRIS CAS"))
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
                            ListBox1.Items.Add(user.EmailAddress.ToString());
                        }
                    }
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            //string eeAck;

            try
            {
                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();

                SqlCommand command = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [Sup_Status] = @supStatus, [HR_Status] = @hrStatus" +
                       ", [Date_Last_Sent_HR] = @lastSentHR, [Supervisor_FollowUp] = @supervisorFollowUp, [Disciplinary_Sup_Date] = @supervisorFinalizedDate, " +
                       "[Disciplinary_Sup_Signed] = @supervisorFollowUpUser WHERE [Counseling_ID] = @counselingID", cnn);

                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@supStatus", "Sup Acknowledged");
                param[1] = new SqlParameter("@hrStatus", "HRM Final");
                param[2] = new SqlParameter("@lastSentHR", System.DateTime.Now.ToString());
                param[3] = new SqlParameter("@supervisorFollowUp", txtFollowUp.Text.Replace("'", "''"));
                param[4] = new SqlParameter("@supervisorFinalizedDate", System.DateTime.Now.ToString());
                param[5] = new SqlParameter("@supervisorFollowUpUser", id2.GetLogin());
                param[6] = new SqlParameter("@counselingID", txtCounselingID.Text);

                command.Parameters.Add(param[0]);
                command.Parameters.Add(param[1]);
                command.Parameters.Add(param[2]);
                command.Parameters.Add(param[3]);
                command.Parameters.Add(param[4]);
                command.Parameters.Add(param[5]);
                command.Parameters.Add(param[6]);

                //cnn.Open();
                object res = command.ExecuteNonQuery();

                cnn.Close();
                
                
                //EMAIL NOTIFICATION
                string html = "<!DOCTYPE html><html><body>";
                html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Acknowledged Corrective Action for Finalization</h1></div>";
                html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                html = html + "";
                html = html + "<tr width='50px'><td><strong>Acknowledged Corrective Action for Finalization</strong></td><td></td></tr>";
                html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
                html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
                html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
                html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text + "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>Status: </td><td>Employee and Supervisor have acknowledged receipt of the Corrective Action. Please review to finalize.</td></tr>";
                html = html + "<tr><td>To review report: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/HumanResources/HRDash'>LEW HRIS CAS Human Resources Dashboard</a></td></tr>";
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
                newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                //newReport.To.Add("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
                newReport.To.Add("lemoorewestperformance@leprinofoods.com"); //HRIS Group
                newReport.Subject = txtSubject.Text;
                newReport.IsBodyHtml = true;
                newReport.Body = html;

                smtpClient.Send(newReport);


                Label20.Text = "Supervisor Acknowledged corrective action.";
                //MessageBox.ShowMessage(newStatus, this.Page);
                Response.Redirect("~/Supervisors/SupervisorDash", false);
            }
            catch (Exception ex) {
                ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), "Disciplinary Detail Page Submission Issue ID " + txtCounselingID );
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was sent to the team.'); window.location.replace('Supervisors/SupervisorDash.aspx');", true);
            }
            finally
            {

            }
        }

        
        protected void txtSupComments_TextChanged(object sender, EventArgs e)
        {
            udpateSupComments = txtSupComments.Text;
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCounselingID.Text);
            Response.Redirect("~/DisciplinePrint.aspx?id=" + id + "", false);
        }

        protected void btnEmployeeSign_Click(object sender, EventArgs e)
        {
            btnEmployeeSign.Visible = false;
            Label16.Visible = true;
            txtUserName.Visible = true;
            Label15.Visible = true;
            txtPassWord.Visible = true;
            btnAuthenticate.Visible = true;

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

        protected void btnAuthenticate_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            //if (!string.IsNullOrEmpty(txtUserName.Text) || GetUsertxtUserName.Text != )
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                Authenticated.Visible= true;
                Authenticated.Text = "Employee needs to enter credentials";
                btnEmployeeSign.Visible = true;
            }
            //else if ((GetUserFullName(id2.GetDomain(), txtUserName.Text) != txtEmployeeName.Text) || (txtUserName.Text != GetUsername(txtEmpID.Text))) //User not empty but Incorrect user trying to sign
            //else if ((GetUserFullName(id2.GetDomain(), txtUserName.Text) != txtEmployeeName.Text)) //User not empty but Incorrect user trying to sign
            //{
            //    Authenticated.Visible= true;
            //    Authenticated.Text = "Incorrect Employee trying to Authenticate";
            //    btnEmployeeSign.Visible = true;

            //}
            else if ((txtUserName.Text.ToLower() != GetUsername(txtEmpID.Text).ToLower())) //User not empty but Incorrect user trying to sign
            {
                Authenticated.Visible= true;
                Authenticated.Text = "Incorrect Employee trying to Authenticate";
                btnEmployeeSign.Visible = true;

            }
            else //Correct user - but check credentials
            {
                if (AuthenticateUser(txtUserName.Text, txtPassWord.Text) || 
                    AuthenticateUser(ConvertFirstChar(txtUserName.Text), txtPassWord.Text))
                {
                    //CORRECT CREDENTIALS
                    //DialogResult = true;
                    //MessageBox.ShowMessage("Success Using the Supplied Credentials", this.Page);
                    //FormsAuthentication.RedirectFromLoginPage(uName.Text, true);
                    //FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);
                    //Authenticated.Visible = false;
                    Authenticated.Text = "Employee Authenticated";
                    Label17.Visible = true;
                    btnReject.Visible = true;
                    btnUpdate.Visible = true;
                    btnEmployeeSign.Visible = false;
                    btnAuthenticate.Visible = false;

                    btnEmployeeSign.Visible = false;
                    Label16.Visible = false;
                    txtUserName.Visible = false;
                    Label15.Visible = false;
                    txtPassWord.Visible = false;
                    btnAuthenticate.Visible = false;
                }
                else
                {
                    //INCORRECT CREDENTIALS
                    Authenticated.Visible= true;
                    Authenticated.Text = "Incorrect Credentials";
                    //Label1.Text = "Incorrect credentials";
                    MessageBox.ShowMessage("Unable to Authenticate Using the Supplied Credentials", this.Page);
                    Authenticated.Visible = false;
                    btnEmployeeSign.Visible = true;
                }
            }


        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            SqlCommand command = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [EE_Status] = @eeStatus" +
                ", [EE_Comments] = @eeNotes, [Disciplinary_EE_Signed] = @eeSigned, " +
                "[Disciplinary_EE_Date] = @eeSignedDate WHERE [Counseling_ID] = @counselingID", cnn);

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@eeStatus", "EE Reject");
            param[1] = new SqlParameter("@eeNotes", txtEmployeeComments.Text.Replace("'", "''"));
            param[2] = new SqlParameter("@eeSigned", "EE Rejected");
            param[3] = new SqlParameter("@eeSignedDate", System.DateTime.Now.ToString());
            param[4] = new SqlParameter("@counselingID", txtCounselingID.Text);

            command.Parameters.Add(param[0]);
            command.Parameters.Add(param[1]);
            command.Parameters.Add(param[2]);
            command.Parameters.Add(param[3]);
            command.Parameters.Add(param[4]);

            cnn.Open();
            object res = command.ExecuteNonQuery();

            cnn.Close();

            Authenticated.Visible = false;
            Label17.Visible = false;
            btnReject.Visible = false;
            btnUpdate.Visible = false;

            Label14.Visible = true;
            txtFollowUp.Visible = true;
            Label19.Visible = true;
            ackstatement.Visible = true;
            timedateAck.Visible = true;
            btnSubmit.Visible = true;
            Label20.Visible = false;

            txtEmployeeComments.ReadOnly = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);



            SqlCommand command = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [EE_Status] = @eeStatus" +
            ", [EE_Comments] = @eeNotes, [Disciplinary_EE_Date] = @eeSignedDate, [Disciplinary_EE_Signed] = @eeSigned " +
            "WHERE [Counseling_ID] = @counselingID", cnn);

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@eeStatus", "EE Acknowledged");
            param[1] = new SqlParameter("@eeNotes", txtEmployeeComments.Text.Replace("'", "''"));
            param[2] = new SqlParameter("@eeSigned", txtUserName.Text);
            param[3] = new SqlParameter("@eeSignedDate", System.DateTime.Now.ToString());
            param[4] = new SqlParameter("@counselingID", txtCounselingID.Text);

            command.Parameters.Add(param[0]);
            command.Parameters.Add(param[1]);
            command.Parameters.Add(param[2]);
            command.Parameters.Add(param[3]);
            command.Parameters.Add(param[4]);

            cnn.Open();
            object res = command.ExecuteNonQuery();

            cnn.Dispose();
            cnn.Close();

            Authenticated.Visible = false;
            Label17.Visible = false;
            btnReject.Visible = false;
            btnUpdate.Visible = false;

            Label14.Visible = true;
            txtFollowUp.Visible = true;
            Label19.Visible = true;
            ackstatement.Visible = true;
            timedateAck.Visible = true;
            btnSubmit.Visible = true;
            Label20.Visible = false;

            txtEmployeeComments.ReadOnly = true;
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
        public void sendEmail(string supEmail, string subject, string bodyMessage)
        {
            
            System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport.From = new MailAddress("lewiss@leprinofoods.com", "LEW Counseling System");
            //newReport.To.Add(hrEmail);
            
            newReport.To.Add(supEmail);
            newReport.Subject = subject;
            newReport.Body = bodyMessage;
            newReport.IsBodyHtml = true;

            smtpClient.Send(newReport);
        }

        public class HRISList
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string selectedItem = "";
            if (ListBox1.Items.Count > 0)
            {
                for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    if (ListBox1.Items[i].Selected)
                    {
                        if (selectedItem == "")
                        {
                            selectedItem = ListBox1.Items[i].Text;
                            break;
                        }
                    }
                }
            }
            MessageBox.ShowMessage(selectedItem, this.Page);
        }
    }
}