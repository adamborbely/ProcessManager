using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GetProcesses
{
    class Proc
    {
        public string Name;
        int Id;
        DateTime StartTime;
        double CpuUsage;
        int MemoryUsage;
        TimeSpan RunningTime;
        int Threads;
        public List<Proc> ProcList = new List<Proc>();

        public Proc(Process[] processes)
        {
            for (int i = 0; i < processes.Length; i++)
            {
                try
                {
                    this.Name = processes[i].ProcessName;
                    this.Id = processes[i].Id;
                    this.StartTime = processes[i].StartTime;
                    this.RunningTime = processes[i].UserProcessorTime;
                    Console.WriteLine(processes[i].ProcessName);
                    
                }
                catch (Exception)
                {
                    Console.WriteLine();          
                }

            }
            ProcList.Add(this);

        }
    }
}
