using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace librarySQL
{
    public partial class typeTransactions : Form
    {

        public typeTransactions()
        {
            InitializeComponent();
        }

        DatabaseTransactions dt = new DatabaseTransactions();
        SqlConnection conn;
        SqlCommand cmd;
        string query;

        public void CLear()
        {
            txtID.Clear();
            txtName.Clear();
        }

        public void Listing()
        {
            try
            {
                conn = dt.Connect();
                query = "SELECT * FROM bookTypes";
                cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgwType.DataSource = dataTable;
                dgwType.Columns[0].HeaderText = "Type ID";
                dgwType.Columns[1].HeaderText = "Type Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error!" , MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                query = "INSERT INTO bookTypes VALUES (@typeID ,@typeName)";
                cmd = new SqlCommand(query , conn);
                cmd.Parameters.AddWithValue("@typeID", int.Parse(txtID.Text));
                cmd.Parameters.AddWithValue("@typeName", txtName.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                Listing();
                CLear();
                MessageBox.Show("New type added!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                query = "DELETE FROM bookTypes WHERE typeID=@typeID";
                cmd = new SqlCommand(query , conn);
                cmd.Parameters.AddWithValue("@typeID" , dgwType.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
                Listing();
                CLear() ;
                MessageBox.Show("Type deleted succesfully!");

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
                query = "UPDATE bookTypes SET typeName=@typeName WHERE typeID = @typeID";
                cmd = new SqlCommand(query , conn);
                cmd.Parameters.AddWithValue("@typeID", int.Parse(txtID.Text));
                cmd.Parameters.AddWithValue("@typeName", txtName.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                Listing();
                CLear();
                MessageBox.Show("Type edited!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void dgwType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dgwType.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgwType.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

    }
}
