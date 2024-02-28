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
using System.Windows.Controls;
using lewHRISlocal.Employees;
using DocumentFormat.OpenXml.Office2010.Excel;
//using Microsoft.Office.Interop.Excel;

namespace lewHRISlocal.HumanResources
{
    
    public partial class PrintRequests : System.Web.UI.Page
    {
        //private PrincipalContext ctx;
        public static string GetUserFullName(string domain, string userName)
        {
            DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + domain + "/" + userName + ",User");
            return (string)userEntry.Properties["fullname"].Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //string empName = Request.QueryString["empName"].ToString();

            //MessageBox.ShowMessage(empName, this.Page);
            IIdentity id = HttpContext.Current.User.Identity;
            //TextBox1.Text =  id.GetLogin();
            //TextBox1.Text =  GetUserFullName(id.GetDomain(), id.GetLogin());
            if (!this.IsPostBack)
            {
                this.BindGrid1();
                this.BindGrid2();
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);

            //PRHistory.Text = id;

            Response.Redirect("~/General/DetailOnly.aspx?id=" + id + "", false);
            //Response.Redirect("/Supervisors/Detail.aspx");
            //Context.ApplicationInstance.CompleteRequest();
        }

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    //Determine the RowIndex of the Row whose Button was clicked.
        //    int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //    //Get the value of column from the DataKeys using the RowIndex.
        //    int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

        //    Response.Redirect("~/HumanResources/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
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

        private void BindGrid1()
        {
            IIdentity id = HttpContext.Current.User.Identity;

            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            DataSet ds2 = new DataSet();
            SqlDataAdapter sda2 = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.View_PrintRequests WHERE [PrintRequest_Status] = 'New'", cnn);
            sda2.SelectCommand = command;
            using (DataTable dt2 = new DataTable())
            {
                sda2.Fill(dt2);
                if (dt2.Rows.Count>0)
                {
                    //NeedAttn.Text = dt2.Rows.Count.ToString() + " record(s) returned.";
                    mydatagrid.DataSource = dt2;
                    mydatagrid.DataBind();
                }
                else
                {
                    CounselingRecord.Text = "No records available.";
                }
            }
            command.Dispose();
            cnn.Close();
        }

        private void BindCounselingPrint(string id)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            //txtSupComments.Text = id2.GetDomain() + " " + id2.GetLogin();
            //txtSubject.Text = GetUserFullName(id2.GetDomain(), id2.GetLogin());
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            SqlCommand command = new SqlCommand("Select * from dbo.View_1 WHERE [Counseling_ID] = " + id + "", cnn);
            SqlDataReader dataReader;
            //String Output = " ";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtDateIncident.Text = dataReader.GetDateTime(3).ToString();
                txtEmployeeName.Text = dataReader.GetString(4);
                txtDepartment.Text = dataReader.GetString(5);
                if (!dataReader.IsDBNull(8))
                {
                    txtSubject.Text = dataReader.GetString(8);
                }
                else txtSubject.Text = "";

                if (!dataReader.IsDBNull(10))
                {
                    txtSupComments.Text = dataReader.GetString(10);
                }
                else txtSupComments.Text = "";


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

                txtOverallStatus.Text = dataReader.GetString(21);
                if (txtOverallStatus.Text == "Sent to HR for Review" || txtOverallStatus.Text == "Waiting for Department/Employee Acknowledgement")
                {
                    txtEEAck.Text = "Form has not been acknowledged electronically.";
                    txtSupFin.Text = "Form has not been signed by supervisor electronically.";
                    txtEEAckDate.Text = "N/A";
                    txtSupFinDate.Text = "N/A";
                }
                else if (txtOverallStatus.Text == "Waiting for Sup Acknowledgement" || txtOverallStatus.Text == "Waiting for EE Acknowledgement")
                {
                    //Bottom Data
                    if (!dataReader.IsDBNull(26))
                    {
                        txtEEAck.Text = dataReader.GetString(4) + " | " + dataReader.GetString(26);
                    }
                    else txtEEAck.Text = "";
                    txtSupFin.Text = "Form has not been signed by supervisor electronically.";

                    if (!dataReader.IsDBNull(12))
                    {
                        txtEEAckDate.Text = dataReader.GetDateTime(12).ToString();
                    }
                    else txtEEAckDate.Text = "";
                    txtSupFinDate.Text = "N/A";
                }
                else
                {
                    //Bottom Data
                    if (!dataReader.IsDBNull(26))
                    {
                        txtEEAck.Text = dataReader.GetString(4) + " | " + dataReader.GetString(26);
                    }
                    else txtEEAck.Text = "";
                    if (!dataReader.IsDBNull(27))
                    {
                        //txtSupFin.Text = dataReader.GetString(27);
                        txtSupFin.Text = GetUserFullName(id2.GetDomain(), dataReader.GetString(27)) + " | " +  dataReader.GetString(27);
                    }
                    else txtSupFin.Text = "";

                    if (!dataReader.IsDBNull(12))
                    {
                        txtEEAckDate.Text = dataReader.GetDateTime(12).ToString();
                    }
                    else txtEEAckDate.Text = "";
                    if (!dataReader.IsDBNull(14))
                    {
                        txtSupFinDate.Text = dataReader.GetDateTime(14).ToString();
                    }
                    else txtSupFinDate.Text = "";
                }



            }
            //Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

        }

        protected void mydatagrid_DataBound(object sender, EventArgs e)
        {
            if ((mydatagrid.DataSource as DataTable).Rows.Count>0)
            {
                CounselingRecord.Text = (mydatagrid.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else CounselingRecord.Text = "No record(s) returned.";

        }

        protected void mydatagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //string empName = Request.QueryString["empName"].ToString();
            mydatagrid.PageIndex = e.NewPageIndex;
            this.BindGrid1();
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in mydatagrid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    System.Web.UI.WebControls.CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as System.Web.UI.WebControls.CheckBox);
                    if (chkRow.Checked)
                    {
                        //Get RowID which is the PrintRequest_ID
                            ////Determine the RowIndex of the Row whose Button was clicked.
                            //int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

                            ////Get the value of column from the DataKeys using the RowIndex.
                            //int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);
                            string id = row.Cells[3].Text;
                            //PRHistory.Text = id;
                        //BindGrid every time using the RowID Call for BindGrid2 -- rebinding panel
                            this.BindCounselingPrint(id);

                        //Print Panel using JavaScript - Call PrintPanel()
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "PrintPanel();", true);
                    }
                }
            }

            // 
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "showMeModal2();", true);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            foreach (GridViewRow row in mydatagrid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    System.Web.UI.WebControls.CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as System.Web.UI.WebControls.CheckBox);
                    if (chkRow.Checked)
                    {
                        // Get the PrintRequest_ID
                        string id = row.Cells[2].Text;
                        //PRHistory.Text = id;
                        //BindGrid every time using the RowID Call for BindGrid2 -- rebinding panel
                        //this.BindGrid2(id);
                        


                        SqlCommand command = new SqlCommand("UPDATE dbo.[PrintRequests] SET [PrintRequest_Status] = 'Ready' " +
                            " WHERE [PrintRequest_ID] = '" + id + "'", cnn);

                        command.ExecuteNonQuery();
                    }
                }
            }

            cnn.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "hideMeModal2();", true);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "hideMeModal2();", true);
        }

        //protected void GridView1_DataBound(object sender, EventArgs e)
        //{
        //    if ((GridView1.DataSource as DataTable).Rows.Count>0)
        //    {
        //        PRHistory.Text = (GridView1.DataSource as DataTable).Rows.Count + " total record(s) returned.";
        //    }
        //    else PRHistory.Text = "No record(s) returned.";

        //}

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    //string empName = Request.QueryString["empName"].ToString();
        //    GridView1.PageIndex = e.NewPageIndex;
        //    this.BindGrid2();
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

            DataSet ds2 = new DataSet();
            SqlDataAdapter sda2 = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.View_PrintRequests_CA WHERE [PrintRequest_Status] = 'New'", cnn);
            sda2.SelectCommand = command;
            using (DataTable dt2 = new DataTable())
            {
                sda2.Fill(dt2);
                if (dt2.Rows.Count>0)
                {
                    //NeedAttn.Text = dt2.Rows.Count.ToString() + " record(s) returned.";
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                }
                else
                {
                    TextBox1.Text = "No records available.";
                }
            }
            command.Dispose();
            cnn.Close();
        }


        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if ((GridView1.DataSource as DataTable).Rows.Count>0)
            {
                TextBox1.Text = (GridView1.DataSource as DataTable).Rows.Count + " total record(s) returned.";
            }
            else TextBox1.Text = "No record(s) returned.";

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //string empName = Request.QueryString["empName"].ToString();
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid2();
        }

        protected void PrintCA_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    System.Web.UI.WebControls.CheckBox chkRow = (row.Cells[0].FindControl("chkRow1") as System.Web.UI.WebControls.CheckBox);
                    if (chkRow.Checked)
                    {
                        //Get RowID which is the PrintRequest_ID
                        ////Determine the RowIndex of the Row whose Button was clicked.
                        //int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

                        ////Get the value of column from the DataKeys using the RowIndex.
                        //int id = Convert.ToInt32(mydatagrid.DataKeys[rowIndex].Values[0]);
                        string id = row.Cells[3].Text;
                        //PRHistory.Text = id;
                        //BindGrid every time using the RowID Call for BindGrid2 -- rebinding panel
                        this.BindCorrectiveAction(id);

                        //Print Panel using JavaScript - Call PrintPanel()
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "PrintPanel2();", true);
                    }
                }
            }

            // 
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "showMeModal3();", true);
        }


        protected void BindCorrectiveAction(string id)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            

            string myConnection;
            SqlConnection cnn;

            
                //txtSupComments.Text = id2.GetDomain() + " " + id2.GetLogin();
                //txtSubject.Text = GetUserFullName(id2.GetDomain(), id2.GetLogin());

                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();
                //Response.Write("Connection Made");

                SqlCommand command = new SqlCommand("Select * from dbo.View_3 WHERE [Counseling_ID] = " + id + "", cnn);
                SqlDataReader dataReader;
                //String Output = " ";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    txtDateIncident2.Text = dataReader.GetDateTime(3).ToString();
                    txtEmployeeID2.Text = "" + dataReader.GetInt32(1);
                    txtPosition2.Text = dataReader.GetString(42);
                    txtEmployeeName2.Text = dataReader.GetString(4);
                    txtDepartment2.Text = dataReader.GetString(5);
                    txtEmployeeStatus2.Text = dataReader.GetString(25);
                    if (!dataReader.IsDBNull(8))
                    {
                        txtSubject2.Text = dataReader.GetString(8);
                    }
                    else txtSubject2.Text = "";

                    if (!dataReader.IsDBNull(10))
                    {
                        txtSupComments2.Text = dataReader.GetString(10);
                    }
                    else txtSupComments2.Text = "";


                    if (!dataReader.IsDBNull(11))
                    {
                        txtEmployeeComments2.Text = dataReader.GetString(11);
                    }
                    else txtEmployeeComments2.Text = "";

                    //if (!dataReader.IsDBNull(13))
                    //{
                    //    txtFollowUp.Text = dataReader.GetString(13);
                    //}
                    //else txtFollowUp.Text = "";

                    //Get Disciplinary Count, Reference ID

                    if (!dataReader.IsDBNull(18))
                    {
                        lblGetReferenceID2.Text = "" + dataReader.GetInt32(18);
                    }
                    else lblGetReferenceID2.Text = "";
                    if (!dataReader.IsDBNull(19))
                    {
                        lblGetDisciplinaryCount2.Text = "" + dataReader.GetInt32(19);
                    }
                    else lblGetDisciplinaryCount2.Text = "";

                    txtOverallStatus2.Text = dataReader.GetString(21);
                    if (txtOverallStatus2.Text == "Initiated Disciplinary Action" ||
                        txtOverallStatus2.Text == "Disciplinary Action Sent to Department" ||
                        txtOverallStatus2.Text == "Waiting for Sup Acknowledgement Disciplinary" ||
                        txtOverallStatus2.Text == "Waiting for EE Acknowledgement Disciplinary")
                    {
                        txtEEAck2.Text = "Form has not been acknowledged by emplpoyee electronically.";
                        txtSup1Ack2.Text = "Form has not been signed by supervisor electronically.";
                        txtSup2Ack2.Text = "Form has not been signed by supervisor electronically.";
                        txtHRAck2.Text = "Form has not been signed by HR electronically.";
                        txtEEAckDate2.Text = "N/A";
                        txtSup1AckDate2.Text = "N/A";
                        txtSup2AckDate2.Text = "N/A";
                        txtHRAckDate2.Text = "N/A";
                    }
                    else if (txtOverallStatus2.Text == "Sent to HRM for Final Review")
                    {
                        //Bottom Data

                        //EE Acknowledgement
                        if (!dataReader.IsDBNull(32))
                        {
                            txtEEAck2.Text = dataReader.GetString(32);
                        }
                        else txtEEAck2.Text = "";
                        if (!dataReader.IsDBNull(33))
                        {
                            txtEEAckDate2.Text = dataReader.GetDateTime(33).ToString();
                        }
                        else txtEEAckDate2.Text = "";
                        //Sup1 Acknowledgement
                        if (!dataReader.IsDBNull(34))
                        {
                            txtSup1Ack2.Text = dataReader.GetString(34);
                        }
                        else txtSup1Ack2.Text = "";
                        if (!dataReader.IsDBNull(35))
                        {
                            txtSup1AckDate2.Text = dataReader.GetDateTime(35).ToString();
                    }
                        else txtSup1AckDate2.Text = "";
                        //Sup2 Acknowledgement
                        if (!dataReader.IsDBNull(43))
                        {
                            txtSup2Ack2.Text = dataReader.GetString(43);
                        }
                        else txtSup2Ack2.Text = "";
                        if (!dataReader.IsDBNull(44))
                        {
                            txtSup2AckDate2.Text = dataReader.GetDateTime(44).ToString();
                    }
                        else txtSup2AckDate2.Text = "";
                        //HR Acknowledgement
                        txtHRAck2.Text = "Form has not been signed by HR electronically.";
                        txtHRAckDate2.Text = "N/A";


                    }
                    else if (txtOverallStatus2.Text == "Disciplinary Action Closed")
                    {
                        //Bottom Data
                        //EE Acknowledgement
                        if (!dataReader.IsDBNull(32))
                        {
                            txtEEAck2.Text = dataReader.GetString(32);
                        }
                        else txtEEAck2.Text = "";
                        if (!dataReader.IsDBNull(33))
                        {
                            txtEEAckDate2.Text = dataReader.GetDateTime(33).ToString();
                        }
                        else txtEEAckDate2.Text = "";
                        //Sup1 Acknowledgement
                        if (!dataReader.IsDBNull(34))
                        {
                            txtSup1Ack2.Text = dataReader.GetString(34);
                        }
                        else txtSup1Ack2.Text = "";
                        if (!dataReader.IsDBNull(35))
                        {
                            txtSup1AckDate2.Text = dataReader.GetDateTime(35).ToString();
                        }
                        else txtSup1AckDate2.Text = "";
                        //Sup2 Acknowledgement
                        if (!dataReader.IsDBNull(43))
                        {
                            txtSup2Ack2.Text = dataReader.GetString(43);
                        }
                        else txtSup2Ack2.Text = "";
                        if (!dataReader.IsDBNull(44))
                        {
                            txtSup2AckDate2.Text = dataReader.GetDateTime(44).ToString();
                        }
                        else txtSup2AckDate2.Text = "";
                        //HR Acknowledgement
                        if (!dataReader.IsDBNull(30))
                        {
                            txtHRAck2.Text = dataReader.GetString(30);
                        }
                        else txtHRAck2.Text = "";
                        if (!dataReader.IsDBNull(31))
                        {
                            txtHRAckDate2.Text = dataReader.GetDateTime(31).ToString();
                        }
                        else txtHRAckDate2.Text = "";

                    }
                    else
                    {

                    }



                }
                //Response.Write(Output);
                dataReader.Close();
                command.Dispose();
                cnn.Close();

            

            PrintedOn2.Text = System.DateTime.Now.ToString();
            PrintedBy2.Text = GetUserFullName(id2.GetDomain(), id2.GetLogin());

            if (txtEmployeeStatus2.Text == "Introductory")
            {
                C11.Visible = false;
                C12.Visible = false;
                C13.Visible = false;
                C14.Visible = false;
                C21.Visible = false;
                C22.Visible = false;
                C23.Visible = false;
                C24.Visible = false;
                //Termination upon level 4.
                probL3.Text = "(Termination)";
            }
            else if (txtEmployeeStatus2.Text == "Part-Time")
            {
                C11.Visible = false;
                C12.Visible = false;
                C13.Visible = false;
                C14.Visible = false;
                C21.Visible = false;
                C22.Visible = false;
                C23.Visible = false;
                C24.Visible = false;
                //Only has 3 levels for Part-Timers
            }
            else
            {
                //Shows everything for Full-Time
            }

            //Fill Up Disciplinary Table
            //Check Employee_Status & Disciplinary_Count
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();
            //Response.Write("Connection Made");

            SqlCommand command1 = new SqlCommand("SELECT * FROM dbo.[Corrective_Action] WHERE [Reference_ID] = '" +
                lblGetReferenceID2.Text + "' AND [EE_ID] = '" + txtEmployeeID2.Text + "'", cnn);
            SqlDataReader dataReader1;
            //String Output = " ";
            dataReader1 = command1.ExecuteReader();
            while (dataReader1.Read())
            {
                //LISTS UP THE DATES
                if ((dataReader1["Corrective_Action"]).ToString() == "1")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox82.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox82.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "2")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox92.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox92.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "3")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox102.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox102.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "4")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox112.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox112.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "5")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox122.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox122.Text = "";
                }
                //LISTS UP SUBJECTS
                if ((dataReader1["Corrective_Action"]).ToString() == "1")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox132.Text = dataReader1.GetString(3);
                    }
                    else TextBox132.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "2")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox142.Text = dataReader1.GetString(3);
                    }
                    else TextBox142.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "3")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox152.Text = dataReader1.GetString(3);
                    }
                    else TextBox152.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "4")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox162.Text = dataReader1.GetString(3);
                    }
                    else TextBox162.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "5")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox172.Text = dataReader1.GetString(3);
                    }
                    else TextBox172.Text = "";
                }
            }
            //Response.Write(Output);
            dataReader1.Close();
            command1.Dispose();
            cnn.Close();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string myConnection;
            SqlConnection cnn;
            myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            cnn = new SqlConnection(myConnection);
            cnn.Open();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    System.Web.UI.WebControls.CheckBox chkRow = (row.Cells[0].FindControl("chkRow1") as System.Web.UI.WebControls.CheckBox);
                    if (chkRow.Checked)
                    {
                        // Get the PrintRequest_ID
                        string id = row.Cells[2].Text;
                        //PRHistory.Text = id;
                        //BindGrid every time using the RowID Call for BindGrid2 -- rebinding panel
                        //this.BindGrid2(id);



                        SqlCommand command = new SqlCommand("UPDATE dbo.[PrintRequests_CA] SET [PrintRequest_Status] = 'Ready' " +
                            " WHERE [PrintRequest_ID] = '" + id + "'", cnn);

                        command.ExecuteNonQuery();
                    }
                }
            }

            cnn.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "hideMeModal3();", true);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                            "hideMeModal3();", true);
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

                //Get the value of column from the DataKeys using the RowIndex.
                int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

                //PRHistory.Text = id;

                Response.Redirect("~/General/DisciplinaryDetailOnly.aspx?id=" + id + "", false);
                //Response.Redirect("/Supervisors/Detail.aspx");
                //Context.ApplicationInstance.CompleteRequest();

        }
    }
}