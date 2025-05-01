namespace librarySQL
{
    partial class frmHomePage
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBook = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnLoanBook = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(12, 13);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(160, 99);
            this.btnBook.TabIndex = 0;
            this.btnBook.Text = "Book Transactions\r\n";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(260, 13);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(160, 99);
            this.btnStudent.TabIndex = 0;
            this.btnStudent.Text = "Student Transactions";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnLoanBook
            // 
            this.btnLoanBook.Location = new System.Drawing.Point(260, 142);
            this.btnLoanBook.Name = "btnLoanBook";
            this.btnLoanBook.Size = new System.Drawing.Size(160, 99);
            this.btnLoanBook.TabIndex = 0;
            this.btnLoanBook.Text = "Loan Book Transactions";
            this.btnLoanBook.UseVisualStyleBackColor = true;
            this.btnLoanBook.Click += new System.EventHandler(this.btnLoanBook_Click);
            // 
            // btnType
            // 
            this.btnType.Location = new System.Drawing.Point(12, 142);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(160, 99);
            this.btnType.TabIndex = 0;
            this.btnType.Text = "Type Transactions";
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // frmHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 253);
            this.Controls.Add(this.btnType);
            this.Controls.Add(this.btnLoanBook);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.btnBook);
            this.Name = "frmHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.frmHomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnLoanBook;
        private System.Windows.Forms.Button btnType;
    }
}

