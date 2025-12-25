using System;
using System.Drawing;
using System.Windows.Forms;

namespace kriptolojisifreleme
{
    partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;

        // GEREKLİ KONTROL TANIMLARI
        private Label lblInput;
        private TextBox txtInput;
        private Label lblKey;
        private TextBox txtKey;
        private ComboBox cmbAlgorithm;
        private Button btnEncrypt;
        private Label lblOutput;
        private TextBox txtOutput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblInput = new Label();
            txtInput = new TextBox();
            lblKey = new Label();
            txtKey = new TextBox();
            cmbAlgorithm = new ComboBox();
            btnEncrypt = new Button();
            lblOutput = new Label();
            txtOutput = new TextBox();
            SuspendLayout();
            // 
            // lblInput
            // 
            lblInput.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInput.ForeColor = Color.FromArgb(64, 64, 64);
            lblInput.Location = new Point(40, 40);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(100, 30);
            lblInput.TabIndex = 0;
            lblInput.Text = "Metin:";
            lblInput.Click += lblInput_Click;
            // 
            // txtInput
            // 
            txtInput.BackColor = Color.White;
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Segoe UI", 11F);
            txtInput.Location = new Point(150, 40);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(400, 30);
            txtInput.TabIndex = 1;
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlgorithm.Font = new Font("Segoe UI", 11F);
            cmbAlgorithm.Items.AddRange(new object[] { 
                "Vigenere",
                "Hill",
                "Doğrusal",
                "Kaydırmalı",
                "Permütasyon",
                "Yer Değiştirme",
                "Yer Değiştirme (Sayı Anahtarlı)",
                "Zigzag",
                "Rota",
                "4-Kare"
            });
            cmbAlgorithm.Location = new Point(150, 90);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(400, 33);
            cmbAlgorithm.TabIndex = 4;
            // 
            // lblKey
            // 
            lblKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblKey.ForeColor = Color.FromArgb(64, 64, 64);
            lblKey.Location = new Point(40, 140);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(140, 30);
            lblKey.TabIndex = 2;
            lblKey.Text = "Anahtar (k):";
            // 
            // txtKey
            // 
            txtKey.BackColor = Color.White;
            txtKey.BorderStyle = BorderStyle.FixedSingle;
            txtKey.Font = new Font("Segoe UI", 11F);
            txtKey.Location = new Point(190, 140);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(360, 30);
            txtKey.TabIndex = 3;
            // 
            // btnEncrypt
            // 
            btnEncrypt.BackColor = Color.FromArgb(0, 122, 204);
            btnEncrypt.FlatAppearance.BorderSize = 0;
            btnEncrypt.FlatStyle = FlatStyle.Flat;
            btnEncrypt.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEncrypt.ForeColor = Color.White;
            btnEncrypt.Location = new Point(240, 190);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(120, 40);
            btnEncrypt.TabIndex = 5;
            btnEncrypt.Text = "Şifrele";
            btnEncrypt.UseVisualStyleBackColor = false;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // lblOutput
            // 
            lblOutput.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOutput.ForeColor = Color.FromArgb(64, 64, 64);
            lblOutput.Location = new Point(40, 250);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(140, 30);
            lblOutput.TabIndex = 6;
            lblOutput.Text = "Şifreli Metin:";
            // 
            // txtOutput
            // 
            txtOutput.BackColor = Color.FromArgb(240, 240, 240);
            txtOutput.BorderStyle = BorderStyle.FixedSingle;
            txtOutput.Font = new Font("Segoe UI", 11F);
            txtOutput.Location = new Point(190, 250);
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(360, 30);
            txtOutput.TabIndex = 7;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(600, 320);
            Controls.Add(lblInput);
            Controls.Add(txtInput);
            Controls.Add(lblKey);
            Controls.Add(txtKey);
            Controls.Add(cmbAlgorithm);
            Controls.Add(btnEncrypt);
            Controls.Add(lblOutput);
            Controls.Add(txtOutput);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kriptoloji Şifreleme";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
