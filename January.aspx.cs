﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace GIT_
{
    public partial class January : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadExcel.HasFile)
            {
                try

                {
                    //Save File that have uploaded
                    FileUploadExcel.SaveAs(@"C:\Users\BSPT0765\source\repos\GIT_\GIT_\App_Data" + FileUploadExcel.FileName);
                    string path1 = @"C:\Users\BSPT0765\source\repos\GIT_\GIT_\App_Data" + FileUploadExcel.FileName;
                    string path = (Server.MapPath("/ExcelFile/" + FileUploadExcel.FileName));
                    FileUploadExcel.SaveAs(path);



                    string ExcelConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=Excel 4.0;";
                    OleDbConnection OleDBcon = new OleDbConnection(ExcelConnString);

                    //Using ole db to read file from excel 
                    OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$] ", OleDBcon);

                    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    objAdapter1.Fill(ds);

                    OleDBcon.Open();

                    // Create DbDataReader to Data Worksheet  
                    DbDataReader dr = cmd.ExecuteReader();

                    // SQL Server Connection String  
                    string ConnStr = "Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345";

                    // Bulk Copy to SQL Server
                    SqlBulkCopy bulkInsert = new SqlBulkCopy(ConnStr);

                    try
                    {
                        bulkInsert.DestinationTableName = "janlot";

                        SqlBulkCopyColumnMapping warehouse_ = new SqlBulkCopyColumnMapping("Warehouse", "warehouse");
                        bulkInsert.ColumnMappings.Add(warehouse_);

                        SqlBulkCopyColumnMapping lotno_ = new SqlBulkCopyColumnMapping("Lot Number", "lotno");
                        bulkInsert.ColumnMappings.Add(lotno_);

                        SqlBulkCopyColumnMapping country_ = new SqlBulkCopyColumnMapping("Country", "country");
                        bulkInsert.ColumnMappings.Add(country_);

                        bulkInsert.WriteToServer(dr);
                    }

                    catch (Exception labelex)
                    {
                        Response.Write("<script>alert('Data Duplicated/Error')</script>");
                        Response.Write(labelex);

                    }
                    OleDBcon.Close();

                    Response.Write("<script>alert('Data Inserted Successfully.')</script>");
                    UploadLabel.Text = FileUploadExcel.FileName + " Uploaded";
                }

                catch (Exception)
                {
                    Response.Write("<script>alert('Error occured. Data may duplicated.')</script>");
                    UploadLabel.Text = "Error while uploading excel file.";
                }
            }

            else
            {
                UploadLabel.Text = "No file uploaded";
            }

        }

    }
}