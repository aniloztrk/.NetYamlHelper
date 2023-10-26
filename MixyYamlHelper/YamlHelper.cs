using System;
using System.IO;
using YamlDotNet.Serialization;

namespace MixyYamlHelper
{
    public class YamlHelper
    {
        public static bool TrySerialize<T>(T obj, out string yaml) where T : class
        {
            try
            {
                var serializer = new SerializerBuilder().WithIndentedSequences().Build();
                yaml = serializer.Serialize(obj);
                return true;
            }
            catch (Exception)
            {
                yaml = null;
                return false;
            }
        }

        public static bool TryDeserialize<T>(out T obj, string yaml) where T : class
        {
            try
            {
                var deserializer = new DeserializerBuilder().Build();
                obj = deserializer.Deserialize<T>(yaml);
                return true;
            }
            catch (Exception)
            {
                obj = default;
                return false;
            }
        }

        public static bool TryWriteFile<T>(T obj, string filePath) where T : class
        {
            try
            {
                var serializer = new SerializerBuilder().WithIndentedSequences().Build();
                File.WriteAllText(filePath, serializer.Serialize(obj));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool TryReadFile<T>(out T obj, string filePath) where T : class
        {
            try
            {
                var deserializer = new DeserializerBuilder().Build();
                obj = deserializer.Deserialize<T>(File.ReadAllText(filePath));
                return true;
            }
            catch (Exception)
            {
                obj = default;
                return false;
            }
        }
    }
}