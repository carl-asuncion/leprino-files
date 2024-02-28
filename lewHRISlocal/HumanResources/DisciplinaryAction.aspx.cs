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
using System.DirectoryServices.AccountManagement;
using System.Data.SqlTypes;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office.Word;
using System.Net.Mail;
using DocumentFormat.OpenXml.Office2010.Excel;
using lewHRISlocal.Supervisors;
using System.Net;
using Org.BouncyCastle.Cms;
using System.Diagnostics;
using System.Web.Mail;
using iTextSharp.text.pdf.parser.clipper;
using ListItem = System.Web.UI.WebControls.ListItem;
using System.DirectoryServices;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Ajax.Utilities;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System.Globalization;

namespace lewHRISlocal.HumanResources
{

    public partial class DisciplinaryAction : System.Web.UI.Page
    {
        string newStatus;
        string udpateSupComments;

        public static string GetUserEmail(string user)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(name=" + user + ")",
                    PropertiesToLoad = { "mail" },
                })
                {
                    return (string)search.FindOne().Properties["mail"][0];
                }
            }
        }

        public static string GetUserEmailwUsername(string user)           //(string domain, string userName)
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
            // Removed 12.28.23 due to SQL injection going on //Context.ApplicationInstance.CompleteRequest();

            //IIdentity id2 = HttpContext.Current.User.Identity;
            //// set up domain context
            //PrincipalContext ctx = new PrincipalContext(ContextType.Domain, id2.GetDomain());

            //// find a user
            //UserPrincipal user = UserPrincipal.FindByIdentity(ctx, id2.GetLogin());

            //// find the group in question
            //GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - HRIS");

            //if (user != null)
            //{
            //    // check if user is member of that group
            //    if (user.IsMemberOf(group))
            //    {
            //        //Button2.Visible = true;
            //        LabelAccess.Visible = false;
            //    }
            //    else
            //    {
            //        //Button2.Visible = false;
            //        LabelAccess.Text = "  No action available for user.";
            //    }
            //}

            if (!IsPostBack)
            {

                string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            SqlCommand command = new SqlCommand("Select * from dbo.View_3 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtEmpID.Text = "" + dataReader.GetInt32(1);
                txtDisciplinaryID.Text = dataReader.GetInt32(36).ToString();
                txtDateEntered.Text = dataReader.GetDateTime(2).ToString();
                txtDateIncident.Text = dataReader.GetDateTime(3).ToString();
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
                    ddLevel.SelectedItem.Text = dataReader.GetString(9);
                        currentLevel.Text = dataReader.GetString(9);
                    }
                else ddLevel.SelectedItem.Text = "";

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

                //Bottom Data
                if (!dataReader.IsDBNull(26))
                {
                    txtEEAck.Text = dataReader.GetString(26);
                }
                else txtEEAck.Text = "";
                if (!dataReader.IsDBNull(32))
                {
                    txtEESigned.Text = dataReader.GetString(32);
                }
                else txtEESigned.Text = "";
                if (!dataReader.IsDBNull(27))
                {
                    txtSupFin.Text = dataReader.GetString(27);
                }
                else txtSupFin.Text = "";
                if (!dataReader.IsDBNull(34))
                {
                    txtSupSigned.Text = dataReader.GetString(34);
                }
                else txtSupSigned.Text = "";
                if (!dataReader.IsDBNull(28))
                {
                    txtHRCSigned.Text = dataReader.GetString(28);
                }
                else txtHRCSigned.Text = "";
                if (!dataReader.IsDBNull(30))
                {
                    txtHRMSigned.Text = dataReader.GetString(30);
                }
                else txtHRMSigned.Text = "";

                if (!dataReader.IsDBNull(12))
                {
                    txtEEAckDate.Text = dataReader.GetDateTime(12).ToString();
                }
                else txtEEAckDate.Text = "";
                if (!dataReader.IsDBNull(33))
                {
                    txtEEDate.Text = dataReader.GetDateTime(33).ToString();
                }
                else txtEEDate.Text = "";
                if (!dataReader.IsDBNull(14))
                {
                    txtSupFinDate.Text = dataReader.GetDateTime(14).ToString();
                }
                else txtSupFinDate.Text = "";
                if (!dataReader.IsDBNull(35))
                {
                    txtSupDate.Text = dataReader.GetDateTime(35).ToString();
                }
                else txtSupDate.Text = "";
                if (!dataReader.IsDBNull(29))
                {
                    txtHRCDate.Text = dataReader.GetDateTime(29).ToString();
                }
                else txtHRCDate.Text = "";
                if (!dataReader.IsDBNull(31))
                {
                    txtHRMDate.Text = dataReader.GetDateTime(31).ToString();
                }
                else txtHRMDate.Text = "";
                //Disciplinary Main
                if (!dataReader.IsDBNull(37))
                {
                    txtDamageValue.Text = dataReader.GetString(37);
                }
                else txtDamageValue.Text = "";
                if (!dataReader.IsDBNull(38))
                {
                        //txtSuspensionDate.Text = dataReader.GetDateTime(38).ToString("MM/dd/yyyy");
                        txtSuspensionDate.Text = ((DateTime)dataReader.GetDateTime(38)).ToString("yyyy-MM-dd");
                }
                else txtSuspensionDate.Text = "";
                if (!dataReader.IsDBNull(39))
                {
                    //txtRTW.Text = dataReader.GetDateTime(39).ToString();
                    txtRTW.Text = ((DateTime)dataReader.GetDateTime(39)).ToString("yyyy-MM-dd");
                    }
                else txtRTW.Text = "";
                //Level 4
                    if (!dataReader.IsDBNull(54))
                    {
                        txtSuspensionDate2.Text = ((DateTime)dataReader.GetDateTime(54)).ToString("yyyy-MM-dd");
                    }
                    else txtSuspensionDate2.Text = "";
                    if (!dataReader.IsDBNull(55))
                    {
                        txtRTW2.Text = ((DateTime)dataReader.GetDateTime(55)).ToString("yyyy-MM-dd"); 
                    }
                    else txtRTW2.Text = "";

                    if (!dataReader.IsDBNull(56))
                    {
                        txtSuspensionDate3.Text = ((DateTime)dataReader.GetDateTime(56)).ToString("yyyy-MM-dd");
                    }
                    else txtSuspensionDate3.Text = "";
                    if (!dataReader.IsDBNull(57))
                    {
                        txtRTW3.Text = ((DateTime)dataReader.GetDateTime(57)).ToString("yyyy-MM-dd"); 
                    }
                    else txtRTW3.Text = "";

                if (!dataReader.IsDBNull(19))
                {
                    txtCounselingCount.Text = "" + dataReader.GetInt32(19);
                }
                else txtCounselingCount.Text = "";
                if (!dataReader.IsDBNull(22))
                {
                    txtSupervisor.Text = "" + dataReader.GetString(22);
                }
                else txtSupervisor.Text = "";

                subGroup.Text = dataReader.GetString(50);
            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
            


            //Get All Emails in a Group
            //String columns = "{0, -55}{1, -35}";
            List<string> items = new List<string>();
                using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
                {
                    using (var group = GroupPrincipal.FindByIdentity(context, "LEW - Exempt"))
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
                                //ListBox1.Items.Add(user.EmailAddress.ToString());
                                try
                                {
                                    if (user.EmailAddress.ToString() == null)
                                    {
                                        //skip
                                    }
                                    else
                                    {

                                        //ListBox1.Items.Add(user.EmailAddress.ToString());
                                        items.Add(user.Name.ToString());
                                        //names.Add(new HRISList { Name =  user.Name.ToString(), Value = user.EmailAddress.ToString() } );
                                        //ListBox1.Items.Add(String.Format(columns, user.Name.ToString(), user.EmailAddress.ToString()));
                                    }

                                }
                                catch (Exception ex)
                                {
                                    //skip?
                                }
                                finally
                                {

                                }
                            }
                        }

                    }

                }

                var sortedItems = items.OrderBy(i => i);
                foreach (var item in sortedItems)
                {
                    ListBox1.Items.Add(item);
                }
                //ListBox1.DataSource = names;
                //ListBox1.DataBind();

            }

            if (txtOverallStatus.Text == "Disciplinary Action Sent to Department" || txtOverallStatus.Text == "Waiting for Sup Acknowledgement Disciplinary" || txtOverallStatus.Text == "Waiting for EE Acknowledgement Disciplinar")
                {
                    if (Int32.Parse(txtCounselingCount.Text) >= 3)
                    {
                        Label50.Visible = true;
                        Label50.Text = "Meeting invite unavailable at this moment.";
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }
                    else
                    {
                        Label50.Visible = true;
                        Label50.Text = "No meeting invite needed.";
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }

                    btnClose.Enabled = false;
                    btnClose.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                    btnSendtoDeptwInvite.Enabled = false;
                    btnSendtoDeptwInvite.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                    pagelabel.Text = "Case is still under department review and waiting for acknowledgement.";
                }
                else if (txtOverallStatus.Text == "Initiated Disciplinary Action")
                {
                    if (Int32.Parse(txtCounselingCount.Text) >= 3)
                    {
                        Label50.Visible = false;
                        Label49.Visible = true;
                        Label46.Visible = true;
                        Label47.Visible = true;
                        Label48.Visible = true;
                        ListBox1.Visible = true;
                        txtStartDate.Visible = true;
                        txtStartTime.Visible = true;
                        txtEndDate.Visible = true;
                        txtEndTime.Visible = true;
                    }
                    else
                    {
                        Label50.Visible = true;
                        Label50.Text = "No meeting invite needed.";
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }

                    btnClose.Enabled = false;
                    btnClose.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                    btnSendtoDeptwInvite.Enabled = true;
                    pagelabel.Visible = false;
                }
                else if (txtOverallStatus.Text == "Ready to Close Disciplinary Action")
                {
                    if (Int32.Parse(txtCounselingCount.Text) >= 3)
                    {
                        Label50.Visible = true;
                        Label50.Text = "Meeting invite no longer available.";
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }
                    else
                    {
                        Label50.Visible = true;
                        Label50.Text = "Meeting invite no longer available.";
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }

                    btnClose.Enabled = true;
                    btnSendtoDeptwInvite.Enabled = false;
                    btnSendtoDeptwInvite.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                    pagelabel.Visible = false;
                }
                else if (txtOverallStatus.Text == "Disciplinary Action Closed")
                {
                    
                    if (Int32.Parse(txtCounselingCount.Text) >= 3)
                    {
                        Label50.Visible = true;
                        Label50.Text = "Meeting invite no longer available.";
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }
                    else
                    {
                        Label50.Visible = true;
                        Label50.Text = "Meeting invite no longer available.";
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }

                    btnClose.Enabled = false;
                    btnClose.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                    btnSendtoDeptwInvite.Enabled = false;
                    btnSendtoDeptwInvite.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                    pagelabel.Text = "Disciplinary action has been concluded. No further actions can be made.";
                }
                else
                {
                    if (Int32.Parse(txtCounselingCount.Text) >= 3)
                    {
                        Label50.Visible = false;
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }
                    else
                    {
                        Label50.Visible = false;
                        Label50.Text = "No meeting invite needed.";
                        Label49.Visible = false;
                        Label46.Visible = false;
                        Label47.Visible = false;
                        Label48.Visible = false;
                        ListBox1.Visible = false;
                        txtStartDate.Visible = false;
                        txtStartTime.Visible = false;
                        txtEndDate.Visible = false;
                        txtEndTime.Visible = false;
                    }

                btnClose.Enabled = false;
                btnClose.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                btnSendtoDeptwInvite.Enabled = false;
                btnSendtoDeptwInvite.CssClass = "w3-btn w3-green w3-ripple w3-round-large w3-block w3-disabled";
                pagelabel.Text = "Disciplinary action has been concluded. No further actions can be made.";
                }
            

        }



        protected void txtSupComments_TextChanged(object sender, EventArgs e)
        {
            udpateSupComments = txtSupComments.Text;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            SqlDateTime sqldatenull;
            IIdentity id2 = HttpContext.Current.User.Identity;
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            //SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [HR_Status] = 'HRM Closed', [Damage_Value] = @Damage, [Date_Suspension_1] = @DateSus, " +
            //    " [Date_RTW_1] = @DateRTW, [Date_HRM_Finalized] = '" + System.DateTime.Now.ToString() + 
            //    "' WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            //command.Parameters.Add(new SqlParameter("@Damage", System.Data.SqlDbType.NVarChar, 255));
            //command.Parameters.Add(new SqlParameter("@DateSus", System.Data.SqlDbType.NVarChar, 255));
            //command.Parameters.Add(new SqlParameter("@DateRTW", System.Data.SqlDbType.Date));
            //sqldatenull = SqlDateTime.Null;
            //command.Parameters["@Damage"].Value = txtDamageValue.Text;
            //if (txtSuspensionDate.Text == "")
            //{
            //    command.Parameters["@DateSus"].Value = sqldatenull;
            //}
            //else
            //{
            //    command.Parameters["@DateSus"].Value = DateTime.Parse(txtSuspensionDate.Text);
            //}
            //if (txtRTW.Text == "")
            //{
            //    command.Parameters["@DateRTW"].Value = sqldatenull;
            //}
            //else
            //{
            //    command.Parameters["@DateRTW"].Value = DateTime.Parse(txtRTW.Text);
            //}



            SqlCommand command2 = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [HR_Status] = 'HRM Closed', " + 
                "[Damage_Value] = @Damage, [Date_Suspension_1] = @DateSus, [Counseling_Level] = '" + ddLevel.SelectedItem.Text + "', " +
                " [Date_RTW_1] = @DateRTW, [Date_HRM_Finalized] = '" + System.DateTime.Now.ToString() +
                "', [Date_Suspension_2] = @DateSus2, [Date_RTW_2] = @DateRTW2 " +
                ", [Date_Suspension_3] = @DateSus3, [Date_RTW_3] = @DateRTW3 " +
                "WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            command2.Parameters.Add(new SqlParameter("@Damage", System.Data.SqlDbType.NVarChar, 255));
            //command2.Parameters.Add(new SqlParameter("@DateSus", System.Data.SqlDbType.NVarChar, 255));
            command2.Parameters.Add(new SqlParameter("@DateSus", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateRTW", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateSus2", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateRTW2", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateSus3", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateRTW3", System.Data.SqlDbType.Date));
            sqldatenull = SqlDateTime.Null;
            command2.Parameters["@Damage"].Value = txtDamageValue.Text;
            //Level 3
            if (txtSuspensionDate.Text == "")
            {
                command2.Parameters["@DateSus"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateSus"].Value = DateTime.Parse(txtSuspensionDate.Text);
            }
            if (txtRTW.Text == "")
            {
                command2.Parameters["@DateRTW"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateRTW"].Value = DateTime.Parse(txtRTW.Text);
            }
            //end of Level 3
            //Level 4
            if (txtSuspensionDate2.Text == "")
            {
                command2.Parameters["@DateSus2"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateSus2"].Value = DateTime.Parse(txtSuspensionDate2.Text);
            }
            if (txtRTW2.Text == "")
            {
                command2.Parameters["@DateRTW2"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateRTW2"].Value = DateTime.Parse(txtRTW2.Text);
            }
            if (txtSuspensionDate3.Text == "")
            {
                command2.Parameters["@DateSus3"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateSus3"].Value = DateTime.Parse(txtSuspensionDate3.Text);
            }
            if (txtRTW3.Text == "")
            {
                command2.Parameters["@DateRTW3"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateRTW3"].Value = DateTime.Parse(txtRTW3.Text);
            }
            //end of Level 4

            cnn.Open();
            //command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command2.Dispose();
            MessageBox.ShowMessage("Disciplinary Action successfully concluded.", this.Page);
            cnn.Close();
            //MessageBox.ShowMessage(newStatus, this.Page);

            //EMAIL NOTIFICATION
            //string siteLink = "http://bit.ly/LEWHRISLocal";
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "LEW Database Coordinator");

            ////MessageBox.Show(newStatus);
            //Response.Redirect("~/Supervisors/SupervisorDash", false);
            ////MessageBox.Show(currEmail + " | " + currUsername + " | " + txtDateToday.Text + " | " + DateTime.Today.ToString("yyyy-MM-dd") + " | " + txtEmpID.Text + " | " + txtDepartment.Text + " | " + myCategory.SelectedItem.Text + " | " + mySubcategory.SelectedItem.Text + " | " + txtSubject.Text + " | " + txtLevel.Text + " | " + txtNotes.Text + " | " + actValue);
            //SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Disciplinary Action Closed</h1></div>";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td><strong>Disciplinary Action Closed</strong></td><td></td></tr>";
            html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
            html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
            html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
            html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Status: </td><td>HR Manager concluded the reported disciplinary action.</td></tr>";
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
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
            //newReport.To.Add("casuncion@leprinofoods.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
            newReport.To.Add(GetUserEmailwUsername(txtSupFin.Text));
            newReport.Subject = txtSubject.Text;
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);


            Response.Redirect("~/HumanResources/HRDash", false);
        }

// ERROR ON LISTBOX1
        protected void btnSendtoDeptwInvite_Click(object sender, EventArgs e)
        {
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


            /* --- Validation Process --- */
            register reg = new register();
            reg.Date = txtStartDate.Text.ToString();
            reg.Time = txtStartTime.Text.ToString();
            reg.Date = txtEndDate.Text.ToString();
            reg.Time = txtEndTime.Text.ToString();



            DateTime dt; //Incident Date
            DateTime ti; //Incident Time
            DateTime.TryParse(txtStartDate.Text, out dt);
            DateTime.TryParse(txtStartTime.Text, out ti);

            DateTime dt2; //Incident Date
            DateTime ti2; //Incident Time
            DateTime.TryParse(txtEndDate.Text, out dt2);
            DateTime.TryParse(txtEndTime.Text, out ti2);

            string startDate = dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss");
            string endDate = dt2.ToString("yyyy-MM-dd") + " " + ti2.ToString("HH:mm:ss");


            SqlDateTime sqldatenull;

            IIdentity id2 = HttpContext.Current.User.Identity;

            try
            {
                List<string> items = new List<string>();

                using (var context2 = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
                {
                    using (var group = GroupPrincipal.FindByIdentity(context2, "LEW - HRIS CAS"))
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
                                //ListBox1.Items.Add(user.EmailAddress.ToString());
                                try
                                {
                                    if (user.EmailAddress.ToString() == null)
                                    {
                                        //skip
                                    }
                                    else
                                    {

                                        //ListBox1.Items.Add(user.EmailAddress.ToString());
                                        items.Add(user.EmailAddress.ToString());
                                        //names.Add(new HRISList { Name =  user.Name.ToString(), Value = user.EmailAddress.ToString() } );
                                        //ListBox1.Items.Add(String.Format(columns, user.Name.ToString(), user.EmailAddress.ToString()));
                                    }

                                }
                                catch (Exception ex)
                                {
                                    //skip?
                                }
                                finally
                                {

                                }
                            }
                        }

                    }

                }

                // IF AND ONLY IF COUNT IS MORE THAN 3
                //if (Int32.Parse(txtCounselingCount.Text) >= 3)
                if (newCount >= 3)
                {
                    int count = 0;
                    foreach (ListItem li in ListBox1.Items)
                    {
                        if (li.Selected)
                        {
                            count += 1;
                        }
                    }
                    //if (ListBox1.SelectedItems.Count() > 0)
                    if (count > 0)
                    {
                        //GET EMAILS
                        string listSupervisors;
                        //string noADEmailList;
                        var items2 = new List<string>();
                        var noademail = new List<string>();
                        foreach (ListItem li in ListBox1.Items)
                        {
                            if (li.Selected)
                            {
                                try
                                {
                                    items2.Add(GetUserEmail(li.Text));
                                }
                                catch (Exception ex)
                                {
                                    noademail.Add(li.Text);
                                }
                                finally
                                {

                                }

                            }
                        }
                        MessageBox.ShowMessage(string.Join(", ", items2), this.Page);
                        listSupervisors = string.Join(", ", items2);

                        //  ---- START OF UPDATE ON REPORT
                        string myConnection;
                        SqlConnection cnn;
                        myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                        cnn = new SqlConnection(myConnection);
                        cnn.Open();

                        SqlCommand command2 = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [EE_Status] = 'EE Sent', " + 
                            "[Sup_Status] = 'Sup Sent', [HR_Status] = 'HRM Pending Meeting', [Counseling_Level] = '" + ddLevel.SelectedItem.Text + "', " +
                            "[Damage_Value] = @Damage, [Date_Suspension_1] = @DateSus, [Date_RTW_1] = @DateRTW, [Actual_Level] = " + newCount + "," +
                            "[Date_Sent_Back_Dept] = '" + System.DateTime.Now.ToString() +
                            "', [Date_Suspension_2] = @DateSus2, [Date_RTW_2] = @DateRTW2 " +
                            ", [Date_Suspension_3] = @DateSus3, [Date_RTW_3] = @DateRTW3 " +
                            "WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
                        command2.Parameters.Add(new SqlParameter("@Damage", System.Data.SqlDbType.NVarChar, 255));
                        command2.Parameters.Add(new SqlParameter("@DateSus", System.Data.SqlDbType.NVarChar, 255));
                        command2.Parameters.Add(new SqlParameter("@DateRTW", System.Data.SqlDbType.Date));
                        command2.Parameters.Add(new SqlParameter("@DateSus2", System.Data.SqlDbType.Date));
                        command2.Parameters.Add(new SqlParameter("@DateRTW2", System.Data.SqlDbType.Date));
                        command2.Parameters.Add(new SqlParameter("@DateSus3", System.Data.SqlDbType.Date));
                        command2.Parameters.Add(new SqlParameter("@DateRTW3", System.Data.SqlDbType.Date));
                        sqldatenull = SqlDateTime.Null;
                        command2.Parameters["@Damage"].Value = txtDamageValue.Text;
                        //Level 3
                        if (txtSuspensionDate.Text == "")
                        {
                            command2.Parameters["@DateSus"].Value = sqldatenull;
                        }
                        else
                        {
                            command2.Parameters["@DateSus"].Value = DateTime.Parse(txtSuspensionDate.Text);
                        }
                        if (txtRTW.Text == "")
                        {
                            command2.Parameters["@DateRTW"].Value = sqldatenull;
                        }
                        else
                        {
                            command2.Parameters["@DateRTW"].Value = DateTime.Parse(txtRTW.Text);
                        }
                        //end of Level 3
                        //Level 4
                        if (txtSuspensionDate2.Text == "")
                        {
                            command2.Parameters["@DateSus2"].Value = sqldatenull;
                        }
                        else
                        {
                            command2.Parameters["@DateSus2"].Value = DateTime.Parse(txtSuspensionDate2.Text);
                        }
                        if (txtRTW2.Text == "")
                        {
                            command2.Parameters["@DateRTW2"].Value = sqldatenull;
                        }
                        else
                        {
                            command2.Parameters["@DateRTW2"].Value = DateTime.Parse(txtRTW2.Text);
                        }
                        if (txtSuspensionDate3.Text == "")
                        {
                            command2.Parameters["@DateSus3"].Value = sqldatenull;
                        }
                        else
                        {
                            command2.Parameters["@DateSus3"].Value = DateTime.Parse(txtSuspensionDate3.Text);
                        }
                        if (txtRTW3.Text == "")
                        {
                            command2.Parameters["@DateRTW3"].Value = sqldatenull;
                        }
                        else
                        {
                            command2.Parameters["@DateRTW3"].Value = DateTime.Parse(txtRTW3.Text);
                        }
                        //end of Level 4



                        //command.ExecuteNonQuery();
                        command2.ExecuteNonQuery();
                        command2.Dispose();
                        cnn.Close();
                        //  ---- END OF UPDATE ON REPORT


                        //EMAIL NOTIFICATION
                        string html = "<!DOCTYPE html><html><body>";
                        html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Disciplinary Action Reviewed</h1></div>";
                        html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                        html = html + "";
                        html = html + "<tr width='50px'><td><strong>Disciplinary Action Reviewed</strong></td><td></td></tr>";
                        html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
                        html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
                        html = html + "<tr><td></td><td></td></tr>";
                        html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
                        html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
                        html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
                        html = html + "<tr><td></td><td></td></tr>";
                        html = html + "<tr><td>What to do: </td><td>Meeting invite with an HR manager/generalist and employee will be sent shortly.</td></tr>";
                        html = html + "<tr><td>Status: </td><td>HR Manager reviewed report and will be contacting the parties involved soon.</td></tr>";
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
                        newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                        //newReport.To.Add("casuncion@leprinofoods.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
                        newReport.To.Add("" + string.Join(", ", items2).ToString() + "");
                        newReport.Subject = txtSubject.Text;
                        newReport.IsBodyHtml = true;
                        newReport.Body = html;

                        smtpClient.Send(newReport);



                        //MEETING INVITE
                        //string startTime1 = Convert.ToDateTime(startDate).ToString("yyyyMMddTHHmmssZ");
                        //string endTime1 = Convert.ToDateTime(endDate).ToString("yyyyMMddTHHmmssZ");
                        System.DateTime schBeginDate = Convert.ToDateTime(startDate);
                        System.DateTime schEndDate = Convert.ToDateTime(endDate);
                        schBeginDate = schBeginDate.ToUniversalTime();
                        schEndDate = schEndDate.ToUniversalTime();
                        //string startTime1 = Convert.ToDateTime(startDate).ToString("yyyyMMdd\\THHmmss\\Z");
                        //string endTime1 = Convert.ToDateTime(endDate).ToString("yyyyMMdd\\THHmmss\\Z");
                        SmtpClient sc = new SmtpClient("smtp.leprino.local");

                        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time");
                        DateTime newDateTime1 = TimeZoneInfo.ConvertTime(Convert.ToDateTime(schBeginDate), timeZoneInfo);
                        DateTime newDateTime2 = TimeZoneInfo.ConvertTime(Convert.ToDateTime(schEndDate), timeZoneInfo);

                        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                        msg.From = new MailAddress("no-reply@leprinofoods.com", "HR Meeting Invite");
                        msg.To.Add(listSupervisors);
                        msg.Subject = "Meeting Invite";
                        msg.Body = "If you received this email, you have been added to the attendees for a corrective action meeting." +
                                "Please check your email from LEW HRIS CAS Notification. If you didn't receive any email about a corrective action, please contact your local HR.";

                        StringBuilder str = new StringBuilder();
                        str.AppendLine("BEGIN:VCALENDAR");

                        //PRODID: identifier for the product that created the Calendar object
                        str.AppendLine("PRODID:-//ABC Company//Outlook MIMEDIR//EN");
                        str.AppendLine("VERSION:2.0");
                        str.AppendLine("METHOD:REQUEST");

                        //str.AppendLine("BEGIN:VTIMEZONE");
                        //str.AppendLine("TZID:America/Los_Angeles");
                        //str.AppendLine("LAST-MODIFIED:20050809T050000Z");
                        //str.AppendLine("BEGIN:STANDARD");
                        //str.AppendLine("DTSTART:19671025T020000");
                        //str.AppendLine("TZOFFSETFROM:-0700");
                        //str.AppendLine("TZOFFSETTO:-0800");
                        //str.AppendLine("TZNAME:PST");
                        //str.AppendLine("END:STANDARD");
                        //str.AppendLine("BEGIN:DAYLIGHT");
                        //str.AppendLine("DTSTART:19870405T020000");
                        //str.AppendLine("TZOFFSETFROM:-0800");
                        //str.AppendLine("TZOFFSETTO:-0700");
                        //str.AppendLine("TZNAME:PDT");
                        //str.AppendLine("END:DAYLIGHT");
                        //str.AppendLine("END:VTIMEZONE");
                        str.AppendLine("TZ:+00");
                        str.AppendLine("BEGIN:VEVENT");

                        //str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", startTime1));//TimeZoneInfo.ConvertTimeToUtc("BeginTime").ToString("yyyyMMddTHHmmssZ")));
                        //str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
                        //str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", endTime1));//TimeZoneInfo.ConvertTimeToUtc("EndTime").ToString("yyyyMMddTHHmmssZ")));
                        //str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", startTime1));//TimeZoneInfo.ConvertTimeToUtc("BeginTime").ToString("yyyyMMddTHHmmssZ")));
                        //str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
                        //str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", endTime1));//TimeZoneInfo.ConvertTimeToUtc("EndTime").ToString("yyyyMMddTHHmmssZ")));
                        str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", schBeginDate));//TimeZoneInfo.ConvertTimeToUtc("BeginTime").ToString("yyyyMMddTHHmmssZ")));
                        str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
                        str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", schEndDate));//TimeZoneInfo.ConvertTimeToUtc("EndTime").ToString("yyyyMMddTHHmmssZ")));
                        str.AppendLine(string.Format("LOCATION: {0}", "TBD"));

                        // UID should be unique.
                        str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
                        str.AppendLine(string.Format("DESCRIPTION:{0}", msg.Body));
                        str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", msg.Body));
                        str.AppendLine(string.Format("SUMMARY:{0}", msg.Subject));

                        str.AppendLine("STATUS:CONFIRMED");
                        str.AppendLine("BEGIN:VALARM");
                        str.AppendLine("TRIGGER:-PT15M");
                        str.AppendLine("ACTION:Accept");
                        str.AppendLine("DESCRIPTION:Reminder");
                        str.AppendLine("X-MICROSOFT-CDO-BUSYSTATUS:BUSY");
                        str.AppendLine("END:VALARM");
                        str.AppendLine("END:VEVENT");

                        str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", msg.From.Address));
                        str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[0].DisplayName, msg.To[0].Address));

                        str.AppendLine("END:VCALENDAR");
                        System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType("text/calendar");
                        ct.Parameters.Add("method", "REQUEST");
                        ct.Parameters.Add("name", "meeting.ics");
                        AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), ct);
                        msg.AlternateViews.Add(avCal);
                        //Response.Write(str);
                        // sc.ServicePoint.MaxIdleTime = 2;
                        sc.Send(msg);

                        if (noademail.Count > 0)
                        {
                            //EMAIL NOTIFICATION
                            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "LEW Database Coordinator");

                            ////MessageBox.Show(newStatus);
                            //Response.Redirect("~/Supervisors/SupervisorDash", false);
                            ////MessageBox.Show(currEmail + " | " + currUsername + " | " + txtDateToday.Text + " | " + DateTime.Today.ToString("yyyy-MM-dd") + " | " + txtEmpID.Text + " | " + txtDepartment.Text + " | " + myCategory.SelectedItem.Text + " | " + mySubcategory.SelectedItem.Text + " | " + txtSubject.Text + " | " + txtLevel.Text + " | " + txtNotes.Text + " | " + actValue);
                            //SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                            string htmlEx = "<!DOCTYPE html><html><body>";
                            htmlEx = htmlEx + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - No Email Address</h1></div>";
                            htmlEx = htmlEx + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                            htmlEx = htmlEx + "";
                            htmlEx = htmlEx + "<tr width='50px'><td><strong>No Email Address Found on Active Directory</strong></td><td></td></tr>";
                            htmlEx = htmlEx + "<tr><td>No email found on Active Directory for the following: </td><td>" + string.Join(", ", noademail) + "</td></tr>";
                            htmlEx = htmlEx + "<tr><td>Suggested Action/s: </td><td>Please modify meeting invite from Outloook.</td></tr>";
                            htmlEx = htmlEx + "</table></div>";
                            htmlEx = htmlEx + "<br /><br />";
                            htmlEx = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
                            htmlEx = htmlEx + "<br /><br />";
                            htmlEx = htmlEx + "<div>Thank you,<br>Leprino Foods Company | Lemoore West<br>PLC/ISS Department</div></body></html>";


                            //smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
                            //System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
                            System.Net.Mail.MailMessage newReportEx = new System.Net.Mail.MailMessage();
                            SmtpClient smtpClientEx = new SmtpClient("smtp.leprino.local");
                            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
                            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
                            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
                            newReportEx.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                            //newReportEx.To.Add("casuncion@leprinofoods.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
                            newReportEx.To.Add("" + string.Join(", ", items).ToString() + "");
                            newReportEx.Subject = txtSubject.Text;
                            newReportEx.IsBodyHtml = true;
                            newReportEx.Body = htmlEx;

                            smtpClientEx.Send(newReportEx);
                        }
                        else
                        {
                            //MessageBox.ShowMessage("No users in the list.", this.Page);
                        }


                        //MessageBox.ShowMessage(newStatus, this.Page);
                        Response.Redirect("~/HumanResources/HRDash", false);
                    }
                    else //SelectedItems.Count() = 0
                    {
                        MessageBox.ShowMessage("No selection made to send the invite to.", this.Page);
                        ListBox1.Items.Clear();

                        using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
                        {
                            using (var group = GroupPrincipal.FindByIdentity(context, "LEW - Exempt"))
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
                                        //ListBox1.Items.Add(user.EmailAddress.ToString());
                                        try
                                        {
                                            if (user.EmailAddress.ToString() == null)
                                            {
                                                //skip
                                            }
                                            else
                                            {

                                                //ListBox1.Items.Add(user.EmailAddress.ToString());
                                                items.Add(user.Name.ToString());
                                                //names.Add(new HRISList { Name =  user.Name.ToString(), Value = user.EmailAddress.ToString() } );
                                                //ListBox1.Items.Add(String.Format(columns, user.Name.ToString(), user.EmailAddress.ToString()));
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            //skip?
                                        }
                                        finally
                                        {

                                        }
                                    }
                                }

                            }

                        }

                        var sortedItems = items.OrderBy(i => i);
                        foreach (var item in sortedItems)
                        {
                            ListBox1.Items.Add(item);
                        }
                        return;
                    }
                    System.Net.Mail.MailMessage reportDB = new System.Net.Mail.MailMessage();
                    SmtpClient smtpClientDB = new SmtpClient("smtp.leprino.local");
                    //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
                    //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
                    //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
                    reportDB.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                    //newReport.To.Add("casuncion@leprinofoods.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
                    reportDB.To.Add("casuncion@leprinofoods.com");
                    reportDB.Subject = "Disciplinary Action - With Meeting";
                    //reportDB.IsBodyHtml = true;
                    reportDB.Body = "Disciplinary Action has been processed for Counseling_ID " + txtCounselingID.Text + ". Please check record integrity.";

                    smtpClientDB.Send(reportDB);
                }
                else
                {
                    //====  No Invite Needed - does not matter if ListBox1 has no selection


                    string myConnection;
                    SqlConnection cnn;
                    myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                    cnn = new SqlConnection(myConnection);

                    cnn.Open();

                    SqlCommand command2 = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [EE_Status] = 'EE Sent', " +
                                "[Sup_Status] = 'Sup Sent', [HR_Status] = 'HRM Pending', [Counseling_Level] = '" + ddLevel.SelectedItem.Text + "', " +
                                "[Damage_Value] = @Damage, [Date_Suspension_1] = @DateSus, [Date_RTW_1] = @DateRTW, [Actual_Level] = " + newCount + "," +
                                "[Date_Sent_Back_Dept] = '" + System.DateTime.Now.ToString() +
                                "', [Date_Suspension_2] = @DateSus2, [Date_RTW_2] = @DateRTW2 " +
                                ", [Date_Suspension_3] = @DateSus3, [Date_RTW_3] = @DateRTW3 " +
                                "WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
                    command2.Parameters.Add(new SqlParameter("@Damage", System.Data.SqlDbType.NVarChar, 255));
                    command2.Parameters.Add(new SqlParameter("@DateSus", System.Data.SqlDbType.NVarChar, 255));
                    command2.Parameters.Add(new SqlParameter("@DateRTW", System.Data.SqlDbType.Date));
                    command2.Parameters.Add(new SqlParameter("@DateSus2", System.Data.SqlDbType.Date));
                    command2.Parameters.Add(new SqlParameter("@DateRTW2", System.Data.SqlDbType.Date));
                    command2.Parameters.Add(new SqlParameter("@DateSus3", System.Data.SqlDbType.Date));
                    command2.Parameters.Add(new SqlParameter("@DateRTW3", System.Data.SqlDbType.Date));
                    sqldatenull = SqlDateTime.Null;
                    command2.Parameters["@Damage"].Value = txtDamageValue.Text;
                    //Level 3
                    if (txtSuspensionDate.Text == "")
                    {
                        command2.Parameters["@DateSus"].Value = sqldatenull;
                    }
                    else
                    {
                        command2.Parameters["@DateSus"].Value = DateTime.Parse(txtSuspensionDate.Text);
                    }
                    if (txtRTW.Text == "")
                    {
                        command2.Parameters["@DateRTW"].Value = sqldatenull;
                    }
                    else
                    {
                        command2.Parameters["@DateRTW"].Value = DateTime.Parse(txtRTW.Text);
                    }
                    //end of Level 3
                    //Level 4
                    if (txtSuspensionDate2.Text == "")
                    {
                        command2.Parameters["@DateSus2"].Value = sqldatenull;
                    }
                    else
                    {
                        command2.Parameters["@DateSus2"].Value = DateTime.Parse(txtSuspensionDate2.Text);
                    }
                    if (txtRTW2.Text == "")
                    {
                        command2.Parameters["@DateRTW2"].Value = sqldatenull;
                    }
                    else
                    {
                        command2.Parameters["@DateRTW2"].Value = DateTime.Parse(txtRTW2.Text);
                    }
                    if (txtSuspensionDate3.Text == "")
                    {
                        command2.Parameters["@DateSus3"].Value = sqldatenull;
                    }
                    else
                    {
                        command2.Parameters["@DateSus3"].Value = DateTime.Parse(txtSuspensionDate3.Text);
                    }
                    if (txtRTW3.Text == "")
                    {
                        command2.Parameters["@DateRTW3"].Value = sqldatenull;
                    }
                    else
                    {
                        command2.Parameters["@DateRTW3"].Value = DateTime.Parse(txtRTW3.Text);
                    }
                    //end of Level 4


                    //command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command2.Dispose();
                    cnn.Close();

                    //EMAIL NOTIFICATION
                    //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "LEW Database Coordinator");

                    ////MessageBox.Show(newStatus);
                    //Response.Redirect("~/Supervisors/SupervisorDash", false);
                    ////MessageBox.Show(currEmail + " | " + currUsername + " | " + txtDateToday.Text + " | " + DateTime.Today.ToString("yyyy-MM-dd") + " | " + txtEmpID.Text + " | " + txtDepartment.Text + " | " + myCategory.SelectedItem.Text + " | " + mySubcategory.SelectedItem.Text + " | " + txtSubject.Text + " | " + txtLevel.Text + " | " + txtNotes.Text + " | " + actValue);
                    //SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                    string html = "<!DOCTYPE html><html><body>";
                    html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - Disciplinary Action Finalized</h1></div>";
                    html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                    html = html + "";
                    html = html + "<tr width='50px'><td><strong>Disciplinary Action Reviewed</strong></td><td></td></tr>";
                    html = html + "<tr><td>Submitted by: </td><td>" + txtSupervisor.Text + "</td></tr>";
                    html = html + "<tr><td>Submitted on: </td><td>" + txtDateEntered.Text + "</td></tr>";
                    html = html + "<tr><td></td><td></td></tr>";
                    html = html + "<tr><td>Counseling ID: </td><td>" + txtCounselingID.Text + "</td></tr>";
                    html = html + "<tr><td>Incident Date/Time: </td><td>" + txtDateIncident.Text + "</td></tr>";
                    html = html + "<tr><td>Employee Name: </td><td>" + txtEmployeeName.Text+ "</td></tr>";
                    html = html + "<tr><td></td><td></td></tr>";
                    html = html + "<tr><td>What to do: </td><td>Meeting invite with an HR manager/generalist and employee will be sent shortly.</td></tr>";
                    html = html + "<tr><td>Status: </td><td>HR Manager reviewed report and will be contacting the parties involved soon.</td></tr>";
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
                    newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                    //newReport.To.Add("casuncion@leprinofoods.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
                    newReport.To.Add(GetUserEmail(txtSupervisor.Text));
                    newReport.Subject = txtSubject.Text;
                    newReport.IsBodyHtml = true;
                    newReport.Body = html;

                    smtpClient.Send(newReport);


                    System.Net.Mail.MailMessage reportDB = new System.Net.Mail.MailMessage();
                    SmtpClient smtpClientDB = new SmtpClient("smtp.leprino.local");
                    //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
                    //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
                    //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
                    reportDB.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                    //newReport.To.Add("casuncion@leprinofoods.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
                    reportDB.To.Add("casuncion@leprinofoods.com");
                    reportDB.Subject = "Disciplinary Action - No Meeting";
                    //reportDB.IsBodyHtml = true;
                    reportDB.Body = "Disciplinary Action has been processed for Counseling_ID " + txtCounselingID.Text + ". Please check record integrity.";

                    smtpClientDB.Send(reportDB);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), txtCounselingID.Text + " - Create/Submit Issue");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", 
                    "alert('We apologize. An error occured and an email was sent to the development team.'); window.location.replace('HRDash.aspx');", 
                    true); //Removed Supervisors/

            }
            finally
            {

            }
        }

        
        public class HRISList
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        protected void txtCounselingCount_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCounselingCount.Text) >= 3)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "reloadInvite();", true);
            }
            else
            {
                //Nothing
            }
            
        }

        protected void Save_Click(object sender, EventArgs e)
        {
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

            SqlDateTime sqldatenull;
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            cnn.Open();

            SqlCommand command2 = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET  " +
                        "[Counseling_Level] = '" + ddLevel.SelectedItem.Text + "', " +
                        "[Damage_Value] = @Damage, [Date_Suspension_1] = @DateSus, [Date_RTW_1] = @DateRTW, [Actual_Level] = " + newCount + "," +
                        "[Date_Sent_Back_Dept] = '" + System.DateTime.Now.ToString() +
                        "', [Date_Suspension_2] = @DateSus2, [Date_RTW_2] = @DateRTW2 " +
                        ", [Date_Suspension_3] = @DateSus3, [Date_RTW_3] = @DateRTW3 " +
                        "WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
            command2.Parameters.Add(new SqlParameter("@Damage", System.Data.SqlDbType.NVarChar, 255));
            command2.Parameters.Add(new SqlParameter("@DateSus", System.Data.SqlDbType.NVarChar, 255));
            command2.Parameters.Add(new SqlParameter("@DateRTW", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateSus2", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateRTW2", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateSus3", System.Data.SqlDbType.Date));
            command2.Parameters.Add(new SqlParameter("@DateRTW3", System.Data.SqlDbType.Date));
            sqldatenull = SqlDateTime.Null;
            command2.Parameters["@Damage"].Value = txtDamageValue.Text;
            //Level 3
            if (txtSuspensionDate.Text == "")
            {
                command2.Parameters["@DateSus"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateSus"].Value = DateTime.Parse(txtSuspensionDate.Text);
            }
            if (txtRTW.Text == "")
            {
                command2.Parameters["@DateRTW"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateRTW"].Value = DateTime.Parse(txtRTW.Text);
            }
            //end of Level 3
            //Level 4
            if (txtSuspensionDate2.Text == "")
            {
                command2.Parameters["@DateSus2"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateSus2"].Value = DateTime.Parse(txtSuspensionDate2.Text);
            }
            if (txtRTW2.Text == "")
            {
                command2.Parameters["@DateRTW2"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateRTW2"].Value = DateTime.Parse(txtRTW2.Text);
            }
            if (txtSuspensionDate3.Text == "")
            {
                command2.Parameters["@DateSus3"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateSus3"].Value = DateTime.Parse(txtSuspensionDate3.Text);
            }
            if (txtRTW3.Text == "")
            {
                command2.Parameters["@DateRTW3"].Value = sqldatenull;
            }
            else
            {
                command2.Parameters["@DateRTW3"].Value = DateTime.Parse(txtRTW3.Text);
            }
            //end of Level 4


            //command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command2.Dispose();
            cnn.Close();
        }

        protected void Withdraw_Click(object sender, EventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);

            cnn.Open();

            SqlCommand command2 = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET " +
                        "[HR_Status] = @hrStatus, [Withdrawn_Date] = @withdrawnDate, " +
                        "[Withdrawn_Status] = @withdrawnStatus " +
                        " WHERE [Counseling_ID] = @counselingID", cnn);

            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@hrStatus", "HR Withdrawn");
            param[1] = new SqlParameter("@withdrawnDate", System.DateTime.Now.ToString());
            param[2] = new SqlParameter("@withdrawnStatus", withdrawReason.SelectedItem.ToString());
            param[3] = new SqlParameter("@counselingID", txtCounselingID.Text);

            command2.Parameters.Add(param[0]);
            command2.Parameters.Add(param[1]);
            command2.Parameters.Add(param[2]);
            command2.Parameters.Add(param[3]);

            object res = command2.ExecuteNonQuery();
            
            command2.Dispose();
            cnn.Close();
        }

    }
}