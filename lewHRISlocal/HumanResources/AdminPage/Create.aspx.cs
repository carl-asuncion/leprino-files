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
using com.itextpdf.text.pdf;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using Microsoft.Exchange.WebServices.Data;
using System.Data.SqlTypes;
//using EASendMail;

namespace lewHRISlocal.HumanResources.AdminPage
{
    
    public partial class Create : System.Web.UI.Page
    {

        [System.Web.Services.WebMethod]
        public static List<string> GetEmployee()
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            List<string> termsList = new List<string>();
            //Grab All Employees
            using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, "LEW - Employees"))
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
                            termsList.Add(user.Name.ToString());
                        }
                    }

                }

            }

            return termsList;

        }

        [System.Web.Services.WebMethod]
        public static List<string> GetSupervisor()
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            List<string> termsList = new List<string>();
            //Grab All Employees
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
                            termsList.Add(user.Name.ToString());
                        }
                    }

                }

            }

            return termsList;

        }


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

        public static string GetUserNameUsingID(string user)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + user + ")",
                    PropertiesToLoad = { "samaccountname" },
                })
                {
                    return (string)search.FindOne().Properties["samaccountname"][0];
                }
            }
        }

        public static string GetUserEmailUsingID(string user)           //(string domain, string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(employeeID=" + user + ")",
                    PropertiesToLoad = { "mail" },
                })
                {
                    return (string)search.FindOne().Properties["mail"][0];
                }
            }
        }

        public string currentID;

        [Obsolete]
        protected void Page_Load(object sender, EventArgs e)
        {
            timedateAck.Text = "Manually added on " + System.DateTime.Now.ToString();

            IIdentity id = HttpContext.Current.User.Identity;
            string currUser = id.GetLogin();
            if (!IsPostBack)
            {
                Label13.Visible = false;
                Label13.BackColor = System.Drawing.Color.Transparent;

                try
                {
                    //TextBox1.Text =  id.GetLogin();
                    string currEmail = GetUserEmail(id.GetLogin());

                    string currUsername = GetUserFullName(id.GetDomain(), id.GetLogin());
                    string currUserID = id.GetLogin();

                    /*********************** Page Load Start ***********************************/
                    try
                    {
                        string myConnection;
                        SqlConnection cnn;
                        myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                        cnn = new SqlConnection(myConnection);
                        cnn.Open();
                        //Response.Write("Connection Made");

                        SqlCommand command2 = new SqlCommand("DELETE FROM dbo.CounselingReport  " +
                                "WHERE [Date_Incident] IS NULL AND [Date_Entered] IS NULL", cnn);
                        command2.ExecuteNonQuery();
                        command2.Dispose();

                        SqlCommand command1 = new SqlCommand("INSERT INTO dbo.CounselingReport  " +
                                "([Supervisor_ID], [Supervisor_Username]) VALUES (" +
                                "'" + currEmail + "', '" + currUserID + "')", cnn);
                        command1.ExecuteNonQuery();
                        command1.Dispose();

                        SqlCommand command = new SqlCommand("SELECT MAX([Counseling_ID]) FROM dbo.CounselingReport " +
                            "WHERE [Supervisor_ID] = '" + currEmail + "' AND [Supervisor_Username] = '" + currUserID + "'", cnn);
                        SqlDataReader dataReader;
                        //String Output = " ";
                        dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            txtCurrentTicketID.Text = "" + dataReader.GetInt32(0);
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

                    txtUserEmail.Text = "Submitting report ID " + txtCurrentTicketID.Text + " as " + currUsername;
                }
                catch (Exception ex)
                {
                    MessageBox.ShowMessage("No email address associated with the user.", this.Page);
                    SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                    smtpClient.Send("lewiss@leprinofoods.com", "casuncion@leprinofoods.com", "subject", "body");

                       
                }
                finally
                {

                }
            }

            
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();


            //string strValue = Page.Request.Form["myInput"].ToString();
            string strValue = String.Format("{0}", Request.Form["myCountry"]);
            txtEmpName.Text = String.Format("{0}", Request.Form["myCountry"]);
            string getID = null;
            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
                {
                    using (var group = GroupPrincipal.FindByIdentity(context, "LEW - Employees"))
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
                                if (strValue ==  user.Name.ToString())
                                {
                                    //MessageBox.ShowMessage(strValue, this.Page);
                                    getID = user.EmployeeId.ToString();
                                }
                            }
                        }

                    }

                }

                txtEmpID.Text = getID;

                SqlCommand command = new SqlCommand("Select * from dbo.MasterList WHERE [EE] = " + getID + "", cnn);
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

                SqlCommand cmd = new SqlCommand("SELECT Counseling_ID, CaseName FROM dbo.View_1 WHERE [EE_ID] = " + getID + " AND [Sup_Status] <> 'Sup Closed' AND Reference_ID = Counseling_ID ", cnn);
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

                cnn.Dispose();
                cnn.Close();

                //txtEmpName.Text = GetUserNameEmployee(txtEmpID.Text);
                txtEmpName.Text = GetUserNameEmployee(getID);
                //txtDepartment.Text = GetUserDepartmentEmployee(txtEmpID.Text);
                //txtDepartment.Text = GetUserDepartmentEmployee(getID);
                txtEmpEmail.Text = GetUserEmailEmployee(getID);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            Label13.Visible = false;
            Label13.BackColor = System.Drawing.Color.Transparent;
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
                con.Dispose();
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
                con.Dispose();
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
                SqlCommand cmd = new SqlCommand("SELECT Level, Sample_Verbatim FROM SubCategory WHERE [SubCategory] = '" + mySubcategory.SelectedItem.Text + "'", con);
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
                    if (!dataReader.IsDBNull(1))
                    {
                        txtNotes.Text = dataReader.GetString(1);
                    }
                    else txtNotes.Text = "";
                }
                dataReader.Close();
                dataReader.Dispose();
                cmd.Dispose();
                con.Dispose();
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
                con.Dispose();
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
                    //Response.Write(validationResult.ErrorMessage.ToString());
                    Label13.Visible = true;
                    Label13.Text = validationResult.ErrorMessage.ToString();
                    Label13.BackColor = System.Drawing.Color.Red;
                }

                return;
            }

            DateTime dt; //Incident Date
            DateTime ti; //Incident Time
            DateTime.TryParse(txtDateToday.Text, out dt);
            DateTime.TryParse(txtTime.Text, out ti);

            ///* Get the selection for Reference ID - if null, use the new Counseling_ID */
            IIdentity id = HttpContext.Current.User.Identity;
            //string actValue;
            string currEmail = GetUserEmail(id.GetLogin());
            string currUsername = id.GetLogin();
            string currName = GetUserFullName(id.GetDomain(), id.GetLogin());

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            SqlDateTime sqldatenull;


            SqlCommand command = new SqlCommand("INSERT INTO dbo.CounselingReport (" +
                    "[Supervisor_ID] = '" + txtSupEmail.Text + "', " +
                    "[Supervisor_Username] = '" + txtSupUserName.Text +"', " +
                    "[Date_Incident] = '" + dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss") + "', " +
                    "[Date_Entered] = '" + System.DateTime.Now.ToString() + "', " +
                    "[EE_ID] = " + txtEmpID.Text + ", " +
                    "[Department_Unit] = '" + txtDepartment.Text + "', " +
                    "[Counseling_Category] = '" + myCategory.SelectedItem.Text + "', " +
                    "[Counseling_SubCategory] = '" + mySubcategory.SelectedItem.Text + "', " +
                    "[Counseling_Subject] = '" + txtSubject.Text + "', " +
                    "[Counseling_Level] = '" + txtLevel.Text + "', " +
                    "[Supervisor_Notes] = '" + txtNotes.Text.Replace("'", "''") + "', " +
                    "[EE_Comments] = '" + txtEEComments.Text.Replace("'", "''") + "', " +
                    "[Supervisor_FollowUp] = '" + txtSupFollowUp.Text.Replace("'", "''") + "', " +
                    "[EE_Status] = 'EE Acknowledged', " +
                    "[Sup_Status] = 'Sup Acknowledged', " +
                    "[HR_Status] = 'HRM Closed', " +
                    "[Damage_Value] = @Damage, " +
                    "[Date_Suspension_1] = @DateSus, " +
                    "[Date_RTW_1] = @DateRTW, " +
                    "[EE_Signed] = '" + GetUserNameUsingID(txtEmpID.Text) + "', " +
                    "[EE_Acknowledge_Date] = '" + txtEECRD.Text + "', " +
                    "[Supervisor_FollowUp_User] = '" + txtSupUserName.Text + "', " +
                    "[Supervisor_Finalized_Date] = '" + txtSupCRD.Text + "', " +
                    "[Processing_HR_Clerk] = '" + txtHRCR.Text + "', " +
                    "[Date_HR_Finalized] = '" + txtHRCRD.Text + "', " +
                    "[Disciplinary_EE_Signed] = '" + GetUserNameUsingID(txtEmpID.Text) + "', " +
                    "[Disciplinary_EE_Date] = '" + txtEECAD.Text + "', " +
                    "[Disciplinary_Sup_Signed] = '" + txtSupUserName.Text + "', " +
                    "[Disciplinary_Sup_Date] = '" + txtSupCAD.Text + "', " +
                    "[Assigned_HR_Manager] = '" + txtHRMCA.Text + "', " +
                    "[Date_HRM_Finalized] = '" + txtHRMCAD.Text + "', " +
                    "[Approved_By] = '" + id.GetLogin() + "', " +
                    "[Supervisor_Name] = '" + txtSupName.Text + "'  " +
                    "WHERE [Counseling_ID] = " + txtCurrentTicketID.Text + "", cnn);

                    command.Parameters.Add(new SqlParameter("@Damage", System.Data.SqlDbType.NVarChar, 255));
                    //command2.Parameters.Add(new SqlParameter("@DateSus", System.Data.SqlDbType.NVarChar, 255));
                    command.Parameters.Add(new SqlParameter("@DateSus", System.Data.SqlDbType.Date));
                    command.Parameters.Add(new SqlParameter("@DateRTW", System.Data.SqlDbType.Date));
                    sqldatenull = SqlDateTime.Null;
                    command.Parameters["@Damage"].Value = txtDamageValue.Text;
                    if (txtSuspensionDate.Text == "")
                    {
                        command.Parameters["@DateSus"].Value = sqldatenull;
                    }
                    else
                    {
                        command.Parameters["@DateSus"].Value = DateTime.Parse(txtSuspensionDate.Text);
                    }
                    if (txtRTW.Text == "")
                    {
                        command.Parameters["@DateRTW"].Value = sqldatenull;
                    }
                    else
                    {
                        command.Parameters["@DateRTW"].Value = DateTime.Parse(txtRTW.Text);
                    }

            command.ExecuteNonQuery();
            //MessageBox.ShowMessage("Counseling Record added successfully.", this.Page);
            command.Dispose();


            if (myReference.Text == "")
            {
                SqlCommand command1 = new SqlCommand("UPDATE dbo.CounselingReport SET [Reference_ID] = '" + txtCurrentTicketID.Text + "' WHERE [Counseling_ID] = '" + txtCurrentTicketID.Text + "'", cnn);
                command1.ExecuteNonQuery();
                command1.Dispose();
            }
            else //Something is selected
            {
                SqlCommand command1 = new SqlCommand("UPDATE dbo.CounselingReport SET [Reference_ID] = '" + myReference.SelectedValue + "' WHERE [Counseling_ID] = '" + txtCurrentTicketID.Text + "'", cnn);
                command1.ExecuteNonQuery();
                command1.Dispose();
            }

            

            SqlCommand command2 = new SqlCommand("INSERT INTO dbo.DisciplinaryRecords SELECT * FROM dbo.CounselingReport " +
                "WHERE [Counseling_ID] = " + txtCurrentTicketID.Text + "", cnn);
            command2.ExecuteNonQuery();
            //MessageBox.ShowMessage("Counseling Record added successfully.", this.Page);
            command2.Dispose();




            cnn.Dispose();
            cnn.Close();
            //List<string> items = new List<string>();

            //using (var context2 = new PrincipalContext(ContextType.Domain, id.GetDomain()))
            //{
            //    //using (var group = GroupPrincipal.FindByIdentity(context2, "LEW - HRIS CAS"))
            //    using (var group = GroupPrincipal.FindByIdentity(context2, "LEW - Email Test"))
            //    {
            //        if (group == null)
            //        {
            //            //MessageBox.Show("Group does not exist");
            //        }
            //        else
            //        {
            //            var users = group.GetMembers(true);
            //            foreach (UserPrincipal user in users)
            //            {
            //                //ListBox1.Items.Add(user.EmailAddress.ToString());
            //                try
            //                {
            //                    if (user.EmailAddress.ToString() == null)
            //                    {
            //                        //skip
            //                    }
            //                    else
            //                    {

            //                        //ListBox1.Items.Add(user.EmailAddress.ToString());
            //                        items.Add(user.EmailAddress.ToString());
            //                        //names.Add(new HRISList { Name =  user.Name.ToString(), Value = user.EmailAddress.ToString() } );
            //                        //ListBox1.Items.Add(String.Format(columns, user.Name.ToString(), user.EmailAddress.ToString()));
            //                    }

            //                }
            //                catch (Exception ex)
            //                {
            //                    //skip?
            //                }
            //                finally
            //                {

            //                }
            //            }
            //        }

            //    }

            //}
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(string.Join(', ', items)); ", true); //window.location.replace('Supervisors/SupervisorDash');

            ////EMAIL NOTIFICATION to HR
            //string html = "<!DOCTYPE html><html><body>";
            //html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Counseling Report for Approval</h1></div>";
            //html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            //html = html + "";
            //html = html + "<tr width='50px'><td><strong>New Counseling Report for Approval</strong></td><td></td></tr>";
            //html = html + "<tr><td>Submitted for Approval by: </td><td>" + currName + "</td></tr>";
            //html = html + "<tr><td>Submitted on: </td><td>" + System.DateTime.Now.ToString() + "</td></tr>";
            //html = html + "<tr><td></td><td></td></tr>";
            //html = html + "<tr><td>Incident Date/Time: </td><td>" + dt.ToString("MM/dd/yyyy") + " " + ti.ToString("HH:mm:ss") + "</td></tr>";
            //html = html + "<tr><td>Employee Name: </td><td>" + txtEmpName.Text + "</td></tr>";
            //html = html + "<tr><td></td><td></td></tr>";
            //html = html + "<tr><td>To review report: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/HumanResources/HRDash'>LEW HRIS CAS Human Resources Dashboard</a></td></tr>";
            //html = html + "</table></div>";
            //html = html + "<br /><br />";
            //html = html + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            //html = html + "<br /><br />";
            //html = html + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";


            ////smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
            ////System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
            //System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
            //SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
            ////MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            ////MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            ////MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            //newReport.To.Add("" + string.Join(", ", items).ToString() + ""); //HRIS Group
            //newReport.Subject = txtSubject.Text;
            //newReport.IsBodyHtml = true;
            //newReport.Body = html;

            //smtpClient.Send(newReport);


            ////EMAIL NOTIFICATION to Supervisor
            //string html2 = "<!DOCTYPE html><html><body>";
            //html2 = html2 + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Counseling Report Submitted for Approval</h1></div>";
            //html2 = html2 + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            //html2 = html2 + "";
            //html2 = html2 + "<tr width='50px'><td><strong>New Counseling Report Submitted for Approval</strong></td><td></td></tr>";
            //html2 = html2 + "<tr><td>Submitted for Approval by: </td><td>" + currName + "</td></tr>";
            //html2 = html2 + "<tr><td>Submitted on: </td><td>" + System.DateTime.Now.ToString() + "</td></tr>";
            //html2 = html2 + "<tr><td></td><td></td></tr>";
            //html2 = html2 + "<tr><td>Incident Date/Time: </td><td>" + dt.ToString("MM/dd/yyyy") + " " + ti.ToString("HH:mm:ss") + "</td></tr>";
            //html2 = html2 + "<tr><td>Employee Name: </td><td>" + txtEmpName.Text + "</td></tr>";
            //html2 = html2 + "<tr><td></td><td></td></tr>";
            //html2 = html2 + "<tr><td></td><td></td></tr>";
            //html2 = html2 + "<tr><td>To review report: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/Supervisors/SupervisorDash'>LEW HRIS CAS Supervisor Dashboard</a></td></tr>";
            //html2 = html2 + "</table></div>";
            //html2 = html2 + "<br /><br />";
            //html2 = html2 + "<div>If you have questions or experience issues accessing the report, please contact the LEW IT Department at 559-925-7547 or casuncion@leprinofoods.com.</div>";
            //html2 = html2 + "<br /><br />";
            //html2 = html2 + "<div>Thank you,<br>Leprino Foods Company | Lemoore West - PLC/ISS Department</div></body></html>";


            ////smtpClient.Send(from, txtEmpEmail.Text + ", " + currEmail, "New Counseling Report: " + txtSubject.Text, bodyMessage);
            ////System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage(from, to);
            //System.Net.Mail.MailMessage newReport2 = new System.Net.Mail.MailMessage();
            //SmtpClient smtpClient2 = new SmtpClient("smtp.leprino.local");
            ////MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            ////MailAddress to = new MailAddress("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com");
            ////MailAddress from = new MailAddress("lewiss@leprinofoods.com", "Database Coordinator");
            //newReport2.From = new MailAddress("no-reply@leprinofoods.com", "LEW HRIS CAS Notification");
            //newReport2.To.Add(currEmail); //Supervisor
            //newReport2.Subject = txtSubject.Text;
            //newReport2.IsBodyHtml = true;
            //newReport2.Body = html2;

            //smtpClient2.Send(newReport2);


            myCategory.SelectedIndex = 0;
            mySubcategory.SelectedIndex = 0;
            txtLevel.Text = string.Empty;

            Response.Redirect("~/HumanResources/AdminPage/AdminPanel.aspx", false);

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
                con.Dispose();
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

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();


            //string strValue = Page.Request.Form["myInput"].ToString();
            string strValue = String.Format("{0}", Request.Form["myCountry2"]);
            txtSupName.Text = String.Format("{0}", Request.Form["myCountry2"]);
            string getID = null;
            try
            {
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
                                if (strValue ==  user.Name.ToString())
                                {
                                    //MessageBox.ShowMessage(strValue, this.Page);
                                    getID = user.EmployeeId.ToString();
                                }
                            }
                        }

                    }

                }

                txtSupID.Text = getID;

                cnn.Dispose();
                cnn.Close();

                //txtEmpName.Text = GetUserNameEmployee(txtEmpID.Text);
                //txtEmpName.Text = GetUserNameEmployee(getID);
                //txtDepartment.Text = GetUserDepartmentEmployee(txtEmpID.Text);
                //txtDepartment.Text = GetUserDepartmentEmployee(getID);
                //txtEmpEmail.Text = GetUserEmailEmployee(getID);
                txtSupEmail.Text = GetUserEmailUsingID(txtSupID.Text);
                txtSupName.Text = GetUserNameEmployee(txtSupID.Text);
                txtSupUserName.Text = GetUserNameUsingID(txtSupID.Text);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            Label13.Visible = false;
            Label13.BackColor = System.Drawing.Color.Transparent;
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

        [Required(ErrorMessage = "Please search for employee and click search. ")]
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
