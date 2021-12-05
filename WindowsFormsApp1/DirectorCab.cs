using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class DirectorCab : Form
    {
        Class1 db = new Class1();

        public DirectorCab()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DirectorForm directorForm = new DirectorForm();
            directorForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DirectorForm1 directorForm1 = new DirectorForm1();
            directorForm1.Show();
        }

        private void LoadData()
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();


                MySqlCommand command = new MySqlCommand("SELECT idcabinet AS id, number_cab AS `Номер`, name_cab AS `Название`, floor AS `Этаж` FROM cabinet", db.getConnection());
                adapter.SelectCommand = command;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "cabinet");


                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);


                dataGridView1.DataSource = dataSet.Tables["cabinet"];
                dataGridView1.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void DirectorCab_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            

        }
    }
}
