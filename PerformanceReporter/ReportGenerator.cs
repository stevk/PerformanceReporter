using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Marshal = System.Runtime.InteropServices.Marshal;

namespace PerformanceReporter
{
    static class ExcelReport
    {
        /// <summary>
        /// Uses the telemetry data to create an report in excel.
        /// If the file already exists, it MUST be closed for this to work.
        /// </summary>
        static internal void Create(List<ScenarioRun> telemetryData, MainWindow.UserInput userInput)
        {
            Excel.Application excelApp = null;

            try
            {
                excelApp = new Excel.Application();
                Excel._Worksheet workSheet;

                // Checks the provided name to see if it has a valid extension, and adds one if not.
                string extension = Path.GetExtension(userInput.ResultFileName);
                string excelExtension = ".xlsx";
                string outputFilename;
                if (Path.GetExtension(userInput.ResultFileName) != excelExtension)
                {
                    outputFilename = Path.ChangeExtension(userInput.ResultFileName, excelExtension);
                }
                else
                {
                    outputFilename = userInput.ResultFileName;
                }

                // Checks if that excel file already exists. Use the existing report if it does, otherwise create a new one.
                int startColumnPosition = 1;
                if (File.Exists(outputFilename))
                {
                    // Makes sure the excel file isn't already open
                    while (IsFileLocked(new FileInfo(outputFilename)))
                    {
                        MessageBox.Show("Excel file is already locked and cannot be edited! Make sure that file is closed.");
                    }

                    // Load the existing excel sheet
                    workSheet = excelApp.Workbooks.Open(outputFilename).Sheets[1];

                    // Determine where the beginning of unused space is by checking the cells containing the scenario names.
                    for (int columnIndex = 1; columnIndex <= workSheet.Columns.Count; columnIndex += 5)
                    {
                        if (workSheet.Cells[2, columnIndex].Value == null)
                        {
                            startColumnPosition = columnIndex;
                            break;
                        }
                    }
                }
                else
                {
                    excelApp.Workbooks.Add();
                    workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
                }

                // Set up column positions. These values are shifted over as more scenarios are added to a report.
                int A = startColumnPosition;
                int B = startColumnPosition + 1;
                int C = startColumnPosition + 2;
                int D = startColumnPosition + 3;

                int eventCount = telemetryData.Count;

                // Generic formatting and labels
                workSheet.Cells[1, B] = userInput.BuildName;
                workSheet.Cells[2, A] = userInput.ScenarioName;
                workSheet.Cells[2, A].Font.Bold = true;
                workSheet.Cells[3, B] = "Start";
                workSheet.Cells[3, B].Font.Bold = true;
                workSheet.Cells[3, C] = "End";
                workSheet.Cells[3, C].Font.Bold = true;
                workSheet.Cells[3, D] = "Result";
                workSheet.Cells[3, D].Font.Bold = true;

                Excel.Range formattingRange = workSheet.Range[workSheet.Cells[2, A], workSheet.Cells[eventCount + 8, D]];
                formattingRange.NumberFormat = "0";
                formattingRange.BorderAround2();

                // Fill in the worksheet
                for (int y = 0; y < eventCount; y++)
                {
                    int eventRow = y + 4;
                    workSheet.Cells[eventRow, A] = y + 1;
                    workSheet.Cells[eventRow, B] = telemetryData[y].Start.Time;
                    workSheet.Cells[eventRow, C] = telemetryData[y].End.Time;
                    workSheet.Cells[eventRow, D] = $"=({ExcelColumnFromNumber(C)}{eventRow} - {ExcelColumnFromNumber(B)}{eventRow})";
                }

                int statsRow = telemetryData.Count + 5;
                Excel.Range statsLabelsFormattingRange = workSheet.Range[workSheet.Cells[statsRow, A], workSheet.Cells[statsRow + 3, A]];
                statsLabelsFormattingRange.Font.Bold = true;

                string range = $"({ExcelColumnFromNumber(D)}{4}:{ExcelColumnFromNumber(D)}{eventCount + 3})";
                workSheet.Cells[statsRow, A] = "High";
                workSheet.Cells[statsRow, B] = $"=MAX{range}";
                statsRow++;
                workSheet.Cells[statsRow, A] = "Median";
                workSheet.Cells[statsRow, B] = $"=MEDIAN{range}";
                statsRow++;
                workSheet.Cells[statsRow, A] = "Low";
                workSheet.Cells[statsRow, B] = $"=MIN{range}";
                statsRow++;
                workSheet.Cells[statsRow, A] = $"{eventCount}th - 2nd Diff";
                workSheet.Cells[statsRow, B] = $"={ExcelColumnFromNumber(D)}{eventCount + 3}-{ExcelColumnFromNumber(D)}{5}";

                // Only merge cells for notes if there are notes to add.
                Excel.Range notesCell = workSheet.Cells[statsRow + 2, A];
                if (!string.IsNullOrEmpty(userInput.Notes))
                {
                    notesCell.Value = userInput.Notes;
                    Excel.Range notes = workSheet.Range[workSheet.Cells[statsRow + 2, A], workSheet.Cells[statsRow + 2, D]].Merge();
                }

                // Adjust column widths to fit the content.
                workSheet.Columns[A].ColumnWidth = 12;
                for (int x = B; x <= D; x++)
                {
                    workSheet.Columns[x].ColumnWidth = 8;
                }

                // Save the file.
                workSheet.SaveAs(userInput.ResultFileName);
            }
            finally
            {
                excelApp.Workbooks.Close();
                Marshal.ReleaseComObject(excelApp.Workbooks);
                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);
            }
        }

        /// <summary>
        /// 1 -> A
        /// 2 -> B
        /// 3 -> C
        /// ...
        /// </summary>
        public static string ExcelColumnFromNumber(int column)
        {
            string columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                decimal currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }

        /// <summary>
        /// Checks if a file is locked, likely by another app.
        /// </summary>
        static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            //file is not locked
            return false;
        }
    }
}
