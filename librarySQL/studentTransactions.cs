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

namespace librarySQL
{
    public partial class studentTransactions : Form
    {
        public studentTransactions()
        {
            InitializeComponent();
        }


        DatabaseTransactions dbt = new DatabaseTransactions();


        private void studentTransactions_Load(object sender, EventArgs e)
        {
            Listing();
            toolTip1.SetToolTip(btnAdd, "You can add a new student with the information you entered in the information entry.\r\n")
            toolTip1.SetToolTip(btnDelete, "You can delete a student with the selected row!");
            toolTip1.SetToolTip(btnEdit, "You can edit a student with the selected row!");
        }

        public void Listing()
        {
            try
            {
                SqlConnection con = dbt.Connect(); //Connect metodunun calismasi icin con nesnesini sqlConnectiondan uret.
                string query = "SELECT * FROM students";
                SqlCommand command = new SqlCommand(query, con); //

                SqlDataAdapter adapter = new SqlDataAdapter(command); //Adapter veritabanindan aldigi verileri dataTable yada dataSete yazar
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgwStudent.DataSource = dt;
                dgwStudent.Columns[0].HeaderText = "Student Number";
                dgwStudent.Columns[1].HeaderText = "Name";
                dgwStudent.Columns[2].HeaderText = "Surname";
                dgwStudent.Columns[3].HeaderText = "Class";
                dgwStudent.Columns[4].HeaderText = "Gender";
                dgwStudent.Columns[5].HeaderText = "Phone Number";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)

        { 
            try
            {
                SqlConnection con = dbt.Connect();
                string query = "INSERT INTO * VALUES(@studentID , @name , @surname , @class , @gender , @phone) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentID", txtStudentID.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@class", cbClass.Text);
                cmd.Parameters.AddWithValue("@gender", cbGender.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Listing();
                MessageBox.Show("New student added succesfully!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = dbt.Connect();
            string query = "";
            
            int rowIndex = dgwStudent.CurrentCell.RowIndex;

            dgwStudent.Rows[rowIndex].

        }
    }
}

