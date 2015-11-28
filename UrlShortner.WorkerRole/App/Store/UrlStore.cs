using System;
using System.Collections.Concurrent;

namespace UrlShortner.WorkerRole.App.Store
{
    public class UrlStore
    {
        private static volatile UrlStore _instance;
        private static readonly Object SyncRoot = new Object();

        private UrlStore()
        {
            this.Dictionary = new ConcurrentDictionary<string, string>();            
        }

        public static UrlStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new UrlStore();
                        }
                    }
                }

                return _instance;
            }
        }

        public ConcurrentDictionary<string, string> Dictionary
        {
            get;
            private set;
        }
    }
}
