using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    internal class IntermediateProduct
    {
        private string path = @"intermediate_product.txt"; // Путь к файлу с отправлеными лекарствами
        public List<string> GetIntermediateProduct() // Считывает с текстового файла данные
        {
            string[] temp_user = File.ReadAllLines(path); // Загрузка в список
            List<string> _temp = temp_user.ToList(); // Преобразование массива в список
            return _temp; // Возвращение списка
        }

        public bool ExaminationId(string id) // Провекрка на существования id
        {
            bool answer = false;
            List<string> temp = GetIntermediateProduct();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    answer = true;
                }
            }

            return answer;

        }

        public List<string> GeIntermediateProducttID(string id) // вовращает лекарство по ID
        {
            List<string> temp = GetIntermediateProduct();
            List<string> product = new List<string>();

            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].Split(":")[0])
                {
                    product.Add(temp[i].Split(":")[0]);
                    product.Add(temp[i].Split(":")[1]);
                    product.Add(temp[i].Split(":")[2]);
                    product.Add(temp[i].Split(":")[3]);
                    break;
                }
            }
            return product;
        }

        // Проверка на существования названия IntermediateProduct

        public bool CheckIntermediateProductName(string name)
        {
            List<string> temp = GetIntermediateProduct();
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


        // выдача ID по названию
        public string GetIDIntermediateProductName(string name)
        {
            List<string> temp = GetIntermediateProduct();
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


        public void CreateNewIntermediateProduct(string id, string name, string quantity, string price) // Создания лекарства
        {
            string[] product = new string[GetIntermediateProduct().Count + 1];
            string[] temp = GetIntermediateProduct().ToArray();

            for (int i = 0; i < product.Length - 1; i++)
            {
                product[i] = temp[i];
            }

            product[temp.Length] = id + ':' + name + ':' + quantity + ':' + price;
            File.WriteAllLines(path, product); // вписка данных
        }

        public void DeleteIntermediateProduct(string id)  // Удаление лекарства
        {

            string t_id;
            string t_name;
            string t_quantity;
            string t_price;

            List<string> temp = GetIntermediateProduct();
            File.Create(path).Close();

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Split(":")[0] != id)
                {
                    t_id = temp[i].Split(":")[0];
                    t_name = temp[i].Split(":")[1];
                    t_quantity = temp[i].Split(":")[2];
                    t_price = temp[i].Split(":")[3];
                    CreateNewIntermediateProduct(t_id, t_name, t_quantity, t_price); 
                }
            }
        }

        public void IntermediateProductClear() // очищает текстовый файл
        {
            File.Create(path).Close();
        }
    }
}
