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

            Proc.Seriali(processes.LocalAll);
            var processes2 = new Proc();
            processes2.DeSerial();
            foreach (var item in processes2.ProcList)
            {
                Console.WriteLine(item.RunningTime);
            }

        }


    }

}