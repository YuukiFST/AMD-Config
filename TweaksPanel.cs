using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AMD_DWORD_Viewer.Controls;
using AMD_DWORD_Viewer.Models;
using AMD_DWORD_Viewer.Services;

namespace AMD_DWORD_Viewer
{
    public class TweaksPanel : Panel
    {
        private Label lblTitle;
        private List<TweakRow> tweakRows = new List<TweakRow>();
        private TweakManager tweakManager;
        private List<DwordEntry> allEntries;
        private Action refreshCallback;
        private GpuVendor vendor;
        private Color accentColor;

        public TweaksPanel(TweakManager manager, List<DwordEntry> entries, Action onRefresh, GpuVendor selectedVendor = GpuVendor.AMD)
        {
            tweakManager = manager;
            allEntries = entries;
            refreshCallback = onRefresh;
            vendor = selectedVendor;
            accentColor = AppColors.GetAccentColor(vendor);
            
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.Black;
            this.Dock = DockStyle.Right;
            this.Width = 320;
            this.AutoScroll = true;
            this.Padding = new Padding(10);

            lblTitle = new Label
            {
                Text = "Quick Tweaks",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = accentColor,
                AutoSize = false,
                Size = new Size(300, 30),
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblTitle);
        }

        public void LoadTweaks(List<TweakDefinition> tweaks)
        {
            int yPos = 50;

            foreach (var tweak in tweaks)
            {
                var row = new TweakRow(tweak, tweakManager, allEntries, refreshCallback, accentColor);
                row.Location = new Point(10, yPos);
                row.Width = 300;
                
                this.Controls.Add(row);
                tweakRows.Add(row);
                
                yPos += row.Height + 10;
            }
        }

        public void UpdateTweakStates()
        {
            foreach (var row in tweakRows)
            {
                row.UpdateStatus();
            }
        }
    }
}
