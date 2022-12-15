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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtIDNumber.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            //txtEmail.Clear();

            txtEmail.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtIDNumber.Text != "" && txtDepartment.Text != "" && txtSemester.Text != "" && txtContact.Text != "" && txtEmail.Text != "")
            {

                String name = txtName.Text;
                String idnumber = txtIDNumber.Text;
                String dep = txtDepartment.Text;
                String sem = txtSemester.Text;
                Int64 cont = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = AYUUB; database = library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = " insert into NewStudent (sname,idnumber,dep,sem,contact,email) values ('" + name + "','" + idnumber + "','" + dep + "','" + sem + "','" + cont + "','" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Date Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
