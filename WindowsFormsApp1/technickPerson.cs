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
    public partial class technickPerson : Form
    {
        Class1 db = new Class1();
        private MySqlDataAdapter adapter = null;
        private DataSet dataSet = null;

        public technickPerson()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            technickCabinet techCab = new technickCabinet();
            techCab.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            technikForm techForm = new technikForm();
            techForm.Show();
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
               

                MySqlCommand command = new MySqlCommand("SELECT person.idperson AS `id`, person.surname AS `Фамилия`, person.name AS `Имя`, person.patronymic AS `Отчество`, person.phone AS `Телефон`, position.name_position AS `Должность`FROM person, position WHERE person.idposition = position.idposition", db.getConnection());
                adapter.SelectCommand = command;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "person");


                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);


                dataGridView1.DataSource = dataSet.Tables["person"];
                dataGridView1.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void technickPerson_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT person.idperson AS `id`, person.surname AS `Фамилия`, person.name AS `Имя`, person.patronymic AS `Отчество`, person.phone AS `Телефон`, position.name_position AS `Должность`FROM person, position WHERE person.idposition = position.idposition", db.getConnection());
                adapter.SelectCommand = command;

                string idperson = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `person` WHERE `idperson` = @lU", db.getConnection());
                command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = idperson;
                adapter1.SelectCommand = command1;




                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "person");
                adapter1.Fill(dataSet, "person");
                dataSet.Tables["person"].Clear();
                adapter.Fill(dataSet, "person");
                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);
                dataGridView1.DataSource = dataSet.Tables["person"];
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

                MySqlCommand command = new MySqlCommand("SELECT person.idperson AS `id`, person.surname AS `Фамилия`, person.name AS `Имя`, person.patronymic AS `Отчество`, person.phone AS `Телефон`, position.name_position AS `Должность`FROM person, position WHERE person.idposition = position.idposition", db.getConnection());
                adapter.SelectCommand = command;



                //int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string idperson = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string surname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string patronymic = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string phone = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `person` ( `surname`, `name`, `patronymic`, `phone`, `idposition`) VALUES ( @1U, @2U, @3U, @4U, '8' )", db.getConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = idperson;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = surname;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = name;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = patronymic;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = phone;

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "person");

                adapter1.Fill(dataSet, "person");
                dataSet.Tables["person"].Clear();
                adapter.Fill(dataSet, "person");
                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataSet.Tables["person"];
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

                MySqlCommand command = new MySqlCommand("SELECT person.idperson AS `id`, person.surname AS `Фамилия`, person.name AS `Имя`, person.patronymic AS `Отчество`, person.phone AS `Телефон`, position.name_position AS `Должность`FROM person, position WHERE person.idposition = position.idposition", db.getConnection());
                adapter.SelectCommand = command;



                //int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string idperson = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string surname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string patronymic = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string phone = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("update `person` SET `surname` = @1U, `name` = @2U , `patronymic` = @3U, `phone` = @4U, `idposition` = 8 WHERE `idperson` = @0U", db.getConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = idperson;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = surname;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = name;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = patronymic;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = phone;

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "person");

                adapter1.Fill(dataSet, "person");
                dataSet.Tables["person"].Clear();
                adapter.Fill(dataSet, "person");
                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataSet.Tables["person"];
                dataGridView1.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
