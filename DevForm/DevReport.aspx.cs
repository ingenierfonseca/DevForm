using DevExpress.XtraReports.UI;
using DevForm.SSRR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevForm
{
    public partial class DevReport : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\Users\DELL\documents\visual studio 2015\Projects\DevForm\DevForm\App_Data\LogicalData.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.ConnectionString = connectionString;//System.Configuration.ConfigurationManager.ConnectionStrings["LogicalData.mdf"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "PcdUserConsult";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Identificacion", SqlDbType.VarChar);
                    cmd.Parameters["@Identificacion"].Value = "m-0001";
                    try
                    {
                        con.Open();

                        XtraReport2 report = new XtraReport2();
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        report.DataSource = ds;

                        //ASPxWebDocumentViewer1.wr
                        /*XtraReport report = new XtraReport();
                        report.DataSource = ds;
                        ASPxWebDocumentViewer1. = report;*/
                        
                        ASPxWebDocumentViewer1.ReportSourceId = report.XmlDataPath;
                        ASPxWebDocumentViewer1.OpenReport(report);
                        report.CreateDocument();
                    //ASPxWebDocumentViewer1.ReportSourceId
                    } catch(Exception ex)
                    {

                    } 
                    finally
                    {
                    con.Close();
                    }
                }
            }
        }
    }
}