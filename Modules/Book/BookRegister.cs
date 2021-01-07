using LBMS.Abstracts;
using System;
using System.Windows.Forms;
// ReSharper disable once VirtualMemberCallInConstructor

namespace LBMS.Modules.Book
{
    public partial class BookRegister : FormBase
    {
        public BookRegister()
        {
            InitializeComponent();
            DbContext = new DbConnection();
            
            GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView.MultiSelect = false;
            GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            TableName = "book";
            Header = "Book Registration";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = DbContext.Save(TableName, $"'{txtBookId.Text}' , '{txtBookName.Text}' , '{txtAuthurName.Text}' , '{txtEdition.Text}' , '{txtQty.Text}' ");
            MessageBox.Show(result ? @"Saved SuccessFully" : @"ERROR failed to save");
            ViewLoaded(null, new EventArgs());
        }

        private void ViewLoaded(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
            txtBookId.Enabled = true;
            GridView.DataSource = DbContext.GetAll(TableName,"*");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = DbContext.Update(TableName, $" `book_name` = '{txtBookName.Text}' ,`authur_name` ='{txtAuthurName.Text}' ,`edition` = '{txtEdition.Text}' , `qty` ='{txtQty.Text}' where `book_id` = '{txtBookId.Text}'");
            MessageBox.Show(result ? @"Update SuccessFully" : @"ERROR failed to update");
            ViewLoaded(null, new EventArgs());
            txtBookId.Enabled = true;
        }

        protected override void OnGridViewRowClick(object sender, MouseEventArgs e)
        {
            if (sender is DataGridView gridView)
            {
                var row = gridView.SelectedRows;
                txtBookId.Text = row[0].Cells[0].Value.ToString();
                txtBookName.Text = row[0].Cells[1].Value.ToString();
                txtAuthurName.Text = row[0].Cells[2].Value.ToString();
                txtEdition.Text = row[0].Cells[3].Value.ToString();
                txtQty.Text = row[0].Cells[4].Value.ToString();

                txtBookId.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = DbContext.Delete(TableName, $" `book_id` = '{txtBookId.Text}'");
            MessageBox.Show(result ? @"Deleted SuccessFully" : @"ERROR failed to Delete");
            ViewLoaded(null, new EventArgs());
        }
    }
}
