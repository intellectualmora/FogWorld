using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;

namespace Backend
{
    public class XmlSerialization
    {
        public static string Serialize<T>(T obj)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter textWriter = new StreamWriter(ms, Encoding.GetEncoding("utf-8"));
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(textWriter, obj);
            string xmlMessage = Encoding.UTF8.GetString(ms.GetBuffer());
            return xmlMessage;
        }

        public static int SerializeWithSaved<T>(string filePath, T obj)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter textWriter = new StreamWriter(ms, Encoding.GetEncoding("utf-8"));
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(textWriter, obj);
            string xmlMessage = Encoding.UTF8.GetString(ms.GetBuffer());
            try
            {
                Debug.Log(filePath);
                StreamWriter file1 = new StreamWriter(Path.Combine(filePath), false); //文件已覆盖方式添加内容
                file1.Write(xmlMessage); //保存数据到文件
                file1.Close(); //关闭文件
                file1.Dispose();
                return 0;
            }
            catch (Exception e)
            {
                return -1;
                //  Block of code to handle errors
            }

        }

        public static T Deserialize<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // Declare an object variable of the type to be deserialized.
            T obj;

            using (Stream reader = new FileStream(Path.Combine(filePath), FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                obj = (T)serializer.Deserialize(reader);
            }
            return obj;
        }
    }
}
