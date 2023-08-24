namespace AI_GIS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.checkBoxBuildings = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBoxLakes = new System.Windows.Forms.CheckBox();
            this.checkBoxRivers = new System.Windows.Forms.CheckBox();
            this.checkBoxForests = new System.Windows.Forms.CheckBox();
            this.checkBoxZone = new System.Windows.Forms.CheckBox();
            this.checkBoxUser = new System.Windows.Forms.CheckBox();
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
            this.button1.Location = new System.Drawing.Point(1047, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CloseForm);
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
            this.button2.Location = new System.Drawing.Point(978, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "Upload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gMap
            // 
            this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemory = 5;
            this.gMap.Location = new System.Drawing.Point(12, 12);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(905, 652);
            this.gMap.TabIndex = 4;
            this.gMap.Zoom = 0D;
            this.gMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMap_OnMarkerClick);
            this.gMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // checkBoxBuildings
            // 
            this.checkBoxBuildings.AutoSize = true;
            this.checkBoxBuildings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxBuildings.FlatAppearance.BorderSize = 3;
            this.checkBoxBuildings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.checkBoxBuildings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.checkBoxBuildings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxBuildings.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBuildings.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxBuildings.Location = new System.Drawing.Point(940, 81);
            this.checkBoxBuildings.Name = "checkBoxBuildings";
            this.checkBoxBuildings.Size = new System.Drawing.Size(123, 27);
            this.checkBoxBuildings.TabIndex = 6;
            this.checkBoxBuildings.Text = "Buildings";
            this.checkBoxBuildings.UseVisualStyleBackColor = true;
            this.checkBoxBuildings.CheckedChanged += new System.EventHandler(this.checkBoxBuildings_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Montserrat", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(937, 347);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(185, 317);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // checkBoxLakes
            // 
            this.checkBoxLakes.AutoSize = true;
            this.checkBoxLakes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxLakes.FlatAppearance.BorderSize = 3;
            this.checkBoxLakes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.checkBoxLakes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.checkBoxLakes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxLakes.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLakes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxLakes.Location = new System.Drawing.Point(940, 113);
            this.checkBoxLakes.Name = "checkBoxLakes";
            this.checkBoxLakes.Size = new System.Drawing.Size(87, 27);
            this.checkBoxLakes.TabIndex = 8;
            this.checkBoxLakes.Text = "Lakes";
            this.checkBoxLakes.UseVisualStyleBackColor = true;
            this.checkBoxLakes.CheckedChanged += new System.EventHandler(this.checkBoxLakes_CheckedChanged);
            // 
            // checkBoxRivers
            // 
            this.checkBoxRivers.AutoSize = true;
            this.checkBoxRivers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxRivers.FlatAppearance.BorderSize = 3;
            this.checkBoxRivers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.checkBoxRivers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.checkBoxRivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRivers.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRivers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxRivers.Location = new System.Drawing.Point(940, 148);
            this.checkBoxRivers.Name = "checkBoxRivers";
            this.checkBoxRivers.Size = new System.Drawing.Size(93, 27);
            this.checkBoxRivers.TabIndex = 9;
            this.checkBoxRivers.Text = "Rivers";
            this.checkBoxRivers.UseVisualStyleBackColor = true;
            this.checkBoxRivers.CheckedChanged += new System.EventHandler(this.checkBoxRivers_CheckedChanged);
            // 
            // checkBoxForests
            // 
            this.checkBoxForests.AutoSize = true;
            this.checkBoxForests.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxForests.FlatAppearance.BorderSize = 3;
            this.checkBoxForests.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.checkBoxForests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.checkBoxForests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxForests.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxForests.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxForests.Location = new System.Drawing.Point(940, 183);
            this.checkBoxForests.Name = "checkBoxForests";
            this.checkBoxForests.Size = new System.Drawing.Size(105, 27);
            this.checkBoxForests.TabIndex = 10;
            this.checkBoxForests.Text = "Forests";
            this.checkBoxForests.UseVisualStyleBackColor = true;
            this.checkBoxForests.CheckedChanged += new System.EventHandler(this.checkBoxForests_CheckedChanged);
            // 
            // checkBoxZone
            // 
            this.checkBoxZone.AutoSize = true;
            this.checkBoxZone.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxZone.FlatAppearance.BorderSize = 3;
            this.checkBoxZone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.checkBoxZone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.checkBoxZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxZone.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxZone.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxZone.Location = new System.Drawing.Point(940, 218);
            this.checkBoxZone.Name = "checkBoxZone";
            this.checkBoxZone.Size = new System.Drawing.Size(185, 27);
            this.checkBoxZone.TabIndex = 11;
            this.checkBoxZone.Text = "Poisoning zone";
            this.checkBoxZone.UseVisualStyleBackColor = true;
            this.checkBoxZone.CheckedChanged += new System.EventHandler(this.checkBoxZone_CheckedChanged);
            // 
            // checkBoxUser
            // 
            this.checkBoxUser.AutoSize = true;
            this.checkBoxUser.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBoxUser.FlatAppearance.BorderSize = 3;
            this.checkBoxUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.checkBoxUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.checkBoxUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxUser.Font = new System.Drawing.Font("Montserrat", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxUser.Location = new System.Drawing.Point(940, 251);
            this.checkBoxUser.Name = "checkBoxUser";
            this.checkBoxUser.Size = new System.Drawing.Size(184, 27);
            this.checkBoxUser.TabIndex = 12;
            this.checkBoxUser.Text = "User\'s markers";
            this.checkBoxUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxUser.UseVisualStyleBackColor = true;
            this.checkBoxUser.CheckedChanged += new System.EventHandler(this.checkBoxUser_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(11)))));
            this.ClientSize = new System.Drawing.Size(1132, 676);
            this.Controls.Add(this.checkBoxUser);
            this.Controls.Add(this.checkBoxZone);
            this.Controls.Add(this.checkBoxForests);
            this.Controls.Add(this.checkBoxRivers);
            this.Controls.Add(this.checkBoxLakes);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBoxBuildings);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.CheckBox checkBoxBuildings;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBoxLakes;
        private System.Windows.Forms.CheckBox checkBoxRivers;
        private System.Windows.Forms.CheckBox checkBoxForests;
        private System.Windows.Forms.CheckBox checkBoxZone;
        private System.Windows.Forms.CheckBox checkBoxUser;
    }
}

