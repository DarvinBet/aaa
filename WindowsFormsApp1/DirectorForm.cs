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
    public partial class DirectorForm : Form
    {
        Class1 db = new Class1();

        public DirectorForm()
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
                MySqlDataAdapter adapterV = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT techtable.idtechtable AS id, techtable.in_number AS Инвентарный_№, techtable.name_tech AS Информация_о_технике_и_характерристика, techtable.date_buy AS Дата_покупки, techtable.cost AS Цена, techtable.status AS Статус, techtable.date_write_off AS Дата_списания,  cabinet.number_cab AS Кабинет, view.name_view AS Вид, person.surname AS Фамилия  FROM techtable, cabinet, view, person WHERE techtable.idview = view.idview AND techtable.idcabinet = cabinet.idcabinet AND techtable.idperson = person.idperson", db.getConnection());
                adapter.SelectCommand = command;
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);


                MySqlCommand commandV = new MySqlCommand("SELECT `name_view` FROM `view`", db.getConnection());
                adapterV.SelectCommand = commandV;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "techtable");

                DataSet dataSetV = new DataSet();
                adapterV.Fill(dataSetV, "view");


                dataGridView1.DataSource = dataSet.Tables["techtable"];
                dataGridView1.AutoResizeColumns();


                for (int i = 0; i < dataSetV.Tables["view"].Rows.Count; i++)
                {
                    comboBox1.Items.Add(dataSetV.Tables["view"].Rows[i]["name_view"]);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DirectorForm1 directorForm1 = new DirectorForm1();
            directorForm1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                
                MySqlDataAdapter adapterVV = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT techtable.idtechtable AS id, techtable.in_number AS Инвентарный_№, techtable.name_tech AS Информация_о_технике_и_характерристика, techtable.date_buy AS Дата_покупки, techtable.cost AS Цена, techtable.status AS Статус, techtable.date_write_off AS Дата_списания,  cabinet.number_cab AS Кабинет, view.name_view AS Вид, person.surname AS Фамилия  FROM techtable, cabinet, view, person WHERE techtable.idview = view.idview AND techtable.idcabinet = cabinet.idcabinet AND techtable.idperson = person.idperson AND view.idview = @XU", db.getConnection());

                

                MySqlCommand commandVV = new MySqlCommand("SELECT idview FROM view WHERE name_view = @VU", db.getConnection());
                adapterVV.SelectCommand = commandVV;

                string view1 = comboBox1.Items[comboBox1.SelectedIndex].ToString();

                commandVV.Parameters.Add("@VU", MySqlDbType.VarChar).Value = view1;

                DataTable tableVV = new DataTable();

                adapterVV.Fill(tableVV);

                int view = tableVV.Rows[0].Field<int>("idview");

                command.Parameters.Add("@XU", MySqlDbType.VarChar).Value = view;

                adapter.SelectCommand = command;





                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "techtable");
                

                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);

                dataGridView1.DataSource = null;

                dataGridView1.DataSource = dataSet.Tables["techtable"];
                dataGridView1.AutoResizeColumns();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();



                MySqlCommand command = new MySqlCommand("SELECT techtable.idtechtable AS id, techtable.in_number AS Инвентарный_№, techtable.name_tech AS Информация_о_технике_и_характерристика, techtable.date_buy AS Дата_покупки, techtable.cost AS Цена, techtable.status AS Статус, techtable.date_write_off AS Дата_списания,  cabinet.number_cab AS Кабинет, view.name_view AS Вид, person.surname AS Фамилия  FROM techtable, cabinet, view, person WHERE techtable.idview = view.idview AND techtable.idcabinet = cabinet.idcabinet AND techtable.idperson = person.idperson AND techtable.date_buy >= @XU AND techtable.date_buy <= @YU", db.getConnection());



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

                dataGridView1.DataSource = null;

                dataGridView1.DataSource = dataSet.Tables["techtable"];
                dataGridView1.AutoResizeColumns();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
