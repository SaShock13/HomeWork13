using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace SkillboxHomework10_1
{
    public abstract class BankWorker : INotifyPropertyChanged
    {

        protected string filePath = "_jsonFile.json"; // Путь к файлу Json
        public AccessType accessType;
        
        public enum AccessType {Консультант,Менеджер };

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод для вызова события PropertyChanged. Параметром передается имя измененного свойства
        /// </summary>        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        
        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients { get { return clients; } set { clients = value; OnPropertyChanged("Clients"); } }


        public BankWorker()
        {
            Clients = new ObservableCollection<Client>();

            //FillList(30);
            ReadFromFile();

        }

        /// <summary>
        /// Заполняет коллекцию  клиентами в количестве count        
        /// </summary>
        private void FillList(int count)
        {
            Random random = new Random();
            for (int i = 1; i < count + 1; i++)
            {
                string passportNumber = $"{random.Next(1000, 10000)}-{random.Next(100000, 1000000)}";
                Clients.Add(new Client($"Фамилия{i}", $"Имя{i}", $"Отчество{i}", random.Next(100000, 1000000), passportNumber,random.Next(1,6)));
            }
        }

        /// <summary>
        /// Сериализует коллекцию в Json и сохраняет в файл
        /// </summary>
        public void SaveToFile()
        {
            var jsonString = JsonConvert.SerializeObject(Clients);
            File.WriteAllText(filePath, jsonString);

        }
        /// <summary>
        /// Читает Json из файла и десериализует в коллекцию объектов Client
        /// </summary>
        public void ReadFromFile()
        {
            
            string jsonString = File.ReadAllText(filePath);
            Clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(jsonString);
            

        }


        


    }
}
