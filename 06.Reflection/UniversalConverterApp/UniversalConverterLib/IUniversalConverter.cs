using System;

namespace UniversalConverterLib
{
    public interface IUniversalConverter
    {
        object Convert(object value);
        Type GetInValueType(object inValue);
        Type GetOutValueType(object outValue);
    }
}
