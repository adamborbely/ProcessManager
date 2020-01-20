using System;
using System.Diagnostics;
using System.ComponentModel;

namespace GetProcesses
{
    public class Program
    {
        static void Main()
        {
            var myProcess = new Proc(Process.GetProcesses());
            Console.WriteLine(myProcess.ProcList.Count);
            foreach (var item in myProcess.ProcList)
            {
                Console.WriteLine(item.Name);
            }
        }

    }

}