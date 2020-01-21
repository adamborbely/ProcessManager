using System;
using System.Diagnostics;
using System.ComponentModel;

namespace GetProcesses
{
    public class Program
    {
        static void Main()
        {
            Process[] runningProcesses = Process.GetProcesses();

            var processes = new Processes();
            foreach (var item in runningProcesses)
            {
                var process = new Proc(item);
                processes.LocalAll.Add(process);
            }

            DataManager.Serial(processes.LocalAll);
            var processesFigureOut = new Processes();
            DataManager.DeSerial(processesFigureOut);
            foreach (var item in processesFigureOut.LocalAll)
            {
                Console.WriteLine(item.CpuUsage);
            }
        }
    }
}