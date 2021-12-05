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

namespace WindowsFormsApp1
{
    public partial class technickCabinet : Form
    {
        Class1 db = new Class1();
        private MySqlDataAdapter adapter = null;
        private DataSet dataSet = null;


        public technickCabinet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            technikForm techForm = new technikForm();
            techForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void technickCabinet_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT idcabinet AS id, number_cab AS `Номер`, name_cab AS `Название`, floor AS `Этаж` FROM cabinet", db.getConnection());
                adapter.SelectCommand = command;

                string numb_cab = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `cabinet` WHERE `number_cab` = @lU", db.getConnection());
                command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = numb_cab;
                adapter1.SelectCommand = command1;




                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "cabinet");
                adapter1.Fill(dataSet, "cabinet");
                dataSet.Tables["cabinet"].Clear();
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT idcabinet AS id, number_cab AS `Номер`, name_cab AS `Название`, floor AS `Этаж` FROM cabinet", db.getConnection());
                adapter.SelectCommand = command;



                //int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string idcabinet = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string number_cab = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name_cab = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string floor = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `cabinet` ( `number_cab`, `name_cab`, `floor`) VALUES ( @1U, @2U, @3U)", db.getConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = idcabinet;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = number_cab;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = name_cab;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = floor;
                

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "cabinet");

                adapter1.Fill(dataSet, "cabinet");
                dataSet.Tables["cabinet"].Clear();
                adapter.Fill(dataSet, "cabinet");
                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataSet.Tables["cabinet"];
                dataGridView1.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT idcabinet AS id, number_cab AS `Номер`, name_cab AS `Название`, floor AS `Этаж` FROM cabinet", db.getConnection());
                adapter.SelectCommand = command;
                string idcabinet = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string number_cab = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name_cab = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string floor = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("update `cabinet` SET `number_cab` = @1U, `name_cab`=@2U, `floor`=@3U WHERE `idcabinet` = @0U", db.getConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = idcabinet;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = number_cab;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = name_cab;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = floor;


                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "cabinet");

                adapter1.Fill(dataSet, "cabinet");
                dataSet.Tables["cabinet"].Clear();
                adapter.Fill(dataSet, "cabinet");
                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataSet.Tables["cabinet"];
                dataGridView1.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            technickPerson techPers = new technickPerson();
            techPers.Show();
        }
    }
}
