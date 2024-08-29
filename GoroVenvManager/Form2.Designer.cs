namespace GoroVenvManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CreateVenvTabPage = new System.Windows.Forms.TabPage();
            this.CreateVenvTabDisplayTextBox = new System.Windows.Forms.TextBox();
            this.CreateVenvTabSelectTemplateComboBox = new System.Windows.Forms.ComboBox();
            this.CreateVenvTabSelectFolderButton = new System.Windows.Forms.Button();
            this.CreateVenvTabSelectFolderTextBox = new System.Windows.Forms.TextBox();
            this.CreateVenvTabSelectFolderLabel = new System.Windows.Forms.Label();
            this.CreateVenvTabSelectTemplateLabel = new System.Windows.Forms.Label();
            this.CreateVenvTabInfoLabel = new System.Windows.Forms.Label();
            this.CreateVenvTabCreateButton = new System.Windows.Forms.Button();
            this.GlobalVersionTabPage = new System.Windows.Forms.TabPage();
            this.GlobalVersionTabDisplayTextBox = new System.Windows.Forms.TextBox();
            this.GlobalVersionTabVersionTextBox = new System.Windows.Forms.TextBox();
            this.GlobalVersionTabVersionLabel = new System.Windows.Forms.Label();
            this.GlobalVersionTabInfoLabel = new System.Windows.Forms.Label();
            this.GlobalVersionTabSetButton = new System.Windows.Forms.Button();
            this.LocalVersionTabPage = new System.Windows.Forms.TabPage();
            this.LocalVersionTabDisplayTextBox = new System.Windows.Forms.TextBox();
            this.LocalVersionTabSelectFolderButton = new System.Windows.Forms.Button();
            this.LocalVersionTabSelectFolderTextBox = new System.Windows.Forms.TextBox();
            this.LocalVersionTabFolderSelectLabel = new System.Windows.Forms.Label();
            this.LocalVersionTabVersionTextBox = new System.Windows.Forms.TextBox();
            this.LocalVersionTabInfoLabel = new System.Windows.Forms.Label();
            this.LocalVersonTabVersionLabel = new System.Windows.Forms.Label();
            this.LocalVersionTabSetButton = new System.Windows.Forms.Button();
            this.InstallTabPage = new System.Windows.Forms.TabPage();
            this.InstallTabDisplayTextBox = new System.Windows.Forms.TextBox();
            this.InstallTabVersionLabel = new System.Windows.Forms.Label();
            this.InstallTabVersionTextBox = new System.Windows.Forms.TextBox();
            this.installTabInfoLavel = new System.Windows.Forms.Label();
            this.InstallTabInstallButton = new System.Windows.Forms.Button();
            this.PyenvTabPage = new System.Windows.Forms.TabPage();
            this.PyenvTabInfoLabel = new System.Windows.Forms.Label();
            this.PyenvTabDisplayTextBox = new System.Windows.Forms.TextBox();
            this.PyenvTabRunButton = new System.Windows.Forms.Button();
            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.SettingsTabSelectBaseFolderButton = new System.Windows.Forms.Button();
            this.SettingsTabLabguageGroup = new System.Windows.Forms.GroupBox();
            this.SettingsTabJapaneseRadioButton = new System.Windows.Forms.RadioButton();
            this.SettingsTabEnglishRadioButton = new System.Windows.Forms.RadioButton();
            this.SettingsTabLanguageLabel = new System.Windows.Forms.Label();
            this.SettingsTabSelectBaseFolderTextBox = new System.Windows.Forms.TextBox();
            this.SettingsTabSelectBaseFolderLabel = new System.Windows.Forms.Label();
            this.SettingsTabSetButton = new System.Windows.Forms.Button();
            this.UsageTabPage = new System.Windows.Forms.TabPage();
            this.UsageTabWebBrowser = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.CreateVenvTabPage.SuspendLayout();
            this.GlobalVersionTabPage.SuspendLayout();
            this.LocalVersionTabPage.SuspendLayout();
            this.InstallTabPage.SuspendLayout();
            this.PyenvTabPage.SuspendLayout();
            this.SettingsTabPage.SuspendLayout();
            this.SettingsTabLabguageGroup.SuspendLayout();
            this.UsageTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.CreateVenvTabPage);
            this.tabControl1.Controls.Add(this.GlobalVersionTabPage);
            this.tabControl1.Controls.Add(this.LocalVersionTabPage);
            this.tabControl1.Controls.Add(this.InstallTabPage);
            this.tabControl1.Controls.Add(this.PyenvTabPage);
            this.tabControl1.Controls.Add(this.SettingsTabPage);
            this.tabControl1.Controls.Add(this.UsageTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 433);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // CreateVenvTabPage
            // 
            this.CreateVenvTabPage.Controls.Add(this.CreateVenvTabDisplayTextBox);
            this.CreateVenvTabPage.Controls.Add(this.CreateVenvTabSelectTemplateComboBox);
            this.CreateVenvTabPage.Controls.Add(this.CreateVenvTabSelectFolderButton);
            this.CreateVenvTabPage.Controls.Add(this.CreateVenvTabSelectFolderTextBox);
            this.CreateVenvTabPage.Controls.Add(this.CreateVenvTabSelectFolderLabel);
            this.CreateVenvTabPage.Controls.Add(this.CreateVenvTabSelectTemplateLabel);
            this.CreateVenvTabPage.Controls.Add(this.CreateVenvTabInfoLabel);
            this.CreateVenvTabPage.Controls.Add(this.CreateVenvTabCreateButton);
            this.CreateVenvTabPage.Location = new System.Drawing.Point(4, 22);
            this.CreateVenvTabPage.Name = "CreateVenvTabPage";
            this.CreateVenvTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CreateVenvTabPage.Size = new System.Drawing.Size(777, 407);
            this.CreateVenvTabPage.TabIndex = 0;
            this.CreateVenvTabPage.Text = "1. Create Venv";
            this.CreateVenvTabPage.UseVisualStyleBackColor = true;
            // 
            // CreateVenvTabDisplayTextBox
            // 
            this.CreateVenvTabDisplayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateVenvTabDisplayTextBox.Location = new System.Drawing.Point(15, 97);
            this.CreateVenvTabDisplayTextBox.Multiline = true;
            this.CreateVenvTabDisplayTextBox.Name = "CreateVenvTabDisplayTextBox";
            this.CreateVenvTabDisplayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CreateVenvTabDisplayTextBox.Size = new System.Drawing.Size(748, 304);
            this.CreateVenvTabDisplayTextBox.TabIndex = 7;
            // 
            // CreateVenvTabSelectTemplateComboBox
            // 
            this.CreateVenvTabSelectTemplateComboBox.FormattingEnabled = true;
            this.CreateVenvTabSelectTemplateComboBox.Location = new System.Drawing.Point(77, 70);
            this.CreateVenvTabSelectTemplateComboBox.Name = "CreateVenvTabSelectTemplateComboBox";
            this.CreateVenvTabSelectTemplateComboBox.Size = new System.Drawing.Size(215, 20);
            this.CreateVenvTabSelectTemplateComboBox.TabIndex = 3;
            // 
            // CreateVenvTabSelectFolderButton
            // 
            this.CreateVenvTabSelectFolderButton.Location = new System.Drawing.Point(693, 69);
            this.CreateVenvTabSelectFolderButton.Name = "CreateVenvTabSelectFolderButton";
            this.CreateVenvTabSelectFolderButton.Size = new System.Drawing.Size(70, 20);
            this.CreateVenvTabSelectFolderButton.TabIndex = 6;
            this.CreateVenvTabSelectFolderButton.Text = "Select";
            this.CreateVenvTabSelectFolderButton.UseVisualStyleBackColor = true;
            this.CreateVenvTabSelectFolderButton.Click += new System.EventHandler(this.CreateVenvTabSelectFolderButton_Click);
            // 
            // CreateVenvTabSelectFolderTextBox
            // 
            this.CreateVenvTabSelectFolderTextBox.Location = new System.Drawing.Point(356, 70);
            this.CreateVenvTabSelectFolderTextBox.Name = "CreateVenvTabSelectFolderTextBox";
            this.CreateVenvTabSelectFolderTextBox.Size = new System.Drawing.Size(331, 19);
            this.CreateVenvTabSelectFolderTextBox.TabIndex = 5;
            // 
            // CreateVenvTabSelectFolderLabel
            // 
            this.CreateVenvTabSelectFolderLabel.AutoSize = true;
            this.CreateVenvTabSelectFolderLabel.Location = new System.Drawing.Point(315, 73);
            this.CreateVenvTabSelectFolderLabel.Name = "CreateVenvTabSelectFolderLabel";
            this.CreateVenvTabSelectFolderLabel.Size = new System.Drawing.Size(37, 12);
            this.CreateVenvTabSelectFolderLabel.TabIndex = 4;
            this.CreateVenvTabSelectFolderLabel.Text = "Folder";
            // 
            // CreateVenvTabSelectTemplateLabel
            // 
            this.CreateVenvTabSelectTemplateLabel.AutoSize = true;
            this.CreateVenvTabSelectTemplateLabel.Location = new System.Drawing.Point(15, 73);
            this.CreateVenvTabSelectTemplateLabel.Name = "CreateVenvTabSelectTemplateLabel";
            this.CreateVenvTabSelectTemplateLabel.Size = new System.Drawing.Size(58, 12);
            this.CreateVenvTabSelectTemplateLabel.TabIndex = 2;
            this.CreateVenvTabSelectTemplateLabel.Text = "Templates";
            this.CreateVenvTabSelectTemplateLabel.Click += new System.EventHandler(this.CreateVenvTabSelectTemplateComboBox_Click);
            // 
            // CreateVenvTabInfoLabel
            // 
            this.CreateVenvTabInfoLabel.Location = new System.Drawing.Point(121, 11);
            this.CreateVenvTabInfoLabel.Name = "CreateVenvTabInfoLabel";
            this.CreateVenvTabInfoLabel.Size = new System.Drawing.Size(642, 49);
            this.CreateVenvTabInfoLabel.TabIndex = 1;
            this.CreateVenvTabInfoLabel.Text = "CreateVenvTabInfoLabel";
            // 
            // CreateVenvTabCreateButton
            // 
            this.CreateVenvTabCreateButton.Location = new System.Drawing.Point(15, 10);
            this.CreateVenvTabCreateButton.Name = "CreateVenvTabCreateButton";
            this.CreateVenvTabCreateButton.Size = new System.Drawing.Size(100, 50);
            this.CreateVenvTabCreateButton.TabIndex = 0;
            this.CreateVenvTabCreateButton.Text = "Create";
            this.CreateVenvTabCreateButton.UseVisualStyleBackColor = true;
            this.CreateVenvTabCreateButton.Click += new System.EventHandler(this.CreateVenvTabCreateButton_Click);
            // 
            // GlobalVersionTabPage
            // 
            this.GlobalVersionTabPage.Controls.Add(this.GlobalVersionTabDisplayTextBox);
            this.GlobalVersionTabPage.Controls.Add(this.GlobalVersionTabVersionTextBox);
            this.GlobalVersionTabPage.Controls.Add(this.GlobalVersionTabVersionLabel);
            this.GlobalVersionTabPage.Controls.Add(this.GlobalVersionTabInfoLabel);
            this.GlobalVersionTabPage.Controls.Add(this.GlobalVersionTabSetButton);
            this.GlobalVersionTabPage.Location = new System.Drawing.Point(4, 22);
            this.GlobalVersionTabPage.Name = "GlobalVersionTabPage";
            this.GlobalVersionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GlobalVersionTabPage.Size = new System.Drawing.Size(777, 407);
            this.GlobalVersionTabPage.TabIndex = 1;
            this.GlobalVersionTabPage.Text = "2. Global Version";
            this.GlobalVersionTabPage.UseVisualStyleBackColor = true;
            // 
            // GlobalVersionTabDisplayTextBox
            // 
            this.GlobalVersionTabDisplayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GlobalVersionTabDisplayTextBox.Location = new System.Drawing.Point(15, 101);
            this.GlobalVersionTabDisplayTextBox.Multiline = true;
            this.GlobalVersionTabDisplayTextBox.Name = "GlobalVersionTabDisplayTextBox";
            this.GlobalVersionTabDisplayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GlobalVersionTabDisplayTextBox.Size = new System.Drawing.Size(745, 300);
            this.GlobalVersionTabDisplayTextBox.TabIndex = 4;
            // 
            // GlobalVersionTabVersionTextBox
            // 
            this.GlobalVersionTabVersionTextBox.Location = new System.Drawing.Point(57, 70);
            this.GlobalVersionTabVersionTextBox.Name = "GlobalVersionTabVersionTextBox";
            this.GlobalVersionTabVersionTextBox.Size = new System.Drawing.Size(158, 19);
            this.GlobalVersionTabVersionTextBox.TabIndex = 3;
            // 
            // GlobalVersionTabVersionLabel
            // 
            this.GlobalVersionTabVersionLabel.AutoSize = true;
            this.GlobalVersionTabVersionLabel.Location = new System.Drawing.Point(14, 72);
            this.GlobalVersionTabVersionLabel.Name = "GlobalVersionTabVersionLabel";
            this.GlobalVersionTabVersionLabel.Size = new System.Drawing.Size(44, 12);
            this.GlobalVersionTabVersionLabel.TabIndex = 2;
            this.GlobalVersionTabVersionLabel.Text = "Version";
            // 
            // GlobalVersionTabInfoLabel
            // 
            this.GlobalVersionTabInfoLabel.Location = new System.Drawing.Point(125, 15);
            this.GlobalVersionTabInfoLabel.Name = "GlobalVersionTabInfoLabel";
            this.GlobalVersionTabInfoLabel.Size = new System.Drawing.Size(624, 44);
            this.GlobalVersionTabInfoLabel.TabIndex = 1;
            this.GlobalVersionTabInfoLabel.Text = "GrobalversionTabInfoLabel";
            // 
            // GlobalVersionTabSetButton
            // 
            this.GlobalVersionTabSetButton.Location = new System.Drawing.Point(15, 10);
            this.GlobalVersionTabSetButton.Name = "GlobalVersionTabSetButton";
            this.GlobalVersionTabSetButton.Size = new System.Drawing.Size(100, 50);
            this.GlobalVersionTabSetButton.TabIndex = 0;
            this.GlobalVersionTabSetButton.Text = "Set";
            this.GlobalVersionTabSetButton.UseVisualStyleBackColor = true;
            this.GlobalVersionTabSetButton.Click += new System.EventHandler(this.GlobalVersionTabSetButton_Click);
            // 
            // LocalVersionTabPage
            // 
            this.LocalVersionTabPage.Controls.Add(this.LocalVersionTabDisplayTextBox);
            this.LocalVersionTabPage.Controls.Add(this.LocalVersionTabSelectFolderButton);
            this.LocalVersionTabPage.Controls.Add(this.LocalVersionTabSelectFolderTextBox);
            this.LocalVersionTabPage.Controls.Add(this.LocalVersionTabFolderSelectLabel);
            this.LocalVersionTabPage.Controls.Add(this.LocalVersionTabVersionTextBox);
            this.LocalVersionTabPage.Controls.Add(this.LocalVersionTabInfoLabel);
            this.LocalVersionTabPage.Controls.Add(this.LocalVersonTabVersionLabel);
            this.LocalVersionTabPage.Controls.Add(this.LocalVersionTabSetButton);
            this.LocalVersionTabPage.Location = new System.Drawing.Point(4, 22);
            this.LocalVersionTabPage.Name = "LocalVersionTabPage";
            this.LocalVersionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LocalVersionTabPage.Size = new System.Drawing.Size(777, 407);
            this.LocalVersionTabPage.TabIndex = 2;
            this.LocalVersionTabPage.Text = "3. Local Version";
            this.LocalVersionTabPage.UseVisualStyleBackColor = true;
            // 
            // LocalVersionTabDisplayTextBox
            // 
            this.LocalVersionTabDisplayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LocalVersionTabDisplayTextBox.Location = new System.Drawing.Point(15, 101);
            this.LocalVersionTabDisplayTextBox.Multiline = true;
            this.LocalVersionTabDisplayTextBox.Name = "LocalVersionTabDisplayTextBox";
            this.LocalVersionTabDisplayTextBox.ReadOnly = true;
            this.LocalVersionTabDisplayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LocalVersionTabDisplayTextBox.Size = new System.Drawing.Size(751, 296);
            this.LocalVersionTabDisplayTextBox.TabIndex = 7;
            // 
            // LocalVersionTabSelectFolderButton
            // 
            this.LocalVersionTabSelectFolderButton.Location = new System.Drawing.Point(671, 70);
            this.LocalVersionTabSelectFolderButton.Name = "LocalVersionTabSelectFolderButton";
            this.LocalVersionTabSelectFolderButton.Size = new System.Drawing.Size(70, 20);
            this.LocalVersionTabSelectFolderButton.TabIndex = 6;
            this.LocalVersionTabSelectFolderButton.Text = "Select";
            this.LocalVersionTabSelectFolderButton.UseVisualStyleBackColor = true;
            this.LocalVersionTabSelectFolderButton.Click += new System.EventHandler(this.LocalVersionTabSelectFolderButton_Click);
            // 
            // LocalVersionTabSelectFolderTextBox
            // 
            this.LocalVersionTabSelectFolderTextBox.Location = new System.Drawing.Point(260, 70);
            this.LocalVersionTabSelectFolderTextBox.Name = "LocalVersionTabSelectFolderTextBox";
            this.LocalVersionTabSelectFolderTextBox.Size = new System.Drawing.Size(400, 19);
            this.LocalVersionTabSelectFolderTextBox.TabIndex = 5;
            // 
            // LocalVersionTabFolderSelectLabel
            // 
            this.LocalVersionTabFolderSelectLabel.AutoSize = true;
            this.LocalVersionTabFolderSelectLabel.Location = new System.Drawing.Point(226, 73);
            this.LocalVersionTabFolderSelectLabel.Name = "LocalVersionTabFolderSelectLabel";
            this.LocalVersionTabFolderSelectLabel.Size = new System.Drawing.Size(37, 12);
            this.LocalVersionTabFolderSelectLabel.TabIndex = 4;
            this.LocalVersionTabFolderSelectLabel.Text = "Folder";
            // 
            // LocalVersionTabVersionTextBox
            // 
            this.LocalVersionTabVersionTextBox.Location = new System.Drawing.Point(57, 70);
            this.LocalVersionTabVersionTextBox.Name = "LocalVersionTabVersionTextBox";
            this.LocalVersionTabVersionTextBox.Size = new System.Drawing.Size(150, 19);
            this.LocalVersionTabVersionTextBox.TabIndex = 3;
            // 
            // LocalVersionTabInfoLabel
            // 
            this.LocalVersionTabInfoLabel.Location = new System.Drawing.Point(122, 18);
            this.LocalVersionTabInfoLabel.Name = "LocalVersionTabInfoLabel";
            this.LocalVersionTabInfoLabel.Size = new System.Drawing.Size(603, 46);
            this.LocalVersionTabInfoLabel.TabIndex = 1;
            this.LocalVersionTabInfoLabel.Text = "LocalVersionTabInfoLabel";
            // 
            // LocalVersonTabVersionLabel
            // 
            this.LocalVersonTabVersionLabel.AutoSize = true;
            this.LocalVersonTabVersionLabel.Location = new System.Drawing.Point(11, 73);
            this.LocalVersonTabVersionLabel.Name = "LocalVersonTabVersionLabel";
            this.LocalVersonTabVersionLabel.Size = new System.Drawing.Size(44, 12);
            this.LocalVersonTabVersionLabel.TabIndex = 2;
            this.LocalVersonTabVersionLabel.Text = "Version";
            // 
            // LocalVersionTabSetButton
            // 
            this.LocalVersionTabSetButton.Location = new System.Drawing.Point(10, 15);
            this.LocalVersionTabSetButton.Name = "LocalVersionTabSetButton";
            this.LocalVersionTabSetButton.Size = new System.Drawing.Size(100, 50);
            this.LocalVersionTabSetButton.TabIndex = 0;
            this.LocalVersionTabSetButton.Text = "Set";
            this.LocalVersionTabSetButton.UseVisualStyleBackColor = true;
            this.LocalVersionTabSetButton.Click += new System.EventHandler(this.LocalVersionTabSetButton_Click);
            // 
            // InstallTabPage
            // 
            this.InstallTabPage.Controls.Add(this.InstallTabDisplayTextBox);
            this.InstallTabPage.Controls.Add(this.InstallTabVersionLabel);
            this.InstallTabPage.Controls.Add(this.InstallTabVersionTextBox);
            this.InstallTabPage.Controls.Add(this.installTabInfoLavel);
            this.InstallTabPage.Controls.Add(this.InstallTabInstallButton);
            this.InstallTabPage.Location = new System.Drawing.Point(4, 22);
            this.InstallTabPage.Name = "InstallTabPage";
            this.InstallTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.InstallTabPage.Size = new System.Drawing.Size(777, 407);
            this.InstallTabPage.TabIndex = 3;
            this.InstallTabPage.Text = "4. Install";
            this.InstallTabPage.UseVisualStyleBackColor = true;
            // 
            // InstallTabDisplayTextBox
            // 
            this.InstallTabDisplayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallTabDisplayTextBox.Location = new System.Drawing.Point(10, 105);
            this.InstallTabDisplayTextBox.Multiline = true;
            this.InstallTabDisplayTextBox.Name = "InstallTabDisplayTextBox";
            this.InstallTabDisplayTextBox.ReadOnly = true;
            this.InstallTabDisplayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InstallTabDisplayTextBox.Size = new System.Drawing.Size(758, 292);
            this.InstallTabDisplayTextBox.TabIndex = 4;
            // 
            // InstallTabVersionLabel
            // 
            this.InstallTabVersionLabel.AutoSize = true;
            this.InstallTabVersionLabel.Location = new System.Drawing.Point(10, 76);
            this.InstallTabVersionLabel.Name = "InstallTabVersionLabel";
            this.InstallTabVersionLabel.Size = new System.Drawing.Size(73, 12);
            this.InstallTabVersionLabel.TabIndex = 2;
            this.InstallTabVersionLabel.Text = "Input Version";
            // 
            // InstallTabVersionTextBox
            // 
            this.InstallTabVersionTextBox.Location = new System.Drawing.Point(95, 73);
            this.InstallTabVersionTextBox.Name = "InstallTabVersionTextBox";
            this.InstallTabVersionTextBox.Size = new System.Drawing.Size(150, 19);
            this.InstallTabVersionTextBox.TabIndex = 3;
            // 
            // installTabInfoLavel
            // 
            this.installTabInfoLavel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.installTabInfoLavel.Location = new System.Drawing.Point(120, 15);
            this.installTabInfoLavel.Name = "installTabInfoLavel";
            this.installTabInfoLavel.Size = new System.Drawing.Size(648, 50);
            this.installTabInfoLavel.TabIndex = 1;
            this.installTabInfoLavel.Text = "label2";
            // 
            // InstallTabInstallButton
            // 
            this.InstallTabInstallButton.Location = new System.Drawing.Point(10, 15);
            this.InstallTabInstallButton.Name = "InstallTabInstallButton";
            this.InstallTabInstallButton.Size = new System.Drawing.Size(100, 50);
            this.InstallTabInstallButton.TabIndex = 0;
            this.InstallTabInstallButton.Text = "Install";
            this.InstallTabInstallButton.UseVisualStyleBackColor = true;
            this.InstallTabInstallButton.Click += new System.EventHandler(this.InstallTabInstallButton_Click);
            // 
            // PyenvTabPage
            // 
            this.PyenvTabPage.Controls.Add(this.PyenvTabInfoLabel);
            this.PyenvTabPage.Controls.Add(this.PyenvTabDisplayTextBox);
            this.PyenvTabPage.Controls.Add(this.PyenvTabRunButton);
            this.PyenvTabPage.Location = new System.Drawing.Point(4, 22);
            this.PyenvTabPage.Name = "PyenvTabPage";
            this.PyenvTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PyenvTabPage.Size = new System.Drawing.Size(777, 407);
            this.PyenvTabPage.TabIndex = 4;
            this.PyenvTabPage.Text = "5. pyenv";
            this.PyenvTabPage.UseVisualStyleBackColor = true;
            // 
            // PyenvTabInfoLabel
            // 
            this.PyenvTabInfoLabel.Location = new System.Drawing.Point(120, 15);
            this.PyenvTabInfoLabel.Name = "PyenvTabInfoLabel";
            this.PyenvTabInfoLabel.Size = new System.Drawing.Size(643, 49);
            this.PyenvTabInfoLabel.TabIndex = 1;
            this.PyenvTabInfoLabel.Text = "PyenvTabInfoLabel";
            // 
            // PyenvTabDisplayTextBox
            // 
            this.PyenvTabDisplayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PyenvTabDisplayTextBox.Location = new System.Drawing.Point(10, 71);
            this.PyenvTabDisplayTextBox.Multiline = true;
            this.PyenvTabDisplayTextBox.Name = "PyenvTabDisplayTextBox";
            this.PyenvTabDisplayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PyenvTabDisplayTextBox.Size = new System.Drawing.Size(754, 330);
            this.PyenvTabDisplayTextBox.TabIndex = 2;
            // 
            // PyenvTabRunButton
            // 
            this.PyenvTabRunButton.Location = new System.Drawing.Point(10, 15);
            this.PyenvTabRunButton.Name = "PyenvTabRunButton";
            this.PyenvTabRunButton.Size = new System.Drawing.Size(100, 50);
            this.PyenvTabRunButton.TabIndex = 0;
            this.PyenvTabRunButton.Text = "Run";
            this.PyenvTabRunButton.UseVisualStyleBackColor = true;
            this.PyenvTabRunButton.Click += new System.EventHandler(this.PyenvTabRunButton_Click);
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.SettingsTabSelectBaseFolderButton);
            this.SettingsTabPage.Controls.Add(this.SettingsTabLabguageGroup);
            this.SettingsTabPage.Controls.Add(this.SettingsTabLanguageLabel);
            this.SettingsTabPage.Controls.Add(this.SettingsTabSelectBaseFolderTextBox);
            this.SettingsTabPage.Controls.Add(this.SettingsTabSelectBaseFolderLabel);
            this.SettingsTabPage.Controls.Add(this.SettingsTabSetButton);
            this.SettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTabPage.Size = new System.Drawing.Size(777, 407);
            this.SettingsTabPage.TabIndex = 5;
            this.SettingsTabPage.Text = "6. Settings";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // SettingsTabSelectBaseFolderButton
            // 
            this.SettingsTabSelectBaseFolderButton.Location = new System.Drawing.Point(470, 187);
            this.SettingsTabSelectBaseFolderButton.Name = "SettingsTabSelectBaseFolderButton";
            this.SettingsTabSelectBaseFolderButton.Size = new System.Drawing.Size(75, 23);
            this.SettingsTabSelectBaseFolderButton.TabIndex = 8;
            this.SettingsTabSelectBaseFolderButton.Text = "Select";
            this.SettingsTabSelectBaseFolderButton.UseVisualStyleBackColor = true;
            this.SettingsTabSelectBaseFolderButton.Click += new System.EventHandler(this.SettingsTabSelectFolderButton_Click);
            // 
            // SettingsTabLabguageGroup
            // 
            this.SettingsTabLabguageGroup.Controls.Add(this.SettingsTabJapaneseRadioButton);
            this.SettingsTabLabguageGroup.Controls.Add(this.SettingsTabEnglishRadioButton);
            this.SettingsTabLabguageGroup.Location = new System.Drawing.Point(111, 78);
            this.SettingsTabLabguageGroup.Name = "SettingsTabLabguageGroup";
            this.SettingsTabLabguageGroup.Size = new System.Drawing.Size(172, 90);
            this.SettingsTabLabguageGroup.TabIndex = 3;
            this.SettingsTabLabguageGroup.TabStop = false;
            // 
            // SettingsTabJapaneseRadioButton
            // 
            this.SettingsTabJapaneseRadioButton.AutoSize = true;
            this.SettingsTabJapaneseRadioButton.Location = new System.Drawing.Point(19, 55);
            this.SettingsTabJapaneseRadioButton.Name = "SettingsTabJapaneseRadioButton";
            this.SettingsTabJapaneseRadioButton.Size = new System.Drawing.Size(72, 16);
            this.SettingsTabJapaneseRadioButton.TabIndex = 5;
            this.SettingsTabJapaneseRadioButton.TabStop = true;
            this.SettingsTabJapaneseRadioButton.Text = "Japanese";
            this.SettingsTabJapaneseRadioButton.UseVisualStyleBackColor = true;
            // 
            // SettingsTabEnglishRadioButton
            // 
            this.SettingsTabEnglishRadioButton.AutoSize = true;
            this.SettingsTabEnglishRadioButton.Location = new System.Drawing.Point(19, 17);
            this.SettingsTabEnglishRadioButton.Name = "SettingsTabEnglishRadioButton";
            this.SettingsTabEnglishRadioButton.Size = new System.Drawing.Size(60, 16);
            this.SettingsTabEnglishRadioButton.TabIndex = 4;
            this.SettingsTabEnglishRadioButton.TabStop = true;
            this.SettingsTabEnglishRadioButton.Text = "English";
            this.SettingsTabEnglishRadioButton.UseVisualStyleBackColor = true;
            // 
            // SettingsTabLanguageLabel
            // 
            this.SettingsTabLanguageLabel.AutoSize = true;
            this.SettingsTabLanguageLabel.Location = new System.Drawing.Point(18, 78);
            this.SettingsTabLanguageLabel.Name = "SettingsTabLanguageLabel";
            this.SettingsTabLanguageLabel.Size = new System.Drawing.Size(59, 12);
            this.SettingsTabLanguageLabel.TabIndex = 2;
            this.SettingsTabLanguageLabel.Text = "Languages";
            // 
            // SettingsTabSelectBaseFolderTextBox
            // 
            this.SettingsTabSelectBaseFolderTextBox.Location = new System.Drawing.Point(111, 187);
            this.SettingsTabSelectBaseFolderTextBox.Name = "SettingsTabSelectBaseFolderTextBox";
            this.SettingsTabSelectBaseFolderTextBox.Size = new System.Drawing.Size(353, 19);
            this.SettingsTabSelectBaseFolderTextBox.TabIndex = 7;
            // 
            // SettingsTabSelectBaseFolderLabel
            // 
            this.SettingsTabSelectBaseFolderLabel.AutoSize = true;
            this.SettingsTabSelectBaseFolderLabel.Location = new System.Drawing.Point(18, 192);
            this.SettingsTabSelectBaseFolderLabel.Name = "SettingsTabSelectBaseFolderLabel";
            this.SettingsTabSelectBaseFolderLabel.Size = new System.Drawing.Size(63, 12);
            this.SettingsTabSelectBaseFolderLabel.TabIndex = 6;
            this.SettingsTabSelectBaseFolderLabel.Text = "BaseFolder";
            // 
            // SettingsTabSetButton
            // 
            this.SettingsTabSetButton.Location = new System.Drawing.Point(10, 15);
            this.SettingsTabSetButton.Name = "SettingsTabSetButton";
            this.SettingsTabSetButton.Size = new System.Drawing.Size(100, 50);
            this.SettingsTabSetButton.TabIndex = 0;
            this.SettingsTabSetButton.Text = "Set";
            this.SettingsTabSetButton.UseVisualStyleBackColor = true;
            this.SettingsTabSetButton.Click += new System.EventHandler(this.SettingsTabSetButton_Click);
            // 
            // UsageTabPage
            // 
            this.UsageTabPage.Controls.Add(this.UsageTabWebBrowser);
            this.UsageTabPage.Location = new System.Drawing.Point(4, 22);
            this.UsageTabPage.Name = "UsageTabPage";
            this.UsageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.UsageTabPage.Size = new System.Drawing.Size(777, 407);
            this.UsageTabPage.TabIndex = 6;
            this.UsageTabPage.Text = "7. Usage";
            this.UsageTabPage.UseVisualStyleBackColor = true;
            // 
            // UsageTabWebBrowser
            // 
            this.UsageTabWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsageTabWebBrowser.Location = new System.Drawing.Point(3, 3);
            this.UsageTabWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.UsageTabWebBrowser.Name = "UsageTabWebBrowser";
            this.UsageTabWebBrowser.Size = new System.Drawing.Size(771, 401);
            this.UsageTabWebBrowser.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Goro VenvManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.CreateVenvTabPage.ResumeLayout(false);
            this.CreateVenvTabPage.PerformLayout();
            this.GlobalVersionTabPage.ResumeLayout(false);
            this.GlobalVersionTabPage.PerformLayout();
            this.LocalVersionTabPage.ResumeLayout(false);
            this.LocalVersionTabPage.PerformLayout();
            this.InstallTabPage.ResumeLayout(false);
            this.InstallTabPage.PerformLayout();
            this.PyenvTabPage.ResumeLayout(false);
            this.PyenvTabPage.PerformLayout();
            this.SettingsTabPage.ResumeLayout(false);
            this.SettingsTabPage.PerformLayout();
            this.SettingsTabLabguageGroup.ResumeLayout(false);
            this.SettingsTabLabguageGroup.PerformLayout();
            this.UsageTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CreateVenvTabPage;
        private System.Windows.Forms.TabPage GlobalVersionTabPage;
        private System.Windows.Forms.TabPage LocalVersionTabPage;
        private System.Windows.Forms.TabPage InstallTabPage;
        private System.Windows.Forms.TabPage PyenvTabPage;
        private System.Windows.Forms.TabPage SettingsTabPage;
        private System.Windows.Forms.TabPage UsageTabPage;
        private System.Windows.Forms.Button PyenvTabRunButton;
        private System.Windows.Forms.TextBox PyenvTabDisplayTextBox;
        private System.Windows.Forms.Label PyenvTabInfoLabel;
        private System.Windows.Forms.Label installTabInfoLavel;
        private System.Windows.Forms.Button InstallTabInstallButton;
        private System.Windows.Forms.TextBox InstallTabVersionTextBox;
        private System.Windows.Forms.Label InstallTabVersionLabel;
        private System.Windows.Forms.TextBox InstallTabDisplayTextBox;
        private System.Windows.Forms.Label LocalVersonTabVersionLabel;
        private System.Windows.Forms.Button LocalVersionTabSetButton;
        private System.Windows.Forms.Label LocalVersionTabFolderSelectLabel;
        private System.Windows.Forms.TextBox LocalVersionTabVersionTextBox;
        private System.Windows.Forms.Label LocalVersionTabInfoLabel;
        private System.Windows.Forms.TextBox LocalVersionTabSelectFolderTextBox;
        private System.Windows.Forms.Button LocalVersionTabSelectFolderButton;
        private System.Windows.Forms.TextBox LocalVersionTabDisplayTextBox;
        private System.Windows.Forms.Button GlobalVersionTabSetButton;
        private System.Windows.Forms.Label GlobalVersionTabInfoLabel;
        private System.Windows.Forms.TextBox GlobalVersionTabDisplayTextBox;
        private System.Windows.Forms.TextBox GlobalVersionTabVersionTextBox;
        private System.Windows.Forms.Label GlobalVersionTabVersionLabel;
        private System.Windows.Forms.TextBox CreateVenvTabDisplayTextBox;
        private System.Windows.Forms.ComboBox CreateVenvTabSelectTemplateComboBox;
        private System.Windows.Forms.Button CreateVenvTabSelectFolderButton;
        private System.Windows.Forms.TextBox CreateVenvTabSelectFolderTextBox;
        private System.Windows.Forms.Label CreateVenvTabSelectFolderLabel;
        private System.Windows.Forms.Label CreateVenvTabSelectTemplateLabel;
        private System.Windows.Forms.Label CreateVenvTabInfoLabel;
        private System.Windows.Forms.Button CreateVenvTabCreateButton;
        private System.Windows.Forms.Button SettingsTabSetButton;
        private System.Windows.Forms.GroupBox SettingsTabLabguageGroup;
        private System.Windows.Forms.RadioButton SettingsTabJapaneseRadioButton;
        private System.Windows.Forms.RadioButton SettingsTabEnglishRadioButton;
        private System.Windows.Forms.Label SettingsTabLanguageLabel;
        private System.Windows.Forms.TextBox SettingsTabSelectBaseFolderTextBox;
        private System.Windows.Forms.Label SettingsTabSelectBaseFolderLabel;
        private System.Windows.Forms.Button SettingsTabSelectBaseFolderButton;
        private System.Windows.Forms.WebBrowser UsageTabWebBrowser;
    }
}