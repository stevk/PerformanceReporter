using System;
using System.Collections.Generic;
using System.IO;

namespace PerformanceReporter
{
    /// <summary>
    /// Manages the telemetry trace file (.etl) and handles extracting data from it.
    /// </summary>
    class ETW
    {
        internal List<TelemetryEvent> Events = new List<TelemetryEvent>();

        internal ETW(MainWindow.UserInput userInput)//string etlFilePath, string symbolPath, string startEvent, string endEvent)
        {
            ExtractDataFromCsv(ConvertToCsv(userInput), userInput);
        }

        /// <summary>
        /// Given an .etl file, convert it into a .csv file.
        /// </summary>
        private string ConvertToCsv(MainWindow.UserInput userInput)
        {
            // Use WaitForExit to check for success, but process needs to be a variable for that to work
            // Might be worth registering the event and disabling UI elements so the app doesn't appear frozen.
            string csvFilePath = Path.ChangeExtension(userInput.TracePath, ".csv");
            System.Diagnostics.Process.Start("CMD.exe", $"/C set _NT_SYMBOL_PATH=SRV*;{userInput.SymbolsPath}").WaitForExit();
            System.Diagnostics.Process.Start("CMD.exe", $"/C xperf -symbols -i {userInput.TracePath} -o {csvFilePath}").WaitForExit();

            return csvFilePath;
        }

        /// <summary>
        /// Given a .csv file, add all of the relevent events to an object list.
        /// </summary>
        private void ExtractDataFromCsv(string csvFilePath, MainWindow.UserInput userInput)
        {
            string line = string.Empty;
            using (StreamReader csv = new StreamReader(csvFilePath))
            {
                while ((line = csv.ReadLine()) != null)
                {
                    string[] partsOfLine = line.Split(',');
                    for (int x = 0; x < partsOfLine.Length; x++)
                    {
                        partsOfLine[x] = partsOfLine[x].Trim();
                    }

                    // Save start/end telemetry events to a list
                    if (partsOfLine[0].Contains(userInput.StartEventName) || partsOfLine[0].Contains(userInput.EndEventName))
                    {
                        // Line[0] is the name. 
                        // Line[1] is the time with the 7th digit being seconds.
                        // Line[9] is the first optional parameter (modifier for a generic event).
                        // Line[10] is the second optional parameter.
                        bool result = int.TryParse(partsOfLine[1], out int time);
                        if (result)
                        {
                            // The parameters are optional, so these checks handle when they are not present.
                            string parameter1 = null;
                            if (partsOfLine.Length > 9)
                            {
                                parameter1 = partsOfLine[9];
                            }

                            string parameter2 = null;
                            if (partsOfLine.Length > 10)
                            {
                                parameter2 = partsOfLine[10];
                            }

                            Events.Add(new TelemetryEvent(time, partsOfLine[0], parameter1, parameter2));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Matches start and end events, and generates statistics based on these pairings.
        /// </summary>
        internal static List<ScenarioRun> Analyze(ETW telemetryData)
        {
            var formattedData = new List<ScenarioRun>();

            return formattedData;
        }
    }

    /// <summary>
    /// Contains values for a telemetry event.
    /// Time is in millaseconds (ms).
    /// </summary>
    struct TelemetryEvent
    {
        internal readonly float Time;
        internal readonly string Name;
        internal readonly string Parameter1;
        internal readonly string Parameter2;

        internal TelemetryEvent(int eventTime, string eventName, string eventParameter1, string eventParameter2)
        {
            Name = eventName;
            Parameter1 = eventParameter1;
            Parameter2 = eventParameter2;

            // Convert the time to millaseconds and store it as a float.
            Time = Convert.ToSingle(eventTime) / 1000;
        }

        /// <summary>
        /// Checks if it is the same type of telemetry event. 
        /// Does not check for time stamp equality.
        /// </summary>
        public bool Equals(TelemetryEvent other)
        {
            if ((object)other == null)
            {
                return false;
            }

            return Name.Contains(other.Name) && StringComparison(Parameter1, other.Parameter1) && StringComparison(Parameter2, other.Parameter2);
        }

        /// <summary>
        /// Checks if a string contains another string. Null and empty strings count as being equal with each other.
        /// </summary>
        static bool StringComparison(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return string.IsNullOrEmpty(b);
            }
            else
            {
                return a.Contains(b);
            }
        }
    }
}
