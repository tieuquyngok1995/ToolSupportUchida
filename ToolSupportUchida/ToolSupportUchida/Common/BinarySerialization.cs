using System;
using System.Collections.Generic;
using System.IO;
using ToolSupportUchida.Model;
using ToolSupportUchida.Utils;

namespace ToolSupportUchida.Common
{
    public static class BinarySerialization
    {
        private static string filePath = AppContext.BaseDirectory + @"\ToolSupportData.bin";
        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>()
        {
            if (!File.Exists(CONST.FILE_PATH))
            {
                string[] data = { };

                ToolSupportModel objTool = new ToolSupportModel();

                List<SekkeiModel> lstSekkei = new List<SekkeiModel>();
                List<AdapterModel> lstAdapter = new List<AdapterModel>();

                if (File.Exists(CONST.FILE_PATH_IMPORT))
                {
                    data = File.ReadAllLines(CONST.FILE_PATH_IMPORT);
                }

                foreach (string line in data)
                {
                    string[] arrLine = line.Split('=');
                    lstSekkei.Add(new SekkeiModel(arrLine[0], arrLine[1]));
                }

                objTool.lstSekkei = lstSekkei;
                objTool.lstAdapter = lstAdapter;

                WriteToBinaryFile<ToolSupportModel>(objTool);
            }

            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
