using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME
{
   public class ShadowForm : DevComponents.DotNetBar.Office2007Form 
    {
        // Define the CS_DROPSHADOW constant
        private const int CS_DROPSHADOW = 0x00020000;

        // Override the CreateParams property
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ShadowForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "ShadowForm";
            this.Load += new System.EventHandler(this.ShadowForm_Load);
            this.ResumeLayout(false);

        }

        private void ShadowForm_Load(object sender, EventArgs e)
        {

        }
    }
}
