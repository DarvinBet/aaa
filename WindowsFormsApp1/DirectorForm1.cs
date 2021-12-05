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
    public partial class DirectorForm1 : Form
    {
        Class1 db = new Class1();

        public DirectorForm1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DirectorForm directorForm = new DirectorForm();
            directorForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DirectorCab dirCab = new DirectorCab();
            dirCab.Show();
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

        private void DirectorForm1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
