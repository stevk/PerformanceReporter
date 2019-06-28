namespace PerformanceReporter
{
    partial class MainWindow
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
            this.selectTraceButton = new System.Windows.Forms.Button();
            this.tracePathTextBox = new System.Windows.Forms.TextBox();
            this.selectSymbolsButton = new System.Windows.Forms.Button();
            this.symbolsPathTextBox = new System.Windows.Forms.TextBox();
            this.buildNameTextBox = new System.Windows.Forms.TextBox();
            this.EventProfileComboBox = new System.Windows.Forms.ComboBox();
            this.startEventTextBox = new System.Windows.Forms.TextBox();
            this.endEventTextBox = new System.Windows.Forms.TextBox();
            this.NotesTextBox = new System.Windows.Forms.TextBox();
            this.tracePathLabel = new System.Windows.Forms.Label();
            this.symbolsPathLabel = new System.Windows.Forms.Label();
            this.buildNameLabel = new System.Windows.Forms.Label();
            this.EventProfileLabel = new System.Windows.Forms.Label();
            this.StartEventLabel = new System.Windows.Forms.Label();
            this.endEventLabel = new System.Windows.Forms.Label();
            this.NotesLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SaveProfileButton = new System.Windows.Forms.Button();
            this.startEventParam1TextBox = new System.Windows.Forms.TextBox();
            this.startEventParam2TextBox = new System.Windows.Forms.TextBox();
            this.endEventParam2TextBox = new System.Windows.Forms.TextBox();
            this.endEventParam1TextBox = new System.Windows.Forms.TextBox();
            this.scenarioNameTextBox = new System.Windows.Forms.TextBox();
            this.scenarioLabel = new System.Windows.Forms.Label();
            this.selectOutputButton = new System.Windows.Forms.Button();
            this.deleteProfileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectTraceButton
            // 
            this.selectTraceButton.Location = new System.Drawing.Point(348, 129);
            this.selectTraceButton.Name = "selectTraceButton";
            this.selectTraceButton.Size = new System.Drawing.Size(76, 23);
            this.selectTraceButton.TabIndex = 0;
            this.selectTraceButton.Text = "Select Trace";
            this.selectTraceButton.UseVisualStyleBackColor = true;
            this.selectTraceButton.Click += new System.EventHandler(this.selectTraceButton_Click);
            // 
            // tracePathTextBox
            // 
            this.tracePathTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.tracePathTextBox.Location = new System.Drawing.Point(59, 131);
            this.tracePathTextBox.Name = "tracePathTextBox";
            this.tracePathTextBox.Size = new System.Drawing.Size(282, 20);
            this.tracePathTextBox.TabIndex = 1;
            this.tracePathTextBox.TextChanged += new System.EventHandler(this.tracePathTextBox_TextChanged);
            // 
            // selectSymbolsButton
            // 
            this.selectSymbolsButton.Location = new System.Drawing.Point(348, 155);
            this.selectSymbolsButton.Name = "selectSymbolsButton";
            this.selectSymbolsButton.Size = new System.Drawing.Size(123, 23);
            this.selectSymbolsButton.TabIndex = 2;
            this.selectSymbolsButton.Text = "Select Symbols Folder";
            this.selectSymbolsButton.UseVisualStyleBackColor = true;
            this.selectSymbolsButton.Click += new System.EventHandler(this.selectSymbolsButton_Click);
            // 
            // symbolsPathTextBox
            // 
            this.symbolsPathTextBox.Location = new System.Drawing.Point(59, 157);
            this.symbolsPathTextBox.Name = "symbolsPathTextBox";
            this.symbolsPathTextBox.Size = new System.Drawing.Size(282, 20);
            this.symbolsPathTextBox.TabIndex = 3;
            this.symbolsPathTextBox.TextChanged += new System.EventHandler(this.symbolsPathTextBox_TextChanged);
            // 
            // buildNameTextBox
            // 
            this.buildNameTextBox.Location = new System.Drawing.Point(59, 183);
            this.buildNameTextBox.Name = "buildNameTextBox";
            this.buildNameTextBox.Size = new System.Drawing.Size(282, 20);
            this.buildNameTextBox.TabIndex = 4;
            this.buildNameTextBox.TextChanged += new System.EventHandler(this.buildNameTextBox_TextChanged);
            // 
            // EventProfileComboBox
            // 
            this.EventProfileComboBox.FormattingEnabled = true;
            this.EventProfileComboBox.Location = new System.Drawing.Point(59, 12);
            this.EventProfileComboBox.Name = "EventProfileComboBox";
            this.EventProfileComboBox.Size = new System.Drawing.Size(282, 21);
            this.EventProfileComboBox.TabIndex = 5;
            this.EventProfileComboBox.SelectedIndexChanged += new System.EventHandler(this.EventProfileComboBox_SelectedIndexChanged);
            // 
            // startEventTextBox
            // 
            this.startEventTextBox.Location = new System.Drawing.Point(78, 65);
            this.startEventTextBox.Name = "startEventTextBox";
            this.startEventTextBox.Size = new System.Drawing.Size(263, 20);
            this.startEventTextBox.TabIndex = 6;
            this.startEventTextBox.TextChanged += new System.EventHandler(this.startEventTextBox_TextChanged);
            // 
            // endEventTextBox
            // 
            this.endEventTextBox.Location = new System.Drawing.Point(78, 91);
            this.endEventTextBox.Name = "endEventTextBox";
            this.endEventTextBox.Size = new System.Drawing.Size(263, 20);
            this.endEventTextBox.TabIndex = 7;
            this.endEventTextBox.TextChanged += new System.EventHandler(this.endEventTextBox_TextChanged);
            // 
            // NotesTextBox
            // 
            this.NotesTextBox.Location = new System.Drawing.Point(59, 209);
            this.NotesTextBox.Multiline = true;
            this.NotesTextBox.Name = "NotesTextBox";
            this.NotesTextBox.Size = new System.Drawing.Size(282, 104);
            this.NotesTextBox.TabIndex = 8;
            // 
            // tracePathLabel
            // 
            this.tracePathLabel.AutoSize = true;
            this.tracePathLabel.Location = new System.Drawing.Point(5, 134);
            this.tracePathLabel.Name = "tracePathLabel";
            this.tracePathLabel.Size = new System.Drawing.Size(35, 13);
            this.tracePathLabel.TabIndex = 9;
            this.tracePathLabel.Text = "Trace";
            // 
            // symbolsPathLabel
            // 
            this.symbolsPathLabel.AutoSize = true;
            this.symbolsPathLabel.Location = new System.Drawing.Point(5, 161);
            this.symbolsPathLabel.Name = "symbolsPathLabel";
            this.symbolsPathLabel.Size = new System.Drawing.Size(46, 13);
            this.symbolsPathLabel.TabIndex = 10;
            this.symbolsPathLabel.Text = "Symbols";
            // 
            // buildNameLabel
            // 
            this.buildNameLabel.AutoSize = true;
            this.buildNameLabel.Location = new System.Drawing.Point(5, 184);
            this.buildNameLabel.Name = "buildNameLabel";
            this.buildNameLabel.Size = new System.Drawing.Size(30, 13);
            this.buildNameLabel.TabIndex = 11;
            this.buildNameLabel.Text = "Build";
            // 
            // EventProfileLabel
            // 
            this.EventProfileLabel.AutoSize = true;
            this.EventProfileLabel.Location = new System.Drawing.Point(5, 16);
            this.EventProfileLabel.Name = "EventProfileLabel";
            this.EventProfileLabel.Size = new System.Drawing.Size(36, 13);
            this.EventProfileLabel.TabIndex = 12;
            this.EventProfileLabel.Text = "Profile";
            // 
            // StartEventLabel
            // 
            this.StartEventLabel.AutoSize = true;
            this.StartEventLabel.Location = new System.Drawing.Point(14, 68);
            this.StartEventLabel.Name = "StartEventLabel";
            this.StartEventLabel.Size = new System.Drawing.Size(60, 13);
            this.StartEventLabel.TabIndex = 13;
            this.StartEventLabel.Text = "Start Event";
            // 
            // endEventLabel
            // 
            this.endEventLabel.AutoSize = true;
            this.endEventLabel.Location = new System.Drawing.Point(14, 94);
            this.endEventLabel.Name = "endEventLabel";
            this.endEventLabel.Size = new System.Drawing.Size(57, 13);
            this.endEventLabel.TabIndex = 14;
            this.endEventLabel.Text = "End Event";
            // 
            // NotesLabel
            // 
            this.NotesLabel.AutoSize = true;
            this.NotesLabel.Location = new System.Drawing.Point(5, 210);
            this.NotesLabel.Name = "NotesLabel";
            this.NotesLabel.Size = new System.Drawing.Size(35, 13);
            this.NotesLabel.TabIndex = 15;
            this.NotesLabel.Text = "Notes";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(454, 299);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 50);
            this.StartButton.TabIndex = 16;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(59, 319);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(282, 20);
            this.resultTextBox.TabIndex = 17;
            this.resultTextBox.TextChanged += new System.EventHandler(this.resultTextBox_TextChanged);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(5, 322);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(39, 13);
            this.resultLabel.TabIndex = 18;
            this.resultLabel.Text = "Output";
            // 
            // SaveProfileButton
            // 
            this.SaveProfileButton.Location = new System.Drawing.Point(347, 10);
            this.SaveProfileButton.Name = "SaveProfileButton";
            this.SaveProfileButton.Size = new System.Drawing.Size(75, 23);
            this.SaveProfileButton.TabIndex = 19;
            this.SaveProfileButton.Text = "Save Profile";
            this.SaveProfileButton.UseVisualStyleBackColor = true;
            this.SaveProfileButton.Click += new System.EventHandler(this.SaveProfileButton_Click);
            // 
            // startEventParam1TextBox
            // 
            this.startEventParam1TextBox.Location = new System.Drawing.Point(348, 64);
            this.startEventParam1TextBox.Name = "startEventParam1TextBox";
            this.startEventParam1TextBox.Size = new System.Drawing.Size(100, 20);
            this.startEventParam1TextBox.TabIndex = 20;
            // 
            // startEventParam2TextBox
            // 
            this.startEventParam2TextBox.Location = new System.Drawing.Point(454, 64);
            this.startEventParam2TextBox.Name = "startEventParam2TextBox";
            this.startEventParam2TextBox.Size = new System.Drawing.Size(100, 20);
            this.startEventParam2TextBox.TabIndex = 21;
            // 
            // endEventParam2TextBox
            // 
            this.endEventParam2TextBox.Location = new System.Drawing.Point(454, 91);
            this.endEventParam2TextBox.Name = "endEventParam2TextBox";
            this.endEventParam2TextBox.Size = new System.Drawing.Size(100, 20);
            this.endEventParam2TextBox.TabIndex = 23;
            // 
            // endEventParam1TextBox
            // 
            this.endEventParam1TextBox.Location = new System.Drawing.Point(348, 91);
            this.endEventParam1TextBox.Name = "endEventParam1TextBox";
            this.endEventParam1TextBox.Size = new System.Drawing.Size(100, 20);
            this.endEventParam1TextBox.TabIndex = 22;
            // 
            // scenarioNameTextBox
            // 
            this.scenarioNameTextBox.Location = new System.Drawing.Point(59, 39);
            this.scenarioNameTextBox.Name = "scenarioNameTextBox";
            this.scenarioNameTextBox.Size = new System.Drawing.Size(282, 20);
            this.scenarioNameTextBox.TabIndex = 24;
            this.scenarioNameTextBox.TextChanged += new System.EventHandler(this.scenarioNameTextBox_TextChanged);
            // 
            // scenarioLabel
            // 
            this.scenarioLabel.AutoSize = true;
            this.scenarioLabel.Location = new System.Drawing.Point(5, 42);
            this.scenarioLabel.Name = "scenarioLabel";
            this.scenarioLabel.Size = new System.Drawing.Size(49, 13);
            this.scenarioLabel.TabIndex = 25;
            this.scenarioLabel.Text = "Scenario";
            // 
            // selectOutputButton
            // 
            this.selectOutputButton.Location = new System.Drawing.Point(348, 317);
            this.selectOutputButton.Name = "selectOutputButton";
            this.selectOutputButton.Size = new System.Drawing.Size(75, 23);
            this.selectOutputButton.TabIndex = 26;
            this.selectOutputButton.Text = "Select FIle";
            this.selectOutputButton.UseVisualStyleBackColor = true;
            this.selectOutputButton.Click += new System.EventHandler(this.selectOutputButton_Click);
            // 
            // deleteProfileButton
            // 
            this.deleteProfileButton.Enabled = false;
            this.deleteProfileButton.Location = new System.Drawing.Point(428, 10);
            this.deleteProfileButton.Name = "deleteProfileButton";
            this.deleteProfileButton.Size = new System.Drawing.Size(80, 23);
            this.deleteProfileButton.TabIndex = 27;
            this.deleteProfileButton.Text = "Delete Profile";
            this.deleteProfileButton.UseVisualStyleBackColor = true;
            this.deleteProfileButton.Click += new System.EventHandler(this.deleteProfileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 362);
            this.Controls.Add(this.deleteProfileButton);
            this.Controls.Add(this.selectOutputButton);
            this.Controls.Add(this.scenarioLabel);
            this.Controls.Add(this.scenarioNameTextBox);
            this.Controls.Add(this.endEventParam2TextBox);
            this.Controls.Add(this.endEventParam1TextBox);
            this.Controls.Add(this.startEventParam2TextBox);
            this.Controls.Add(this.startEventParam1TextBox);
            this.Controls.Add(this.SaveProfileButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NotesLabel);
            this.Controls.Add(this.endEventLabel);
            this.Controls.Add(this.StartEventLabel);
            this.Controls.Add(this.EventProfileLabel);
            this.Controls.Add(this.buildNameLabel);
            this.Controls.Add(this.symbolsPathLabel);
            this.Controls.Add(this.tracePathLabel);
            this.Controls.Add(this.NotesTextBox);
            this.Controls.Add(this.endEventTextBox);
            this.Controls.Add(this.startEventTextBox);
            this.Controls.Add(this.EventProfileComboBox);
            this.Controls.Add(this.buildNameTextBox);
            this.Controls.Add(this.symbolsPathTextBox);
            this.Controls.Add(this.selectSymbolsButton);
            this.Controls.Add(this.tracePathTextBox);
            this.Controls.Add(this.selectTraceButton);
            this.Name = "Form1";
            this.Text = "Performance Reporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectTraceButton;
        private System.Windows.Forms.TextBox tracePathTextBox;
        private System.Windows.Forms.Button selectSymbolsButton;
        private System.Windows.Forms.TextBox symbolsPathTextBox;
        private System.Windows.Forms.TextBox buildNameTextBox;
        private System.Windows.Forms.ComboBox EventProfileComboBox;
        private System.Windows.Forms.TextBox startEventTextBox;
        private System.Windows.Forms.TextBox endEventTextBox;
        private System.Windows.Forms.TextBox NotesTextBox;
        private System.Windows.Forms.Label tracePathLabel;
        private System.Windows.Forms.Label symbolsPathLabel;
        private System.Windows.Forms.Label buildNameLabel;
        private System.Windows.Forms.Label EventProfileLabel;
        private System.Windows.Forms.Label StartEventLabel;
        private System.Windows.Forms.Label endEventLabel;
        private System.Windows.Forms.Label NotesLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button SaveProfileButton;
        private System.Windows.Forms.TextBox startEventParam1TextBox;
        private System.Windows.Forms.TextBox startEventParam2TextBox;
        private System.Windows.Forms.TextBox endEventParam2TextBox;
        private System.Windows.Forms.TextBox endEventParam1TextBox;
        private System.Windows.Forms.TextBox scenarioNameTextBox;
        private System.Windows.Forms.Label scenarioLabel;
        private System.Windows.Forms.Button selectOutputButton;
        private System.Windows.Forms.Button deleteProfileButton;
    }
}

