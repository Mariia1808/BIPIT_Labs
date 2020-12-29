using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");
            DataSet ds = client.GetTex_obslysh();
            dataGridView1.DataSource = ds.Tables["Tex_obslysh"];
            dataGridView1.Update();
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy hh:mm";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker2.Value.ToString("yyyy-MM-dd hh:mm"));
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");
                client.Insert(dateTimePicker2.Value.ToString("dd-MM-yyyy hh:mm"), textBox1.Text, textBox2.Text);
                DataSet ds = client.GetTex_obslysh();
                dataGridView1.DataSource = ds.Tables["Tex_obslysh"];
                dataGridView1.Update();
            }
            else
            {
                MessageBox.Show("Ошибка!!! Заполните пустые поля!!!");
            }          
        }       
    }
}
