using System;
using System.Drawing;
using System.Windows.Forms;
using AMD_DWORD_Viewer.Models;

namespace AMD_DWORD_Viewer
{
    public partial class VendorSelectionForm : Form
    {
        public GpuVendor SelectedVendor { get; private set; }

        public VendorSelectionForm()
        {
            InitializeComponent();
        }

        private void btnAMD_Click(object sender, EventArgs e)
        {
            SelectedVendor = GpuVendor.AMD;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnNvidia_Click(object sender, EventArgs e)
        {
            SelectedVendor = GpuVendor.Nvidia;
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            try
            {
                int value = 1;
                DwmSetWindowAttribute(this.Handle, 20, ref value, sizeof(int));
            }
            catch { }
        }

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
    }
}
