using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RLDC_Report
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = @"SELECT  Departments.Id AS IdDepartmentId, Departments.Name AS DepartmentName, Employees.DepartmentId, Employees.Name, Employees.Address, Employees.MobileNumber
                            FROM   Departments INNER JOIN
                                    Employees ON Departments.Id = Employees.DepartmentId
                            WHERE  (Employees.DepartmentId = @Param1)";
            string departmentsQuery = @"SELECT Id, Name FROM Departments";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@Param1", DropDownDepartment.SelectedValue.ToString()));
            SqlDataAdapter s = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            s.Fill(dt);
            //ReportParameter parameter = new ReportParameter("ReportParameter1",);
            ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer.LocalReport.ReportPath = Server.MapPath("EmployeeReport.rdlc");
            ReportViewer.LocalReport.DataSources.Add(rds);
            ReportViewer.LocalReport.Refresh();
        }
    }
}