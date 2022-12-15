using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System
{
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = AYUUB;database=library;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }


        private void TxtSearchIDNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchIDNumber.Text != "")
            {
                label1.Visible = false;
                Image image = Image.FromFile("C:/Users/Ayuub/Documents/Liberay Management System/search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = AYUUB;database=library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where idnumber LIKE '" + txtSearchIDNumber.Text + "%' ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                label1.Visible = true;
                Image image = Image.FromFile("C:/Users/Ayuub/Documents/Liberay Management System/search.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = AYUUB;database=library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];

            }
        }
        int bid;
        Int64 rowid;
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = AYUUB;database=library;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stuid = " + bid + "";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());

            txtStudentName.Text = DS.Tables[0].Rows[0][1].ToString();
            txtIDNumber.Text = DS.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text = DS.Tables[0].Rows[0][3].ToString();
            txtStudentSemester.Text = DS.Tables[0].Rows[0][4].ToString();
            txtStudentContact.Text = DS.Tables[0].Rows[0][5].ToString();
            txtStudentEmail.Text = DS.Tables[0].Rows[0][6].ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            String sname = txtStudentName.Text;
            String idnumber = txtIDNumber.Text;
            String dep = txtDepartment.Text;
            String sem = txtStudentSemester.Text;
            Int64 contact = Int64.Parse(txtStudentContact.Text);
            String email = txtStudentEmail.Text;

            if (MessageBox.Show("Data will Be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = AYUUB;database=library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set sname ='" + sname + "',idnumber='" + idnumber + "',dep='" + dep + "',sem='" + sem + "',contact='" + contact + "',email='" + email + "' where stuid = " + rowid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ViewStudentInformation_Load(this, null);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Be Deleted?. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = AYUUB;database=library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stuid=" + rowid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved Data will be lost.","Are you Sure?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
        }
    }
    
}
