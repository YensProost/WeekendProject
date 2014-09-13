using System;
using System.Collections.Generic;

namespace WeekendProjectje.Tests
{
    public static class Factory<T>
    {

        public static T MaakAan(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}