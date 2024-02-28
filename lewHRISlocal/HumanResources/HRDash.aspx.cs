using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.UI.WebControls.WebParts;
//using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Common;
using System.Security.Policy;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.DirectoryServices;
using lewHRISlocal.Employees;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Services;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Net.Mail;

namespace lewHRISlocal.HumanResources
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
    public partial class HRDash : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        //public static string GetJson(string name)
        public static string GetJsonNewCounseling()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Employee_Status] As 'EmpStatus', COUNT(Counseling_ID) As 'Count' FROM dbo.View_1 WHERE [Overall Status] IN ('Ready to Close', 'Sent to HR for Final Review')  GROUP BY [Employee_Status] FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString();
            
        }

        [System.Web.Services.WebMethod]
        //public static string GetJson(string name)
        // Can be DISREGARDED
        public static string GetJsonOpenCounseling()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Employee_Status] As 'EmpStatus', COUNT(Counseling_ID) As 'Count' FROM dbo.View_1 WHERE [Overall Status] = 'Waiting for HR Decision' GROUP BY [Employee_Status] FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString();
            
        }

        [System.Web.Services.WebMethod]
        //public static string GetJson(string name)
        public static string GetJsonInitiated()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Employee_Status] As 'EmpStatus', COUNT(Counseling_ID) As 'Count' FROM dbo.View_3 WHERE [Overall Status] = 'Initiated Disciplinary Action' GROUP BY [Employee_Status] FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString();
            
        }

        [System.Web.Services.WebMethod]
        public static string GetJsonReview()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT [Employee_Status] As 'EmpStatus', COUNT(Counseling_ID) As 'Count' FROM dbo.View_1 WHERE [Overall Status] = 'Sent to HR for Review' GROUP BY [Employee_Status] FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0).ToString();

        }

        [System.Web.Services.WebMethod]
        public static string GetTrendCounseling()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            //SqlCommand command = new SqlCommand("SELECT CONVERT(VARCHAR(10), Date_Incident, 101) AS [DateEntered], Count([Counseling_ID]) AS [DailyCount] " +
            //    "FROM dbo.CounselingReport WHERE YEAR(Date_Incident) = YEAR(dbo.fnc_FiscalYearStart(GETDATE())) GROUP BY CONVERT(VARCHAR(10), Date_Incident, 101) FOR JSON PATH", cnn);

            SqlCommand command = new SqlCommand("SELECT [Month_Name] AS [DateEntered], [Count] AS [DailyCount] FROM [dbo].[HRDash_CTrend]  FOR JSON PATH", cnn);


            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0);

        }

        [System.Web.Services.WebMethod]
        public static string GetTrendDisciplinary()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            //SqlCommand command = new SqlCommand("SELECT CONVERT(VARCHAR(10), Date_Incident, 101) AS [DateEntered], Count([Counseling_ID]) AS " +
            //    "[DailyCount] FROM dbo.DisciplinaryRecords WHERE YEAR(Date_Incident) = YEAR(dbo.fnc_FiscalYearStart(GETDATE())) GROUP BY CONVERT(VARCHAR(10), Date_Incident, 101) FOR JSON PATH", cnn);

            SqlCommand command = new SqlCommand("SELECT [Month_Name] AS [DateEntered], [Count] AS [DailyCount] FROM [dbo].[HRDash_DATrend]  FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0);

        }

        [System.Web.Services.WebMethod]
        public static string GetOpenCases()
        {
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            //SqlCommand command = new SqlCommand("SELECT CONVERT(VARCHAR(10), Date_Incident, 101) AS [DateEntered], Count([Counseling_ID]) AS " +
            //    "[DailyCount] FROM dbo.DisciplinaryRecords WHERE YEAR(Date_Incident) = YEAR(dbo.fnc_FiscalYearStart(GETDATE())) GROUP BY CONVERT(VARCHAR(10), Date_Incident, 101) FOR JSON PATH", cnn);

            SqlCommand command = new SqlCommand("SELECT [Department_Group] AS [DateEntered], [Counseling_Count] AS [DailyCount], [Disciplinary_Count] AS [DailyCount2] FROM [dbo].[View_Counts]  FOR JSON PATH", cnn);

            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    return dataReader.GetString(0).ToString();
            //}
            dataReader.Read();
            return dataReader.GetString(0);

        }

        //private PrincipalContext ctx;
        public static string GetUserFullName(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = HttpContext.Current.User.Identity;

            WelcomeLabel.Text = "Welcome, " + GetUserFullName(id.GetDomain(), id.GetLogin()) + "!";

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            //SqlCommand command = new SqlCommand("SELECT COUNT(Counseling_ID) As 'Count' FROM dbo.View_1 WHERE YEAR(Date_Incident) = YEAR(GETDATE())", cnn);
            SqlCommand command = new SqlCommand("SELECT SUM([Count]) FROM [dbo].[HRDash_CTrend]", cnn);
            SqlDataReader dataReader;
            
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                numCounselingsYTD.Text = "" + dataReader.GetInt32(0);
            }
            dataReader.Close();
            command.Dispose(); 

            //SqlCommand command2 = new SqlCommand("SELECT COUNT(Disciplinary_ID) As 'Count' FROM dbo.View_3 WHERE YEAR(Date_Incident) = YEAR(GETDATE())", cnn);
            SqlCommand command2 = new SqlCommand("SELECT SUM([Count]) FROM [dbo].[HRDash_DATrend]", cnn);

            SqlDataReader dataReader2;
            dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                numDAYTD.Text = "" + dataReader2.GetInt32(0);
            }
            dataReader2.Close();
            command2.Dispose();

            //SqlCommand command2 = new SqlCommand("SELECT COUNT(Disciplinary_ID) As 'Count' FROM dbo.View_3 WHERE YEAR(Date_Incident) = YEAR(GETDATE())", cnn);
            SqlCommand command3 = new SqlCommand("SELECT SUM([Total_Count]) FROM [dbo].[View_Counts]", cnn);

            SqlDataReader dataReader3;
            dataReader3 = command3.ExecuteReader();
            while (dataReader3.Read())
            {
                openCasesTotal.Text = "" + dataReader3.GetInt32(0);
            }
            dataReader3.Close();
            command3.Dispose();

            cnn.Dispose();
            cnn.Close();

            if (!this.IsPostBack)
            {
                this.BindGridPrint();
                this.CounselingTracker();
                this.DisciplinaryTracker();
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


           

        }


        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Supervisors/DetailOnly.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Supervisors/Detail.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}

        //protected void LinkButton3_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView2.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/Supervisors/DetailOnly.aspx?id=" + id + "", false);
        //    //Response.Redirect("/Supervisors/Detail.aspx");
        //    //Context.ApplicationInstance.CompleteRequest();
        //}
        protected void PrintReq_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
            //          "showMeModal2();", true);

            Response.Redirect("~/HumanResources/PrintRequests.aspx", false);
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

        private void BindGridPrint()
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
            SqlCommand command = new SqlCommand("SELECT [PrintRequest_ID],[Counseling_ID],[Request_Date], " +
                "[EE_ID],[PrintRequest_Status],[PickUp_Date],[Incident_Date] FROM [PrintRequests] " +
                "WHERE [PrintRequest_Status] = 'New' UNION SELECT [PrintRequest_ID],[Counseling_ID],[Request_Date], " +
                "[EE_ID],[PrintRequest_Status],[PickUp_Date],[Incident_Date] FROM [PrintRequests_CA] " +
                "WHERE [PrintRequest_Status] = 'New'", cnn);
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
        }

        protected void readyPrint_DataBound(object sender, EventArgs e)
        {
            //if ((readyPrint.DataSource as DataTable).Rows.Count>0)
            //{
                //CounselingRecords.Text = (readyPrint.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            //}
            //else CounselingRecords.Text = "No record(s) returned.";
        }

        protected void readyPrint_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            readyPrint.PageIndex = e.NewPageIndex;
            this.BindGridPrint();
        }

        protected void sentPrintReq_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            //List<string> items = new List<string>();

            //using (var context2 = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
            //{
            //    using (var group = GroupPrincipal.FindByIdentity(context2, "LEW - HRIS CAS"))
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

            ////EMAIL NOTIFICATION to HR
            //string html = "<!DOCTYPE html><html><body>";
            //html = html + "<div style='background-color: #003366; color: white; width: 50%; padding: 25px;'><h1>LEW HRIS CAS Notification - New Print Request</h1></div>";
            //html = html + "<table style='max-width: 75%; background-color: #cccccc; border-style: solid; border-color: transparent;'><div style='padding: 20px; font-family:'Segoe UI', Calibri, Arial, Helvetica; font-size: 16px;'>";
            //html = html + "";
            //html = html + "<tr width='50px'><td><strong>New Print Request</strong></td><td></td></tr>";
            //html = html + "<tr><td>Request to Print from: </td><td>" + GetUserFullName(id2.GetDomain(), id2.GetLogin()) + "</td></tr>";
            //html = html + "<tr><td>Requested on: </td><td>" + System.DateTime.Now.ToString() + "</td></tr>";
            //html = html + "<tr><td></td><td></td></tr>";
            //html = html + "<tr><td><strong>Request to Print ID</strong></td><td><strong>" + printRequest_ID.Text + "</strong></td></tr>";
            //html = html + "<tr><td>Counseling ID: </td><td>" + TextBox3.Text + "</td></tr>";
            //html = html + "<tr><td>Incident Date: </td><td>" + TextBox1.Text + "</td></tr>";
            //html = html + "<tr><td>Subject: </td><td>" + TextBox2.Text + "</td></tr>";
            //html = html + "<tr><td></td><td></td></tr>";
            //html = html + "<tr><td>To view requests: </td><td><a href='http://10.40.80.28:150/lewHRISlocal/HumanResources/HRDash'>LEW HRIS CAS Human Resources Dashboard</a></td></tr>";
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
            ////newReport.To.Add("" + string.Join(", ", items).ToString() + ""); //HRIS Group
            //newReport.To.Add("" + GetUserEmail(id2.GetLogin()) + ", carlamae.asuncion@gmail.com"); //HRIS Group
            //newReport.Subject = printRequest_ID.Text + " - New Request to Print";
            //newReport.IsBodyHtml = true;
            //newReport.Body = html;

            //smtpClient.Send(newReport);



            //// -- ADD SQL EXECUTE TO SAVE REQUESTS
            //string myConnection;
            //SqlConnection cnn;
            //myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            //cnn = new SqlConnection(myConnection);
            //cnn.Open();

            
            //SqlCommand command = new SqlCommand("UPDATE dbo.PrintRequests SET [PrintRequest_Status] = 'Ready' " +
            //    "WHERE ", cnn);

            //command.ExecuteNonQuery();
            //cnn.Close();
        }




        // Bind Tracker
        private void CounselingTracker()
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
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.[Tracker] " +
                "WHERE NOT [Overall Status] IN ('Counseling Closed', 'HR Dismissed Report', 'Initiated Disciplinary Action - Closed', 'Counseling Closed - Withdrawn') " +
                "AND NOT [EE_Name] IS NULL ORDER BY [Counseling_ID]", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //txtPrintReady.Text = dt.Rows.Count.ToString();
                    mydatagrid.DataSource = dt;
                    mydatagrid.DataBind();
                }
                else
                {
                    //txtPrintReady.Text = "nothing";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            mydatagrid.PageIndex = e.NewPageIndex;
            this.CounselingTracker();
        }

        protected void mydatagrid_DataBound(object sender, EventArgs e)
        {
            //if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
            //{
            //    NeedAttn.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            //}
            //else NeedAttn.Text = "No record(s) returned.";

        }


        // Bind Tracker
        private void DisciplinaryTracker()
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
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.[Tracker_CA] " +
                "WHERE NOT [Overall Status] IN ('Counseling Closed', 'HR Dismissed Report', 'Disciplinary Action Closed', 'Disciplinary Action Closed - Withdrawn') " +
                "ORDER BY [Counseling_ID]", cnn);
            sda.SelectCommand = command;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    //txtPrintReady.Text = dt.Rows.Count.ToString();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    //txtPrintReady.Text = "nothing";
                }
            }

            command.Dispose();
            cnn.Close();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.DisciplinaryTracker();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            //if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
            //{
            //    NeedAttn.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            //}
            //else NeedAttn.Text = "No record(s) returned.";

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DetailOnly.aspx?id=" + id + "", false);
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "window.location.replace('~/General/DetailOnly.aspx?id=" + id + "');return false;", true); //Removed Supervisors/
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "Redirect", "window.location.replace = '~/General/DetailOnly.aspx?id=" + id + "'", true);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

            Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }


        protected void btnSendAlert_Click(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            List<string> items = new List<string>();
            using (var context = new PrincipalContext(ContextType.Domain, id2.GetDomain()))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, "LEW - HRIS " + departmentList.SelectedItem.Value.Trim()))
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

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            
            SqlCommand command = new SqlCommand("Select * from dbo.View_Counts WHERE TRIM([Department_Group]) = TRIM('" + departmentList.SelectedItem.Value + "')", cnn);
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
            newReport.To.Add(listofEmails.Text); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
            //newReport.To.Add("casuncion@leprinofoods.com, carlamae.asuncion@gmail.com"); //WILL HAVE TO BE CHANGED TO HR EMAIL ADDRESS
                                                            //newReport.To.Add("carlamae.asuncion@gmail.com");
            newReport.Subject = "Open Corrective Action Cases";
            newReport.IsBodyHtml = true;
            newReport.Body = html;

            smtpClient.Send(newReport);
            //MessageBox.ShowMessage(newStatus, this.Page);
            Response.Redirect("~/", false);
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                      "showAlert();", true);
        }
    }


}


    
