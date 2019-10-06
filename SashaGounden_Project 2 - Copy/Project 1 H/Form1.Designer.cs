namespace Project_1_H
{
    partial class Form1
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
            this.lblMap = new System.Windows.Forms.Label();
            this.lblCurrentRound = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.btnStartPause = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblNumUnits = new System.Windows.Forms.Label();
            this.lblNumBuilding = new System.Windows.Forms.Label();
            this.lblMapWidth = new System.Windows.Forms.Label();
            this.lblMapHeight = new System.Windows.Forms.Label();
            this.txtNumUnits = new System.Windows.Forms.TextBox();
            this.txtNumBuildings = new System.Windows.Forms.TextBox();
            this.txtMapWidth = new System.Windows.Forms.TextBox();
            this.txtMapHeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(12, 9);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(598, 543);
            this.lblMap.TabIndex = 0;
            this.lblMap.Text = "label1";
            this.lblMap.Click += new System.EventHandler(this.lblMap_Click);
            // 
            // lblCurrentRound
            // 
            this.lblCurrentRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentRound.Location = new System.Drawing.Point(645, 9);
            this.lblCurrentRound.Name = "lblCurrentRound";
            this.lblCurrentRound.Size = new System.Drawing.Size(216, 93);
            this.lblCurrentRound.TabIndex = 1;
            this.lblCurrentRound.Text = "label2";
            this.lblCurrentRound.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(644, 105);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(216, 172);
            this.txtInfo.TabIndex = 2;
            this.txtInfo.Text = "";
            // 
            // btnStartPause
            // 
            this.btnStartPause.Location = new System.Drawing.Point(644, 324);
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(216, 51);
            this.btnStartPause.TabIndex = 3;
            this.btnStartPause.Text = "START";
            this.btnStartPause.UseVisualStyleBackColor = true;
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(644, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(760, 283);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 35);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblNumUnits
            // 
            this.lblNumUnits.AutoSize = true;
            this.lblNumUnits.Location = new System.Drawing.Point(641, 409);
            this.lblNumUnits.Name = "lblNumUnits";
            this.lblNumUnits.Size = new System.Drawing.Size(110, 17);
            this.lblNumUnits.TabIndex = 6;
            this.lblNumUnits.Text = "Number of Units";
            // 
            // lblNumBuilding
            // 
            this.lblNumBuilding.AutoSize = true;
            this.lblNumBuilding.Location = new System.Drawing.Point(787, 409);
            this.lblNumBuilding.Name = "lblNumBuilding";
            this.lblNumBuilding.Size = new System.Drawing.Size(135, 17);
            this.lblNumBuilding.TabIndex = 7;
            this.lblNumBuilding.Text = "Number of Buildings";
            // 
            // lblMapWidth
            // 
            this.lblMapWidth.AutoSize = true;
            this.lblMapWidth.Location = new System.Drawing.Point(787, 498);
            this.lblMapWidth.Name = "lblMapWidth";
            this.lblMapWidth.Size = new System.Drawing.Size(75, 17);
            this.lblMapWidth.TabIndex = 8;
            this.lblMapWidth.Text = "Map Width";
            // 
            // lblMapHeight
            // 
            this.lblMapHeight.AutoSize = true;
            this.lblMapHeight.Location = new System.Drawing.Point(641, 498);
            this.lblMapHeight.Name = "lblMapHeight";
            this.lblMapHeight.Size = new System.Drawing.Size(80, 17);
            this.lblMapHeight.TabIndex = 9;
            this.lblMapHeight.Text = "Map Height";
            // 
            // txtNumUnits
            // 
            this.txtNumUnits.Location = new System.Drawing.Point(644, 429);
            this.txtNumUnits.Name = "txtNumUnits";
            this.txtNumUnits.Size = new System.Drawing.Size(70, 22);
            this.txtNumUnits.TabIndex = 10;
            this.txtNumUnits.Text = "30";
            // 
            // txtNumBuildings
            // 
            this.txtNumBuildings.Location = new System.Drawing.Point(790, 429);
            this.txtNumBuildings.Name = "txtNumBuildings";
            this.txtNumBuildings.Size = new System.Drawing.Size(70, 22);
            this.txtNumBuildings.TabIndex = 11;
            this.txtNumBuildings.Text = "10";
            // 
            // txtMapWidth
            // 
            this.txtMapWidth.Location = new System.Drawing.Point(790, 518);
            this.txtMapWidth.Name = "txtMapWidth";
            this.txtMapWidth.Size = new System.Drawing.Size(70, 22);
            this.txtMapWidth.TabIndex = 12;
            this.txtMapWidth.Text = "20";
            // 
            // txtMapHeight
            // 
            this.txtMapHeight.Location = new System.Drawing.Point(644, 518);
            this.txtMapHeight.Name = "txtMapHeight";
            this.txtMapHeight.Size = new System.Drawing.Size(70, 22);
            this.txtMapHeight.TabIndex = 13;
            this.txtMapHeight.Text = "20";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 606);
            this.Controls.Add(this.txtMapHeight);
            this.Controls.Add(this.txtMapWidth);
            this.Controls.Add(this.txtNumBuildings);
            this.Controls.Add(this.txtNumUnits);
            this.Controls.Add(this.lblMapHeight);
            this.Controls.Add(this.lblMapWidth);
            this.Controls.Add(this.lblNumBuilding);
            this.Controls.Add(this.lblNumUnits);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStartPause);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblCurrentRound);
            this.Controls.Add(this.lblMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblCurrentRound;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.Button btnStartPause;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblNumUnits;
        private System.Windows.Forms.Label lblNumBuilding;
        private System.Windows.Forms.Label lblMapWidth;
        private System.Windows.Forms.Label lblMapHeight;
        private System.Windows.Forms.TextBox txtNumUnits;
        private System.Windows.Forms.TextBox txtNumBuildings;
        private System.Windows.Forms.TextBox txtMapWidth;
        private System.Windows.Forms.TextBox txtMapHeight;
    }
}

