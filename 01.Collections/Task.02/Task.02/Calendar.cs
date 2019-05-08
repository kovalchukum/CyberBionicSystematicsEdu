using System;
using System.Collections;
using System.Globalization;

namespace Task._02
{
    public class CustomCalendar : IEnumerable, IEnumerator
    {
        private readonly string[] _monthNames = DateTimeFormatInfo.CurrentInfo?.MonthNames;
        private readonly int[] _daysArr = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private int _id = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current => _monthNames[_id];

        public bool MoveNext()
        {
            if (_id >= _monthNames.Length - 1) return false;
            _id++;
            return true;
        }

        public void Reset()
        {
            _id = -1;
        }

        public string GetMonthByDays(int days)
        {
            var result = string.Empty;
            var i = 0;

            foreach (var mounth in _monthNames)
            {
                if (_daysArr[i] == days)
                    result += mounth + "\n";
                i++;

                if (i >= _daysArr.Length)
                    break;
            }
            return result;
        }

        public string GetMonthByNum(int monthNum)
        {
            var result = string.Empty;
            if (monthNum < 1 || monthNum > 12)
                result = "Не верный номер месяца";
            else
                result = _monthNames[monthNum];

            return result;
        }

    }
}
