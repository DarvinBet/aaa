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
    public partial class technikForm : Form
    {
        Class1 db = new Class1();
        private MySqlDataAdapter adapter = null;
        private MySqlCommandBuilder builder = null;
        private DataSet dataSet = null;
       

        public technikForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            technikForm techForm = new technikForm();
            techForm.Show();
        }

        private void LoadData()
        {
            try
            {
                
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlDataAdapter adapterP = new MySqlDataAdapter();
                MySqlDataAdapter adapterV = new MySqlDataAdapter();
                MySqlDataAdapter adapterC = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT techtable.idtechtable AS id, techtable.in_number AS Инвентарный_№, techtable.name_tech AS Информация_о_технике_и_характерристика, techtable.date_buy AS Дата_покупки, techtable.cost AS Цена, techtable.status AS Статус, techtable.date_write_off AS Дата_списания,  cabinet.number_cab AS Кабинет, view.name_view AS Вид, person.surname AS Фамилия  FROM techtable, cabinet, view, person WHERE techtable.idview = view.idview AND techtable.idcabinet = cabinet.idcabinet AND techtable.idperson = person.idperson", db.getConnection());
                adapter.SelectCommand = command;
                MySqlCommand commandP = new MySqlCommand("SELECT `surname` FROM `person`", db.getConnection());
                adapterP.SelectCommand = commandP;
                MySqlCommand commandV = new MySqlCommand("SELECT `name_view` FROM `view`", db.getConnection());
                adapterV.SelectCommand = commandV;
                MySqlCommand commandC = new MySqlCommand("SELECT `number_cab` FROM `cabinet`", db.getConnection());
                adapterC.SelectCommand = commandC;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "techtable");
                DataSet dataSetP = new DataSet();
                adapterP.Fill(dataSetP, "person");
                DataSet dataSetV = new DataSet();
                adapterV.Fill(dataSetV, "view");
                DataSet dataSetC = new DataSet();
                adapterC.Fill(dataSetC, "cabinet");

                DataRow dr = dataSet.Tables[0].NewRow();                
                dataSet.Tables[0].Rows.Add(dr);

                

                dataGridView1.DataSource = dataSet.Tables["techtable"];
                dataGridView1.AutoResizeColumns();

                for (int i = 0; i < dataSetC.Tables["cabinet"].Rows.Count; i++)
                {
                    comboBox2.Items.Add(dataSetC.Tables["cabinet"].Rows[i]["number_cab"]);
                }

                //comboBox3.DataSource = dataSetP.Tables["person"];
                for (int i = 0; i < dataSetP.Tables["person"].Rows.Count; i++)
                {
                    comboBox3.Items.Add(dataSetP.Tables["person"].Rows[i]["surname"]);
                }


                //comboBox4.DataSource = dataSetV.Tables["view"];
                for (int i = 0; i < dataSetV.Tables["view"].Rows.Count; i++)
                {
                    comboBox4.Items.Add(dataSetV.Tables["view"].Rows[i]["name_view"]);
                }

                for (int i = 0; i < dataSetV.Tables["view"].Rows.Count; i++)
                {
                    comboBox1.Items.Add(dataSetV.Tables["view"].Rows[i]["name_view"]);
                }
                textBox1.Text = Form1.quantity;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        

        private void technikForm_Load(object sender, EventArgs e)
        {
            
            LoadData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT techtable.idtechtable AS id, techtable.in_number AS Инвентарный_№, techtable.name_tech AS Информация_о_технике_и_характерристика, techtable.date_buy AS Дата_покупки, techtable.cost AS Цена, techtable.status AS Статус, techtable.date_write_off AS Дата_списания,  cabinet.number_cab AS Кабинет, view.name_view AS Вид, person.surname AS Фамилия  FROM techtable, cabinet, view, person WHERE techtable.idview = view.idview AND techtable.idcabinet = cabinet.idcabinet AND techtable.idperson = person.idperson", db.getConnection());
                adapter.SelectCommand = command;
                //int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string idtechtable = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string in_numb = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name_tech = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                string date_buy = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                

                if (date_buy != "")
                {
                    date_buy = DateTime.Parse(date_buy).ToString("yyyyMMdd");
                    //date_buy.ToShortDateString();
                }
                else
                {
                    date_buy = null;
                }

                //MessageBox.Show(idtechtable);


                string cost = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string status = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string date_write_off = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                
                if (date_write_off != "")
                {
                    date_write_off = DateTime.Parse(date_write_off).ToString("yyyyMMdd");
                    //date_buy.ToShortDateString();
                }
                else
                {
                    date_write_off = null;
                }


                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("UPDATE `techtable` SET `in_number` =  @1U ,  `name_tech` = @2U  , `date_buy` = @3U, `cost` = @4U, `status` =@5U, `date_write_off` = @6U  WHERE `idtechtable` = @0U", db.getConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = idtechtable;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = in_numb;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = name_tech;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = date_buy;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = cost;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = status;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = date_write_off;
                
                adapter1.SelectCommand = command1;

                
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "techtable");
                
                adapter1.Fill(dataSet, "techtable");
                dataSet.Tables["techtable"].Clear();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                       
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
                   }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT techtable.idtechtable AS id, techtable.in_number AS Инвентарный_№, techtable.name_tech AS Информация_о_технике_и_характерристика, techtable.date_buy AS Дата_покупки, techtable.cost AS Цена, techtable.status AS Статус, techtable.date_write_off AS Дата_списания,  cabinet.number_cab AS Кабинет, view.name_view AS Вид, person.surname AS Фамилия  FROM techtable, cabinet, view, person WHERE techtable.idview = view.idview AND techtable.idcabinet = cabinet.idcabinet AND techtable.idperson = person.idperson", db.getConnection());
                adapter.SelectCommand = command;

                string in_numb = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `techtable` WHERE `in_number` = @lU", db.getConnection());
                command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = in_numb;
                adapter1.SelectCommand = command1;
                



                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "techtable");
                adapter1.Fill(dataSet, "techtable");
                dataSet.Tables["techtable"].Clear();
                adapter.Fill(dataSet, "techtable");
                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);
                dataGridView1.DataSource = dataSet.Tables["techtable"];
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
                MySqlDataAdapter adapterC = new MySqlDataAdapter();
                MySqlDataAdapter adapterV = new MySqlDataAdapter();
                MySqlDataAdapter adapterP = new MySqlDataAdapter();
                MySqlCommand commandC = new MySqlCommand("SELECT idcabinet FROM cabinet WHERE number_cab = @CU", db.getConnection());
                MySqlCommand commandV = new MySqlCommand("SELECT idview FROM view WHERE name_view = @VU", db.getConnection());
                MySqlCommand commandP = new MySqlCommand("SELECT idperson FROM person WHERE surname = @PU", db.getConnection());
                MySqlCommand command = new MySqlCommand("SELECT techtable.idtechtable AS id, techtable.in_number AS Инвентарный_№, techtable.name_tech AS Информация_о_технике_и_характерристика, techtable.date_buy AS Дата_покупки, techtable.cost AS Цена, techtable.status AS Статус, techtable.date_write_off AS Дата_списания,  cabinet.number_cab AS Кабинет, view.name_view AS Вид, person.surname AS Фамилия  FROM techtable, cabinet, view, person WHERE techtable.idview = view.idview AND techtable.idcabinet = cabinet.idcabinet AND techtable.idperson = person.idperson", db.getConnection());

                string cabinet1 = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                string person1 = comboBox3.Items[comboBox3.SelectedIndex].ToString();
                string view1 = comboBox4.Items[comboBox4.SelectedIndex].ToString();
                commandC.Parameters.Add("@CU", MySqlDbType.VarChar).Value = cabinet1;
                commandV.Parameters.Add("@VU", MySqlDbType.VarChar).Value = view1;
                commandP.Parameters.Add("@PU", MySqlDbType.VarChar).Value = person1;

                adapter.SelectCommand = command;
                adapterC.SelectCommand = commandC;
                adapterV.SelectCommand = commandV;
                adapterP.SelectCommand = commandP;

                // -------DataTable создается чтобы выбранную в combobox строку связать с параметром id

                DataTable tableC = new DataTable();
                DataTable tableV = new DataTable();
                DataTable tableP = new DataTable();

                adapterC.Fill(tableC);
                adapterV.Fill(tableV);
                adapterP.Fill(tableP);

                int cabinet = tableC.Rows[0].Field<int>("idcabinet"); 
                int view = tableV.Rows[0].Field<int>("idview");
                int person = tableP.Rows[0].Field<int>("idperson");

                //-----------------------------------------------------------
                               
                //int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string idtechtable = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string in_numb = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name_tech = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                string date_buy = dataGridView1.CurrentRow.Cells[3].Value.ToString();


                if (date_buy != "")
                {
                    date_buy = DateTime.Parse(date_buy).ToString("yyyyMMdd");
                    //date_buy.ToShortDateString();
                }
                else
                {
                    date_buy = null;
                }

                //MessageBox.Show(idtechtable);


                string cost = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string status = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string date_write_off = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                if (date_write_off != "")
                {
                    date_write_off = DateTime.Parse(date_write_off).ToString("yyyyMMdd");
                    //date_buy.ToShortDateString();
                }
                else
                {
                    date_write_off = null;
                }

                
                


                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `techtable` (`in_number`, `name_tech`, `date_buy`, `cost`, `status`, `date_write_off`, `idcabinet`, `idview`, `idperson`) VALUES (@1U, @2U, @3U, @4U, @5U, @6U, @7U, @8U, @9U)", db.getConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = idtechtable;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = in_numb;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = name_tech;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = date_buy;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = cost;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = status;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = date_write_off;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = cabinet;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = view;
                command1.Parameters.Add("@9U", MySqlDbType.VarChar).Value = person;

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "techtable");

                adapter1.Fill(dataSet, "techtable");
                dataSet.Tables["techtable"].Clear();
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            technickCabinet techCab = new technickCabinet();
            techCab.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            technickPerson techPers = new technickPerson();
            techPers.Show();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button7_Click_1(object sender, EventArgs e)
        {
            Report4 rep4 = new Report4();
            rep4.Show();
        }
    }
}
