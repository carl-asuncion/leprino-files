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
            Context.ApplicationInstance.CompleteRequest();

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

                    if (!dataReader.IsDBNull(22))
                    {
                        txtSupervisor.Text = dataReader.GetString(22);
                    }
                    else txtSupervisor.Text = "";
                }
                dataReader.Close();
                command.Dispose();

                SqlCommand command1 = new SqlCommand("Select * from dbo.View_MainDepartment " +
                                    "WHERE [Department_Name] = '" + txtDepartment.Text + "'", cnn);
                SqlDataReader dataReader1;
                dataReader1 = command1.ExecuteReader();
                while (dataReader1.Read())
                {
                    txtAssignedGeneralist.Text = dataReader1.GetString(2);
                }
                dataReader1.Close();
                command1.Dispose();
                cnn.Close();

               
                string query = "SELECT DISTINCT [Assigned_UserName], [Assigned_Name]  FROM [View_GeneralistGrouped] " +
                    " WHERE NOT [Assigned_UserName] IS NULL ORDER BY [Assigned_UserName]";
                string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (System.Data.DataTable dt = new System.Data.DataTable())
                            {
                                sda.Fill(dt);
                                ListBox1.DataValueField = "Assigned_UserName";
                                ListBox1.DataTextField = "Assigned_Name";
                                ListBox1.DataSource = dt;
                                ListBox1.DataBind();
                            }
                            sda.Dispose();
                        }
                        cmd.Dispose();
                    }
                    con.Dispose();
                    con.Close();
                }
            }
        }

        protected void txtSupComments_TextChanged(object sender, EventArgs e)
        {
            udpateSupComments = txtSupComments.Text;
        }

        protected void btnInitialize_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            string currEmail = GetUserEmail(id2.GetLogin());

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

            //try
            //{


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
                    //if (li.Selected)
                    if (li.Selected)
                    {
                        items.Add(GetUserEmail(li.Value.Trim()));
                    }
                }
                string ListHRM = string.Join(", ", items);
                
                System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
                newReport.To.Add(ListHRM);
                newReport.Subject = "CASE New Disciplinary Action - " + txtSubject.Text;
                newReport.IsBodyHtml = true;
                newReport.Body = html;

                smtpClient.Send(newReport);


                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();

                SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = @eeStatus, [Sup_Status] = @supStatus, " +
                 "[HR_Status] = @hrStatus, [Processing_HR_Clerk] = @hrClerk, [Date_HRM_Forwarded] = @dateHRMforwarded, [Date_HR_Finalized] = @dateHRfinalized, " +
                 " [Counseling_Level] = @counselingLevel, [Actual_Level] = @actualLevel, [Counseling_Subject] = @counselingSubject, [Supervisor_Notes] = @supNotes, " +
                 "[EE_Comments] = @eeNotes, [Supervisor_FollowUp] = @supFollowUp WHERE [Counseling_ID] = @counselingID", cnn);


                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@eeStatus", "Unavailable");
                param[1] = new SqlParameter("@supStatus", "Sup Open");
                param[2] = new SqlParameter("@hrStatus", "HRM Sent");
                param[3] = new SqlParameter("@hrClerk", id2.GetLogin());
                param[4] = new SqlParameter("@dateHRMforwarded", System.DateTime.Now.ToString());
                param[5] = new SqlParameter("@dateHRfinalized", System.DateTime.Now.ToString());
                param[6] = new SqlParameter("@counselingLevel", newLevel);
                param[7] = new SqlParameter("@actualLevel", newCount);
                param[8] = new SqlParameter("@counselingSubject", txtSubject.Text.Replace("'", "''"));
                param[9] = new SqlParameter("@supNotes", txtSupComments.Text.Replace("'", "''"));
                param[10] = new SqlParameter("@eeNotes", txtEmployeeComments.Text.Replace("'", "''"));
                param[11] = new SqlParameter("@supFollowUp", txtFollowUp.Text.Replace("'", "''"));
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

                object res = command.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand("INSERT INTO dbo.DisciplinaryRecords SELECT * FROM dbo.CounselingReport WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
                SqlCommand command3 = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [EE_Status] = 'Unavailable', [Sup_Status] = 'Unavailable', [HR_Status] = 'HRM Sent'" +
                    " WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);

                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command.Dispose();
                command2.Dispose();
                command3.Dispose();
                cnn.Close();


                Response.Redirect("~/HumanResources/HRDash", false);
            
        }


        public class HRISList
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        protected void btnToGeneralist_Click(object sender, EventArgs e)
        {

        }
    }
}