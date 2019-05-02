namespace CrossCutting.ConfigCache
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Caching;
    using System.Text;

    public interface IGlobalConfigurationInMemoryCache
    {
        void AddKeysAndValues(Dictionary<string, object> keyValuePairs);

        object GetValue(string key);
    }

    public class ConfigurationModel
    {
        public string Key { get; set; }

        public object Value { get; set; }
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
                string res = ApplicationConfiguration[key].ToString();

                return res;
            }
        }
    }

    public class GlobalConfigurationInMemoryCache : CachingProviderBase, IGlobalConfigurationInMemoryCache
    {
        #region Singleton

        protected GlobalConfigurationInMemoryCache()
        {
        }

        public static GlobalConfigurationInMemoryCache Instance
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

        public virtual new object GetValue(string key)
        {
            return base.GetValue(key);
        }

        private class Nested
        {
            internal static readonly GlobalConfigurationInMemoryCache Instance = new GlobalConfigurationInMemoryCache();

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
        }

        #endregion Singleton
    }
}