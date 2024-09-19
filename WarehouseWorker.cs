using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    internal class WarehouseWorker
    {
        private string path = @"warehouse_worker.txt";
        public List<string> GetWarehouseWorker()
        {
            string[] temp_user = File.ReadAllLines(path); // Загрузка в список
            List<string> _temp = temp_user.ToList();
            return _temp;
        }

        public bool ExaminationId(string id) // Провекрка на существования id
        {
            bool answer = false;
            List<string> temp = GetWarehouseWorker();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    answer = true;
                }
            }

            return answer;

        }

        public string GetPassword(string id) // Выдача пароля по id
        {
            List<string> temp = GetWarehouseWorker();
            string pass = "";

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    pass = temp[i].Split(":")[1];
                }
            }
            return pass;
        }

        public List<string> GetWarehouseWorkerID(string id)
        {
            List<string> temp = GetWarehouseWorker();
            List<string> warehouseWorker = new List<string>();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    warehouseWorker.Add(temp[i].Split(":")[0]);
                    warehouseWorker.Add(temp[i].Split(":")[1]);
                    warehouseWorker.Add(temp[i].Split(":")[2]);
                    warehouseWorker.Add(temp[i].Split(":")[3]);
                    warehouseWorker.Add(temp[i].Split(":")[4]);
                    break;
                }
            }
            return warehouseWorker;
        }

        public void CreateNewWarehouseWorker(string id, string password, string surname, string name, string otchestvo) // Создания пользователя Surname - фамилия, name - имя, otchestvo - отчество
        {
            string[] warehouseworker = new string[GetWarehouseWorker().Count + 1];
            string[] temp = GetWarehouseWorker().ToArray();

            for (int i = 0; i < warehouseworker.Length - 1; i++)
            {
                warehouseworker[i] = temp[i];
            }

            warehouseworker[temp.Length] = id + ':' + password + ':' + surname + ':' + name + ':' + otchestvo;
            File.WriteAllLines(path, warehouseworker);
        }

        public void DeleteWarehouseWorker(string id)  // Удаление пользователя
        {

            string t_id;
            string t_password;
            string t_surname;
            string t_name;
            string t_otchestvo;

            List<string> temp = GetWarehouseWorker();
            File.Create(path).Close();

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Split(":")[0] != id)
                {
                    t_id = temp[i].Split(":")[0];
                    t_password = temp[i].Split(":")[1];
                    t_surname = temp[i].Split(":")[2];
                    t_name = temp[i].Split(":")[3];
                    t_otchestvo = temp[i].Split(":")[4];

                    CreateNewWarehouseWorker(t_id, t_password, t_surname, t_name, t_otchestvo);
                }
            }
        }
    }
}
