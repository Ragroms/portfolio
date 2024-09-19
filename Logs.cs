using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Курсач
{
    internal class Logs
    {
        string path = @"logs.txt";
        public List<string> GetLogs() // выгрузка из текстового файла
        {
            string[] temp_logs = File.ReadAllLines(path); // Загрузка в список
            List<string> _temp = temp_logs.ToList();
            return _temp;
        }
        public void CreateLogProduct(string action, string id, string surname, string id_product, string name_product, string quantity_product, string price_product) // создание истории о продукте
        {
            string[] log = new string[GetLogs().Count + 1];
            string[] temp = GetLogs().ToArray();

            for (int i = 0; i < log.Length - 1; i++)
            {
                log[i] = temp[i];
            }

            log[temp.Length] = action + ':' + id + ':' + surname + ':' + id_product + ':' + name_product + ':' + quantity_product + ':' + price_product;
            File.WriteAllLines(path, log);
        }

        // удаление логов

        public void AllDeleteLogs()
        {
            File.Create(path).Close();
        }
     
    }
}
