using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.Drawing;
using System.Security.Principal;
using Org.BouncyCastle.Tls;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.EnterpriseServices.Internal;
using Microsoft.Identity.Client;
using System.DirectoryServices;
using AjaxControlToolkit;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Web.Services.Description;
//using Microsoft.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.UI.WebControls.WebParts;
//using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Common;
using System.Security.Policy;
using DocumentFormat.OpenXml.Spreadsheet;

namespace lewHRISlocal
{
   
    public partial class DisciplinePrint : System.Web.UI.Page
    {
        public static string GetUserFullName(string domain, string userName)
        {
            //// set up domain context
            //using (var connection = new DirectoryEntry())
            //{
            //    using (var search = new DirectorySearcher(connection)
            //    {
            //        Filter = "(samaccountname=" + userName + ")",
            //        PropertiesToLoad = { "displayname" },
            //    })
            //    {
            //        return (string)search.FindOne().Properties["displayname"][0];
            //    }
            //}
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);

            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);



            return user.GivenName + " " + user.Surname;
        }


        string supUserName;

        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id2 = HttpContext.Current.User.Identity;
            string id = Request.QueryString["id"];

            string supFullName;

            txtCounselingID.Text = id;

            string myConnection;
            SqlConnection cnn;

            if (!IsPostBack)
            {
                //txtSupComments.Text = id2.GetDomain() + " " + id2.GetLogin();
                //txtSubject.Text = GetUserFullName(id2.GetDomain(), id2.GetLogin());
                
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
                    txtDateIncident.Text = dataReader.GetDateTime(3).ToString();
                    txtEmployeeID.Text = "" + dataReader.GetInt32(1);
                    txtPosition.Text = dataReader.GetString(42);
                    txtEmployeeName.Text = dataReader.GetString(4); 
                    txtDepartment.Text = dataReader.GetString(5);
                    txtEmployeeStatus.Text = dataReader.GetString(25);
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

                    //if (!dataReader.IsDBNull(13))
                    //{
                    //    txtFollowUp.Text = dataReader.GetString(13);
                    //}
                    //else txtFollowUp.Text = "";

                    //Get Disciplinary Count, Reference ID
                    
                    if (!dataReader.IsDBNull(18))
                    {
                        lblGetReferenceID.Text = "" + dataReader.GetInt32(18);
                    }
                    else lblGetReferenceID.Text = "";
                    if (!dataReader.IsDBNull(19))
                    {
                        lblGetDisciplinaryCount.Text = "" + dataReader.GetInt32(19);
                    }
                    else lblGetDisciplinaryCount.Text = "";

                    txtOverallStatus.Text = dataReader.GetString(21);
                    if (txtOverallStatus.Text == "Initiated Disciplinary Action" || 
                        txtOverallStatus.Text == "Disciplinary Action Sent to Department" ||
                        txtOverallStatus.Text == "Waiting for Sup Acknowledgement Disciplinary" ||
                        txtOverallStatus.Text == "Waiting for EE Acknowledgement Disciplinary")
                    {
                        txtEEAck.Text = "Form has not been acknowledged by emplpoyee electronically.";
                        txtSup1Ack.Text = "Form has not been signed by supervisor electronically.";
                        txtSup2Ack.Text = "Form has not been signed by supervisor electronically.";
                        txtHRAck.Text = "Form has not been signed by HR electronically.";
                        txtEEAckDate.Text = "N/A";
                        txtSup1AckDate.Text = "N/A";
                        txtSup2AckDate.Text = "N/A";
                        txtHRAckDate.Text = "N/A";
                    }
                    else if (txtOverallStatus.Text == "Sent to HRM for Final Review")
                    {
                        //Bottom Data
                        
                    //EE Acknowledgement
                        if (!dataReader.IsDBNull(32))
                        {
                            txtEEAck.Text = dataReader.GetString(32);
                        }
                        else txtEEAck.Text = "";
                        if (!dataReader.IsDBNull(33))
                        {
                            txtEEAckDate.Text = dataReader.GetString(33);
                        }
                        else txtEEAckDate.Text = "";
                    //Sup1 Acknowledgement
                        if (!dataReader.IsDBNull(34))
                        {
                            txtSup1Ack.Text = dataReader.GetString(34);
                        }
                        else txtSup1Ack.Text = "";
                        if (!dataReader.IsDBNull(35))
                        {
                            txtSup1AckDate.Text = dataReader.GetString(35);
                        }
                        else txtSup1AckDate.Text = "";
                    //Sup2 Acknowledgement
                        if (!dataReader.IsDBNull(43))
                        {
                            txtSup2Ack.Text = dataReader.GetString(43);
                        }
                        else txtSup2Ack.Text = "";
                        if (!dataReader.IsDBNull(44))
                        {
                            txtSup2AckDate.Text = dataReader.GetString(44);
                        }
                        else txtSup2AckDate.Text = "";
                    //HR Acknowledgement
                        txtHRAck.Text = "Form has not been signed by HR electronically.";
                        txtHRAckDate.Text = "N/A";


                    }
                    else if (txtOverallStatus.Text == "Disciplinary Action Closed")
                    {
                        //Bottom Data
                    //EE Acknowledgement
                        if (!dataReader.IsDBNull(32))
                        {
                            txtEEAck.Text = dataReader.GetString(32);
                        }
                        else txtEEAck.Text = "";
                        if (!dataReader.IsDBNull(33))
                        {
                            txtEEAckDate.Text = dataReader.GetDateTime(33).ToString();
                        }
                        else txtEEAckDate.Text = "";
                    //Sup1 Acknowledgement
                        if (!dataReader.IsDBNull(34))
                        {
                            txtSup1Ack.Text = dataReader.GetString(34);
                        }
                        else txtSup1Ack.Text = "";
                        if (!dataReader.IsDBNull(35))
                        {
                            txtSup1AckDate.Text = dataReader.GetDateTime(35).ToString();
                        }
                        else txtSup1AckDate.Text = "";
                    //Sup2 Acknowledgement
                        if (!dataReader.IsDBNull(43))
                        {
                            txtSup2Ack.Text = dataReader.GetString(43);
                        }
                        else txtSup2Ack.Text = "";
                        if (!dataReader.IsDBNull(44))
                        {
                            txtSup2AckDate.Text = dataReader.GetDateTime(44).ToString();
                        }
                        else txtSup2AckDate.Text = "";
                    //HR Acknowledgement
                        if (!dataReader.IsDBNull(30))
                        {
                            txtHRAck.Text = dataReader.GetString(30);
                        }
                        else txtHRAck.Text = "";
                        if (!dataReader.IsDBNull(31))
                        {
                            txtHRAckDate.Text = dataReader.GetDateTime(31).ToString();
                        }
                        else txtHRAckDate.Text = "";

                    }
                    else
                    {

                    }



                }
                //Response.Write(Output);
                dataReader.Close();
                command.Dispose();
                cnn.Close();

            }

            PrintedOn.Text = System.DateTime.Now.ToString();
            PrintedBy.Text = GetUserFullName(id2.GetDomain(), id2.GetLogin());

            if (txtEmployeeStatus.Text == "Introductory")
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
            else if (txtEmployeeStatus.Text == "Part-Time")
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

            SqlCommand command1 = new SqlCommand("SELECT * FROM [Corrective_Action] WHERE [Reference_ID] = " + lblGetReferenceID.Text + " AND [EE_ID] = " + txtEmployeeID.Text + "", cnn);
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
                        TextBox8.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox8.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "2")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox9.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox9.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "3")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox10.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox10.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "4")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox11.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox11.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "5")
                {
                    if (!dataReader1.IsDBNull(0))
                    {
                        TextBox12.Text = dataReader1.GetDateTime(0).ToString();
                    }
                    else TextBox12.Text = "";
                }
                //LISTS UP SUBJECTS
                if ((dataReader1["Corrective_Action"]).ToString() == "1")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox13.Text = dataReader1.GetString(3);
                    }
                    else TextBox13.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "2")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox14.Text = dataReader1.GetString(3);
                    }
                    else TextBox14.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "3")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox15.Text = dataReader1.GetString(3);
                    }
                    else TextBox15.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "4")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox16.Text = dataReader1.GetString(3);
                    }
                    else TextBox16.Text = "";
                }
                if ((dataReader1["Corrective_Action"]).ToString() == "5")
                {
                    if (!dataReader1.IsDBNull(3))
                    {
                        TextBox17.Text = dataReader1.GetString(3);
                    }
                    else TextBox17.Text = "";
                }
            }
            //Response.Write(Output);
            dataReader1.Close();
            command1.Dispose();
            cnn.Close();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            
        }
    }
}