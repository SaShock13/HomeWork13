using SkillboxHomework10_1.BankWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkillboxHomework10_1
{
    internal class Manager :BankWorker,IEditClientData
    {
        public Manager()
        {
            accessType = AccessType.Менеджер;
        }

        /// <summary>
        /// Редактирование данных клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public void EditClientData(Client client)
        {
            Client tempClient = new Client();
            tempClient.LastName = client.LastName;
            tempClient.Name = client.Name;
            tempClient.SurName = client.SurName;
            tempClient.Passport = client.Passport;
            tempClient.PhoneNumber = client.PhoneNumber;

            if (client != null)
            {
                EditWindow editWindow = new EditWindow();

                editWindow.tbLastName.IsEnabled = true;
                editWindow.tbName.IsEnabled = true;
                editWindow.tbSurName.IsEnabled = true;
                editWindow.tbPassport.IsEnabled = true;

                editWindow.tbLastName.Text = client.LastName;
                editWindow.tbName.Text = client.Name;
                editWindow.tbSurName.Text = client.SurName;
                editWindow.tbPhone.Text = client.PhoneNumber.ToString();
                editWindow.tbPassport.Text = client.Passport;
                editWindow.ShowDialog();
                if (editWindow.DialogResult == true)
                {
                    client.WhatChanged = "";
                    client.PhoneNumber = int.Parse(editWindow.tbPhone.Text);
                    if (tempClient.PhoneNumber!=client.PhoneNumber)
                    {
                        client.WhatChanged += " Номер телефона,";
                    }
                    client.LastName = editWindow.tbLastName.Text;
                    if (tempClient.LastName != client.LastName)
                    {
                        client.WhatChanged += " Фамилия,";
                    }
                    client.Name = editWindow.tbName.Text;
                    if (tempClient.Name != client.Name)
                    {
                        client.WhatChanged += " Имя,";
                    }
                    client.SurName = editWindow.tbSurName.Text;
                    if (tempClient.SurName != client.SurName)
                    {
                        client.WhatChanged += " Отчество,";
                    }
                    client.Passport = editWindow.tbPassport.Text;
                    if (tempClient.Passport != client.Passport)
                    {
                        client.WhatChanged += " Паспортные данные,";
                    }

                    
                    StringBuilder builder = new StringBuilder(client.WhatChanged);
                    builder[builder.Length-1] = ' ';
                    client.WhatChanged = builder.ToString();


                    client.ChangeDate = DateTime.Now;
                    client.WhoChanged = "Менеджер";
                    MessageBox.Show("Данные изменены!");
                    
                }
            }
        }

        public void DeleteClient(Client client)
        { 
            Clients.Remove(client);
        }
        public void AddClient(Client client)
        {

            Clients.Add(client);
        }

        public void AddAccount(Client client, string type, int amount)
        {
            client.AccList.Add(new BankAccount(type, amount));
        }

        
    }
}
