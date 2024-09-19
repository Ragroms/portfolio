using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Курсач
{
    internal class Medicine
    {
        // id : назваб : кол. в аптеке : цена 


        private string path = @"medicine.txt";
        public List<string> GetMedicine() // выгрузка из текстового файла
        {
            string[] temp_user = File.ReadAllLines(path); // Загрузка в список
            List<string> _temp = temp_user.ToList();
            return _temp;
        }

        public bool ExaminationId(string id) // Провекрка на существования id
        {
            bool answer = false;
            List<string> temp = GetMedicine();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    answer = true;
                }
            }

            return answer;

        }

        public List<string> GetMedicinetID(string id) // выдает данные медикамента по ID
        {
            List<string> temp = GetMedicine();
            List<string> med = new List<string>();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    med.Add(temp[i].Split(":")[0]);
                    med.Add(temp[i].Split(":")[1]);
                    med.Add(temp[i].Split(":")[2]);
                    med.Add(temp[i].Split(":")[3]);
                    break;
                }
            }
            return med;
        }

        // Проверка на существования названия

        public bool CheckMedicineName(string name)
        {
            List<string> temp = GetMedicine();
            bool result = false;

            for (int i = 0; i < temp.Count; i++)
            {
                if (name == temp[i].Split(":")[1])
                {
                    result = true;
                }
            }
            return result;
        }

        public string GetIDMedicineName(string name) // выдача ID по названию
        {
            List<string> temp = GetMedicine();
            string id = "000000";

            for (int i = 0; i < temp.Count; i++)
            {
                if (name == temp[i].Split(":")[1])
                {
                    id = temp[i].Split(":")[0];
                }
            }
            return id;
        }


        public void CreateNewMedicine(string id, string name, string quantity, string price) // Создания медикомента
        {
            string[] medicine = new string[GetMedicine().Count + 1];
            string[] temp = GetMedicine().ToArray();

            for (int i = 0; i < medicine.Length - 1; i++)
            {
                medicine[i] = temp[i];
            }

            medicine[temp.Length] = id + ':' + name + ':' + quantity + ':' + price;
            File.WriteAllLines(path, medicine);
        }

        public void DeleteMedicine(string id)  // Удаление медикамента
        {

            string t_id;
            string t_name;
            string t_quantity;
            string t_price;

            List<string> temp = GetMedicine();
            File.Create(path).Close();

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Split(":")[0] != id)
                {
                    t_id = temp[i].Split(":")[0];
                    t_name = temp[i].Split(":")[1];
                    t_quantity = temp[i].Split(":")[2];
                    t_price = temp[i].Split(":")[3];
                    CreateNewMedicine(t_id, t_name, t_quantity, t_price);
                }
            }
        }
    }
}
