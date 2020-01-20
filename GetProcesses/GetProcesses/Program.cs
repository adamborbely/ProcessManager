using System;
using System.Diagnostics;
using System.ComponentModel;

namespace GetProcesses
{
    public class Program
    {
        static void Main()
        {
            var dataManager = new DataManager();
            var myProcess = new Processes();
            myProcess.Save(myProcess);
            myProcess.List();

        }

    }

}