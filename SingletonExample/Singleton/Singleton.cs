using System;
using System.Threading;

namespace SingletonExample
{
    public sealed class Singleton
    {
        private static Singleton _instance;
        private static readonly object _lock = new object();
        private int _requestCount;

        private Singleton() => _requestCount = 0;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }

        public void IncrementRequestCount() => Interlocked.Increment(ref _requestCount);

        public int GetRequestCount() => _requestCount;
    }
}