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
using System.Windows.Controls;
using System.Web.Providers.Entities;
using System.Net.Mail;
using System.Net;
using Org.BouncyCastle.Cms;
using System.Diagnostics;
using System.Web.Mail;
using iTextSharp.text.pdf.parser.clipper;
using DocumentFormat.OpenXml.Office.Word;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Win32;
using DocumentFormat.OpenXml.Office2010.Excel;
//using EASendMail;

namespace lewHRISlocal.Supervisors
{
    
    public partial class Create : System.Web.UI.Page
    {

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

        public static string GetUserEmailEmployee(string empName)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + empName + ")",
                    PropertiesToLoad = { "mail" },
                })
                {
                    return (string)search.FindOne().Properties["mail"][0];
                }
            }
        }

        public static string GetUserNameEmployee(string empName)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + empName + ")",
                    PropertiesToLoad = { "name" },
                })
                {
                    return (string)search.FindOne().Properties["name"][0];
                }
            }
        }

        public static string GetUserDepartmentEmployee(string empName)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + empName + ")",
                    PropertiesToLoad = { "department" },
                })
                {
                    return (string)search.FindOne().Properties["department"][0];
                }
            }
        }

        public string currentID;

        [Obsolete]
        protected void Page_Load(object sender, EventArgs e)
        {
            timedateAck.Text = "Submitting on " + System.DateTime.Now.ToString();

            IIdentity id = HttpContext.Current.User.Identity;
            string currUser = id.GetLogin();
            if (!IsPostBack)
            {
                
                try
                {
                    //TextBox1.Text =  id.GetLogin();
                    string currEmail = GetUserEmail(id.GetLogin());
                   
                    string currUsername = GetUserFullName(id.GetDomain(), id.GetLogin());
                    txtUserEmail.Text = "Submitting as " + currUsername;

                    /*********************** Page Load Start ***********************************/
                    try
                    {
                        string myConnection;
                        SqlConnection cnn;
                        myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                        cnn = new SqlConnection(myConnection);
                        cnn.Open();
                        //Response.Write("Connection Made");

                        SqlCommand command = new SqlCommand("Select MAX([Counseling_ID]) + 1 FROM dbo.CounselingReport", cnn);
                        SqlDataReader dataReader;
                        //String Output = " ";
                        dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            currentID = "" + dataReader.GetInt32(0);
                        }
                        //Response.Write(Output);
                        dataReader.Close();
                        dataReader.Dispose();
                        command.Dispose();
                        cnn.Close();
                    }
                    catch (Exception ex2)
                    {
                        currentID = Char.ToString('1');
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.ShowMessage("No email address associated with the user.", this.Page);
                    SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                    smtpClient.Send("lewiss@leprinofoods.com", "casuncion@leprinofoods.com", "subject", "body");

                    //string myConnection;
                    //SqlConnection cnn;
                    //myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                    //cnn = new SqlConnection(myConnection);
                    //cnn.Open();
                    ////Response.Write("Connection Made");

                    //SqlCommand command = new SqlCommand("INSERT INTO ErrorLogs ([Error_Code], [Error_Description], [Username_Access], [Error_DateTime]) " +
                    //    "VALUES ('" + ex.GetType().Name + "', '" + ex.GetType().Module + "', '" + id.GetLogin() + "', '" + DateTime.Now + "')", cnn);


                    //command.ExecuteNonQuery();
                    //MessageBox.ShowMessage("Error Logged.", this.Page);
                    //cnn.Close();
                    //////MessageBox.Show(newStatus);
                       
                }
                finally
                {

                }
            }

        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            try
                {
                    string myConnection;
                    SqlConnection cnn;
                    myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                    cnn = new SqlConnection(myConnection);
                    cnn.Open();
                //Response.Write("Connection Made");

                SqlCommand command = new SqlCommand("Select * from dbo.MasterList WHERE [EE] = " + EmpID.SelectedValue + "", cnn);
                SqlDataReader dataReader;
                String Output = " ";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    txtDepartment.Text = dataReader.GetString(6);
                    //txtEmpEmail.Text = dataReader.GetString(13);
                }
                Response.Write(Output);
                dataReader.Close();
                dataReader.Dispose();

                ////SqlCommand cmd = new SqlCommand("SELECT Counseling_ID, Counseling_Subject FROM dbo.View_1 WHERE [EE_ID] = " + txtEmpID.Text + " AND [Sup_Status] <> 'Sup Closed' AND Reference_ID = Counseling_ID", cnn);
                //SqlCommand cmd = new SqlCommand("SELECT Counseling_ID, Counseling_Subject FROM dbo.View_1 WHERE [EE_ID] = " + EmpID.SelectedValue + " AND [Sup_Status] <> 'Sup Closed' AND Reference_ID = Counseling_ID ", cnn);
                //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds);


                //    myReference.DataSource = ds;
                //    myReference.DataBind();
                //    myReference.DataTextField =  "Counseling_Subject";
                //    myReference.DataValueField = "Counseling_ID";
                //    myReference.DataBind();

                //    myReference.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, ""));
                //    myReference.SelectedIndex= 0;

                //    cnn.Close();

                //SqlCommand cmd = new SqlCommand("SELECT Counseling_ID, Counseling_Subject FROM dbo.View_1 WHERE [EE_ID] = " + txtEmpID.Text + " AND [Sup_Status] <> 'Sup Closed' AND Reference_ID = Counseling_ID", cnn);
                SqlCommand cmd = new SqlCommand("SELECT Counseling_ID, CaseName FROM dbo.View_1 WHERE [EE_ID] = " + EmpID.SelectedValue + " AND [Sup_Status] <> 'Sup Closed' AND Reference_ID = Counseling_ID ", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                myReference.DataSource = ds;
                myReference.DataBind();
                myReference.DataTextField =  "CaseName";
                myReference.DataValueField = "Counseling_ID";
                myReference.DataBind();

                myReference.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, ""));
                myReference.SelectedIndex= 0;

                cnn.Close();

                //txtEmpName.Text = GetUserNameEmployee(txtEmpID.Text);
                txtEmpName.Text = GetUserNameEmployee(EmpID.SelectedValue);
                //txtDepartment.Text = GetUserDepartmentEmployee(txtEmpID.Text);
                //txtDepartment.Text = GetUserDepartmentEmployee(EmpID.SelectedValue);
                //txtEmpEmail.Text = GetUserEmailEmployee(txtEmpID.Text);
                txtEmpEmail.Text = GetUserEmailEmployee(EmpID.SelectedValue);
                }
                catch (Exception ex)
                {
                    MessageBox.ShowMessage("Please check the Employee ID entered.", this.Page);
                    SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                    smtpClient.Send("no-reply@leprinofoods.com", "casuncion@leprinofoods.com", "Invalid Employee ID", "Invalid employee ID was entered.");
                }
                finally
                {
                    
                }
            
            

        }

        protected void CategoryList_TextChanged(object sender, EventArgs e)
        {   
            if (myReference.Text == "" || IsNullOrEmpty(myReference.Text))
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT SubCategory, Level, Sub_Category FROM SubCategory WHERE Category = '" + myCategory.SelectedItem.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                mySubcategory.DataSource = ds;
                mySubcategory.DataBind();
                mySubcategory.DataTextField = "SubCategory";
                mySubcategory.DataValueField = "SubCategory";
                mySubcategory.DataBind();

                
                cmd.Dispose();
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT [Counseling_SubCategory] FROM View_1 WHERE [Counseling_ID] = " + myReference.SelectedValue + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dataReader;
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    mySubcategory.DataTextField =  dataReader.GetString(0);
                    mySubcategory.DataBind();
                }

                dataReader.Close();
                dataReader.Dispose();
                cmd.Dispose();
                con.Close();

            }
            
            //txtNotes.Text = SubCategoryList.SelectedValue;
        }

        protected void SubCategoryList_TextChanged(object sender, EventArgs e)
        {
            if (myReference.Text == "" || IsNullOrEmpty(myReference.Text))
            {
                //MessageBox.ShowMessage("GOES HERE Selection " + mySubcategory.SelectedItem.Text, this.Page); //returning null, thus the error
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT Level FROM SubCategory WHERE [SubCategory] = '" + mySubcategory.SelectedItem.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dataReader;
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        txtLevel.Text = dataReader.GetString(0);
                    }
                    else txtLevel.Text = "";
                }
                dataReader.Close();
                dataReader.Dispose();
                cmd.Dispose();
                con.Close();

            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT Level FROM SubCategory WHERE [SubCategory] = '" + mySubcategory.SelectedItem.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dataReader;
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    txtLevel.Text = dataReader.GetString(0);
                    //MessageBox.ShowMessage(dataReader.GetString(0), this.Page);
                }
                dataReader.Close();
                dataReader.Dispose();
                cmd.Dispose();
                con.Close();
                MessageBox.ShowMessage("ERROR APPARENTLY", this.Page);
            }

            

        }

// ---- SUBMIT COUNSELING FORM
        protected void btnSubmitForm_Click(object sender, EventArgs e)
        {
            /* --- Validation Process --- */
            register reg = new register();
            reg.Date = txtDateToday.Text.ToString();
            reg.Time = txtTime.Text.ToString();
            reg.EmpName = txtEmpName.Text.ToString();

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(reg, serviceProvider: null, items: null);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            //var isValid = new System.ComponentModel.DataAnnotations.Validator.TryValidateObject(reg, context, results);
            //bool isValid = new System.ComponentModel.DataAnnotations.Validator.


            if (!Validator.TryValidateObject(reg, context, results, true))
            {
                foreach (var validationResult in results)
                {
                    Response.Write(validationResult.ErrorMessage.ToString());
                }

                return;
            }

            DateTime dt; //Incident Date
            DateTime ti; //Incident Time
            DateTime.TryParse(txtDateToday.Text, out dt);
            DateTime.TryParse(txtTime.Text, out ti);

            ///* Get the selection for Reference ID - if null, use the new Counseling_ID */
            IIdentity id = HttpContext.Current.User.Identity;
            string actValue;
            string currEmail = GetUserEmail(id.GetLogin());
            string currUsername = id.GetLogin();
            string currName = GetUserFullName(id.GetDomain(), id.GetLogin());

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            
                
             

            //MessageBox.ShowMessage("My reference ID = " + myReference.Text + ".", this.Page);

            
            
            SqlCommand command = new SqlCommand("INSERT INTO dbo.CounselingReport (" +
                    "[Supervisor_ID], " +
                    "[Supervisor_Username], " +
                    "[Date_Incident], " +
                    "[Date_Entered], " +
                    "[EE_ID], " +
                    "[Department_Unit], " +
                    "[Counseling_Category], " +
                    "[Counseling_SubCategory], " +
                    "[Counseling_Subject], " +
                    "[Counseling_Level], " +
                    "[Supervisor_Notes], " +
                    "[EE_Status], " +
                    "[Sup_Status], " +
                    "[HR_Status], " +
                    "[Supervisor_Name] )  " +
                    "VALUES ( " +
                    "'" + currEmail + "', '" + currUsername +"', '" + dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss") + "', '" + System.DateTime.Now.ToString() + "', " + EmpID.SelectedValue +
                    ", '" + txtDepartment.Text + "', '" + myCategory.SelectedItem.Text + "', '" + mySubcategory.SelectedItem.Text +
                    "', '" + txtSubject.Text + "', '" + txtLevel.Text + "', '" + txtNotes.Text.Replace("'", "''") + "', 'Unavailable', 'Sup Open', 'HR Sent', '" + currName + "')", cnn); 


            command.ExecuteNonQuery();
            //MessageBox.ShowMessage("Counseling Record added successfully.", this.Page);

            if (myReference.Text == "")
            {
                SqlCommand command1 = new SqlCommand("UPDATE dbo.CounselingReport SET [Reference_ID] = (SELECT MAX([Counseling_ID]) FROM dbo.CounselingReport) WHERE [Counseling_ID] = (SELECT MAX([Counseling_ID]) FROM dbo.CounselingReport)", cnn);
                command1.ExecuteNonQuery();
                command1.Dispose();
            }
            else //Something is selected
            {
                SqlCommand command1 = new SqlCommand("UPDATE dbo.CounselingReport SET [Reference_ID] = '" + myReference.SelectedValue + "' WHERE [Counseling_ID] = (SELECT MAX([Counseling_ID]) FROM dbo.CounselingReport)", cnn);
                command1.ExecuteNonQuery();
                command1.Dispose();
            }



            

            cnn.Close();
            List<string> items = new List<string>();

            using (var context2 = new PrincipalContext(ContextType.Domain, id.GetDomain()))
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
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(string.Join(', ', items)); ", true); //window.location.replace('Supervisors/SupervisorDash');

            //EMAIL NOTIFICATION to HR
            string html = "<!DOCTYPE html><html><body>";
            html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Counseling Report for Approval</h1></div>";
            html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html = html + "";
            html = html + "<tr width='50px'><td><strong>New Counseling Report for Approval</strong></td><td></td></tr>";
            html = html + "<tr><td>Submitted for Approval by: </td><td>" + currName + "</td></tr>";
            html = html + "<tr><td>Submitted on: </td><td>" + System.DateTime.Now.ToString() + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
            html = html + "<tr><td>Incident Date/Time: </td><td>" + dt.ToString("MM/dd/yyyy") + " " + ti.ToString("HH:mm:ss") + "</td></tr>";
            html = html + "<tr><td>Employee Name: </td><td>" + txtEmpName.Text + "</td></tr>";
            html = html + "<tr><td></td><td></td></tr>";
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
            newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            newReport.To.Add("" + string.Join(", ", items).ToString() + ""); //HRIS Group
            newReport.Subject = txtSubject.Text;
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);


            //EMAIL NOTIFICATION to Supervisor
            string html2 = "<!DOCTYPE html><html><body>";
            html2 = html2 + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Counseling Report Submitted for Approval</h1></div>";
            html2 = html2 + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            html2 = html2 + "";
            html2 = html2 + "<tr width='50px'><td><strong>New Counseling Report Submitted for Approval</strong></td><td></td></tr>";
            html2 = html2 + "<tr><td>Submitted for Approval by: </td><td>" + currName + "</td></tr>";
            html2 = html2 + "<tr><td>Submitted on: </td><td>" + System.DateTime.Now.ToString() + "</td></tr>";
            html2 = html2 + "<tr><td></td><td></td></tr>";
            html2 = html2 + "<tr><td>Incident Date/Time: </td><td>" + dt.ToString("MM/dd/yyyy") + " " + ti.ToString("HH:mm:ss") + "</td></tr>";
            html2 = html2 + "<tr><td>Employee Name: </td><td>" + txtEmpName.Text + "</td></tr>";
            html2 = html2 + "<tr><td></td><td></td></tr>";
            html2 = html2 + "<tr><td></td><td></td></tr>";
            html2 = html2 + "<tr><td>To review report: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
            html2 = html2 + "</table></div>";
            html2 = html2 + "<br /><br />";
            html2 = html2 + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            html2 = html2 + "<br /><br />";
            html2 = html2 + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";


            //smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
            //System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
            System.Net.Mail.MailMessage newReport2 = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient2 = new SmtpClient("smtp.leprino.local");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            //MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            newReport2.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            newReport2.To.Add(currEmail); //Supervisor
            newReport2.Subject = txtSubject.Text;
            newReport2.IsBodyHtml = true;
            newReport2.Body = html2;

            smtpClient2.Send(newReport2);


            myCategory.SelectedIndex = 0;
            mySubcategory.SelectedIndex = 0;
            txtLevel.Text = string.Empty;

            Response.Redirect("~/Supervisors/SupervisorDash", false);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void myReference_TextChanged(object sender, EventArgs e)
        {
            //string currSubCat;
            if (myReference.Text == "")
            {
                myCategory.SelectedIndex = 0;
                mySubcategory.SelectedIndex = 0;
                mySubcategory.Items.Clear();
                //MessageBox.ShowMessage((myReference.Text == "").ToString(), this.Page); Returns TRUE
                txtLevel.Text = "";
                myCategory.Enabled = true;
                mySubcategory.Enabled = true;
                txtLevel.Enabled = true;
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT [Counseling_Category], [Counseling_SubCategory], [Counseling_Level] FROM View_1 WHERE [Counseling_ID] = " + myReference.SelectedValue + "", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dataReader;
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    myCategory.Enabled = false;
                    mySubcategory.Enabled = false;
                    txtLevel.Enabled = false;
                    myCategory.Text = dataReader.GetString(0);
                    mySubcategory.Items.Clear();
                    mySubcategory.Items.Add(dataReader.GetString(1));
                    txtLevel.Text = dataReader.GetString(2);
                    //MessageBox.ShowMessage(dataReader.GetString(0) + " | " + dataReader.GetString(1) + " | " + dataReader.GetString(2), this.Page);

                }

                dataReader.Close();
                cmd.Dispose();
                con.Close();
            }
            

            //MessageBox.ShowMessage(myReference.SelectedValue, this.Page);
        }

        private bool IsNullOrEmpty(string text)
        {
            throw new NotImplementedException();
        }

        [System.Web.Services.WebMethod]
        //public static string GetJson(string name)
        public string VoidRecord(object sender, GridViewSelectEventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            SqlCommand command = new SqlCommand("SELECT ([First_Name] + ' ' + [Last_Name]), [EE] FROM [MasterList]", cnn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString() + " | " + dataReader.GetInt32(1).ToString();
            

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            listOfuploadedFiles.Text = "";

            int fileCount = 0;
            string subPath = "~/SupportDocs/" + txtEmpName.Text; // Your code goes here

            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));


            if (!exists)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
            }
                
            
            if (addFile.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in addFile.PostedFiles)
                {
                    fileCount++;
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath(subPath), uploadedFile.FileName));
                    listOfuploadedFiles.Text += String.Format("● {0}<br />", uploadedFile.FileName);
                }
                finalRun.Text = fileCount.ToString() + " file(s) uploaded successfully.";
            }
            countFiles.Text = fileCount.ToString();
        }
    }

    internal class register
    {
        [Required(ErrorMessage = "Please enter incident date. ")]
        [DataType(DataType.Date)]
        public string Date
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please enter incident time. ")]
        [DataType(DataType.Time)]
        public string Time
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please search for employee and click Get Info. ")]
        public string EmpName
        {
            get;
            set;
        }


        public class HRISList
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
