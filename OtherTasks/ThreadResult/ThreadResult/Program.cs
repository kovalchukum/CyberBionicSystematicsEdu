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
//    - Добавить возможность создания экземпляров с помощью записи: 
//    "var thread = ThreadWithResult.Create(()=>10)" (пример),
//    с автоматическим определением типа возвращаемого значения, с помощью переданного делегата.

namespace ThreadResult
{
    public class ThreadWithResult<TReturn>
    {
        private readonly Func<TReturn> _function;

        public TReturn Result { get; set; }

        public bool Success { get; set; } = false;

        public bool IsCompleated { get; set; } = false;

        private void InternalFunc()
        {
            void GetResult() => Result = _function();

            try
            {
                GetResult();
            }
            catch (Exception e)
            {
                IsCompleated = true;
                throw;
            }
            finally
            {
                Success = true;
                IsCompleated = true;
            }
        }

        public void Start()
        {
            IsCompleated = false;
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
        public static string SomeFunc()
        {
          //  throw new Exception("SomeFunc exception");
           // Thread.Sleep(800);
            return "sadsadas";
        }

        static void Main(string[] args)
        {
            var resultThead = new ThreadWithResult<string>(SomeFunc);
           // Console.WriteLine(resultThead.Result);

            resultThead.Start();

            Thread.Sleep(500);
            Console.WriteLine("Result: " + resultThead.Result);

            Console.WriteLine("End of work");
            Console.ReadKey();
        }
    }
}
