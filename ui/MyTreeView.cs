using System;
using System.Windows.Forms;

namespace FSModMan.ui
{
    class MyTreeView : TreeView
    {
        protected override void WndProc(ref Message m)
        {
            // Filter WM_LBUTTONDBLCLK
            if (m.Msg != 0x203) base.WndProc(ref m);
        }
    }
}
