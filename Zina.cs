using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Tumakov_dop
{
    internal class Zina
    {
        private Stack<Resident> _waitingQueue = new Stack<Resident>();
        private List<Window> _windows = new List<Window>();
        private Random _random = new Random();

        public Zina(List<Window> windows)
        {
            _windows = windows;
        }

        public void AddResidentToQueue(Resident resident)
        {
            _waitingQueue.Push(resident);
        }

        public void ProcessWaitingQueue()
        {
            while (_waitingQueue.Count > 0)
            {
                Resident currentResident = _waitingQueue.Pop();
                AssignResidentToWindow(currentResident);
            }
        }

        // Метод для определения окна
        private void AssignResidentToWindow(Resident resident)
        {
            int selectedWindowNumber;

            if (resident.TemperamentSmart == false)
            {
                selectedWindowNumber = _random.Next(1, _windows.Count + 1);
            }
            else
            {

                if (resident.Problem.Description.Contains("отопление") && resident.Problem.Description.Contains("подключение"))
                {
                    selectedWindowNumber = 1;
                }
                else if (resident.Problem.Description.Contains("оплата"))
                {
                    selectedWindowNumber = 2;
                }
                else
                {
                    selectedWindowNumber = 3;
                }
            }

            // Находим нужное окно (без лямбда)
            Window selectedWindow = null;
            foreach (var window in _windows)
            {
                if (window.WindowNumber == selectedWindowNumber)
                {
                    selectedWindow = window;
                    break; // Выходим из цикла, если нашли нужное окно
                }
            }


            if (selectedWindow == null)
            {
                Console.WriteLine("Неверный номер окна.");
                return;
            }

            // Обработка скандалистов
            if (resident.TemperamentScandalousness >= 5)
            {
                Console.WriteLine($"{resident.Name} (скандалист) обгоняет очередь.");
                Console.WriteLine("На сколько человек обогнать очередь?");
                if (int.TryParse(Console.ReadLine(), out int bypassCount))
                {
                    BypassQueue(selectedWindow, bypassCount, resident);
                }
                else
                {
                    selectedWindow.Queue.Enqueue(resident);
                }

            }
            else
            {
                selectedWindow.Queue.Enqueue(resident);
            }
            Console.WriteLine($"Житель '{resident.Name}' направлен в окно {selectedWindowNumber}.");
        }

        private void BypassQueue(Window window, int bypassCount, Resident currentResident)
        {
            Queue<Resident> tempQueue = new Queue<Resident>();
            int count = 0;


            // Извлекаем из очереди всех, кто впереди
            while (window.Queue.Count > 0 && count < bypassCount)
            {
                tempQueue.Enqueue(window.Queue.Dequeue());
                count++;
            }

            // Добавляем скандалиста
            window.Queue.Enqueue(currentResident);

            // Возвращаем тех кто впереди в очередь
            while (tempQueue.Count > 0)
            {
                window.Queue.Enqueue(tempQueue.Dequeue());
            }
        }
    }
}
