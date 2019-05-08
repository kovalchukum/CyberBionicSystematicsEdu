using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task._02
{
    //Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
    //количество дней в соответствующем месяце.Реализуйте возможность выбора месяцев, как по
    //порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
    //только один месяц.

    class Program
    {
        static void Main(string[] args)
        {
            var calendar = new CustomCalendar();

            Console.WriteLine("Введите количество дней в месяце: ");
            var days = Console.ReadLine();
            Console.WriteLine(calendar.GetMonthByDays(Convert.ToInt32(days)));
            Console.WriteLine();

            Console.WriteLine("Введите количество номер месяца: ");
            var monthNum = Console.ReadLine();
            Console.WriteLine(calendar.GetMonthByNum(Convert.ToInt32(monthNum)));

            Console.ReadKey();
        }
    }
}
