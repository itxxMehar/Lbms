using LBMS.Abstracts;
using LBMS.Modules.Book;
using LBMS.Modules.User;
using System.Windows.Forms;

namespace LBMS.Modules
{
    public partial class DashBoard : FormBase
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void registerToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var bookRegister = new BookRegister();
            bookRegister.ShowDialog();
        }

        private void assignToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var bookAssign = new BookAssign();
            bookAssign.ShowDialog();
        }

        private void registerToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var userRegister = new UserRegister();
            userRegister.ShowDialog();
        }

    }
}
