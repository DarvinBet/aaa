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
    public partial class Form2 : Form
    {
        Class1 db = new Class1();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string log = textBox1.Text;
            string pass = textBox2.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO person (Login, password) VALUES (@1, @2)", db.getConnection());

            adapter.SelectCommand = command;

            string Down = "abcdefghijklmnopqrstuvwxyz";
            string Up = "ABCDEFGIHJKLMNOPQRSTUVWXYZ";
            string Num = "1234567890";
            string Sym = "!@#$%^&*()-_=+";

            command.Parameters.Add("@1", MySqlDbType.VarChar).Value = log;
            command.Parameters.Add("@2", MySqlDbType.VarChar).Value = pass;

            if (pass.IndexOfAny(Up.ToCharArray()) == -1) 
            {
                MessageBox.Show("Минимум 1 строчная и прописная буквы, 1 цифра и символ");
            }
            else if (pass.IndexOfAny(Down.ToCharArray()) == -1) 
            {
                MessageBox.Show("Минимум 1 строчная и прописная буквы, 1 цифра и символ");
            }
            else if (pass.IndexOfAny(Num.ToCharArray()) == -1) 
            {
                MessageBox.Show("Минимум 1 строчная и прописная буквы, 1 цифра и символ");
            }
            else if (pass.IndexOfAny(Sym.ToCharArray()) == -1) 
            {
                MessageBox.Show("Минимум 1 строчная и прописная буквы, 1 цифра и символ");
            }
            else if (pass.Length < 6) 
            {
                MessageBox.Show("Слишком короткий пароль");

            }
            else
            {
                MessageBox.Show("Успешная регистрация");
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
            }

        }
    }
}
