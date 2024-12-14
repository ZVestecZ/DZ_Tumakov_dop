using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Tumakov_dop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Window> windows = new List<Window>
         {
            new Window(1),
            new Window(2),
            new Window(3)
         };

            // Создание Зины
            Zina zina = new Zina(windows);

            // Создание жителей
            List<Resident> residents = new List<Resident>
        {
            new Resident("a", "123456", new Problem(1, "Нет отопления"), 8, true),
            new Resident("b", "789012", new Problem(2, "Проблема с оплатой за отопление"), 2, true),
            new Resident("c", "345678", new Problem(3, "Неработает лифт"), 6, false),
            new Resident("d", "901234", new Problem(4, "Протекает крыша"), 3, true),
            new Resident("e", "567890", new Problem(5, "Проблема с отоплением"), 1, true),
            new Resident("f", "123987", new Problem(6, "Счет за отопление неверный"), 9, false),
            new Resident("g", "927344", new Problem(4, "Протекает крыша"), 3, true)
        };

            //Зина ставит жителей в очередь
            foreach (var resident in residents)
            {
                zina.AddResidentToQueue(resident);
            }

            // Зина распределяет жителей по окнам
            zina.ProcessWaitingQueue();


            // Вывод информации об очередях
            foreach (var window in windows)
            {
                Console.WriteLine($"\nОчередь в окно {window.WindowNumber}:");
                foreach (var resident in window.Queue)
                {
                    Console.WriteLine($"{resident.Name}, Проблема: {resident.Problem.Description}");
                }
            }
            Console.ReadKey();
        }
    }
}
