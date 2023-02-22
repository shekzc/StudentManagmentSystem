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

namespace RAD
{
    public partial class stPg : Form
    {
        public stPg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stResult sr = new stResult();
            sr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stResult sr = new stResult();
            sr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stLecdtails dLec = new stLecdtails();
            dLec.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(" Do you really want to close the program ?", " Exit ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                logPg l = new logPg();
                l.Show();
            }
            else if (dialog == DialogResult.No)
            {

            }
            
        }
        SqlConnection con = new SqlConnection("Data Source=SHEKZ;Initial Catalog=RAD;Integrated Security=True");

        private void stPg_Load(object sender, EventArgs e)
        {
            lbregNo.Text = logPg.uname;
            //SqlConnection con = new SqlConnection("Data Source=SHEKZ;Initial Catalog=RAD;Integrated Security=True");
            con.Open();

            SqlCommand com = new SqlCommand("SELECT Username, Full_Name, Email, Mobile_No, Gender, DOB FROM Student WHERE Username = @u", con);
            com.Parameters.AddWithValue("@u", logPg.uname);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {

                name.Text = dr.GetValue(1).ToString();
                email.Text = dr.GetValue(2).ToString();
                mob.Text = dr.GetValue(3).ToString();
                gender.Text = dr.GetValue(4).ToString();
                dob.Text = dr.GetValue(5).ToString();

                uname.Text = logPg.uname;
            } con.Close();
        }
        

        private void back_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(" Do you really want to close the program ?", " Exit ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                logPg l = new logPg();
                l.Show();
            }
            else if (dialog == DialogResult.No)
            {

            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            issue.Visible = true;
        }

        private void issueback_Click(object sender, EventArgs e)
        {
            issue.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            issue.Visible = false;
        }

        private void issuedone_Click(object sender, EventArgs e)
        {
            String regNo = lbregNo.Text;
            String issue = istxt.Text;

            SqlCommand cmd = new SqlCommand("INSERT INTO Issue VALUES (@regNo, @name)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@regNo", regNo);
            cmd.Parameters.AddWithValue("@name", issue);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your request was sent to our administrator.", "Attention", MessageBoxButtons.OK);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            issue.Visible = true;
        }

        private void issue_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
