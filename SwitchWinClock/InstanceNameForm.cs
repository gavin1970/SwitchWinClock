using System;
using System.Windows.Forms;

namespace SwitchWinClock
{
    public partial class InstanceNameForm : Form
    {
        public InstanceNameForm()
        {
            InitializeComponent();
        }

        public string InstanceName { get; set; }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.InstanceName = this.TxtInstanceName.Text.Trim();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.InstanceName = string.Empty;
            this.Close();
        }

        private void InstanceNameForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.InstanceName))
                this.TxtInstanceName.Text = this.InstanceName;
        }
    }
}
