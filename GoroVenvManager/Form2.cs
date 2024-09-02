using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Linq;

namespace GoroVenvManager

{
    public partial class Form2 : Form
    {
        private const string TemplatesFolderName = "templates";
        private const string DefaultLanguage = "English";
        private const string SecondLanguage = "Japanese";
        private const string Utf8EncodingCommand = "[Console]::InputEncoding = [System.Text.Encoding]::UTF8; " +
                             "[Console]::OutputEncoding = [System.Text.Encoding]::UTF8;";

        public Form2()
        {
            InitializeComponent();

            if(Properties.Settings.Default.Language == SecondLanguage)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }

            // このプログラムのあるフォルダの.venv/を削除する
            string currentDirectory = Directory.GetCurrentDirectory();
            string venvPath = Path.Combine(currentDirectory, ".venv");

            if (Directory.Exists(venvPath))
            {
                Directory.Delete(venvPath, true);
            }

            // このプログラムのあるフォルダの .python-version を削除する
            string pythonVersionFile = Path.Combine(currentDirectory, ".python-version");
            if (File.Exists(pythonVersionFile))
            {
                File.Delete(pythonVersionFile);
            }

            ExecuteCreateVenvTabActions();
        }

        //TabControl

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private async Task Async_executeButton_click_action(object sender, EventArgs e, string runCommand, TextBox displayTextBox)
        {
            // 古いCancellationTokenSourceがあればキャンセルし、破棄する
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
            }

            // 新しいCancellationTokenSourceを作成
            _cancellationTokenSource = new CancellationTokenSource();

            string powershellCommand = "powershell.exe";
            string powershellArguments = $@"-NoProfile -ExecutionPolicy Bypass {runCommand} ";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = powershellCommand,
                Arguments = powershellArguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8,
                StandardErrorEncoding = System.Text.Encoding.UTF8

            };

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;

                try
                {
                    process.Start();

                    var outputTask = ReadStreamAsync(process.StandardOutput, displayTextBox, _cancellationTokenSource.Token);
                    var errorTask = ReadStreamAsync(process.StandardError, displayTextBox, _cancellationTokenSource.Token);

                    await Task.WhenAll(outputTask, errorTask).ConfigureAwait(false);

                    await Task.Run(() => process.WaitForExit(), _cancellationTokenSource.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    displayTextBox.Invoke(new Action(() => displayTextBox.AppendText("操作がキャンセルされました。" + Environment.NewLine)));
                }
                catch (Exception ex)
                {
                    displayTextBox.Invoke(new Action(() => displayTextBox.AppendText($"エラーが発生しました: {ex.Message}" + Environment.NewLine)));
                }
            }
        }


        private async Task ReadStreamAsync(StreamReader reader, TextBox displayTextBox, CancellationToken cancellationToken)
        {
            string line;
            try
            {
                while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    displayTextBox.Invoke(new Action(() =>
                    {
                        displayTextBox.AppendText(line + Environment.NewLine);
                    }));
                }
            }
            catch (OperationCanceledException)
            {
                // キャンセルされた場合の処理
                displayTextBox.Invoke(new Action(() => displayTextBox.AppendText("読み取り操作がキャンセルされました。" + Environment.NewLine)));
            }
            catch (Exception ex)
            {
                displayTextBox.Invoke(new Action(() => displayTextBox.AppendText($"エラーが発生しました: {ex.Message}" + Environment.NewLine)));
            }
        }

        // 操作をキャンセルするためのメソッド
        public void CancelExecution()
        {
            _cancellationTokenSource.Cancel();
        }


        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 0) //VenvTab
            {
                ExecuteCreateVenvTabActions();
            }
            else if (((TabControl)sender).SelectedIndex == 1) //GlovalVersionTab
            {
                ExecuteGlobalVersionTabActions(sender, e);
            }
            else if (((TabControl)sender).SelectedIndex == 2) //LocalVersionTab
            {
                ExecuteLocalVersionTabActions();
            }
            else if (((TabControl)sender).SelectedIndex == 3) //InstallTab
            {
                ExecuteInstallTabActions(sender, e);
            }
            else if (((TabControl)sender).SelectedIndex == 4)
            {
                ExecutePyenvTabActions();
            }
            else if (((TabControl)sender).SelectedIndex == 5)
            {
                ExecuteSettingsTabActions(sender, e);
            }
            else if (((TabControl)sender).SelectedIndex == 6)
            {
                ExecuteUsageTabActions(sender, e);
            }


        }

        //Menu (Exit)
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //PyenvTab
        private void ExecutePyenvTabActions()
        {
            PyenvTabDisplayTextBox.Text = "";

            PyenvTabInfoLabel.Text = Properties.Resources.PyenvTabInfoLabelText;
        }
        private async void PyenvTabRunButton_Click(object sender, EventArgs e)
        {
            DisabledAllButtons();
            string runCommand = "";

            if (Properties.Settings.Default.Language == SecondLanguage)
            {
                runCommand = $@" -File "".\Assets\pyenv-win.ja.ps1"" ";
            }
            else
            {
                runCommand = $@" -File "".\Assets\pyenv-win.en.ps1"" ";
            }

            await Async_executeButton_click_action(sender, e, runCommand, PyenvTabDisplayTextBox);

            EnabledAllButtons();
            SystemSounds.Asterisk.Play();
            MessageBox.Show(Properties.Resources.InstallComplete);
        }

        //InstallTab
        private async void ExecuteInstallTabActions(object sender, EventArgs e)
        {
            installTabInfoLavel.Text = Properties.Resources.InstallTabInfoLavelText;
            InstallTabVersionTextBox.Text = "";
            InstallTabDisplayTextBox.Text = "";

            InstallTabVersionTextBox.Text = "";

            InstallTabDisplayTextBox.AppendText(Properties.Resources.DownloadableVersion + Environment.NewLine);
            InstallTabDisplayTextBox.AppendText("Command > pyenv install --list" + Environment.NewLine);
            String runCommand = $@" -Command ""{Utf8EncodingCommand}; pyenv install --list; ""  ";
            await Async_executeButton_click_action(sender, e, runCommand, InstallTabDisplayTextBox);

            InstallTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.DownloadedVersion + Environment.NewLine);
            InstallTabDisplayTextBox.AppendText("Command > pyenv versions" + Environment.NewLine);

            String runCommand2 = $@" -Command ""{Utf8EncodingCommand}; pyenv versions;""  ";
            await Async_executeButton_click_action(sender, e, runCommand2, InstallTabDisplayTextBox);

            InstallTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);
        }

        private async void InstallTabInstallButton_Click(object sender, EventArgs e)
        {
            string version = InstallTabVersionTextBox.Text;

            DisabledAllButtons();

            if (version == "")
            {
                InstallTabDisplayTextBox.AppendText(Properties.Resources.EnterVersionToInstall + Environment.NewLine);
                InstallTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);

                EnabledAllButtons();
                SystemSounds.Asterisk.Play();
                MessageBox.Show(Properties.Resources.EnterVersionToInstall, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InstallTabDisplayTextBox.AppendText(string.Format(Properties.Resources.InstallPythonVersion, version) + Environment.NewLine);

            InstallTabDisplayTextBox.AppendText($@"Command > pyenv install {version}; pyenv rehash;" + Environment.NewLine);
            string commandText = $@"-Command ""{Utf8EncodingCommand}; pyenv install \""{version}\"" ; pyenv rehash; "" ";
            await Async_executeButton_click_action(sender, e, commandText, InstallTabDisplayTextBox);

            InstallTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.ConfirmInstallation + Environment.NewLine);
            InstallTabDisplayTextBox.AppendText("Command > pyenv versions" + Environment.NewLine);
            string commandText2 = $@"-Command ""{Utf8EncodingCommand}; pyenv versions "" ";
            await Async_executeButton_click_action(sender, e, commandText2, InstallTabDisplayTextBox);

            InstallTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);

            EnabledAllButtons();
            SystemSounds.Asterisk.Play();
            MessageBox.Show(Properties.Resources.InstallComplete);
        }

        //LocalVersionTab
        private void ExecuteLocalVersionTabActions()
        {
            String baseFolder = Properties.Settings.Default.BaseFolder;

            if (Directory.Exists(baseFolder))
            {
                LocalVersionTabSelectFolderTextBox.Text = baseFolder;
            }
            else
            {
                LocalVersionTabSelectFolderTextBox.Text = "";
            }

            LocalVersionTabVersionTextBox.Text = "";
            LocalVersionTabDisplayTextBox.Text = "";
            LocalVersionTabInfoLabel.Text = Properties.Resources.LocalVersionTabInfoLabelText;

        }

        private async void LocalVersionTabSelectFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Plese select a folder.";

                String baseFolder = Properties.Settings.Default.BaseFolder;

                if (Directory.Exists(baseFolder))
                {
                    folderBrowserDialog.SelectedPath = baseFolder;
                }
                else
                {
                    baseFolder = Directory.GetCurrentDirectory();
                }

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    LocalVersionTabSelectFolderTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }

            await Task.Delay(1000);

            String localPath = LocalVersionTabSelectFolderTextBox.Text;

            if (!Directory.Exists(localPath) || localPath == "")
            {
                return;
            }

            // 設定可能なバージョンを表示
            LocalVersionTabDisplayTextBox.AppendText(Properties.Resources.ConfigurableVersion + Environment.NewLine);
            LocalVersionTabDisplayTextBox.AppendText($@"Command > Set-Location ""{localPath} ""; pyenv versions" + Environment.NewLine);
            String commandString5 = $@"-Command "" {Utf8EncodingCommand}; Set-Location \""{localPath}\""; pyenv versions "" ";
            await Async_executeButton_click_action(sender, e, commandString5, LocalVersionTabDisplayTextBox);

            // 現在のローカルバージョンを表示
            LocalVersionTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.CheckVersionInFolder + Environment.NewLine);
            LocalVersionTabDisplayTextBox.AppendText($@"Command > Set-Location ""{localPath}""; pyenv local" + Environment.NewLine);
            String commandString3 = $@"-Command "" {Utf8EncodingCommand}; Set-Location \""{localPath}\""; pyenv local "" ";
            await Async_executeButton_click_action(sender, e, commandString3, LocalVersionTabDisplayTextBox);

            LocalVersionTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);

        }

        private async void LocalVersionTabSetButton_Click(object sender, EventArgs e)
        {
            String localPath = LocalVersionTabSelectFolderTextBox.Text;
            String localVersion = LocalVersionTabVersionTextBox.Text;

            DisabledAllButtons();

            //Pathが正しくない場合
            if (ValidateFilePath(localPath) == false)
            {
                EnabledAllButtons();
                return;
            }

            //バージョンが正しくない場合
            if (ValidatePythonVersionInput(localVersion) == false)
            {
                // 設定可能なバージョンを表示
                LocalVersionTabDisplayTextBox.AppendText(Properties.Resources.ConfigurableVersion + Environment.NewLine);
                LocalVersionTabDisplayTextBox.AppendText($@"Command > Set-Location ""{localPath}""; pyenv versions" + Environment.NewLine);
                String commandString5 = $@"-Command "" {Utf8EncodingCommand}; Set-Location \""{localPath}\""; pyenv versions "" ";
                await Async_executeButton_click_action(sender, e, commandString5, LocalVersionTabDisplayTextBox);

                LocalVersionTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.CheckVersionSetInFolder + Environment.NewLine);
                LocalVersionTabDisplayTextBox.AppendText($@"Command > Set-Location ""{localPath}""; pyenv local" + Environment.NewLine);
                String commandString7 = $@"-Command "" {Utf8EncodingCommand}; Set-Location \""{localPath}\""; pyenv local;"" ";
                await Async_executeButton_click_action(sender, e, commandString7, LocalVersionTabDisplayTextBox);

                LocalVersionTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);

                EnabledAllButtons();
                return;
            }

            LocalVersionTabDisplayTextBox.AppendText(Properties.Resources.SetLocalVersion + Environment.NewLine + Environment.NewLine);

            // ローカルバージョンを設定
            LocalVersionTabDisplayTextBox.AppendText($@"Command > Set-Location ""{localPath}""; pyenv local ""{localVersion}""; pyenv rehash; " + Environment.NewLine);
            String commandString2 = $@"-Command ""{Utf8EncodingCommand}; Set-Location \""{localPath}\""; pyenv local \""{localVersion}\""; pyenv rehash "" ";
            await Async_executeButton_click_action(sender, e, commandString2, LocalVersionTabDisplayTextBox);
            Console.WriteLine(commandString2); //debug print

            // フォルダを確認
            LocalVersionTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.FolderToSet + Environment.NewLine + Environment.NewLine);
            LocalVersionTabDisplayTextBox.AppendText("Command > Get-Location" + Environment.NewLine);
            String commandString3 = $@"-Command ""{Utf8EncodingCommand}; Set-Location \""{localPath}\"" ; Get-Location; "" ";
            await Async_executeButton_click_action(sender, e, commandString3, LocalVersionTabDisplayTextBox);

            // ローカルバージョンを表示
            LocalVersionTabDisplayTextBox.AppendText(Properties.Resources.CheckVersionSetInFolder + Environment.NewLine);
            LocalVersionTabDisplayTextBox.AppendText($@"Command > Set-Location ""{localPath}""; pyenv local" + Environment.NewLine);
            String commandString4 = $@"-Command ""{Utf8EncodingCommand}; Set-Location \""{localPath}\""; pyenv local; "" ";
            await Async_executeButton_click_action(sender, e, commandString4, LocalVersionTabDisplayTextBox);
            LocalVersionTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);

            EnabledAllButtons();
            SystemSounds.Asterisk.Play();
            MessageBox.Show(Properties.Resources.SettingCompleted);
        }

        //GrobalVersionTab
        private async void ExecuteGlobalVersionTabActions(object sender, EventArgs e)
        {
            GlobalVersionTabVersionTextBox.Text = "";
            GlobalVersionTabDisplayTextBox.Text = "";
            GlobalVersionTabInfoLabel.Text = Properties.Resources.GlobalVersionTabInfoLabelText;

            GlobalVersionTabDisplayTextBox.AppendText(Properties.Resources.ConfigurableVersion + Environment.NewLine);
            GlobalVersionTabDisplayTextBox.AppendText("Command > pyenv versions" + Environment.NewLine);
            String commandString = $@"-Command ""{Utf8EncodingCommand}; pyenv versions; "" ";
            await Async_executeButton_click_action(sender, e, commandString, GlobalVersionTabDisplayTextBox);
            GlobalVersionTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);
        }

        private async void GlobalVersionTabSetButton_Click(object sender, EventArgs e)
        {
            DisabledAllButtons();

            String globalVersion = GlobalVersionTabVersionTextBox.Text;

            if (ValidatePythonVersionInput(globalVersion) == false)
            { 
                EnabledAllButtons();
                return;
            }

            // グローバルバージョンを設定
            GlobalVersionTabDisplayTextBox.AppendText(Properties.Resources.SetGlobalVersion + Environment.NewLine + Environment.NewLine);
            GlobalVersionTabDisplayTextBox.AppendText($@"Command > pyenv global {globalVersion}; pyenv rehash; " + Environment.NewLine);
            String commandString = $@" ""{Utf8EncodingCommand}; pyenv global \""{globalVersion}\"" ; pyenv rehash "" ";
            await Async_executeButton_click_action(sender, e, commandString, GlobalVersionTabDisplayTextBox);

            GlobalVersionTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.CheckSetGlobalVersion + Environment.NewLine);
            GlobalVersionTabDisplayTextBox.AppendText("Command > pyenv versions" + Environment.NewLine);
            String commandString2 = $@" "" {Utf8EncodingCommand}; pyenv versions; "" ";
            await Async_executeButton_click_action(sender, e, commandString2, GlobalVersionTabDisplayTextBox);
            GlobalVersionTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);

            EnabledAllButtons();
            SystemSounds.Asterisk.Play();
            MessageBox.Show(Properties.Resources.SettingCompleted);
        }

        //CreateVenvTab
        private void CreateVenvTabSelectTemplateComboBox_Click(object sender, EventArgs e)
        {
            //何もしない
        }

        private void ExecuteCreateVenvTabActions()
        {
            String baseFolder = Properties.Settings.Default.BaseFolder;

            if (Directory.Exists(baseFolder))
            {
                CreateVenvTabSelectFolderTextBox.Text = baseFolder;
            }
            else
            {
                CreateVenvTabSelectFolderTextBox.Text = "";
            }

            CreateVenvTabInfoLabel.Text = Properties.Resources.CreateVenvTabInfoLabelTex;
            CreateVenvTabDisplayTextBox.Text = "";

            // 環境変数 VENV_HOME を取得
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;


            // もし VENV_HOME が設定されていない場合は処理を中断
            if (string.IsNullOrEmpty(appDirectory))
            {
                CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.VenvHomeNotSet);
                return;
            }

            // テンプレートフォルダのパスを設定
            string templatesPath = System.IO.Path.Combine(appDirectory, TemplatesFolderName);

            // ComboBoxをクリア
            CreateVenvTabSelectTemplateComboBox.Items.Clear();

            // テンプレートフォルダが存在するか確認
            if (System.IO.Directory.Exists(templatesPath))
            {
                // フォルダ内のディレクトリを取得
                string[] directories = System.IO.Directory.GetDirectories(templatesPath);
                Array.Sort(directories);

                if (directories.Length > 0)
                {

                    // ディレクトリ名をComboBoxに追加
                    foreach (string directory in directories)
                    {
                        // フルパスからディレクトリ名のみを抽出して追加
                        string directoryName = System.IO.Path.GetFileName(directory);
                        CreateVenvTabSelectTemplateComboBox.Items.Add(directoryName);
                        CreateVenvTabSelectTemplateComboBox.SelectedIndex = 0;
                    }
                }
                else
                {
                    CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.TemplatesNotFound);

                }
            }
            else
            {
                // テンプレートフォルダが存在しない場合はエラーメッセージを表示
                CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.TemplatesFolderNotFound);
            }
        }

        private void CreateVenvTabSelectFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                String baseFolder = Properties.Settings.Default.BaseFolder;

                if (Directory.Exists(baseFolder))
                {
                    folderBrowserDialog.SelectedPath = baseFolder;
                }
                else
                {
                    baseFolder = Directory.GetCurrentDirectory();
                }

                folderBrowserDialog.Description = "Plese select a folder.";

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    CreateVenvTabSelectFolderTextBox.Text = folderBrowserDialog.SelectedPath;
                }

                String venvPath = CreateVenvTabSelectFolderTextBox.Text;

                if (!Directory.Exists(venvPath) || venvPath == "")
                {
                    return;
                }
            }
        }

        private async void CreateVenvTabCreateButton_Click(object sender, EventArgs e)
        {
            DisabledAllButtons();

            String venvPath = CreateVenvTabSelectFolderTextBox.Text; // 仮想環境を作成するフォルダ
            String venvTemplatePath = CreateVenvTabSelectTemplateComboBox.Text; // テンプレートとなるフォルダ

            if (ValidateFilePath(venvPath) == false)
            {
                EnabledAllButtons();
                return;
            }
            else
            {
                CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.StartVenvCreation + Environment.NewLine + Environment.NewLine);

                string[] directories = System.IO.Directory.GetDirectories(venvPath);
                string[] files = System.IO.Directory.GetFiles(venvPath);
                bool dotPythonVersionFile = File.Exists(Path.Combine(venvPath, ".python-version"));

                if (files.Length == 1 && dotPythonVersionFile)
                {
                    // .python-versionファイルのみが存在する場合、特に処理を行わない
                }
                else if (directories.Length > 0 || files.Length > 0)
                {
                    // フォルダ内にファイルやフォルダが存在する場合、エラーメッセージを表示
                    CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.VenvFolderNotEmpty + Environment.NewLine);
                    CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);

                    EnabledAllButtons();
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(Properties.Resources.FolderNotEmpty,"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 仮想環境を作成
            CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.VenvCreationFolder + Environment.NewLine);
            CreateVenvTabDisplayTextBox.AppendText("Command > Get-Location" + Environment.NewLine);
            String commandString1 = $@" ""{Utf8EncodingCommand};Set-Location \""{venvPath}\""; Get-Location; python -m venv .venv "" ";
            await Async_executeButton_click_action(sender, e, commandString1, CreateVenvTabDisplayTextBox);

            CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.CreateVenvDirectory + Environment.NewLine);
            CreateVenvTabDisplayTextBox.AppendText("Command > python -m venv .venv" + Environment.NewLine);
            String commandString5 = $@" ""{Utf8EncodingCommand};Set-Location \""{venvPath}\""; python -m venv .venv "" ";
            await Async_executeButton_click_action(sender, e, commandString5, CreateVenvTabDisplayTextBox);

            String venvTemplateFullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TemplatesFolderName, venvTemplatePath);

            //テンプレートフォルダが存在する場合、テンプレートをコピー
            if (Directory.Exists(venvTemplateFullPath) && venvTemplatePath != "")
            {
                CreateVenvTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.CopyTemplate + Environment.NewLine);
                CreateVenvTabDisplayTextBox.AppendText($@"Command > Copy-Item -Recurse -Force -Path ""{venvTemplateFullPath}\*"" -Destination ""{venvPath}"" " + Environment.NewLine);
                String commandString3 = $@" "" {Utf8EncodingCommand}; Copy-Item -Recurse -Force -Path \""{venvTemplateFullPath}\*\"" -Destination \""{venvPath}\"" "" ";
                await Async_executeButton_click_action(sender, e, commandString3, CreateVenvTabDisplayTextBox);
            }
            else
            {
                CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.TemplateNotSelected + Environment.NewLine);
                CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.TemplateNotCopied + Environment.NewLine + Environment.NewLine);
            }

            CreateVenvTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.UpdatePip + Environment.NewLine);
            CreateVenvTabDisplayTextBox.AppendText($@"Command > .venv\Scripts\Activate.ps1; python -m pip install --upgrade pip"" " + Environment.NewLine);
            String commandString2 = $@" "" {Utf8EncodingCommand}; Set-Location \""{venvPath}\""; .venv\Scripts\Activate.ps1; python -m pip install --upgrade pip"" ";
            await Async_executeButton_click_action(sender, e, commandString2, CreateVenvTabDisplayTextBox);

            CreateVenvTabDisplayTextBox.AppendText(Environment.NewLine + Properties.Resources.VenvCreationCompleted + Environment.NewLine);
            CreateVenvTabDisplayTextBox.AppendText(Properties.Resources.CommandResponseEndMarker + Environment.NewLine + Environment.NewLine);

            EnabledAllButtons();
            SystemSounds.Asterisk.Play();
            MessageBox.Show(Properties.Resources.VenvCreated);
        }

        //SettingsTab
        private void ExecuteSettingsTabActions(object sender, EventArgs e)
        {
            String baseFolder = Properties.Settings.Default.BaseFolder;
            String language = Properties.Settings.Default.Language;

            SettingsTabSelectBaseFolderTextBox.Text = baseFolder;

            if (language == "")
            {
                SettingsTabEnglishRadioButton.Checked = true;
                Properties.Settings.Default.Language = DefaultLanguage;
            }
            else if (language == SecondLanguage)
            {
                SettingsTabJapaneseRadioButton.Checked = true;
            }
            else
            {
                SettingsTabEnglishRadioButton.Checked = true;
            }
        }
        private void SettingsTabSelectFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {

                String baseFolder = Properties.Settings.Default.BaseFolder;

                if (Directory.Exists(baseFolder))
                {
                    folderBrowserDialog.SelectedPath = baseFolder;
                }
                else
                {
                    baseFolder = Directory.GetCurrentDirectory();
                }

                folderBrowserDialog.Description = "Plese select a folder.";

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    SettingsTabSelectBaseFolderTextBox.Text = folderBrowserDialog.SelectedPath;
                }



            }
        }

        private void SettingsTabSetButton_Click(object sender, EventArgs e)
        {
            String baseFolder = SettingsTabSelectBaseFolderTextBox.Text;

            if(ValidateFilePath(baseFolder) == false)
            {
                return;
            }

            Properties.Settings.Default.BaseFolder = baseFolder;

            if (SettingsTabEnglishRadioButton.Checked)
            {
                Properties.Settings.Default.Language = DefaultLanguage;
            }
            else
            {
                Properties.Settings.Default.Language = SecondLanguage;
            }

            Properties.Settings.Default.Save();
            SystemSounds.Asterisk.Play();
            MessageBox.Show(Properties.Resources.SettingCompleted);
        }

        //UsageTab
        private void ExecuteUsageTabActions(object sender, EventArgs args)
        {

            string relativePath = "";

            if (Properties.Settings.Default.Language == DefaultLanguage)
            { // 英語の場合
                relativePath = @".\Assets\usage.en.html";
            }
            else
            { // 日本語の場合
                relativePath = @".\Assets\usage.ja.html";
            }

            Console.Write(relativePath); //debug print

            // ローカルの相対パス
            string absolutePath = Path.Combine(Application.StartupPath, relativePath); // 絶対パスに変換
            string url = new Uri(absolutePath).AbsoluteUri; // file://スキームのURLに変換

            UsageTabWebBrowser.Navigate(url); // WebBrowserコントロールでファイルを表示

        }

        //Utility
        private bool ValidateFilePath(string DirectoryPath)
        {
            // 1. 空のパスのチェック
            if (string.IsNullOrWhiteSpace(DirectoryPath))
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(Properties.Resources.FilePathEmpty, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 2. 無効な文字のチェック
            char[] invalidChars = Path.GetInvalidPathChars();
            if (DirectoryPath.IndexOfAny(invalidChars) >= 0)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(Properties.Resources.FilePathInvalidCharacters, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 3. フォルダの存在チェック
            if (!Directory.Exists(DirectoryPath))
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(Properties.Resources.FolderNotFound, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 4. フォルダのアクセス権チェック
            try
            {
                // フォルダ内のファイルへのアクセス権をチェック
                Directory.GetFiles(DirectoryPath);
            }
            catch (UnauthorizedAccessException)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(Properties.Resources.FolderAccessDenied, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // すべてのチェックを通過
            return true;
        }

        private bool ValidatePythonVersionInput(string version)
        { 
            // 空チェック
            if (string.IsNullOrWhiteSpace(version))
            {
                SystemSounds.Asterisk.Play();
                //MessageBox.Show(Properties.Resources.EnterFolderBeforeSetting, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Properties.Resources.EnterVersionBeforeSetting, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 禁止文字チェック
            string invalidChars = @";:`""',/\&=";
            foreach (char c in invalidChars)
            {
                if (version.Contains(c))
                {
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(Properties.Resources.InvalidVersionCharacters, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // すべてのバリデーションに成功した場合
            return true;
        }

        private bool ValidateFilenameInput(string filename)
        {
            // 禁止文字チェック
            string invalidChars = @"<>:""/\|?*";
            foreach (char c in invalidChars)
            {
                if (filename.Contains(c))
                {
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(Properties.Resources.InvalidFileNameCharacters, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // すべてのバリデーションに成功した場合
            return true;
        }

        private void DisabledAllButtons()
        {
            PyenvTabRunButton.Enabled = false;
            InstallTabInstallButton.Enabled = false;
            LocalVersionTabSetButton.Enabled = false;
            LocalVersionTabSelectFolderButton.Enabled = false;
            GlobalVersionTabSetButton.Enabled = false;

            CreateVenvTabCreateButton.Enabled = false;
            CreateVenvTabSelectFolderButton.Enabled = false;
            SettingsTabSetButton.Enabled = false;
            SettingsTabSelectBaseFolderButton.Enabled = false;
        }

        private void EnabledAllButtons()
        {
            PyenvTabRunButton.Enabled = true;
            InstallTabInstallButton.Enabled = true;
            LocalVersionTabSetButton.Enabled = true;
            LocalVersionTabSelectFolderButton.Enabled = true;
            GlobalVersionTabSetButton.Enabled = true;

            CreateVenvTabCreateButton.Enabled = true;
            CreateVenvTabSelectFolderButton.Enabled = true;
            SettingsTabSetButton.Enabled = true;
            SettingsTabSelectBaseFolderButton.Enabled = true;
        }

    }
}
