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
    public partial class Form1 : Form
    {
        public static string quantity;

        public Form1()
        {
            InitializeComponent();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            int p;
            string t;
            String loginUser = loginField.Text;
            String passUser = passField.Text;
         
            Class1 db = new Class1();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `idposition` FROM `person` WHERE `login` = @lU AND `password` = @pU", db.getConnection());
            command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pU", MySqlDbType.VarChar).Value = passUser;
            

            adapter.SelectCommand = command;
            adapter.Fill(table);


            p=table.Rows[0].Field<int>("idposition");
            quantity = p.ToString();
            
            MessageBox.Show(quantity);


            if (table.Rows.Count>0)
            {
                if (table.Rows[0].Field<int>("idposition") == 1)
                {
                    this.Hide();
                    DirectorForm directorForm = new DirectorForm();
                    directorForm.Show();
                }
                if (table.Rows[0].Field<int>("idposition") == 3)
                {
                    this.Hide();
                    technikForm techForm = new technikForm();
                    techForm.Show();
                }
            }
            

            else
            {
                MessageBox.Show("Retry");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }
    }
}
