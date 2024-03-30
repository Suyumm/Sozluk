using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;



namespace WindowsFormsApp2
{

    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection fiydan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\DataBase2.accdb");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fiydan.Open();
            OleDbCommand ekle = new OleDbCommand("insert into sözlük(İngilizce,Türkçe)values('" + textBox1.Text + "','" + textBox2.Text + "')", fiydan);
            ekle.ExecuteNonQuery();
            fiydan.Close();

            MessageBox.Show("Bilgi Kaydedildi");
            textBox1.Clear();
            textBox2.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fiydan.Open();
            OleDbCommand guncelle = new OleDbCommand("update sözlük set Türkçe='" + textBox2.Text + "'where İngilizce='" + textBox1.Text + "'", fiydan);
            guncelle.ExecuteNonQuery();
            fiydan.Close();

            MessageBox.Show("Bilgi Güncellendi");
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            fiydan.Open();
            OleDbCommand sil= new OleDbCommand("delete from sözlük where İngilizce = '" + textBox1.Text + "'", fiydan);
            sil.ExecuteNonQuery();
            fiydan.Close();

            MessageBox.Show("Bilgi Sİlindi");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            fiydan.Open();
            OleDbCommand ara = new OleDbCommand("select İngilizce,Türkçe from sözlük where İngilizce like '" + textBox1.Text + "%'", fiydan);

            OleDbDataReader oku = ara.ExecuteReader();

            while (oku.Read())
            {
                listBox1.Items.Add(oku["İngilizce"].ToString() + "|" + oku["Türkçe"].ToString());
            }
            fiydan.Close();
        }
    }
}
