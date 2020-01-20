using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;


namespace GetProcesses
{
    [Serializable()]
    public class Processes : ISerializable
    {
        private string path = "database.xml";

        public Processes()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Process []", LocalAll);
        }
        public Processes(SerializationInfo info, StreamingContext context)
        {
            LocalAll = (Process[])info.GetValue("Process[]", typeof(Process[]));
        }

        public void Kill()
        {
            foreach (var process in LocalAll)
            {
                try
                {
                    process.Kill();

                }
                catch (Exception)
                {

                    Console.WriteLine(process.ProcessName + "This cant b closed");
                }
            }
        }
        public void List()
        {
            foreach (var process in LocalAll)
            {
                Console.WriteLine(process.Id + " " + process.ProcessName);
            }
        }
        public void Save(Processes process)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Processes));
            using (TextWriter tw = new StreamWriter(path))
            {
                serializer.Serialize(tw, process);
            }
        }
    }
}
