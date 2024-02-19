using System;
using System.Windows.Forms;

namespace CustomersEncode.Forms
{
    public partial class WarningForm : Form
    {

        public event EventHandler ClickRequest;

        public WarningForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            send(sender, EventArgs.Empty);
        }

        private void send(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.Name.Equals("AffirmButton"))
            {
                EventHandler eh = ClickRequest;
                if (eh != null)
                    eh(true, e);
            }
            else
            {
                EventHandler eh = ClickRequest;
                if (eh != null)
                    eh(false, e);
            }
            this.Close();
        }
    }
}
