using LBMS.Abstracts;
using System.Windows.Forms;

namespace LBMS.Modules.User
{
    public partial class UserLogin : Form
    {
        private readonly DbConnection _dbContext;
        public UserLogin()
        {
            InitializeComponent();
            _dbContext = new DbConnection();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var results = _dbContext.Find("user", $"user_name = '{txt_userName.Text}' and password = '{txt_password.Text}' ");
            if (results.Rows.Count == 1)
            {
                Hide();
                var dashboard = new DashBoard();
                dashboard.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"Invalid user name or password", @"System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
