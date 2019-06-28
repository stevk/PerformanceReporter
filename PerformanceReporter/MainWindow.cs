using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerformanceReporter
{
    public partial class MainWindow : Form
    {
        Properties.Settings Settings = Properties.Settings.Default;
        private LoadingForm LoadingScreen;
        BackgroundWorker Worker;

        public MainWindow()
        {
            InitializeComponent();

            // Populates text fields with previous entries, if available.
            LoadProfile();

            if (EventProfileComboBox.Items.Count > 0)
            {
                EventProfileComboBox.SelectedItem = EventProfileComboBox.Items[0];
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Configure the worker.
            Worker = new BackgroundWorker();
            Worker.DoWork += new DoWorkEventHandler(Worker_CreateReport);
            Worker.WorkerSupportsCancellation = true;
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);

            // Start the worker.
            Worker.RunWorkerAsync();

            // Display a loading form.
            Enabled = false;
            LoadingScreen = new LoadingForm(Worker);
            LoadingScreen.StartPosition = FormStartPosition.CenterParent;
            LoadingScreen.TopMost = true;
            LoadingScreen.ShowDialog(this);
        }

        private void Worker_CreateReport(object sender, DoWorkEventArgs e)
        {
            // Bundles all of the the user input text for easier handling.
            var userInput = new UserInput(this);
            if (Worker_CheckIfCanceled(e)) return;

            // Extract the data from the .etl
            var telemetryData = new ETW(userInput);
            if (Worker_CheckIfCanceled(e)) return;

            // Format the data for the report and create statistics.
            List<ScenarioRun> formattedTelemetryData = Telemetry.FormatData(telemetryData, userInput);
            if (Worker_CheckIfCanceled(e)) return;

            // Create the excel report.
            ExcelReport.Create(formattedTelemetryData, userInput);
            if (Worker_CheckIfCanceled(e)) return;
        }

        internal bool Worker_CheckIfCanceled(DoWorkEventArgs e)
        {
            if (Worker.CancellationPending)
            {
                e.Cancel = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadingScreen.Close();
            Enabled = true;
        }

        private void EventProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfile(EventProfileComboBox.SelectedIndex);
            EventProfileComboBox.Text = EventProfileComboBox.SelectedItem.ToString();
            deleteProfileButton.Enabled = true;
        }

        private void SaveProfileButton_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }

        private void selectTraceButton_Click(object sender, EventArgs e)
        {
            FilePicker(tracePathTextBox);
        }

        private void selectSymbolsButton_Click(object sender, EventArgs e)
        {
            FilePicker(symbolsPathTextBox);
        }

        private void selectOutputButton_Click(object sender, EventArgs e)
        {
            FilePicker(resultTextBox);
        }

        private void FilePicker(TextBox textBox)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog(this) == DialogResult.OK)
            {
                textBox.Text = file.FileName;
            }
        }

        private void LoadProfile(int profileIndex = 0)
        {
            if (Settings.FirstLaunch == 1)
            {
                Settings.SettingsProfile = new StringCollection();
                Settings.TracePath = new StringCollection();
                Settings.SymbolsPath = new StringCollection();
                Settings.BuildName = new StringCollection();
                Settings.StartEventName = new StringCollection();
                Settings.StartEventParameter1 = new StringCollection();
                Settings.StartEventParameter2 = new StringCollection();
                Settings.EndEventName = new StringCollection();
                Settings.EndEventParameter1 = new StringCollection();
                Settings.EndEventParameter2 = new StringCollection();
                Settings.Notes = new StringCollection();
                Settings.ScenarioName = new StringCollection();
                Settings.ResultFileName = new StringCollection();
                Settings.FirstLaunch = 0;
            }
            else
            {

                if (EventProfileComboBox.Items.Count == 0)
                {
                    foreach (var profile in Settings.SettingsProfile)
                    {
                        EventProfileComboBox.Items.Add(profile);
                    }
                }

                tracePathTextBox.Text = Settings.TracePath?[profileIndex] ?? "";
                symbolsPathTextBox.Text = Settings.SymbolsPath?[profileIndex] ?? "";
                buildNameTextBox.Text = Settings.BuildName?[profileIndex] ?? "";
                startEventTextBox.Text = Settings.StartEventName?[profileIndex] ?? "";
                startEventParam1TextBox.Text = Settings.StartEventParameter1?[profileIndex] ?? "";
                startEventParam2TextBox.Text = Settings.StartEventParameter2?[profileIndex] ?? "";
                endEventTextBox.Text = Settings.EndEventName?[profileIndex] ?? "";
                endEventParam1TextBox.Text = Settings.EndEventParameter1?[profileIndex] ?? "";
                endEventParam2TextBox.Text = Settings.EndEventParameter2?[profileIndex] ?? "";
                NotesTextBox.Text = Settings.Notes?[profileIndex] ?? "";
                scenarioNameTextBox.Text = Settings.ScenarioName?[profileIndex] ?? "";
                resultTextBox.Text = Settings.ResultFileName?[profileIndex] ?? "";
            }
        }

        private void SaveProfile()
        {
            bool newProfile = false;
            if (!EventProfileComboBox.Items.Contains(EventProfileComboBox.Text))
            {
                EventProfileComboBox.Items.Add(EventProfileComboBox.Text);
                newProfile = true;
            }
            int profileIndex = EventProfileComboBox.Items.IndexOf(EventProfileComboBox.Text);

            if (newProfile)
            {
                Settings.SettingsProfile.Add(EventProfileComboBox.Text);
                Settings.TracePath.Add(tracePathTextBox.Text);
                Settings.SymbolsPath.Add(symbolsPathTextBox.Text);
                Settings.BuildName.Add(buildNameTextBox.Text);
                Settings.StartEventName.Add(startEventTextBox.Text);
                Settings.StartEventParameter1.Add(startEventParam1TextBox.Text);
                Settings.StartEventParameter2.Add(startEventParam2TextBox.Text);
                Settings.EndEventName.Add(endEventTextBox.Text);
                Settings.EndEventParameter1.Add(endEventParam1TextBox.Text);
                Settings.EndEventParameter2.Add(endEventParam2TextBox.Text);
                Settings.Notes.Add(NotesTextBox.Text);
                Settings.ScenarioName.Add(scenarioNameTextBox.Text);
                Settings.ResultFileName.Add(resultTextBox.Text);

                EventProfileComboBox.SelectedIndex = profileIndex;
            }
            else
            {
                Settings.SettingsProfile[profileIndex] = EventProfileComboBox.Text;
                Settings.TracePath[profileIndex] = tracePathTextBox.Text;
                Settings.SymbolsPath[profileIndex] = symbolsPathTextBox.Text;
                Settings.BuildName[profileIndex] = buildNameTextBox.Text;
                Settings.StartEventName[profileIndex] = startEventTextBox.Text;
                Settings.StartEventParameter1[profileIndex] = startEventParam1TextBox.Text;
                Settings.StartEventParameter2[profileIndex] = startEventParam2TextBox.Text;
                Settings.EndEventName[profileIndex] = endEventTextBox.Text;
                Settings.EndEventParameter1[profileIndex] = endEventParam1TextBox.Text;
                Settings.EndEventParameter2[profileIndex] = endEventParam2TextBox.Text;
                Settings.Notes[profileIndex] = NotesTextBox.Text;
                Settings.ScenarioName[profileIndex] = scenarioNameTextBox.Text;
                Settings.ResultFileName[profileIndex] = resultTextBox.Text;
            }
            Settings.Save();
        }

        /// <summary>
        /// Keeps user input bundled together.
        /// </summary>
        internal struct UserInput
        {
            internal string TracePath;
            internal string SymbolsPath;
            internal string BuildName;
            internal string StartEventName;
            internal string StartEventParameter1;
            internal string StartEventParameter2;
            internal string EndEventName;
            internal string EndEventParameter1;
            internal string EndEventParameter2;
            internal string Notes;
            internal string ScenarioName;
            internal string ResultFileName;

            internal UserInput(MainWindow form)
            {
                TracePath = form.tracePathTextBox.Text;
                SymbolsPath = form.symbolsPathTextBox.Text;
                BuildName = form.buildNameTextBox.Text;
                StartEventName = form.startEventTextBox.Text;
                StartEventParameter1 = form.startEventParam1TextBox.Text;
                StartEventParameter2 = form.startEventParam2TextBox.Text;
                EndEventName = form.endEventTextBox.Text;
                EndEventParameter1 = form.endEventParam1TextBox.Text;
                EndEventParameter2 = form.endEventParam2TextBox.Text;
                Notes = form.NotesTextBox.Text;
                ScenarioName = form.scenarioNameTextBox.Text;
                ResultFileName = form.resultTextBox.Text;
            }
        }

        private void EnableStartButtonIfFieldsArePopulated()
        {
            var requiredFieldsList = new List<TextBox>()
            {
                tracePathTextBox,
                symbolsPathTextBox,
                buildNameTextBox,
                startEventTextBox,
                endEventTextBox,
                scenarioNameTextBox,
                resultTextBox,
            };

            bool enableStartButton = true;
            foreach (var textbox in requiredFieldsList)
            {
                if (string.IsNullOrEmpty(textbox.Text))
                {
                    enableStartButton = false;
                }
            }

            if (enableStartButton)
            {
                StartButton.Enabled = true;
            }
            else
            {
                StartButton.Enabled = false;
            }
        }

        private void scenarioNameTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableStartButtonIfFieldsArePopulated();
        }

        private void startEventTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableStartButtonIfFieldsArePopulated();
        }

        private void endEventTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableStartButtonIfFieldsArePopulated();
        }

        private void tracePathTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableStartButtonIfFieldsArePopulated();
        }

        private void symbolsPathTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableStartButtonIfFieldsArePopulated();
        }

        private void buildNameTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableStartButtonIfFieldsArePopulated();
        }

        private void resultTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableStartButtonIfFieldsArePopulated();
        }

        private void deleteProfileButton_Click(object sender, EventArgs e)
        {
            int profileIndex = EventProfileComboBox.SelectedIndex;

            Settings.SettingsProfile.RemoveAt(profileIndex);
            Settings.TracePath.RemoveAt(profileIndex);
            Settings.SymbolsPath.RemoveAt(profileIndex);
            Settings.BuildName.RemoveAt(profileIndex);
            Settings.StartEventName.RemoveAt(profileIndex);
            Settings.StartEventParameter1.RemoveAt(profileIndex);
            Settings.StartEventParameter2.RemoveAt(profileIndex);
            Settings.EndEventName.RemoveAt(profileIndex);
            Settings.EndEventParameter1.RemoveAt(profileIndex);
            Settings.EndEventParameter2.RemoveAt(profileIndex);
            Settings.Notes.RemoveAt(profileIndex);
            Settings.ScenarioName.RemoveAt(profileIndex);
            Settings.ResultFileName.RemoveAt(profileIndex);

            if (EventProfileComboBox.Items.Count > 0)
            {
                EventProfileComboBox.SelectedIndex = 0;
            }
            else
            {
                deleteProfileButton.Enabled = false;
            }
        }
    }
}
