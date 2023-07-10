using Azure;
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

namespace lewHRISlocal
{
    public partial class AddBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit(object sender, EventArgs e)
        {
            string query = "INSERT INTO [Blogs] VALUES (@Title, @Date_Entered, @Body)";
            string conString = ConfigurationManager.ConnectionStrings["LEW_HRIS_LocalConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Date_Entered", System.DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@Body", txtBody.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}