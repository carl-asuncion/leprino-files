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
    public partial class CounselingPrint : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                //txtSupComments.Text = id2.GetDomain() + " " + id2.GetLogin();
                //txtSubject.Text = GetUserFullName(id2.GetDomain(), id2.GetLogin());
                string myConnection;
                SqlConnection cnn;
                myConnection = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
                cnn = new SqlConnection(myConnection);
                cnn.Open();
                //Response.Write("Connection Made");

                SqlCommand command = new SqlCommand("Select * from dbo.View_1 WHERE [Counseling_ID] = " + txtCounselingID.Text + "", cnn);
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

            PrintedOn.Text = System.DateTime.Now.ToString();
            PrintedBy.Text = GetUserFullName(id2.GetDomain(), id2.GetLogin());

            //txtEEAck.Text = txtEmployeeName.Text + " |";


            ////supUserName = txtSupUserName.Text;
            //if (txtSupUserName.Text != "")
            //{
            //    txtSupFin.Text = GetUserFullName(id2.GetDomain(), txtSupUserName.Text.ToString()) + " |";
            //}
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            
        }

    }
}