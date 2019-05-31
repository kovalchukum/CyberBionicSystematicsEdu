using System;
using System.Threading;

//    Написать класс "ThreadWithResult<TReturn>", который будет иметь методы/свойства:
//
//    - IsCompleted // Операция завершена или нет
//    - Success // Операция завершена успешно или нет
//    - Result // Результат операции
//    - Start() // Запуск операции
//
//    - Операцию для выполнения передавать в конструктор с помощью делегата
//    - Класс должен быть generic.Generic-параметр указывает тип результата операции.
//    - Result - должен выдавать результат операции или исключение если оно произошло внутри переданной операции
//    или если операция еще не запускалась
//
//
//
//    - Добавить возможность создания экземпляров с помощью записи: 
//    "var thread = ThreadWithResult.Create(()=>10)" (пример),
//    с автоматическим определением типа возвращаемого значения, с помощью переданного делегата.

namespace ThreadResult
{
    public class ThreadWithResult<TReturn>
    {
        private readonly Func<TReturn> _function;

        public TReturn Result;
        public bool Success { get; }
        public bool IsCompleated { get; } = false;

        private void InternalFunc()
        {
            void GetResult() => Result = _function();
            GetResult();
        }

        public void Start()
        {
            var customThread = new Thread(InternalFunc);
            customThread.Start();
        }

        public ThreadWithResult(Func<TReturn> function)
        {
            this._function = function;
        }
    }

    class Program
    {
        public static string someFunc()
        {
            Thread.Sleep(800);
            return "sadsadas";
        }

        static void Main(string[] args)
        {
            var resultThead = new ThreadWithResult<string>(someFunc);
            resultThead.Start();

            Thread.Sleep(500);
            Console.WriteLine(resultThead.Result);


            Console.ReadKey();
        }
    }
}
