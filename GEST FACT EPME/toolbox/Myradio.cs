using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class Myradio : System.Windows.Forms.RadioButton
{
    protected override bool ProcessDialogKey(Keys keyData)
    {
        //cell is in Edit mode
        if (keyData == Keys.Enter)
        {
            keyData = Keys.Tab;
        }
        return base.ProcessDialogKey(keyData);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        //cell is not in Edit mode
        if (keyData == Keys.Enter)
        {
            keyData = Keys.Tab;
            msg.LParam = (IntPtr)0xf0001;
            msg.WParam = (IntPtr)0x9;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}
