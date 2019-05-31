using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalConverterLib
{
    public class CelsiusToFahrenheitConverter : IUniversalConverter
    {
        private const 
//        (Фаренгейт — 32) : 1,8 = Цельсий Пример: (50°F - 32) : 1,8 = 10°C
//         Цельсий х 1,8 + 32 = Фаренгейт Пример: 10°C x 1,8 + 32 = 50°F
        public object Convert(object value)
        {

            return null;
        }

        public Type GetInValueType(object inValue)
        {

            return this.GetType();
        }

        public Type GetOutValueType(object outValue)
        {

            return this.GetType();
        }

    }
}
