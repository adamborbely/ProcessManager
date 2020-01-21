using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GetProcesses
{
    [Serializable()]
    public class Proc : ISerializable
    {

        public string Name;
        public int Id;
        public DateTime StartTime;
        public double CpuUsage;
        public double MemoryUsage;
        public TimeSpan RunningTime;
        public int Threads;
        public List<Proc> ProcList = new List<Proc>();
        public string comment;

        public Proc() { }
        public Proc(Process process)
        {

            try
            {
                this.Name = process.ProcessName;
                this.Id = process.Id;
                this.StartTime = process.StartTime;
                this.RunningTime = DateTime.Now - StartTime;
                this.Threads = process.Threads.Count;
                this.MemoryUsage = Math.Round((double)process.WorkingSet64 / 1024 / 1024, 2);
                var result = GetCpuUsageForProcess();
                this.CpuUsage = Math.Round(result.Result, 2);
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }
        public Proc(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Id = (int)info.GetValue("Id", typeof(int));
            StartTime = (DateTime)info.GetValue("StartTime", typeof(DateTime));
            CpuUsage = (double)info.GetValue("CpuUsage", typeof(double));
            MemoryUsage = (double)info.GetValue("MemoryUsage", typeof(double));
            RunningTime = (TimeSpan)info.GetValue("RunningTime", typeof(TimeSpan));
            Threads = (int)info.GetValue("Threads", typeof(int));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Id", Id);
            info.AddValue("StartTime", StartTime);
            info.AddValue("CpuUsage", CpuUsage);
            info.AddValue("MemoryUsage", MemoryUsage);
            info.AddValue("RunningTime", RunningTime);
            info.AddValue("Threads", Threads);
        }

        private async Task<double> GetCpuUsageForProcess()
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;

            await Task.Delay(0);

            var endTime = DateTime.UtcNow;
            var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;

            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;

            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);

            return cpuUsageTotal * 100;
        }

        public static void Kill()
        {
            Process[] runningProcesses = Process.GetProcesses();
            foreach (var process in runningProcesses)
            {
                try
                {
                    process.Kill();
                }
                catch (Exception)
                {

                    Console.WriteLine("I can't kill everything :(  " + process.ProcessName);
                }
            }
        }
        public static void RunNewProcess(string txtOpen)
        {
            if (!string.IsNullOrEmpty(txtOpen))
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.FileName = txtOpen;
                    proc.Start();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}






