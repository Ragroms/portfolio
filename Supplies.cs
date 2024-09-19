using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;

namespace Курсач
{
    internal class Supplies // медикоменты на складе
    {
        //id : назван : кол. на складе : обще цена

        
        private string path = @"supplies.txt";
        public List<string> GetSupplice()
        {
            string[] temp_user = File.ReadAllLines(path); // Загрузка в список
            List<string> _temp = temp_user.ToList();
            return _temp;
        }
        public bool ExaminationId(string id) // Провекрка на существования id
        {
            bool answer = false;
            List<string> temp = GetSupplice();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    answer = true;
                }
            }

            return answer;
        }
        public List<string> GetSuppliceID(string id)
        {
            List<string> temp = GetSupplice();
            List<string> supplice = new List<string>();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    supplice.Add(temp[i].Split(":")[0]);
                    supplice.Add(temp[i].Split(":")[1]);
                    supplice.Add(temp[i].Split(":")[2]);
                    supplice.Add(temp[i].Split(":")[3]);
                    break;
                }
            }
            return supplice;
        }

        // Проверка на существования названия

        public bool CheckSuppliceName(string name)
        {
            List<string> temp = GetSupplice();
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


        // выдача по названию
        public string GetIDSuppliceName(string name)
        {
            List<string> temp = GetSupplice();
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


        public void CreateNewSupplice(string id, string name, string quantity, string total_price) // Создания пользователя Surname - фамилия, name - имя, otchestvo - отчество
        {
            string[] supplice = new string[GetSupplice().Count + 1];
            string[] temp = GetSupplice().ToArray();

            for (int i = 0; i < supplice.Length - 1; i++)
            {
                supplice[i] = temp[i];
            }

            supplice[temp.Length] = id + ':' + name + ':' + quantity + ':' + total_price;
            File.WriteAllLines(path, supplice);
        }

        public void DeleteSupplice(string id)  // Удаление пользователя
        {

            string t_id;
            string t_name;
            string t_quantity;
            string t_total_price;

            List<string> temp = GetSupplice();
            File.Create(path).Close();

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Split(":")[0] != id)
                {
                    t_id = temp[i].Split(":")[0];
                    t_name = temp[i].Split(":")[1];
                    t_quantity = temp[i].Split(":")[2];
                    t_total_price = temp[i].Split(":")[3];
                    CreateNewSupplice(t_id, t_name, t_quantity, t_total_price);
                }
            }
        }
        

    }
}
