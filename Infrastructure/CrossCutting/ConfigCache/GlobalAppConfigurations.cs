namespace CrossCutting.ConfigCache
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Caching;
    using System.Text;

    public interface IGlobalAppConfigurations
    {
        void AddKeysAndValues(Dictionary<string, object> keyValuePairs);

        object GetValue(string key);

        Dictionary<string, object> GetAllValues();
    }

    public abstract class CachingProviderBase
    {
        private static readonly MemoryCache ApplicationConfiguration = new MemoryCache("ApplicationConfiguration");

        private static readonly object Padlock = new object();

        public CachingProviderBase()
        {
        }

        protected virtual void AddKeysAndValues(Dictionary<string, object> keyValuePairs)
        {
            foreach (var item in keyValuePairs)
            {
                lock (Padlock)
                {
                    ApplicationConfiguration.Add(item.Key, item.Value, DateTimeOffset.MaxValue);
                }
            }
        }

        protected virtual object GetValue(string key)
        {
            lock (Padlock)
            {
                return ApplicationConfiguration[key];
            }
        }

        protected virtual Dictionary<string, object> GetAllValues()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            foreach (var item in ApplicationConfiguration)
            {
                keyValuePairs.Add(item.Key, item.Value);
            }

            return keyValuePairs;
        }
    }

    public class GlobalAppConfigurations : CachingProviderBase, IGlobalAppConfigurations
    {
        #region Singleton

        protected GlobalAppConfigurations()
        {
        }

        public static GlobalAppConfigurations Instance
        {
            get
            {
                return Nested.Instance;
            }
        }

        public virtual new void AddKeysAndValues(Dictionary<string, object> keyValuePairs)
        {
            base.AddKeysAndValues(keyValuePairs);
        }

        public virtual new Dictionary<string, object> GetAllValues()
        {
            return base.GetAllValues();
        }

        public virtual new object GetValue(string key)
        {
            return base.GetValue(key);
        }

        private class Nested
        {
            internal static readonly GlobalAppConfigurations Instance = new GlobalAppConfigurations();

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
        }

        #endregion Singleton
    }
}