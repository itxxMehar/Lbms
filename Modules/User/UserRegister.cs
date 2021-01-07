using LBMS.Abstracts;
using System;
using System.Windows.Forms;

namespace LBMS.Modules.User
{
    public partial class UserRegister : FormBase
    {
        public UserRegister()
        {
            InitializeComponent();
            Header = "User Registration";
            TableName = "user";

            GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView.MultiSelect = false;
            GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = DbContext.Save(TableName, $"'{txtUserId.Text}' , '{txtUserName.Text}' , '{txtPassword.Text}' , '{txtEmail.Text}' ");
            MessageBox.Show(result ? @"Saved SuccessFully" : @"ERROR failed to save");
            ViewLoaded(null, new EventArgs());
        }

        private void ViewLoaded(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
            GridView.DataSource = DbContext.GetAll(TableName, "*");
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            var result = DbContext.Update(TableName, $" `user_id` = '{txtUserId.Text}' ,`user_name` ='{txtUserName.Text}' ,`password` = '{txtPassword.Text}' , `email` ='{txtEmail.Text}' where `user_id` = '{txtUserId.Text}'");
            MessageBox.Show(result ? @"Update SuccessFully" : @"ERROR failed to update");
            ViewLoaded(null, new EventArgs());
            txtUserId.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = DbContext.Delete(TableName, $" `user_id` = '{txtUserId.Text}'");
            MessageBox.Show(result ? @"Deleted SuccessFully" : @"ERROR failed to Delete");
            ViewLoaded(null, new EventArgs());
        }
        protected override void OnGridViewRowClick(object sender, MouseEventArgs e)
        {
            if (sender is DataGridView gridView)
            {
                var row = gridView.SelectedRows;
                txtUserId.Text = row[0].Cells[0].Value.ToString();
                txtUserName.Text = row[0].Cells[1].Value.ToString();
                txtPassword.Text = row[0].Cells[2].Value.ToString();
                txtEmail.Text = row[0].Cells[3].Value.ToString();

                txtUserId.Enabled = false;
            }
        }
    }
}
