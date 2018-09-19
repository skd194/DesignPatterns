using System;

namespace DesignPatterns
{
    public sealed class Singleton
    {
        private static Singleton _instance;

        private static readonly object Obj = new object();

        public static Singleton GetInstance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                lock (Obj)
                {
                    _instance = _instance ?? new Singleton();
                }
                return _instance;
            }
        }

        private Singleton()
        {

        }
    }

    public sealed class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> Instance =
            new Lazy<SingletonLazy>(() => new SingletonLazy());

        private static SingletonLazy GetInstance => Instance.Value;

        private SingletonLazy()
        {
        }
    }
}
