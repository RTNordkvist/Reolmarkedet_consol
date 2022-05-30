using Newtonsoft.Json;
using Reolmarkedet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet
{
    public class Database<T> where T : BaseIdentifiableItem
    {
        public List<T> Items { get; }
        private string _path = Path.Combine(Directory.GetCurrentDirectory(), $"Database");
        private string _filePath => Path.Combine(_path, $"{typeof(T).Name}.txt");

        public Database()
        {
            try
            {
                Directory.CreateDirectory(_path);
                var json = File.ReadAllText(_filePath);
                Items = JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (Exception)
            {
                Items = new List<T>();
            }
        }

        public int AddItem(T item)
        {
            item.Id = GetId();
            Items.Add(item);
            UpdateDatabase();

            return item.Id;
        }

        public int DeleteItem(int id)
        {
            T item = Items.First(x => x.Id == id);
            Items.Remove(item);
            UpdateDatabase();

            return id;
        }

        public void UpdateDatabase()
        {
            string json = JsonConvert.SerializeObject(Items);
            File.WriteAllText(_filePath, json);
        }

        private int GetId()
        {
            if (Items.Any())
            {
                return Items.Max(x => x.Id) + 1;
            }

            return 1;
        }
    }
}
