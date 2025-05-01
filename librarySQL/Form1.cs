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
    public partial class frmHomePage : Form
    {
        public frmHomePage()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=GURCAN;Initial Catalog=Library;Integrated Security=True");
        private void frmHomePage_Load(object sender, EventArgs e)
        {
           
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            bookTransactions book = new bookTransactions();
            book.ShowDialog();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            studentTransactions student = new studentTransactions();
            student.ShowDialog();
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            typeTransactions type = new typeTransactions();
            type.ShowDialog();
        }

        private void btnLoanBook_Click(object sender, EventArgs e)
        {
            loanBookTransactions loan = new loanBookTransactions();
            loan.ShowDialog();
        }
    }
}
