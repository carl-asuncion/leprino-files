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
using context = System.Web.HttpContext;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Office.CustomUI;
//using EASendMail;

namespace lewHRISlocal.Supervisors
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
                        // Skip
                    }
                    else
                    {
                        var users = group.GetMembers(true);
                        foreach (UserPrincipal user in users)
                        {
                            if (!user.SamAccountName.ToString().Contains("_c"))
                            {
                                termsList.Add(user.Name.ToString());
                            }
                        }
                    }
                }
            }
            return termsList;
        }


        public static string GetUserFullName(string domain, string userName)
        {
           using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + userName + ")",
                    PropertiesToLoad = { "name" },
                })
                {
                    return (string)search.FindOne().Properties["name"][0];
                }
            }
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

        public static string GetUserID(string user)           //(string domain, string userName)
        {
            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + user + ")",
                    PropertiesToLoad = { "employeeID" },
                })
                {
                    return (string)search.FindOne().Properties["employeeID"][0];
                }
            }
        }

        public static string GetUserEmailEmployee(string empName)           //(string domain, string userName)
        {
            try
            {
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
            catch (Exception ex)
            {
                return "No email address";
            }
            finally { }
        }

        public static string GetUserNameEmployee(string empName)           //(string domain, string userName)
        {
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
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, id.GetDomain());

                // find a user
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, id.GetLogin());

                // find the group in question
                GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "LEW - Human Resource Department");

                if (user != null)
                {
                    // check if user is member of that group
                    if (user.IsMemberOf(group))
                    {
                        DropDownList1.Visible = true;
                        txtLevel.Visible = false;
                        txtLevel.Text = null;
                    }
                    else
                    {
                        DropDownList1.Visible = false;
                        txtLevel.Visible = true;
                        DropDownList1.Text = null;
                    }
                }

                Label13.Visible = false;
                Label13.BackColor = System.Drawing.Color.Transparent;

                try
                {
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

                        // -- DELETE EMPTY RECORD - REMOVED THIS SO NO ONGOING REPORTING GETS DELETED
                        SqlCommand command2 = new SqlCommand("DELETE FROM dbo.CounselingReport  " +
                                "WHERE dbo.CounselingReport.Date_Incident IS NULL AND " +
                                "dbo.CounselingReport.EE_ID IS NULL AND DATEDIFF(HH, " + 
                                "dbo.CounselingReport.Date_Entered, GETDATE()) > 6", cnn);
                        command2.ExecuteNonQuery();
                        command2.Dispose();

                        SqlCommand command1 = new SqlCommand("INSERT INTO dbo.CounselingReport  " +
                                "([Supervisor_ID], [Supervisor_Username], [Date_Entered]) VALUES (" +
                                "'" + currEmail + "', '" + currUserID + "', '" + System.DateTime.Now.ToString() + "')", cnn);
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
                    ExceptionLogging.SendErrorTomail(ex, id.GetLogin(), "Create Page Load Issue");
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was sent to the team.'); window.location.replace('Supervisors/SupervisorDash.aspx');", true);
                }
                finally
                {
                    // Skip
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
            
                using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
                {
                    using (var group = GroupPrincipal.FindByIdentity(context, "LEW - Employees"))
                    {
                        if (group == null)
                        {
                            // Skip
                        }
                        else
                        {
                            var users = group.GetMembers(true);
                            try
                            {
                                foreach (UserPrincipal user in users)
                                {
                                    if (strValue ==  user.Name.ToString())
                                    {
                                        //MessageBox.ShowMessage(strValue, this.Page);
                                        getID = user.EmployeeId.ToString();
                                    }
                                }

                                //if user does not have an employee id based on name, check 
                                if (getID == null)
                                {
                                    getID = String.Format("{0}", Request.Form["myCountry"]);
                                }
                            }
                            catch (Exception ex)
                            {

                            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please confirm employee is not a temp prior to clicking on search button.'); ", true);
                            //return;
                                //getID = GetUserID(String.Format("{0}", Request.Form["myCountry"]));
                            }

                        }

                    }

                }
            try
            {

                //if ( IsNullOrEmpty(getID) )
                //    txtEmpID.Text = String.Format("{0}", Request.Form["myCountry"]);
                //else 

                //txtEmpID.Text = getID;
                var isNumeric = int.TryParse(getID, out int n);
                if (isNumeric)
                {
                    txtEmpID.Text = n.ToString();
                }
                else txtEmpID.Text = GetUserID(txtEmpName.Text);

                try
                {

                    

                    //SqlCommand command = new SqlCommand("Select * from dbo.MasterList WHERE [EE] = " + getID + "", cnn);
                    SqlCommand command = new SqlCommand("Select * from dbo.MasterList WHERE [EE] = " + txtEmpID.Text + "", cnn);
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
                

                    //SqlCommand cmd = new SqlCommand("SELECT Counseling_ID, CaseName FROM dbo.View_1 WHERE [EE_ID] = " + getID + " AND [Sup_Status] <> 'Sup Closed' AND Reference_ID = Counseling_ID ", cnn);
                    SqlCommand cmd = new SqlCommand("SELECT Counseling_ID, CaseName FROM dbo.View_1 WHERE [EE_ID] = " + txtEmpID.Text + " AND [Sup_Status] <> 'Sup Closed' AND Reference_ID = Counseling_ID ", cnn);
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
                    //txtEmpName.Text = GetUserNameEmployee(getID); ---- used to be getID
                    txtEmpName.Text = GetUserNameEmployee(txtEmpID.Text);
                    //txtDepartment.Text = GetUserDepartmentEmployee(txtEmpID.Text);
                    //txtDepartment.Text = GetUserDepartmentEmployee(getID);
                    txtEmpEmail.Text = GetUserEmailEmployee(txtEmpID.Text);
                }
                catch (Exception ex)
                {
                    //ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), txtCurrentTicketID.Text + " - entry error " + strValue);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please confirm correct employee name has been selected or is not a temp prior to clicking on search button.'); ", true);
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), txtCurrentTicketID.Text + " - User Search " + strValue);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was sent to the development team.'); window.location.replace('SupervisorDash.aspx');", true);

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
            IIdentity id = HttpContext.Current.User.Identity;
            try
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
                int actLvl = 0;
                if (txtLevel.Text == "Counseling" || DropDownList1.SelectedItem.Text == "Counseling") { actLvl = 0; }
                if (txtLevel.Text == "Level 1" || DropDownList1.SelectedItem.Text == "Level 1") { actLvl = 1; }
                if (txtLevel.Text == "Level 2" || DropDownList1.SelectedItem.Text == "Level 2") { actLvl = 2; }
                if (txtLevel.Text == "Level 3" || DropDownList1.SelectedItem.Text == "Level 3") { actLvl = 3; }
                if (txtLevel.Text == "Level 4" || DropDownList1.SelectedItem.Text == "Level 4") { actLvl = 4; }
                if (txtLevel.Text == "Termination" || DropDownList1.SelectedItem.Text == "Termination") { actLvl = 5; }

                string textLevel = null;
                if (txtLevel.Visible == false) { textLevel = DropDownList1.SelectedItem.Text;  }
                else { textLevel = txtLevel.Text; }


                //string actValue;
                string currEmail = GetUserEmail(id.GetLogin());
                string currUsername = id.GetLogin();
                string currName = GetUserFullName(id.GetDomain(), id.GetLogin());

                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();

                SqlCommand command4 = new SqlCommand("SELECT [Assigned_UserName] FROM dbo.[View_MainDepartment] " +
                        " WHERE [Department_Name] = '" + txtDepartment.Text + "'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(command4);
                SqlDataReader dataReader;
                dataReader = command4.ExecuteReader();
                while (dataReader.Read())
                {
                    generalist.Text = dataReader.GetString(0).ToString();
                }
                dataReader.Close();
                command4.Dispose();

                SqlCommand command = new SqlCommand("UPDATE dbo.CounselingReport SET " +
                        "[Supervisor_ID] = '" + currEmail + "', " +
                        "[Supervisor_Username] = '" + currUsername + "'," +
                        "[Date_Incident] = '" + dt.ToString("yyyy-MM-dd") + " " + ti.ToString("HH:mm:ss") + "', " +
                        "[Date_Entered] = '" + System.DateTime.Now.ToString() + "', " +
                        "[EE_ID] = " + txtEmpID.Text + ", " +           //creates error when it is null -- cannot be null
                        "[Department_Unit] = '" + txtDepartment.Text + "', " +
                        "[Counseling_Category] = '" + myCategory.SelectedItem.Text + "', " +
                        "[Counseling_SubCategory] = '" + mySubcategory.SelectedItem.Text + "', " +
                        "[Counseling_Subject] = '" + txtSubject.Text + "', " +
                        //"[Counseling_Level] = '" + txtLevel.Text + "', " + ======== UPDATED
                        "[Counseling_Level] = '" + textLevel + "', " +
                        "[Supervisor_Notes] = '" + txtNotes.Text.Replace("'", "''") + "', " +
                        "[EE_Status] = 'Unavailable', " +
                        "[Sup_Status] = 'Sup Open', " +
                        "[HR_Status] = 'HR Sent', " +
                        "[Actual_Level] = " + actLvl + ", " +
                        "[Assigned_HR_Manager] = '" + GetUserFullName(id.GetDomain(), generalist.Text) + "', " +
                        "[Supervisor_Name] = '" + currName + "' " +
                        "WHERE [Counseling_ID] = " + txtCurrentTicketID.Text + "", cnn);


                command.ExecuteNonQuery();
                //MessageBox.ShowMessage("Counseling Record added successfully.", this.Page);



                if (myReference.Text == "")
                {
                    SqlCommand command1 = new SqlCommand("UPDATE dbo.CounselingReport SET [Reference_ID] = " + txtCurrentTicketID.Text + " WHERE [Counseling_ID] = " + txtCurrentTicketID.Text + "", cnn);
                    command1.ExecuteNonQuery();
                    command1.Dispose();
                }
                else //Something is selected
                {
                    SqlCommand command1 = new SqlCommand("UPDATE dbo.CounselingReport SET [Reference_ID] = " + myReference.SelectedValue + " WHERE [Counseling_ID] = " + txtCurrentTicketID.Text + "", cnn);
                    command1.ExecuteNonQuery();
                    command1.Dispose();
                }





                cnn.Close();

                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();

                if (textLevel == "Termination")
                {

                    SqlCommand command1 = new SqlCommand("UPDATE dbo.CounselingReport SET [EE_Status] = 'Unavailable', [Sup_Status] = " +
                        "'Sup Open', [HR_Status] = 'HRM Sent', [Assigned_HR_Manager] = '" + GetUserFullName(id.GetDomain(), generalist.Text) + 
                        "', [Date_HRM_Forwarded] = '" + System.DateTime.Now.ToString() + ", " +
                        "' WHERE [Counseling_ID] = " + txtCurrentTicketID.Text + "", cnn);
                    command1.ExecuteNonQuery();
                    command1.Dispose();

                    SqlCommand command2 = new SqlCommand("INSERT INTO dbo.DisciplinaryRecords SELECT * FROM dbo.CounselingReport " +
                    "WHERE [Counseling_ID] = " + txtCurrentTicketID.Text + "", cnn);
                    command2.ExecuteNonQuery();
                    //MessageBox.ShowMessage("Counseling Record added successfully.", this.Page);
                    command2.Dispose();

                    SqlCommand command3 = new SqlCommand("UPDATE dbo.DisciplinaryRecords SET [EE_Status] = 'Unavailable', [Sup_Status] = " +
                       "'Unavailable', [HR_Status] = 'HRM Sent' WHERE [Counseling_ID] = " + txtCurrentTicketID.Text + "", cnn);
                    command3.ExecuteNonQuery();
                    command3.Dispose();

                    cnn.Close();

                    //EMAIL NOTIFICATION to HR
                    string html = "<!DOCTYPE html><html><body>";
                    html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Counseling Report for Approval</h1></div>";
                    html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                    html = html + "";
                    html = html + "<tr width='50px'><td><strong>Termination Report Submitted for Review</strong></td><td></td></tr>";
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


                    System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
                    SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                    newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                    newReport.To.Add(GetUserEmail(generalist.Text)); //HRIS Group
                    newReport.Subject = "Termination - " + txtSubject.Text;
                    newReport.IsBodyHtml = true;
                    newReport.Body = html;

                    smtpClient.Send(newReport);
                }
                else
                {
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


                    System.Net.Mail.MailMessage newReport = new System.Net.Mail.MailMessage();
                    SmtpClient smtpClient = new SmtpClient("smtp.leprino.local");
                    newReport.From = new MailAddress("no-reply@leprinofoods.com", "LEW Corrective Action Notification");
                    newReport.To.Add("lemoorewestperformance@leprinofoods.com"); //HRIS Group
                    //newReport.To.Add("casuncion@leprinofoods.com"); //HRIS Group
                    newReport.Subject = "New - " + txtSubject.Text;
                    newReport.IsBodyHtml = true;
                    newReport.Body = html;

                    smtpClient.Send(newReport);
                }



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
                newReport2.Subject = "Submitted - " + txtSubject.Text;
                newReport2.IsBodyHtml = true;
                newReport2.Body = html2;

                smtpClient2.Send(newReport2);


                myCategory.SelectedIndex = 0;
                mySubcategory.SelectedIndex = 0;
                txtLevel.Text = string.Empty;

                Response.Redirect("~/Supervisors/SupervisorDash", false);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorTomail(ex, id.GetLogin(), txtCurrentTicketID.Text + " - Create/Submit Issue");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was sent to the development team.'); window.location.replace('SupervisorDash.aspx');", true); //Removed Supervisors/

            }
            finally { }

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
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public string Date
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please enter incident time. ")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Time)]
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
