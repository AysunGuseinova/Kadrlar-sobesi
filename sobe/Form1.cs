using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sobe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public SqlConnection con = new SqlConnection("data source=SEYMUR-PC\\SQLEXPRESS;initial catalog=sobe;integrated security=SSPI");
        SqlCommand com;
        SqlDataAdapter da;
        DataSet ds;
        Image foto;
        System.IO.MemoryStream ms;
        SqlParameter sp;
        string w;
        int R;
        string m;


        public int Nomre(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            int K = ds.Tables[0].Rows.Count;
            if (K > 0)
                return ds.Tables[0].Rows.Count;

            else return (0);
        }

        public void goster1(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        public void goster2(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }

        public void goster3(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            con.Close();
        }


           public void goster4(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sobeDataSet8.maaslar' table. You can move, or remove it, as needed.
            this.maaslarTableAdapter.Fill(this.sobeDataSet8.maaslar);
            // TODO: This line of code loads data into the 'sobeDataSet7.davamiyyet' table. You can move, or remove it, as needed.
            this.davamiyyetTableAdapter1.Fill(this.sobeDataSet7.davamiyyet);

            // TODO: This line of code loads data into the 'sobeDataSet5.davamiyyet' table. You can move, or remove it, as needed.
            this.davamiyyetTableAdapter.Fill(this.sobeDataSet5.davamiyyet);
            // TODO: This line of code loads data into the 'sobeDataSet4.telephon' table. You can move, or remove it, as needed.
            this.telephonTableAdapter.Fill(this.sobeDataSet4.telephon);
            // TODO: This line of code loads data into the 'sobeDataSet3.esas' table. You can move, or remove it, as needed.
            this.esasTableAdapter.Fill(this.sobeDataSet3.esas);


            dataGridView1.Left = 8;
            dataGridView1.Top = this.Height - dataGridView1.Height - 50;
            dataGridView1.Width = this.Width - 35;
            groupBox1.Width = 234;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
                pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();
            da = new SqlDataAdapter("select* from esas", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

            string F = "";
            string K;
            int N = 0;
            string il = DateTime.Now.Year.ToString();
            N = Nomre("select* from esas"); N++;


            if (N.ToString().Length == 1)
                F = il + "0" + N.ToString();
            else
                F = il + N.ToString();
            K = F + m;
            textBox1.Text = K;
            MessageBox.Show(K);
            textBox9.Text = textBox1.Text;
            groupBox1.Width = 756;
            textBox9.Text = K;


            ms = new System.IO.MemoryStream();
            //foto = Image.FromFile(pictureBox1.ImageLocation);
            foto = pictureBox1.Image;
            foto.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            sp = new SqlParameter("@img", SqlDbType.VarBinary);
            sp.Value = ms.ToArray();
            com = new SqlCommand("insert into esas(nomre,ad,soyad,ata_adi,tevellud,maas,saat,foto,unvan,wobe) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "',@img,'" + textBox8.Text + "','" + comboBox1.Text + "')", con);



            com.Parameters.Add(sp);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            foto.Dispose();
            ms.Dispose();
            goster1("select* from esas");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: m = "10"; break;
                case 1: m = "17"; break;
                case 2: m = "37"; break;
                case 3: m = "56"; break;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            textBox2.Focus();
            groupBox3.Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox3.Visible = true;
        }

        private void continuityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
        }

        private void absalaryCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == 8))
                textBox2.ReadOnly = false;
            else textBox2.ReadOnly = true;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox2.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox3.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == 8))
                textBox3.ReadOnly = false;
            else textBox3.ReadOnly = true;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox3.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox4.Focus();
            }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == 8))
                textBox4.ReadOnly = false;
            else textBox4.ReadOnly = true;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox4.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox5.Focus();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == 8))
                textBox5.ReadOnly = false;
            else textBox5.ReadOnly = true;
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox5.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox6.Focus();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
                textBox6.ReadOnly = false;
            else textBox6.ReadOnly = true;
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox6.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox7.Focus();
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == 8))
                textBox7.ReadOnly = false;
            else textBox7.ReadOnly = true;
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox7.TextLength == 0)
                    MessageBox.Show("Empty");
                else pictureBox1.Focus();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == 8))
                textBox7.ReadOnly = false;
            else textBox7.ReadOnly = true;
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox8.TextLength == 0)
                    MessageBox.Show("Empty");
                else comboBox1.Focus();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            R = e.RowIndex;
            groupBox1.Visible = true;
            textBox1.Text = dataGridView1[0, R].Value.ToString();
            textBox2.Text = dataGridView1[1, R].Value.ToString();
            textBox3.Text = dataGridView1[2, R].Value.ToString();
            textBox4.Text = dataGridView1[3, R].Value.ToString();
            textBox5.Text = dataGridView1[4, R].Value.ToString();
            textBox6.Text = dataGridView1[5, R].Value.ToString();
            textBox7.Text = dataGridView1[6, R].Value.ToString();
            textBox8.Text = dataGridView1[7, R].Value.ToString();
            comboBox1.Text = dataGridView1[8, R].Value.ToString();

            con.Open();
            com = new SqlCommand("select * from esas where nomre like '" + textBox1.Text + "'", con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {

                foreach (System.Data.Common.DbDataRecord dba in dr)
                {
                    ms = new System.IO.MemoryStream();
                    ms.Write((byte[])dba["foto"], 0, ((byte[])dba["foto"]).Length);
                    foto = Image.FromStream(ms);
                    pictureBox1.Image = (Bitmap)foto;
                }
            }

            con.Close();
         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select* from esas where nomre like '" + comboBox2.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];

            textBox11.Text = dataGridView1[0, R].Value.ToString();
    
            textBox12.Text = dataGridView1[1, R].Value.ToString();
            textBox13.Text = dataGridView1[2, R].Value.ToString();
            textBox14.Text = dataGridView1[3, R].Value.ToString();
            textBox15.Text = dataGridView1[4, R].Value.ToString();
            textBox16.Text = dataGridView1[5, R].Value.ToString();
            textBox17.Text = dataGridView1[6, R].Value.ToString();
            textBox18.Text = dataGridView1[7, R].Value.ToString();
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            con.Open();
            com = new SqlCommand("delete from esas where nomre like '" + comboBox2.Text + "'", con);
            com.ExecuteNonQuery();
            con.Close();

            DialogResult a = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
            switch (a)
            {
                case DialogResult.Yes: break;
                case DialogResult.No: break;
            }

           goster1("select* from esas");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select* from telephon where nomre like '"+textBox9.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();

            con.Open();
            com = new SqlCommand("insert into telephon(nomre,telefon,kimlik)values('" + textBox9.Text + "','" + maskedTextBox1.Text + "','" + textBox10.Text + "')", con);
            com.ExecuteNonQuery();
            con.Close();


            goster2("select* from telephon where nomre like '"+ textBox9.Text+"'");

        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox10.Clear();
            maskedTextBox1.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
              con.Open();
            da = new SqlDataAdapter("select* from esas where nomre like '"+comboBox3.Text+"'",con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

            double Saat=Convert.ToDouble (ds.Tables[0].Rows[0].ItemArray[6].ToString());
            double Maaw = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[5].ToString());
            double qm = 0;
            
          
            string  Day=Convert.ToDateTime(maskedTextBox4.Text).DayOfWeek.ToString();
            int AY = Convert.ToInt16(Convert.ToDateTime(maskedTextBox4.Text).Month.ToString());
            textBox20.Text = AY.ToString();    
            double Emsal = 0;

            string S1 = maskedTextBox2.Text;
            double x = Convert.ToDouble(S1.Substring(0,2));
            double y = Convert.ToDouble(S1.Substring(3, 2));
            double z = x + y / 60;
            double geldi = z;

             S1 = maskedTextBox3.Text;
             x = Convert.ToDouble(S1.Substring(0, 2));
             y = Convert.ToDouble(S1.Substring(3, 2));
             z = x + y / 60;
            double gedti = z;

            double umumi = gedti - geldi;
            textBox21.Text = umumi.ToString();
           
            if (geldi < 14 && gedti > 15) umumi--;

            double over = umumi - Saat;
            textBox22.Text = over.ToString();
            string WD=Convert.ToDateTime(maskedTextBox4.Text).DayOfWeek.ToString();
            if (WD == "Saturday"|| WD=="Sunday") Emsal = 2; 
           else Emsal=1.2;
               


            umumi = Saat + over * Emsal;
            qm = (Maaw / 30 / Saat) * umumi;
            textBox23.Text = qm.ToString();
           // MessageBox.Show("insert into davamiyyet(nomre,tarix,ay,geldi,getdi,umumi,ower,qmaas)values('" + comboBox3.Text + "','" + maskedTextBox4.Text.ToString() + "','" + textBox20.Text + "','" + geldi.ToString() + "','" + gedti.ToString() + "','" + textBox21.Text + "','" + textBox22.Text + "','" + textBox23.Text + "')");                        
            con.Open();
            com = new SqlCommand("insert into davamiyyet(nomre,tarix,ay,geldi,getdi,umumi,ower,qmaas)values('" +comboBox3.Text + "','" + maskedTextBox4.Text.ToString() + "','" +textBox20.Text+ "','" +geldi.ToString()+ "','" +gedti.ToString()+ "','" +textBox21.Text+ "','" +textBox22.Text+ "','" +textBox23.Text+ "')", con);
            com.ExecuteNonQuery();
            con.Close();
            goster3("select* from davamiyyet");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            maskedTextBox4.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
        
            con.Open();
           da = new SqlDataAdapter("select* from davamiyyet where nomre like  '" + comboBox4.Text + "' and ay like '"+(comboBox5.SelectedIndex+1).ToString()+"'", con);
           ds = new DataSet();
          da.Fill(ds);
          con.Close();

        }

        
        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
         if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == 8))
                textBox20.ReadOnly = false;
            else textBox20.ReadOnly = true;
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
          if (e.KeyValue == 13)
            {
                if (textBox20.TextLength == 0)
                    MessageBox.Show("Empty");
                else maskedTextBox2.Focus();
        }

        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           if ((e.KeyChar >= '0' && e.KeyChar <= '9')  || (e.KeyChar == 8))
                maskedTextBox2.ReadOnly = false;
            else maskedTextBox2.ReadOnly = true;
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
         if (e.KeyValue == 13)
            {
                if (maskedTextBox2.TextLength == 0)
                    MessageBox.Show("Empty");
                else maskedTextBox3.Focus();
        }

        }

        private void maskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
         if ((e.KeyChar >= '0' && e.KeyChar <= '9')  || (e.KeyChar == 8))
                maskedTextBox3.ReadOnly = false;
            else maskedTextBox3.ReadOnly = true;
        }

        private void maskedTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (maskedTextBox3.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox21.Focus();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("insert into maaslar(nomre,ay,maas)values('" + comboBox4.Text + "','" +( comboBox5.SelectedIndex+1).ToString() + "','" + textBox19.Text + "')", con);
            com.ExecuteNonQuery();
            con.Close();
      
        }

        private void button17_Click(object sender, EventArgs e)
        {
            con.Open();
            MessageBox.Show("select sum(qmaas) from davamiyyet where nomre like '" + comboBox4.Text + "' and ay like '" + (comboBox5.SelectedIndex+1).ToString() + "'");
            com = new SqlCommand("select sum(qmaas) from davamiyyet where nomre like '"+comboBox4.Text+"' and ay like '"+(comboBox5.SelectedIndex+1).ToString()+"'",con);
            textBox19.Text= com.ExecuteScalar().ToString();
        
            con.Close();
                 
                
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }
        }
    }

    

