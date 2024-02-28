using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services.Description;
//using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.UI.WebControls.WebParts;
//using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Common;
using System.Security.Policy;
using System.DirectoryServices.ActiveDirectory;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Bibliography;
using iTextSharp.text.pdf;
using static iTextSharp.text.pdf.PdfDiv;
using System.IdentityModel.Metadata;
using System.Net.NetworkInformation;
using System.Net.Mail;
using DocumentFormat.OpenXml.Office2010.Excel;

using context = System.Web.HttpContext;
using WebGrease.Css.Ast.Selectors;

namespace lewHRISlocal.Employees
{
    public static class Extensions
    {

        public static string GetDomain(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(0, stop) : string.Empty;
        }

        public static string GetLogin(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : string.Empty;
        }
    }
    public partial class EmployeeDash : System.Web.UI.Page
    {
        

        public static string GetUserFullName(string domain, string userName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);



            return user.GivenName + " " + user.Surname;
        }

        public static string GetUserDepartmentEmployee(string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + userName + ")",
                    PropertiesToLoad = { "department" },
                })
                {
                    return (string)search.FindOne().Properties["department"][0];
                }
            }
        }

        public static string GetUserID(string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + userName + ")",
                    PropertiesToLoad = { "employeeId" },
                })
                {
                    return (string)search.FindOne().Properties["employeeId"][0];
                }
            }
        }

        public static string GetUserEmail(string userName)
        {
            //DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            //return (string)userEntry.Properties["mail"][0];

            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + userName + ")",
                    PropertiesToLoad = { "mail" },
                })
                {
                    return (string)search.FindOne().Properties["mail"][0];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = HttpContext.Current.User.Identity;
            WelcomeLabel.Text = "Welcome, " + GetUserFullName(id.GetDomain(), id.GetLogin()) + "!";

            //try
            //{
                if (!this.IsPostBack)
                {
                    //this.BindGrid1();
                    this.BindGrid2();
                    this.BindGrid3();
                    this.BindGridPrint();
                    //this.BindGrid4();
                }

                if (txtPrintReady.Text == "nothing")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                          "hideBadge();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                          "showBadge();", true);
                }
            //}
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendErrorTomail(ex, id.GetLogin());
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was sent to the team. '); window.location.href('http://10.40.80.28:150/lewHRISlocal/Default.aspx');", true);

            //}
            //finally { }
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Employees/Detail.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

       

        //protected void LinkButton4_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView3.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Employees/DisciplinaryDetail.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        //private void BindGrid1()
        //{
        //    IIdentity id = HttpContext.Current.User.Identity;

        //    string myConnection;
        //    SqlConnection cnn;
        //    myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
        //    cnn = new SqlConnection(myConnection);
        //    cnn.Open();
        //    //Response.Write("Connection Made");

        //    DataSet ds2 = new DataSet();
        //    SqlDataAdapter sda2 = new SqlDataAdapter();
        //    SqlCommand command2 = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
        //        "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_1] " +
        //        "WHERE ([Overall Status] = 'Waiting for EE Acknowledgement' OR [Overall Status] = 'Waiting for Department/Employee Acknowledgement') AND " +
        //        "[EE_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
        //    sda2.SelectCommand = command2;
        //    using (DataTable dt2 = new DataTable())
        //    {
        //        sda2.Fill(dt2);
        //        if (dt2.Rows.Count>0)
        //        {
        //            //NeedAttn.Text = dt2.Rows.Count.ToString() + " record(s) returned.";
        //            mydatagrid.DataSource = dt2;
        //            mydatagrid.DataBind();
        //        }
        //        else
        //        {
        //            ReqAck.Text = "No records available.";
        //        }
        //    }
        //    command2.Dispose();
        //    cnn.Close();
        //}

        private void BindGrid2()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_1] " +
                "WHERE [Overall Status] NOT IN  ('Requires Employee Acknowledgment', 'Waiting for Department/Employee Acknowledgement', 'HR Dismissed Report') AND " +
                "[EE_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    CounselingRecords.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
            cnn.Dispose();
        }

        private void BindGrid3()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
                "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_3] " +
                "WHERE [Overall Status] NOT IN ('Disciplinary Action Sent to Department', 'Waiting for Sup Acknowledgement Disciplinary', 'Waiting for EE Acknowledgement Disciplinary') AND " +
                "[EE_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {
                    DARecords.Text = "No records available.";
                }
            }

            command.Dispose();
            cnn.Close();
            cnn.Dispose();
        }

        public static String ErrorlineNo, Errormsg, ErrorLocation, extype, exurl, Frommail, ToMail, Sub, HostAdd, EmailHead, EmailSing;
        private void BindGridPrint()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            try
            {
                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();
                //Response.Write("Connection Made");
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT [PrintRequest_ID],[Counseling_ID],[Request_Date], " +
                    "[EE_ID],[PrintRequest_Status],[PickUp_Date],[Incident_Date] FROM [PrintRequests] " +
                    "WHERE [PrintRequest_Status] = 'Ready' AND " +
                    "[EE_ID] = " + GetUserID(id.GetLogin()) + " UNION SELECT [PrintRequest_ID],[Counseling_ID],[Request_Date], " +
                    "[EE_ID],[PrintRequest_Status],[PickUp_Date],[Incident_Date] FROM [PrintRequests_CA] " +
                    "WHERE [PrintRequest_Status] = 'Ready' AND " +
                    "[EE_ID] = " + GetUserID(id.GetLogin()) + "", cnn);
                sda.SelectCommand = command;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    if (dt.Rows.Count>0)
                    {
                        txtPrintReady.Text = dt.Rows.Count.ToString();
                        readyPrint.DataSource = dt;
                        readyPrint.DataBind();
                    }
                    else
                    {
                        txtPrintReady.Text = "nothing";
                    }
                }

                command.Dispose();
                cnn.Close();
                cnn.Dispose();
            }
            catch (Exception ex)
            {

                ExceptionLogging.SendErrorTomail(ex, id.GetLogin(), "Not Applicable - Access Issue");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We apologize. An error occured and an email was sent to the team.'); window.location.replace('http://10.40.80.28:150/lewHRISlocal/Default.aspx');", true);

            }
        }
        //private void BindGrid4()
        //{
        //    IIdentity id = HttpContext.Current.User.Identity;

        //    string myConnection;
        //    SqlConnection cnn;
        //    myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
        //    cnn = new SqlConnection(myConnection);
        //    cnn.Open();
        //    //Response.Write("Connection Made");
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    SqlCommand command = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
        //        "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_3] " +
        //        "WHERE [Overall Status] IN ('Disciplinary Action Sent to Department', 'Waiting for Sup Acknowledgement Disciplinary', 'Waiting for EE Acknowledgement Disciplinary') AND " +
        //        "[EE_Name] = '" + GetUserFullName(id.GetDomain(), id.GetLogin()) + "'", cnn);
        //    sda.SelectCommand = command;
        //    using (DataTable dt = new DataTable())
        //    {
        //        sda.Fill(dt);
        //        if (dt.Rows.Count>0)
        //        {
        //            //RecentSubs.Text = dt.Rows.Count.ToString() + " record(s) returned.";
        //            GridView3.DataSource = dt;
        //            GridView3.DataBind();
        //        }
        //        else
        //        {
        //            txtReqAckDA.Text = "No records available.";
        //        }
        //    }

        //    command.Dispose();
        //    cnn.Close();
        //}

        //protected void mydatagrid_DataBound(object sender, EventArgs e)
        //{
        //    if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
        //    {
        //        ReqAck.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else ReqAck.Text = "No record(s) returned.";

        //}

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if ((GridView1.DataSource as DataTable).Rows.Count>0)
            {
                CounselingRecords.Text = (GridView1.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else CounselingRecords.Text = "No record(s) returned.";
        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            if ((GridView2.DataSource as DataTable).Rows.Count>0)
            {
                DARecords.Text = (GridView2.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else DARecords.Text = "No record(s) returned.";
        }

        protected void readyPrint_DataBound(object sender, EventArgs e)
        {
            //if ((readyPrint.DataSource as DataTable).Rows.Count>0)
            //{
            //    txtPrintReady.Text = (readyPrint.DataSource as DataTable).Rows.Count.ToString();
            //}
            //else txtPrintReady.Text = "nothing";  //[Space] to indicate to not show the Badge
        }
        //protected void GridView3_DataBound(object sender, EventArgs e)
        //{
        //    if ((GridView3.DataSource as DataTable).Rows.Count>0)
        //    {
        //        txtReqAckDA.Text = (GridView3.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else txtReqAckDA.Text = "No record(s) returned.";
        //}
        //protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    mydatagrid.PageIndex = e.NewPageIndex;
        //    this.BindGrid1();
        //}
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid2();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.BindGrid3();
        }

        protected void readyPrint_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            readyPrint.PageIndex = e.NewPageIndex;
            this.BindGridPrint();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
               "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_1] " +
               "WHERE [Overall Status] NOT IN  ('Requires Employee Acknowledgment', 'Waiting for Department/Employee Acknowledgement', 'HR Dismissed Report') AND " +
               "[Counseling_ID] = " + id + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                TextBox1.Text = dataReader.GetDateTime(0).ToString();
                TextBox2.Text = dataReader.GetString(4);
                TextBox3.Text = "" + dataReader.GetInt32(7);

            }
            command.Dispose();
            cnn.Close();
            cnn.Dispose();

            //DateTime today = DateTime.Today;
            printRequest_ID.Text = GetUserID(id2.GetLogin()) + "-" + DateTime.Now.ToString("MMdd") + "-" + id.ToString();


            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                      "showMeModal();", true);
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView2.DataKeys[rowIndex].Values[0]);
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            SqlCommand command = new SqlCommand("SELECT [Date_Incident], [Supervisor_Name], [Counseling_Category], [Counseling_SubCategory], " +
               "[Counseling_Subject], [Counseling_Level], [Overall Status], [Counseling_ID], [EE_Name] FROM [View_3] " +
               "WHERE " +
               "[Counseling_ID] = " + id + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                TextBox5.Text = dataReader.GetDateTime(0).ToString();
                TextBox6.Text = dataReader.GetString(4);
                TextBox4.Text = "" + dataReader.GetInt32(7);

            }
            command.Dispose();
            cnn.Close();
            cnn.Dispose();

            //DateTime today = DateTime.Today;
            TextBox7.Text = GetUserID(id2.GetLogin()) + "-" + DateTime.Now.ToString("MMdd") + "-" + id.ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                      "showMeModal3();", true);
        }

        protected void sentPrintReq_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            

            try
            {
                //EMAIL NOTIFICATION to HR
                string html = "<!DOCTYPE html><html><body>";
                html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Print Request</h1></div>";
                html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                html = html + "";
                html = html + "<tr width='50px'><td><strong>New Print Request</strong></td><td></td></tr>";
                html = html + "<tr><td>Request to Print from: </td><td>" + GetUserFullName(id2.GetDomain(), id2.GetLogin()) + "</td></tr>";
                html = html + "<tr><td>Requested on: </td><td>" + System.DateTime.Now.ToString() + "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td><strong>Request to Print ID</strong></td><td><strong>" + printRequest_ID.Text + "</strong></td></tr>";
                html = html + "<tr><td>Counseling ID: </td><td>" + TextBox3.Text + "</td></tr>";
                html = html + "<tr><td>Incident Date: </td><td>" + TextBox1.Text + "</td></tr>";
                html = html + "<tr><td>Subject: </td><td>" + TextBox2.Text + "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>To view requests: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/HumanResources/HRDash'>LEW HRIS CAS Human Resources Dashboard</a></td></tr>";
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
                //newReport.To.Add("" + string.Join(", ", items).ToString() + ""); //HRIS Group
                newReport.To.Add("lemoorewestperformance@leprinofoods.com"); //HRIS Group
                newReport.Subject = printRequest_ID.Text + " - New Request to Print";
                newReport.IsBodyHtml = true;
                newReport.Body = html;

                smtpClient.Send(newReport);



                // -- ADD SQL EXECUTE TO SAVE REQUESTS
                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO dbo.PrintRequests (" +
                        "[PrintRequest_ID], " +
                        "[Counseling_ID], " +
                        "[Request_Date], " +
                        "[EE_ID], " +
                        "[PrintRequest_Status], " +
                        "[Incident_Date] ) " +
                        "VALUES ( " +
                        "'" + printRequest_ID.Text + "', '" + TextBox3.Text +"', '" + System.DateTime.Now.ToString() + "', " + GetUserID(id2.GetLogin()) +
                        ", 'New', '" + TextBox1.Text + "')", cnn);


                command.ExecuteNonQuery();
                cnn.Close();
                cnn.Dispose();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), "Print Request Error");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('An error occured. Please make sure there is no existing open request for the same case.'); window.location.replace('http://10.40.80.28:150/lewHRISlocal/Default.aspx');", true);
            }
            finally
            {

            }
        }
        //GetUserID(id2.GetLogin())
        //protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView3.PageIndex = e.NewPageIndex;
        //    this.BindGrid4();
        //}
        protected void PrintReq_Click(object sender, EventArgs e)
        {
            

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                      "showMeModal2();", true);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            
            try
            {
                //EMAIL NOTIFICATION to HR
                string html = "<!DOCTYPE html><html><body>";
                html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Print Request</h1></div>";
                html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
                html = html + "";
                html = html + "<tr width='50px'><td><strong>New Print Request</strong></td><td></td></tr>";
                html = html + "<tr><td>Request to Print from: </td><td>" + GetUserFullName(id2.GetDomain(), id2.GetLogin()) + "</td></tr>";
                html = html + "<tr><td>Requested on: </td><td>" + System.DateTime.Now.ToString() + "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td><strong>Request to Print ID</strong></td><td><strong>" + TextBox7.Text + "</strong></td></tr>";
                html = html + "<tr><td>Counseling ID: </td><td>" + TextBox4.Text + "</td></tr>";
                html = html + "<tr><td>Incident Date: </td><td>" + TextBox5.Text + "</td></tr>";
                html = html + "<tr><td>Subject: </td><td>" + TextBox6.Text + "</td></tr>";
                html = html + "<tr><td></td><td></td></tr>";
                html = html + "<tr><td>To view requests: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/HumanResources/HRDash'>LEW HRIS CAS Human Resources Dashboard</a></td></tr>";
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
                //newReport.To.Add("" + string.Join(", ", items).ToString() + ""); //HRIS Group
                newReport.To.Add("lemoorewestperformance@leprinofoods.com"); //HRIS Group
                newReport.Subject = TextBox7.Text + " - New Request to Print";
                newReport.IsBodyHtml = true;
                newReport.Body = html;

                smtpClient.Send(newReport);



                // -- ADD SQL EXECUTE TO SAVE REQUESTS
                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO dbo.PrintRequests_CA (" +
                        "[PrintRequest_ID], " +
                        "[Counseling_ID], " +
                        "[Request_Date], " +
                        "[EE_ID], " +
                        "[PrintRequest_Status], " +
                        "[Incident_Date] ) " +
                        "VALUES ( " +
                        "'" + TextBox7.Text + "', '" + TextBox4.Text +"', '" + System.DateTime.Now.ToString() + "', " + GetUserID(id2.GetLogin()) +
                        ", 'New', '" + TextBox5.Text + "')", cnn);


                command.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorTomail(ex, id2.GetLogin(), "Print Request Error");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('An error occured. Please make sure there is no existing open request for the same case.'); window.location.replace('http://10.40.80.28:150/lewHRISlocal/Default.aspx');", true);
            }
            finally
            {
            }
        }
    }
}