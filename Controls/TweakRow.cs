using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AMD_DWORD_Viewer.Models;
using AMD_DWORD_Viewer.Services;

namespace AMD_DWORD_Viewer.Controls
{
    public class TweakRow : Panel
    {
        private Label lblName;
        private Label lblStatus;
        private Button btnApply;
        private Button btnRevert;
        private TweakDefinition tweak;
        private TweakManager manager;
        private List<DwordEntry> allEntries;
        private Action refreshCallback;
        private Color accentColor;

        public TweakRow(TweakDefinition tweakDef, TweakManager tweakManager, List<DwordEntry> entries, Action onRefresh, Color buttonAccentColor)
        {
            tweak = tweakDef;
            manager = tweakManager;
            allEntries = entries;
            refreshCallback = onRefresh;
            accentColor = buttonAccentColor;
            
            InitializeComponent();
            UpdateStatus();
        }

        private void InitializeComponent()
        {
            this.BackColor = AppColors.DarkBackground;
            this.Height = 80;

            lblName = new Label
            {
                Text = tweak.Name,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(280, 22),
                Location = new Point(10, 8),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblName);

            lblStatus = new Label
            {
                Font = new Font("Segoe UI", 8F),
                AutoSize = false,
                Size = new Size(280, 18),
                Location = new Point(10, 28),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblStatus);

            btnApply = new Button
            {
                Text = "Apply",
                Size = new Size(85, 26),
                Location = new Point(10, 48),
                BackColor = AppColors.ButtonBackground,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8F)
            };
            btnApply.FlatAppearance.BorderColor = accentColor;
            btnApply.Click += BtnApply_Click;
            this.Controls.Add(btnApply);

            btnRevert = new Button
            {
                Text = "Revert",
                Size = new Size(85, 26),
                Location = new Point(105, 48),
                BackColor = AppColors.ButtonBackground,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8F)
            };
            btnRevert.FlatAppearance.BorderColor = accentColor;
            btnRevert.Click += BtnRevert_Click;
            this.Controls.Add(btnRevert);
        }

        public void UpdateStatus()
        {
            if (tweak.IsApplied)
            {
                lblStatus.Text = $"✓ Applied | {tweak.Changes.Count} DWORDs";
                lblStatus.ForeColor = Color.LimeGreen;
                btnApply.Enabled = false;
                btnRevert.Enabled = true;
            }
            else
            {
                lblStatus.Text = $"Not Applied | {tweak.Changes.Count} DWORDs";
                lblStatus.ForeColor = Color.Gray;
                btnApply.Enabled = true;
                btnRevert.Enabled = false;
            }
        }

        private void BtnApply_Click(object? sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(
                    $"Apply {tweak.Name}?\n\n" +
                    $"This will modify {tweak.Changes.Count} DWORD values.\n" +
                    $"Original values will be backed up and can be reverted.\n\n" +
                    $"Continue?",
                    "Confirm Apply Tweak",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    manager.ApplyTweak(tweak, allEntries);
                    UpdateStatus();
                    refreshCallback?.Invoke();
                    
                    MessageBox.Show(
                        $"{tweak.Name} applied successfully!\n\n" +
                        $"{tweak.Changes.Count} DWORDs modified.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error applying tweak:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnRevert_Click(object? sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(
                    $"Revert {tweak.Name}?\n\n" +
                    $"This will restore original values for {tweak.Changes.Count} DWORDs.\n" +
                    $"DWORDs that didn't exist before will be deleted.\n\n" +
                    $"Continue?",
                    "Confirm Revert Tweak",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    manager.RevertTweak(tweak);
                    UpdateStatus();
                    refreshCallback?.Invoke();
                    
                    MessageBox.Show(
                        $"{tweak.Name} reverted successfully!\n\n" +
                        $"Original values restored.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error reverting tweak:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
