using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    internal class Pharmacists
    {
        private string path = @"pharmacists.txt";
        public List <string> GetPharmacists() // Выгрузка из текстового файла
        {
            string[] temp_user = File.ReadAllLines(path); // Загрузка в список
            List<string> _temp = temp_user.ToList();
            return _temp;
        }

        public bool ExaminationId(string id) // Провекрка на существования id
        {
            bool answer = false;
            List<string> temp = GetPharmacists();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    answer = true;
                }
            }

            return answer;

        }

        public List<string> GetPharmacistID(string id) // вовращает фармоцевта по ID
        {
            List<string> temp = GetPharmacists();
            List<string> pharmacist = new List<string>();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    pharmacist.Add(temp[i].Split(":")[0]);
                    pharmacist.Add(temp[i].Split(":")[1]);
                    pharmacist.Add(temp[i].Split(":")[2]);
                    pharmacist.Add(temp[i].Split(":")[3]);
                    pharmacist.Add(temp[i].Split(":")[4]);
                    break;
                }
            }
            return pharmacist;
        }

        public string GetPassword(string id) // Выдача пароля по id
        {
            List<string> temp = GetPharmacists();
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

        public void CreateNewPharmacists(string id, string password, string surname, string name, string otchestvo) // Создания пользователя Surname - фамилия, name - имя, otchestvo - отчество
        {
            string[] pharmacists = new string[GetPharmacists().Count + 1];
            string[] temp = GetPharmacists().ToArray();

            for (int i = 0; i < pharmacists.Length - 1; i++)
            {
                pharmacists[i] = temp[i];
            }

            pharmacists[temp.Length] = id + ':' + password + ':' + surname + ':' + name + ':' + otchestvo;
            File.WriteAllLines(path, pharmacists);
        }

        public void DeletePharmacists(string id)  // Удаление пользователя
        {

            string t_id;
            string t_password;
            string t_surname;
            string t_name;
            string t_otchestvo;

            List<string> temp = GetPharmacists();
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

                    CreateNewPharmacists(t_id, t_password, t_surname, t_name, t_otchestvo);
                }
            }
        }
    }
}
