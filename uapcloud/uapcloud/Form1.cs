using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace uapcloud
{
    public partial class Form1 : Form
    {
        NpgsqlConnection Cn;
        DataTable dt;
        NpgsqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cn = new NpgsqlConnection("Server=c1.east1.stormdb.us;Port=5432;Database=r1401309084;User Id=admin;Password=3Y2u9jGuEv;ssl=true");
            da = new NpgsqlDataAdapter("select nombre,dni from alumno", Cn);
            dt = new DataTable();
                        try
            {
                Cn.Open();
                llenar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void Alineargrid()
        {
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[0].HeaderText = "Nombre de Alumno";
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[1].HeaderText = "D.N.I";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 F = new Form2();
            F.ShowDialog();
            if (F.DialogResult == DialogResult.OK)
            {
                llenar();
            }
        }
        private void llenar()
        {
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            Alineargrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            da = new NpgsqlDataAdapter("delete from alumno where nombre='" + this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'" , Cn);

            llenar();

        }
    }
}
