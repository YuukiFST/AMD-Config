using System;
using System.Windows.Forms;

namespace AMD_DWORD_Viewer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

                using (var selectionForm = new VendorSelectionForm())
                {
                    if (selectionForm.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new MainForm(selectionForm.SelectedVendor));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Fatal error starting application:\n\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                    "Fatal Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
