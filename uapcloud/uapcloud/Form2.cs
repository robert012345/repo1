using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace uapcloud
{
    public partial class Form2 : Form
    {
            NpgsqlConnection Cn;
            DataTable dt=new DataTable();
            NpgsqlDataAdapter da;
           
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            Cn = new NpgsqlConnection("Server=c1.east1.stormdb.us;Port=5432;Database=r1401309084;User Id=admin;Password=3Y2u9jGuEv;ssl=true");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            da = new NpgsqlDataAdapter("insert into alumno(nombre,dni) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "')", Cn);
            da.Fill(dt);
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
