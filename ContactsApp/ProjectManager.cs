using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ContactsApp
{
    /// <summary>
    /// Класс "Менеджер проекта". Позволяет сохранять и загружать даннные.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Метод сохранения
        /// </summary>
        /// <param name="data">Переменная, которая хранит данные контактов и сохраняет их в текстовый файл</param>
        /// <param name="filename">Именование файла</param>
        public static void SaveToFile(Project data, string filename)
        {        
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            using (StreamWriter sw = new StreamWriter(documents+@"\json.txt"))
            using(Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }
        /// <summary>
        /// Метод загрузки
        /// </summary>
        /// <param name="filename">Именование файла</param>
        public static Project Load(string filename)
        {
            Project project = null;
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            using (StreamReader sr = new StreamReader(documents + @"\json.txt"))
            using(Newtonsoft.Json.JsonReader reader = new Newtonsoft.Json.JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }
            return project;
        }
    }
}
