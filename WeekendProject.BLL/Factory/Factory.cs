using System;

namespace WeekendProject.BLL.Factory
{
    public static class Factory<T>
    {

        public static T MaakAan(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}