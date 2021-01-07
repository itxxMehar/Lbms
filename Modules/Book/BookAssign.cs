using System;
using System.Windows.Forms;
using LBMS.Abstracts;

namespace LBMS.Modules.Book
{
    public partial class BookAssign : FormBase
    {
        public BookAssign()
        {
            InitializeComponent();
            Header = "Book Assign";
            TableName = "book_assign";
            
            GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView.MultiSelect = false;
            GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var lookUps = DbContext.GetAll("book", "(`book_id`),(`book_name`)");
            cmbBooks.DataSource = lookUps;
            cmbBooks.ValueMember = "book_id";
            cmbBooks.DisplayMember = "book_name";
        }

        private void ViewLoaded(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
            GridView.DataSource = DbContext.GetAll(TableName, "*");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = DbContext.Save(TableName, $"'{cmbBooks.SelectedValue}' , '{txtStudentId.Text}' , '{txtStudentName.Text}' ");
            MessageBox.Show(result ? @"Saved SuccessFully" : @"ERROR failed to save");
            ViewLoaded(null, new EventArgs());
        }

    }
}
