using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace librarySQL
{
    public partial class bookTransactions : Form
    {
        public bookTransactions()
        {
            InitializeComponent();
        }

        DatabaseTransactions dt = new DatabaseTransactions();
        SqlConnection conn ;
        SqlCommand cmd ;
        string query ; 

        public void Clear()
        {
            txtName.Clear();
            txtBookID.Clear();
            txtWriter.Clear();
            txtPublisher.Clear();
            txtPage.Clear();
            
        }

        public void Listing()
        {
            try
            {
                conn = dt.Connect();
                query = "SELECT * FROM books";
                cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);    //Bu 4u sadece veritabaninda veri cekmek icin kullanilir.
                DataTable table = new DataTable();   //2 Yani sadece SELECT'te  UPDATE INSERT VE DELETE'te kullanilmaz
                adapter.Fill(table);        //3
                dgwBook.DataSource = table; //4
                dgwBook.Columns[0].HeaderText = "Book ID";
                dgwBook.Columns[2].HeaderText = "Book Name";
                dgwBook.Columns[3].HeaderText = "Writer";
                dgwBook.Columns[4].HeaderText = "Publisher";
                dgwBook.Columns[5].HeaderText = "Number of Page";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error!" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        public void Search(string key)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM books WHERE bookName LIKE '%' + @key + '%'";
                cmd.Parameters.AddWithValue("@key", key);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd) ;
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgwBook.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                query = "INSERT INTO books(bookID,bookName,writer,publisher,numberOfPage)  VALUES(@bookID , @bookName , @writer , @publisher , @numberOfPage)";
                cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@bookID", int.Parse(txtBookID.Text));
                cmd.Parameters.AddWithValue("@bookName", txtName.Text);
                cmd.Parameters.AddWithValue("@writer", txtWriter.Text);
                cmd.Parameters.AddWithValue("@publisher", txtPublisher.Text);
                cmd.Parameters.AddWithValue("@numberOfPage", int.Parse(txtPage.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
                Listing();
                Clear();
                MessageBox.Show("Book succesfully added!");
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
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                query = "DELETE FROM books WHERE bookID = @bookID";
                cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@bookID", dgwBook.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
                Listing();
                Clear();
                MessageBox.Show("Book deleted succesfully!");

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
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                query = "UPDATE books SET bookName=@bookName , writer=@writer , publisher=@publisher , numberOfPage=@numberOfPage WHERE bookID=@bookID";
                cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@bookID", int.Parse(txtBookID.Text));
                cmd.Parameters.AddWithValue("@bookName", txtName.Text);
                cmd.Parameters.AddWithValue("@writer", txtWriter.Text);
                cmd.Parameters.AddWithValue("@publisher", txtPublisher.Text);
                cmd.Parameters.AddWithValue("@numberOfPage", int.Parse(txtPage.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
                Listing();
                Clear();
                MessageBox.Show("Book succesfully edited!");


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

        private void dgwBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBookID.Text = dgwBook.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgwBook.CurrentRow.Cells [2].Value.ToString();
                txtWriter.Text = dgwBook.CurrentRow.Cells[3].Value.ToString();
                txtPublisher.Text = dgwBook.CurrentRow.Cells[4].Value.ToString();
                txtPage.Text = dgwBook.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
