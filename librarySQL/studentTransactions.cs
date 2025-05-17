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

            private void studentTransactions_Load(object sender, EventArgs e)
            {
            
                Listing();
                toolTip1.SetToolTip(btnAdd, "You can add a new student with the information you entered in the information entry.\r\n");
                toolTip1.SetToolTip(btnDelete, "You can delete a student with the selected row!");
                toolTip1.SetToolTip(btnEdit, "You can edit a student with the selected row!");
            }

            DatabaseTransactions dbt = new DatabaseTransactions();
            SqlConnection con;
            SqlCommand cmd;
            string query;

         
            public void Clear()
            {
                txtName.Clear();
                txtSurname.Clear();
                txtStudentID.Clear();
                txtPhone.Clear();
           
            }

            public void Listing()
            {
                try
                {
                    con = dbt.Connect(); //Connect metodunun calismasi icin con nesnesini sqlConnectiondan uret.
                    query = "SELECT * FROM students";
                    cmd = new SqlCommand(query, con); 
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd); //Adapter veritabanindan aldigi verileri dataTable yada dataSete yazar
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


            public void Search(string key)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM students WHERE name LIKE '%' + @key + '%'";
                    cmd.Parameters.AddWithValue("@key", key);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgwStudent.DataSource = dt;
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            public void btnAdd_Click(object sender, EventArgs e)

            { 
                try
                {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                query = "INSERT INTO students VALUES(@studentID , @name , @surname , @class , @gender , @phone) ";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", int.Parse(txtStudentID.Text));
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@class", int.Parse(cbClass.Text.ToString()));
                    cmd.Parameters.AddWithValue("@gender", cbGender.Text.ToString());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);

                cmd.ExecuteNonQuery();
                    con.Close();
                    Listing();
                    MessageBox.Show("New student added succesfully!");
                    Clear();
                }
                catch (Exception ex)
                {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            private void btnDelete_Click(object sender, EventArgs e)
            {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                query = "DELETE FROM students WHERE studentID = @studentID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentID", dgwStudent.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                Listing();
                Clear();
                MessageBox.Show("Student deleted succesfully!");
            }
            catch (Exception ex)
            {
                    
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }


            private void btnEdit_Click(object sender, EventArgs e)
            {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                query = "UPDATE students SET name=@name , surname=@surname , class=@class , gender=@gender , phone=@phone WHERE studentID = @studentID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentID", int.Parse(txtStudentID.Text));
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@class", int.Parse(cbClass.Text));
                cmd.Parameters.AddWithValue("@gender", cbGender.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Listing();
                Clear();
                MessageBox.Show("Student edited succesfully!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            }

            private void txtSearch_TextChanged(object sender, EventArgs e)
            {
            Search(txtSearch.Text);
            }

        private void dgwStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtStudentID.Text = dgwStudent.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgwStudent.CurrentRow.Cells[1].Value.ToString();
                txtSurname.Text = dgwStudent.CurrentRow.Cells[2].Value.ToString();
                cbClass.SelectedItem = dgwStudent.CurrentRow.Cells[3].Value.ToString();
                cbGender.SelectedItem = dgwStudent.CurrentRow.Cells[4].Value.ToString();
                txtPhone.Text = dgwStudent.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
    }

