namespace FMStream
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SerialRawText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioNode = new System.Windows.Forms.GroupBox();
            this.rdsButton = new System.Windows.Forms.Button();
            this.slotButton = new System.Windows.Forms.Button();
            this.tuneStatus = new System.Windows.Forms.GroupBox();
            this.getTuneStatus = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.AntenaCap = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.snr = new System.Windows.Forms.TextBox();
            this.rssi = new System.Windows.Forms.TextBox();
            this.freqStatus = new System.Windows.Forms.TextBox();
            this.validStatus = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Sw2 = new System.Windows.Forms.Button();
            this.Sw1 = new System.Windows.Forms.Button();
            this.rds = new System.Windows.Forms.TextBox();
            this.Frequency = new System.Windows.Forms.TextBox();
            this.tuneFrequencyLabel = new System.Windows.Forms.Label();
            this.sendTune = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.slot = new System.Windows.Forms.TextBox();
            this.shutDownPicture = new System.Windows.Forms.PictureBox();
            this.powerManager = new System.Windows.Forms.GroupBox();
            this.value2 = new System.Windows.Forms.TextBox();
            this.value1 = new System.Windows.Forms.TextBox();
            this.value0 = new System.Windows.Forms.TextBox();
            this.key2 = new System.Windows.Forms.Label();
            this.key1 = new System.Windows.Forms.Label();
            this.key0 = new System.Windows.Forms.Label();
            this.chargePicture = new System.Windows.Forms.PictureBox();
            this.batteryPicture = new System.Windows.Forms.PictureBox();
            this.PowerPicture = new System.Windows.Forms.PictureBox();
            this.sw2Picture = new System.Windows.Forms.PictureBox();
            this.sw1Picture = new System.Windows.Forms.PictureBox();
            this.ModulePicture = new System.Windows.Forms.PictureBox();
            this.Seek = new System.Windows.Forms.Button();
            this.RadioNode.SuspendLayout();
            this.tuneStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shutDownPicture)).BeginInit();
            this.powerManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteryPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sw2Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sw1Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModulePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // SerialRawText
            // 
            this.SerialRawText.Location = new System.Drawing.Point(360, 16);
            this.SerialRawText.Multiline = true;
            this.SerialRawText.Name = "SerialRawText";
            this.SerialRawText.ReadOnly = true;
            this.SerialRawText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SerialRawText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SerialRawText.Size = new System.Drawing.Size(116, 127);
            this.SerialRawText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial Data";
            // 
            // RadioNode
            // 
            this.RadioNode.Controls.Add(this.rdsButton);
            this.RadioNode.Controls.Add(this.slotButton);
            this.RadioNode.Controls.Add(this.tuneStatus);
            this.RadioNode.Controls.Add(this.Sw2);
            this.RadioNode.Controls.Add(this.Sw1);
            this.RadioNode.Controls.Add(this.rds);
            this.RadioNode.Controls.Add(this.Frequency);
            this.RadioNode.Controls.Add(this.tuneFrequencyLabel);
            this.RadioNode.Controls.Add(this.Seek);
            this.RadioNode.Controls.Add(this.sendTune);
            this.RadioNode.Controls.Add(this.label4);
            this.RadioNode.Controls.Add(this.label8);
            this.RadioNode.Controls.Add(this.label3);
            this.RadioNode.Controls.Add(this.slot);
            this.RadioNode.Controls.Add(this.shutDownPicture);
            this.RadioNode.Location = new System.Drawing.Point(360, 141);
            this.RadioNode.Name = "RadioNode";
            this.RadioNode.Size = new System.Drawing.Size(219, 174);
            this.RadioNode.TabIndex = 8;
            this.RadioNode.TabStop = false;
            this.RadioNode.Text = "Radio Node";
            // 
            // rdsButton
            // 
            this.rdsButton.Location = new System.Drawing.Point(10, 122);
            this.rdsButton.Name = "rdsButton";
            this.rdsButton.Size = new System.Drawing.Size(40, 21);
            this.rdsButton.TabIndex = 16;
            this.rdsButton.Text = "RDS";
            this.rdsButton.UseVisualStyleBackColor = true;
            this.rdsButton.Click += new System.EventHandler(this.rdsButton_Click);
            // 
            // slotButton
            // 
            this.slotButton.Location = new System.Drawing.Point(10, 149);
            this.slotButton.Name = "slotButton";
            this.slotButton.Size = new System.Drawing.Size(40, 23);
            this.slotButton.TabIndex = 16;
            this.slotButton.Text = "Slot";
            this.slotButton.UseVisualStyleBackColor = true;
            this.slotButton.Click += new System.EventHandler(this.slotButton_Click);
            // 
            // tuneStatus
            // 
            this.tuneStatus.Controls.Add(this.getTuneStatus);
            this.tuneStatus.Controls.Add(this.label6);
            this.tuneStatus.Controls.Add(this.AntenaCap);
            this.tuneStatus.Controls.Add(this.label5);
            this.tuneStatus.Controls.Add(this.snr);
            this.tuneStatus.Controls.Add(this.rssi);
            this.tuneStatus.Controls.Add(this.freqStatus);
            this.tuneStatus.Controls.Add(this.validStatus);
            this.tuneStatus.Controls.Add(this.label7);
            this.tuneStatus.Controls.Add(this.label2);
            this.tuneStatus.Location = new System.Drawing.Point(119, 10);
            this.tuneStatus.Name = "tuneStatus";
            this.tuneStatus.Size = new System.Drawing.Size(98, 158);
            this.tuneStatus.TabIndex = 15;
            this.tuneStatus.TabStop = false;
            this.tuneStatus.Text = "Tune Status";
            // 
            // getTuneStatus
            // 
            this.getTuneStatus.Location = new System.Drawing.Point(54, 13);
            this.getTuneStatus.Name = "getTuneStatus";
            this.getTuneStatus.Size = new System.Drawing.Size(36, 20);
            this.getTuneStatus.TabIndex = 20;
            this.getTuneStatus.Text = "Get";
            this.getTuneStatus.UseVisualStyleBackColor = true;
            this.getTuneStatus.Click += new System.EventHandler(this.getTuneStatus_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Snr";
            // 
            // AntenaCap
            // 
            this.AntenaCap.Enabled = false;
            this.AntenaCap.Location = new System.Drawing.Point(63, 104);
            this.AntenaCap.Name = "AntenaCap";
            this.AntenaCap.Size = new System.Drawing.Size(27, 20);
            this.AntenaCap.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Rssi";
            // 
            // snr
            // 
            this.snr.Enabled = false;
            this.snr.Location = new System.Drawing.Point(34, 82);
            this.snr.Name = "snr";
            this.snr.Size = new System.Drawing.Size(27, 20);
            this.snr.TabIndex = 18;
            // 
            // rssi
            // 
            this.rssi.Enabled = false;
            this.rssi.Location = new System.Drawing.Point(34, 59);
            this.rssi.Name = "rssi";
            this.rssi.Size = new System.Drawing.Size(27, 20);
            this.rssi.TabIndex = 18;
            // 
            // freqStatus
            // 
            this.freqStatus.Enabled = false;
            this.freqStatus.Location = new System.Drawing.Point(54, 37);
            this.freqStatus.Name = "freqStatus";
            this.freqStatus.Size = new System.Drawing.Size(40, 20);
            this.freqStatus.TabIndex = 16;
            // 
            // validStatus
            // 
            this.validStatus.AutoSize = true;
            this.validStatus.Enabled = false;
            this.validStatus.Location = new System.Drawing.Point(3, 15);
            this.validStatus.Name = "validStatus";
            this.validStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.validStatus.Size = new System.Drawing.Size(48, 17);
            this.validStatus.TabIndex = 14;
            this.validStatus.TabStop = true;
            this.validStatus.Text = "Valid";
            this.validStatus.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "AntenaCap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Frequency";
            // 
            // Sw2
            // 
            this.Sw2.Location = new System.Drawing.Point(58, 58);
            this.Sw2.Name = "Sw2";
            this.Sw2.Size = new System.Drawing.Size(40, 22);
            this.Sw2.TabIndex = 14;
            this.Sw2.Text = "Sw2";
            this.Sw2.UseVisualStyleBackColor = true;
            this.Sw2.Click += new System.EventHandler(this.Sw2_Click);
            // 
            // Sw1
            // 
            this.Sw1.Location = new System.Drawing.Point(9, 58);
            this.Sw1.Name = "Sw1";
            this.Sw1.Size = new System.Drawing.Size(43, 22);
            this.Sw1.TabIndex = 13;
            this.Sw1.Text = "Sw1";
            this.Sw1.UseVisualStyleBackColor = true;
            this.Sw1.Click += new System.EventHandler(this.Sw1_Click);
            // 
            // rds
            // 
            this.rds.Location = new System.Drawing.Point(52, 122);
            this.rds.Name = "rds";
            this.rds.Size = new System.Drawing.Size(61, 20);
            this.rds.TabIndex = 12;
            // 
            // Frequency
            // 
            this.Frequency.Location = new System.Drawing.Point(9, 32);
            this.Frequency.Name = "Frequency";
            this.Frequency.Size = new System.Drawing.Size(43, 20);
            this.Frequency.TabIndex = 12;
            // 
            // tuneFrequencyLabel
            // 
            this.tuneFrequencyLabel.AutoSize = true;
            this.tuneFrequencyLabel.Location = new System.Drawing.Point(7, 16);
            this.tuneFrequencyLabel.Name = "tuneFrequencyLabel";
            this.tuneFrequencyLabel.Size = new System.Drawing.Size(85, 13);
            this.tuneFrequencyLabel.TabIndex = 11;
            this.tuneFrequencyLabel.Text = "Tune Frequency";
            // 
            // sendTune
            // 
            this.sendTune.Location = new System.Drawing.Point(58, 31);
            this.sendTune.Name = "sendTune";
            this.sendTune.Size = new System.Drawing.Size(40, 20);
            this.sendTune.TabIndex = 5;
            this.sendTune.Text = "Send";
            this.sendTune.UseVisualStyleBackColor = true;
            this.sendTune.Click += new System.EventHandler(this.sendTune_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "ShutDown";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // slot
            // 
            this.slot.Location = new System.Drawing.Point(52, 151);
            this.slot.Name = "slot";
            this.slot.Size = new System.Drawing.Size(30, 20);
            this.slot.TabIndex = 3;
            // 
            // shutDownPicture
            // 
            this.shutDownPicture.BackColor = System.Drawing.Color.Transparent;
            this.shutDownPicture.Image = global::FMStream.Properties.Resources.ButtonGreen;
            this.shutDownPicture.InitialImage = global::FMStream.Properties.Resources.ButtonGreen;
            this.shutDownPicture.Location = new System.Drawing.Point(88, 96);
            this.shutDownPicture.Name = "shutDownPicture";
            this.shutDownPicture.Size = new System.Drawing.Size(11, 11);
            this.shutDownPicture.TabIndex = 10;
            this.shutDownPicture.TabStop = false;
            // 
            // powerManager
            // 
            this.powerManager.Controls.Add(this.value2);
            this.powerManager.Controls.Add(this.value1);
            this.powerManager.Controls.Add(this.value0);
            this.powerManager.Controls.Add(this.key2);
            this.powerManager.Controls.Add(this.key1);
            this.powerManager.Controls.Add(this.key0);
            this.powerManager.Location = new System.Drawing.Point(375, 389);
            this.powerManager.Name = "powerManager";
            this.powerManager.Size = new System.Drawing.Size(176, 118);
            this.powerManager.TabIndex = 9;
            this.powerManager.TabStop = false;
            this.powerManager.Text = "Power Manager";
            // 
            // value2
            // 
            this.value2.Location = new System.Drawing.Point(129, 88);
            this.value2.Name = "value2";
            this.value2.Size = new System.Drawing.Size(36, 20);
            this.value2.TabIndex = 14;
            // 
            // value1
            // 
            this.value1.Location = new System.Drawing.Point(129, 49);
            this.value1.Name = "value1";
            this.value1.Size = new System.Drawing.Size(36, 20);
            this.value1.TabIndex = 14;
            // 
            // value0
            // 
            this.value0.Location = new System.Drawing.Point(129, 13);
            this.value0.Name = "value0";
            this.value0.Size = new System.Drawing.Size(36, 20);
            this.value0.TabIndex = 14;
            // 
            // key2
            // 
            this.key2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.key2.Location = new System.Drawing.Point(27, 91);
            this.key2.Name = "key2";
            this.key2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.key2.Size = new System.Drawing.Size(101, 13);
            this.key2.TabIndex = 12;
            this.key2.Text = "key";
            this.key2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // key1
            // 
            this.key1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.key1.Location = new System.Drawing.Point(24, 52);
            this.key1.Name = "key1";
            this.key1.Size = new System.Drawing.Size(104, 13);
            this.key1.TabIndex = 12;
            this.key1.Text = "key";
            this.key1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // key0
            // 
            this.key0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.key0.Location = new System.Drawing.Point(24, 16);
            this.key0.Name = "key0";
            this.key0.Size = new System.Drawing.Size(104, 13);
            this.key0.TabIndex = 12;
            this.key0.Text = "key";
            this.key0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chargePicture
            // 
            this.chargePicture.BackColor = System.Drawing.Color.Transparent;
            this.chargePicture.Image = global::FMStream.Properties.Resources.ButtonGreen;
            this.chargePicture.InitialImage = global::FMStream.Properties.Resources.ButtonGreen;
            this.chargePicture.Location = new System.Drawing.Point(245, 389);
            this.chargePicture.Name = "chargePicture";
            this.chargePicture.Size = new System.Drawing.Size(11, 10);
            this.chargePicture.TabIndex = 10;
            this.chargePicture.TabStop = false;
            // 
            // batteryPicture
            // 
            this.batteryPicture.BackColor = System.Drawing.Color.Transparent;
            this.batteryPicture.Image = global::FMStream.Properties.Resources.ButtonGreen;
            this.batteryPicture.InitialImage = global::FMStream.Properties.Resources.ButtonGreen;
            this.batteryPicture.Location = new System.Drawing.Point(245, 261);
            this.batteryPicture.Name = "batteryPicture";
            this.batteryPicture.Size = new System.Drawing.Size(10, 10);
            this.batteryPicture.TabIndex = 10;
            this.batteryPicture.TabStop = false;
            // 
            // PowerPicture
            // 
            this.PowerPicture.BackColor = System.Drawing.Color.Transparent;
            this.PowerPicture.Image = global::FMStream.Properties.Resources.ButtonGreen;
            this.PowerPicture.InitialImage = global::FMStream.Properties.Resources.ButtonGreen;
            this.PowerPicture.Location = new System.Drawing.Point(245, 199);
            this.PowerPicture.Name = "PowerPicture";
            this.PowerPicture.Size = new System.Drawing.Size(10, 10);
            this.PowerPicture.TabIndex = 10;
            this.PowerPicture.TabStop = false;
            // 
            // sw2Picture
            // 
            this.sw2Picture.BackColor = System.Drawing.Color.Transparent;
            this.sw2Picture.Image = global::FMStream.Properties.Resources.ButtonGreen;
            this.sw2Picture.InitialImage = global::FMStream.Properties.Resources.ButtonGreen;
            this.sw2Picture.Location = new System.Drawing.Point(86, 199);
            this.sw2Picture.Name = "sw2Picture";
            this.sw2Picture.Size = new System.Drawing.Size(10, 10);
            this.sw2Picture.TabIndex = 10;
            this.sw2Picture.TabStop = false;
            // 
            // sw1Picture
            // 
            this.sw1Picture.BackColor = System.Drawing.Color.Transparent;
            this.sw1Picture.Image = global::FMStream.Properties.Resources.ButtonGreen;
            this.sw1Picture.InitialImage = global::FMStream.Properties.Resources.ButtonGreen;
            this.sw1Picture.Location = new System.Drawing.Point(86, 174);
            this.sw1Picture.Name = "sw1Picture";
            this.sw1Picture.Size = new System.Drawing.Size(10, 10);
            this.sw1Picture.TabIndex = 10;
            this.sw1Picture.TabStop = false;
            // 
            // ModulePicture
            // 
            this.ModulePicture.BackColor = System.Drawing.Color.Transparent;
            this.ModulePicture.BackgroundImage = global::FMStream.Properties.Resources.Final_Layout__1_;
            this.ModulePicture.Image = global::FMStream.Properties.Resources.Final_Layout__1_;
            this.ModulePicture.Location = new System.Drawing.Point(0, 0);
            this.ModulePicture.Name = "ModulePicture";
            this.ModulePicture.Size = new System.Drawing.Size(351, 519);
            this.ModulePicture.TabIndex = 0;
            this.ModulePicture.TabStop = false;
            // 
            // Seek
            // 
            this.Seek.Location = new System.Drawing.Point(10, 92);
            this.Seek.Name = "Seek";
            this.Seek.Size = new System.Drawing.Size(40, 20);
            this.Seek.TabIndex = 5;
            this.Seek.Text = "Seek";
            this.Seek.UseVisualStyleBackColor = true;
            this.Seek.Click += new System.EventHandler(this.seekTune_Click);
            // 
            // Form1
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 519);
            this.Controls.Add(this.chargePicture);
            this.Controls.Add(this.batteryPicture);
            this.Controls.Add(this.PowerPicture);
            this.Controls.Add(this.sw2Picture);
            this.Controls.Add(this.sw1Picture);
            this.Controls.Add(this.powerManager);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SerialRawText);
            this.Controls.Add(this.ModulePicture);
            this.Controls.Add(this.RadioNode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "Radio Stream";
            this.RadioNode.ResumeLayout(false);
            this.RadioNode.PerformLayout();
            this.tuneStatus.ResumeLayout(false);
            this.tuneStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shutDownPicture)).EndInit();
            this.powerManager.ResumeLayout(false);
            this.powerManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteryPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sw2Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sw1Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModulePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ModulePicture;
        private System.Windows.Forms.TextBox SerialRawText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox RadioNode;
        private System.Windows.Forms.GroupBox powerManager;
        private System.Windows.Forms.PictureBox sw1Picture;
        private System.Windows.Forms.PictureBox sw2Picture;
        private System.Windows.Forms.PictureBox PowerPicture;
        private System.Windows.Forms.PictureBox batteryPicture;
        private System.Windows.Forms.PictureBox chargePicture;
        private System.Windows.Forms.Button sendTune;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox slot;
        private System.Windows.Forms.PictureBox shutDownPicture;
        private System.Windows.Forms.Button Sw2;
        private System.Windows.Forms.Button Sw1;
        private System.Windows.Forms.TextBox Frequency;
        private System.Windows.Forms.Label tuneFrequencyLabel;
        private System.Windows.Forms.GroupBox tuneStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AntenaCap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox snr;
        private System.Windows.Forms.TextBox rssi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox freqStatus;
        private System.Windows.Forms.RadioButton validStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rds;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button getTuneStatus;
        private System.Windows.Forms.Button slotButton;
        private System.Windows.Forms.Button rdsButton;
        private System.Windows.Forms.Label key0;
        private System.Windows.Forms.TextBox value2;
        private System.Windows.Forms.TextBox value1;
        private System.Windows.Forms.TextBox value0;
        private System.Windows.Forms.Label key2;
        private System.Windows.Forms.Label key1;
        private System.Windows.Forms.Button Seek;
    }
}

