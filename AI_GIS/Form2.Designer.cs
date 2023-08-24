namespace AI_GIS
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.labelOptions = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelDirection = new System.Windows.Forms.Label();
            this.maskedTextBoxSpeed = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDirection = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.maskedTextBoxVolume = new System.Windows.Forms.MaskedTextBox();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelSubstance = new System.Windows.Forms.Label();
            this.checkedListBoxSubstance = new System.Windows.Forms.CheckedListBox();
            this.groupBoxSpeed = new System.Windows.Forms.GroupBox();
            this.groupBoxDirection = new System.Windows.Forms.GroupBox();
            this.groupBoxVolume = new System.Windows.Forms.GroupBox();
            this.groupBoxSubstance = new System.Windows.Forms.GroupBox();
            this.groupBoxArea = new System.Windows.Forms.GroupBox();
            this.labelSpill = new System.Windows.Forms.Label();
            this.maskedTextBoxSpill = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxTime = new System.Windows.Forms.GroupBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.maskedTextBoxTime = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxTemperature = new System.Windows.Forms.GroupBox();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.maskedTextBoxTemperature = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxAtmoState = new System.Windows.Forms.CheckedListBox();
            this.groupBoxSpeed.SuspendLayout();
            this.groupBoxDirection.SuspendLayout();
            this.groupBoxVolume.SuspendLayout();
            this.groupBoxSubstance.SuspendLayout();
            this.groupBoxArea.SuspendLayout();
            this.groupBoxTime.SuspendLayout();
            this.groupBoxTemperature.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Montserrat", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(424, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CloseForm);
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Montserrat", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOptions.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelOptions.Location = new System.Drawing.Point(176, 17);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(195, 25);
            this.labelOptions.TabIndex = 3;
            this.labelOptions.Text = "Choose options";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSpeed.Location = new System.Drawing.Point(6, 16);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(146, 23);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "Speed (m/s):";
            // 
            // labelDirection
            // 
            this.labelDirection.AutoSize = true;
            this.labelDirection.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirection.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelDirection.Location = new System.Drawing.Point(6, 16);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(114, 23);
            this.labelDirection.TabIndex = 5;
            this.labelDirection.Text = "Direction:";
            // 
            // maskedTextBoxSpeed
            // 
            this.maskedTextBoxSpeed.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxSpeed.Location = new System.Drawing.Point(6, 41);
            this.maskedTextBoxSpeed.Mask = "00.00";
            this.maskedTextBoxSpeed.Name = "maskedTextBoxSpeed";
            this.maskedTextBoxSpeed.Size = new System.Drawing.Size(68, 26);
            this.maskedTextBoxSpeed.TabIndex = 6;
            // 
            // maskedTextBoxDirection
            // 
            this.maskedTextBoxDirection.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxDirection.Location = new System.Drawing.Point(6, 41);
            this.maskedTextBoxDirection.Mask = "LL";
            this.maskedTextBoxDirection.Name = "maskedTextBoxDirection";
            this.maskedTextBoxDirection.Size = new System.Drawing.Size(33, 26);
            this.maskedTextBoxDirection.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(398, 416);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 48);
            this.button2.TabIndex = 8;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // maskedTextBoxVolume
            // 
            this.maskedTextBoxVolume.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxVolume.Location = new System.Drawing.Point(6, 38);
            this.maskedTextBoxVolume.Mask = "00000";
            this.maskedTextBoxVolume.Name = "maskedTextBoxVolume";
            this.maskedTextBoxVolume.Size = new System.Drawing.Size(79, 26);
            this.maskedTextBoxVolume.TabIndex = 10;
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVolume.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelVolume.Location = new System.Drawing.Point(6, 16);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(234, 23);
            this.labelVolume.TabIndex = 9;
            this.labelVolume.Text = "Storage volume (m3):";
            // 
            // labelSubstance
            // 
            this.labelSubstance.AutoSize = true;
            this.labelSubstance.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubstance.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSubstance.Location = new System.Drawing.Point(6, 16);
            this.labelSubstance.Name = "labelSubstance";
            this.labelSubstance.Size = new System.Drawing.Size(181, 23);
            this.labelSubstance.TabIndex = 11;
            this.labelSubstance.Text = "Substance type:";
            // 
            // checkedListBoxSubstance
            // 
            this.checkedListBoxSubstance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(11)))));
            this.checkedListBoxSubstance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxSubstance.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxSubstance.ForeColor = System.Drawing.SystemColors.Info;
            this.checkedListBoxSubstance.FormattingEnabled = true;
            this.checkedListBoxSubstance.Items.AddRange(new object[] {
            "Ammonia",
            "Chlorine"});
            this.checkedListBoxSubstance.Location = new System.Drawing.Point(6, 41);
            this.checkedListBoxSubstance.Name = "checkedListBoxSubstance";
            this.checkedListBoxSubstance.Size = new System.Drawing.Size(133, 42);
            this.checkedListBoxSubstance.TabIndex = 12;
            // 
            // groupBoxSpeed
            // 
            this.groupBoxSpeed.Controls.Add(this.labelSpeed);
            this.groupBoxSpeed.Controls.Add(this.maskedTextBoxSpeed);
            this.groupBoxSpeed.Location = new System.Drawing.Point(21, 55);
            this.groupBoxSpeed.Name = "groupBoxSpeed";
            this.groupBoxSpeed.Size = new System.Drawing.Size(153, 74);
            this.groupBoxSpeed.TabIndex = 13;
            this.groupBoxSpeed.TabStop = false;
            // 
            // groupBoxDirection
            // 
            this.groupBoxDirection.Controls.Add(this.labelDirection);
            this.groupBoxDirection.Controls.Add(this.maskedTextBoxDirection);
            this.groupBoxDirection.Location = new System.Drawing.Point(21, 135);
            this.groupBoxDirection.Name = "groupBoxDirection";
            this.groupBoxDirection.Size = new System.Drawing.Size(146, 75);
            this.groupBoxDirection.TabIndex = 14;
            this.groupBoxDirection.TabStop = false;
            // 
            // groupBoxVolume
            // 
            this.groupBoxVolume.Controls.Add(this.labelVolume);
            this.groupBoxVolume.Controls.Add(this.maskedTextBoxVolume);
            this.groupBoxVolume.Location = new System.Drawing.Point(256, 55);
            this.groupBoxVolume.Name = "groupBoxVolume";
            this.groupBoxVolume.Size = new System.Drawing.Size(243, 82);
            this.groupBoxVolume.TabIndex = 15;
            this.groupBoxVolume.TabStop = false;
            // 
            // groupBoxSubstance
            // 
            this.groupBoxSubstance.Controls.Add(this.labelSubstance);
            this.groupBoxSubstance.Controls.Add(this.checkedListBoxSubstance);
            this.groupBoxSubstance.Location = new System.Drawing.Point(256, 143);
            this.groupBoxSubstance.Name = "groupBoxSubstance";
            this.groupBoxSubstance.Size = new System.Drawing.Size(189, 100);
            this.groupBoxSubstance.TabIndex = 16;
            this.groupBoxSubstance.TabStop = false;
            // 
            // groupBoxArea
            // 
            this.groupBoxArea.Controls.Add(this.labelSpill);
            this.groupBoxArea.Controls.Add(this.maskedTextBoxSpill);
            this.groupBoxArea.Location = new System.Drawing.Point(21, 216);
            this.groupBoxArea.Name = "groupBoxArea";
            this.groupBoxArea.Size = new System.Drawing.Size(201, 75);
            this.groupBoxArea.TabIndex = 15;
            this.groupBoxArea.TabStop = false;
            // 
            // labelSpill
            // 
            this.labelSpill.AutoSize = true;
            this.labelSpill.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpill.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSpill.Location = new System.Drawing.Point(6, 16);
            this.labelSpill.Name = "labelSpill";
            this.labelSpill.Size = new System.Drawing.Size(191, 23);
            this.labelSpill.TabIndex = 5;
            this.labelSpill.Text = "Spill area (sq. m):";
            // 
            // maskedTextBoxSpill
            // 
            this.maskedTextBoxSpill.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxSpill.Location = new System.Drawing.Point(6, 41);
            this.maskedTextBoxSpill.Mask = "0000";
            this.maskedTextBoxSpill.Name = "maskedTextBoxSpill";
            this.maskedTextBoxSpill.Size = new System.Drawing.Size(56, 26);
            this.maskedTextBoxSpill.TabIndex = 7;
            // 
            // groupBoxTime
            // 
            this.groupBoxTime.Controls.Add(this.labelTime);
            this.groupBoxTime.Controls.Add(this.maskedTextBoxTime);
            this.groupBoxTime.Location = new System.Drawing.Point(256, 249);
            this.groupBoxTime.Name = "groupBoxTime";
            this.groupBoxTime.Size = new System.Drawing.Size(146, 75);
            this.groupBoxTime.TabIndex = 16;
            this.groupBoxTime.TabStop = false;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTime.Location = new System.Drawing.Point(6, 16);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(125, 23);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "Time after:";
            // 
            // maskedTextBoxTime
            // 
            this.maskedTextBoxTime.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxTime.Location = new System.Drawing.Point(6, 41);
            this.maskedTextBoxTime.Mask = "00";
            this.maskedTextBoxTime.Name = "maskedTextBoxTime";
            this.maskedTextBoxTime.Size = new System.Drawing.Size(35, 26);
            this.maskedTextBoxTime.TabIndex = 7;
            // 
            // groupBoxTemperature
            // 
            this.groupBoxTemperature.Controls.Add(this.labelTemperature);
            this.groupBoxTemperature.Controls.Add(this.maskedTextBoxTemperature);
            this.groupBoxTemperature.Location = new System.Drawing.Point(256, 330);
            this.groupBoxTemperature.Name = "groupBoxTemperature";
            this.groupBoxTemperature.Size = new System.Drawing.Size(167, 75);
            this.groupBoxTemperature.TabIndex = 17;
            this.groupBoxTemperature.TabStop = false;
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperature.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTemperature.Location = new System.Drawing.Point(6, 16);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(154, 23);
            this.labelTemperature.TabIndex = 5;
            this.labelTemperature.Text = "Temperature:";
            // 
            // maskedTextBoxTemperature
            // 
            this.maskedTextBoxTemperature.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxTemperature.Location = new System.Drawing.Point(6, 41);
            this.maskedTextBoxTemperature.Mask = "#00";
            this.maskedTextBoxTemperature.Name = "maskedTextBoxTemperature";
            this.maskedTextBoxTemperature.Size = new System.Drawing.Size(44, 26);
            this.maskedTextBoxTemperature.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkedListBoxAtmoState);
            this.groupBox1.Location = new System.Drawing.Point(21, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 135);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 46);
            this.label1.TabIndex = 11;
            this.label1.Text = "Atmosphere \r\ntype:";
            // 
            // checkedListBoxAtmoState
            // 
            this.checkedListBoxAtmoState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(11)))));
            this.checkedListBoxAtmoState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxAtmoState.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxAtmoState.ForeColor = System.Drawing.SystemColors.Info;
            this.checkedListBoxAtmoState.FormattingEnabled = true;
            this.checkedListBoxAtmoState.Items.AddRange(new object[] {
            "Сonvection",
            "Isothermia",
            "Inversion"});
            this.checkedListBoxAtmoState.Location = new System.Drawing.Point(6, 65);
            this.checkedListBoxAtmoState.Name = "checkedListBoxAtmoState";
            this.checkedListBoxAtmoState.Size = new System.Drawing.Size(133, 63);
            this.checkedListBoxAtmoState.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(11)))));
            this.ClientSize = new System.Drawing.Size(511, 476);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxTemperature);
            this.Controls.Add(this.groupBoxTime);
            this.Controls.Add(this.groupBoxArea);
            this.Controls.Add(this.groupBoxSubstance);
            this.Controls.Add(this.groupBoxVolume);
            this.Controls.Add(this.groupBoxDirection);
            this.Controls.Add(this.groupBoxSpeed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelOptions);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.groupBoxSpeed.ResumeLayout(false);
            this.groupBoxSpeed.PerformLayout();
            this.groupBoxDirection.ResumeLayout(false);
            this.groupBoxDirection.PerformLayout();
            this.groupBoxVolume.ResumeLayout(false);
            this.groupBoxVolume.PerformLayout();
            this.groupBoxSubstance.ResumeLayout(false);
            this.groupBoxSubstance.PerformLayout();
            this.groupBoxArea.ResumeLayout(false);
            this.groupBoxArea.PerformLayout();
            this.groupBoxTime.ResumeLayout(false);
            this.groupBoxTime.PerformLayout();
            this.groupBoxTemperature.ResumeLayout(false);
            this.groupBoxTemperature.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelDirection;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxSpeed;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDirection;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxVolume;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelSubstance;
        private System.Windows.Forms.CheckedListBox checkedListBoxSubstance;
        private System.Windows.Forms.GroupBox groupBoxSpeed;
        private System.Windows.Forms.GroupBox groupBoxDirection;
        private System.Windows.Forms.GroupBox groupBoxVolume;
        private System.Windows.Forms.GroupBox groupBoxSubstance;
        private System.Windows.Forms.GroupBox groupBoxArea;
        private System.Windows.Forms.Label labelSpill;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxSpill;
        private System.Windows.Forms.GroupBox groupBoxTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTime;
        private System.Windows.Forms.GroupBox groupBoxTemperature;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTemperature;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxAtmoState;
    }
}