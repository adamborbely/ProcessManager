//using System;
//using System.IO;
//using System.Xml;
//using System.Runtime.Serialization;

//using System.Xml.Serialization;

//namespace GetProcesses
//{
//    class DataManager
//    {
//        private string path = "database.xml";

//        public void Save(Processes process)
//        {
//            XmlSerializer serializer = new XmlSerializer(typeof(Processes));
//            using (TextWriter tw = new StreamWriter(path))
//            {
//                serializer.Serialize(tw, process);
//            }
//        }
//        public void Load()
//        {
//            XmlSerializer deserializer = new XmlSerializer(typeof(Processes));
//            TextReader reader = new StreamReader(path);
//            object obj = deserializer.Deserialize(reader);
//            var bowser = (Processes)obj;
//        }

//    }
//}
