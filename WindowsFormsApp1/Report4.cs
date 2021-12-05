﻿using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Report4 : Form
    {
        Class1 db = new Class1();
        public Report4()
        {
            InitializeComponent();
        }

        private void Report4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DataSetR4.DataTable1". При необходимости она может быть перемещена или удалена.
            this.DataTable1TableAdapter.Fill(this.DataSetR4.DataTable1);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();



                MySqlCommand command = new MySqlCommand("SELECT techtable.idtechtable, techtable.in_number, techtable.name_tech, techtable.date_buy, techtable.cost, techtable.status, techtable.date_write_off,  cabinet.number_cab, person.surname FROM techtable, cabinet, person WHERE techtable.idcabinet = cabinet.idcabinet AND techtable.idperson = person.idperson AND techtable.date_buy >= @XU AND techtable.date_buy <= @YU", db.getConnection());



                string date1 = String.Format(dateTimePicker1.Value.ToString());

                if (date1 != "")
                {
                    date1 = DateTime.Parse(date1).ToString("yyyyMMdd");
                    //date_buy.ToShortDateString();
                }
                else
                {
                    date1 = null;
                }

                string date2 = String.Format(dateTimePicker2.Value.ToString());

                if (date2 != "")
                {
                    date2 = DateTime.Parse(date2).ToString("yyyyMMdd");
                    //date_buy.ToShortDateString();
                }
                else
                {
                    date2 = null;
                }



                command.Parameters.Add("@XU", MySqlDbType.VarChar).Value = date1;
                command.Parameters.Add("@YU", MySqlDbType.VarChar).Value = date2;

                adapter.SelectCommand = command;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "techtable");


                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);


                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSet.Tables["techtable"]));
                reportViewer1.LocalReport.ReportPath = @"C: \Users\me\source\repos\WindowsFormsApp1\WindowsFormsApp1\Report5.rdlc";
                reportViewer1.RefreshReport();





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
