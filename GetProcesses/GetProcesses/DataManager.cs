using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GetProcesses

{
    class DataManager
    {
        private static string path = "database.xml";

        public static void Serial(List<Proc> allProcesses)
        {
            using (Stream fs = new FileStream(path,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Proc>));
                serializer2.Serialize(fs, allProcesses);
            }
        }
        public static void DeSerial(Processes processes)
        {
            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Proc>));
            using (FileStream fs2 = File.OpenRead(path))
            {
                processes.LocalAll = (List<Proc>)serializer3.Deserialize(fs2);
            }
        }
    }
}