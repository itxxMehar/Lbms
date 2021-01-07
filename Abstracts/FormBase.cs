using System.Windows.Forms;
// ReSharper disable once VirtualMemberCallInConstructor

namespace LBMS.Abstracts
{
    public class FormBase : Form
    {
        protected DbConnection DbContext;
        protected FormBase()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            FontHeight = 14;
            DbContext = new DbConnection();
           
        }

        public string TableName { get; set; }
        public string Header
        {
            get => Text;
            set => Text = value;
        }
        protected virtual void OnGridViewRowClick(object sender, MouseEventArgs e)
        {

        }

        protected void ClearTextBoxes(Form form)
        {
            foreach (var control in form.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(614, 381);
            this.Name = "FormBase";
            this.ResumeLayout(false);

        }
    }
}
