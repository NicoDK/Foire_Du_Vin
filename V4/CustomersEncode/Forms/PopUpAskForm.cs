using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomersEncode.Forms
{
    public partial class PopUpAskForm : Form
    {

        public event EventHandler ClickRequest;

        public PopUpAskForm()
        {
            InitializeComponent();
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
