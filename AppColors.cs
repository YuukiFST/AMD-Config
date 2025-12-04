using System.Drawing;
using AMD_DWORD_Viewer.Models;

namespace AMD_DWORD_Viewer
{
    public static class AppColors
    {
        public static readonly Color AmdRed = Color.FromArgb(220, 0, 0);
        public static readonly Color NvidiaGreen = Color.FromArgb(118, 185, 0);
        public static readonly Color DarkBackground = Color.FromArgb(30, 30, 30);
        public static readonly Color ButtonBackground = Color.FromArgb(60, 60, 60);

        public static Color GetAccentColor(GpuVendor vendor)
        {
            return vendor == GpuVendor.Nvidia ? NvidiaGreen : AmdRed;
        }
    }
}
