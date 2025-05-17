using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace librarySQL
{
    public partial class loanBookTransactions : Form
    {
        public loanBookTransactions()
        {
            InitializeComponent();
        }
        DatabaseTransactions dt = new DatabaseTransactions();
        SqlConnection conn;
        SqlCommand cmd;
        string query;

        public void Clear()
        {
            txtID.Clear();
            txtDescrip.Clear();
        }
        public void Listing()
        {
            conn = dt.Connect();
            query = "SELECT * FROM loanBook";
            cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvLoan.DataSource = table;
            dgvLoan.Columns[0].HeaderText = "Loan ID";
            dgvLoan.Columns[3].HeaderText = "Issue Date";
            dgvLoan.Columns[4].HeaderText = "Delivery Date";
            dgvLoan.Columns[5].HeaderText = "Description";
        }
        public void Search(string key)
        {
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM loanBook WHERE studentID LIKE '%' + @key + '%' ";
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvLoan.DataSource = table;
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
        private void btnLoan_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                query = "INSERT INTO loanBook(id,issueDate,deliveryDate,description) VALUES (@id , @issueDate , @deliveryDate , @description)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                cmd.Parameters.AddWithValue("@description",txtDescrip.Text);
                cmd.Parameters.AddWithValue("@issueDate", dtpIssue.Text.ToString());
                cmd.Parameters.AddWithValue("@deliveryDate", dtpDelivery.Text.ToString());
                cmd.ExecuteNonQuery();
                Listing();
                Clear();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                query = "DELETE FROM loanBook WHERE id=@id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", dgvLoan.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery ();
                Listing();
                Clear();
                conn.Close();

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
                query = "UPDATE loanBook SET issueDate=@issueDate , deliveryDate=@deliveryDate ,description=@desription WHERE id=@id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                cmd.Parameters.AddWithValue("@description", txtDescrip.Text);
                cmd.Parameters.AddWithValue("@issueDate", dtpIssue.Text.ToString());
                cmd.Parameters.AddWithValue("@deliveryDate", dtpDelivery.Text.ToString());
                cmd.ExecuteNonQuery();
                Listing();
                Clear();
                conn.Close();
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

        private void dgvLoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dgvLoan.CurrentRow.Cells[0].Value.ToString();
                txtDescrip.Text = dgvLoan.CurrentRow.Cells[3].Value.ToString();
                dtpIssue.Text = dgvLoan.CurrentRow.Cells[4].Value.ToString();
                dtpDelivery.Text = dgvLoan.CurrentRow.Cells [5].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
