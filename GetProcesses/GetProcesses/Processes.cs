using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.IO;
using System.Collections.Generic;


namespace GetProcesses
{
    [Serializable()]
    class Processes
    {
        public List<Proc> LocalAll = new List<Proc>();



        public Processes()
        {
        }
    }
}
