using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using SkillboxHomework10_1.BankWorkers;

namespace SkillboxHomework10_1
{


    // Изменение данных прописывать в список!!!
    internal class Consultant:BankWorker,IEditClientData
    {
        public Consultant()
        {
            accessType = AccessType.Консультант;
        }
        /// <summary>
        /// Редактирование данных клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public void EditClientData(Client client)
        {
            Client tempClient = client;
            string phoneNumber = client.PhoneNumber.ToString();
            if (tempClient != null)
            {
                EditWindow editWindow = new EditWindow();

                editWindow.tbLastName.IsEnabled = false;
                editWindow.tbName.IsEnabled = false;
                editWindow.tbSurName.IsEnabled = false;
                editWindow.tbPassport.IsEnabled = false;

                editWindow.tbLastName.Text = client.LastName;
                editWindow.tbName.Text = client.Name;
                editWindow.tbSurName.Text = client.SurName;
                editWindow.tbPhone.Text = client.PhoneNumber.ToString();
                editWindow.tbPassport.Text = "****-******";
                editWindow.ShowDialog();
                if (editWindow.DialogResult == true)
                {
                    client.WhatChanged = "";
                    
                    if (phoneNumber != editWindow.tbPhone.Text)
                    {
                        client.WhatChanged += " Номер телефона ";
                    }
                    client.PhoneNumber = int.Parse(editWindow.tbPhone.Text);
                    client.ChangeDate = DateTime.Now;
                    MessageBox.Show("Данные изменены!");
                    client.WhoChanged = "Консультант";
                    client.WhatChanged = "Номер телефона";
                    
                   
                }
            }
        }
    }
}
