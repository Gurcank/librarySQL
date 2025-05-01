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
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Student Number";
                dataGridView1.Columns[1].HeaderText = "Name";
                dataGridView1.Columns[2].HeaderText = "Surname";
                dataGridView1.Columns[3].HeaderText = "Class";
                dataGridView1.Columns[4].HeaderText = "Gender";
                dataGridView1.Columns[5].HeaderText = "Phone Number";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }




        }
    } 
}

