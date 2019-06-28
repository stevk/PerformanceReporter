using System.Collections.Generic;

namespace PerformanceReporter
{
    /// <summary>
    /// Creates start/end pairings.
    /// All times are in milliseconds(ms).
    /// </summary>
    static class Telemetry
    {
        static internal List<ScenarioRun> FormatData(ETW telemetryData, MainWindow.UserInput userInput)
        {
            var scenario = new List<ScenarioRun>();

            // Pair start/end events.
            var eventCount = telemetryData.Events.Count;
            var events = telemetryData.Events;
            var DesiredStartEvent = new TelemetryEvent(0, userInput.StartEventName, userInput.StartEventParameter1, userInput.StartEventParameter2);
            var DesiredEndEvent = new TelemetryEvent(0, userInput.EndEventName, userInput.EndEventParameter1, userInput.EndEventParameter2);
            for (int startEventIndex = 0; startEventIndex < eventCount; startEventIndex++)
            {
                if (events[startEventIndex].Equals(DesiredStartEvent))
                {
                    for (int endEventIndex = startEventIndex; endEventIndex < eventCount; endEventIndex++)
                    {
                        if (events[endEventIndex].Equals(DesiredEndEvent))
                        {
                            scenario.Add(new ScenarioRun(events[startEventIndex], events[endEventIndex]));
                            endEventIndex = eventCount; // Break the inner loop
                        }
                    }
                }
            }

            return scenario;
        }
    }

    /// <summary>
    /// Keeps matching start/end telemetry events together.
    /// </summary>
    internal struct ScenarioRun
    {
        internal TelemetryEvent Start;
        internal TelemetryEvent End;

        internal ScenarioRun(TelemetryEvent eventStart, TelemetryEvent eventEnd)
        {
            Start = eventStart;
            End = eventEnd;
        }
    }
}
