using System;
using Newtonsoft.Json;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace MyElectricCar.Commons
{
    /// <summary>
    /// Helper that sets and gets from localstorage.
    /// </summary>
    public class LocalStorageHelper
    {
        private static readonly IPropertySet Settings = ApplicationData.Current.LocalSettings.Values;

        /// <summary>
        /// Adds the key value pair to the LocalSettings.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public static void Set(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            if (Settings.ContainsKey(key))
            {
                Settings[key] = JsonConvert.SerializeObject(value);
            }
            else
            {
                Settings.Add(key, JsonConvert.SerializeObject(value));
            }
        }

        /// <summary>
        /// Gets object from local storage, if that object does not exist,
        /// returns the default value for the type.
        /// </summary>
        /// <typeparam name="T">Expected type of object</typeparam>
        /// <param name="key">Local storage key</param>
        /// <returns>object</returns>
        /// <exception cref="System.ArgumentExecption"/>
        public static T GetOrDefault<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty.");
            }

            if (Settings.ContainsKey(key))
            {
                var obj = Settings[key];
                return JsonConvert.DeserializeObject<T>((string)obj);
            }

            return default(T);
        }

        /// <summary>
        /// Attempts to get the object associated with the key in IslocatedLocalStorage.
        /// The returned object must be castable to type T, otherwise this method will
        /// return false and obj will be set to the default value for the type T.
        /// </summary>
        /// <typeparam name="T">Expected value type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="obj">Stored Value or default</param>
        /// <returns>Whether or not the object was retrieved</returns>
        public static bool TryGet<T>(string key, out T obj)
        {
            string serializedSetting;
            if (TryGet(key, out serializedSetting))
            {
                try
                {
                    obj = JsonConvert.DeserializeObject<T>(serializedSetting);
                    return true;
                }
                catch (JsonException)
                {
                    obj = default(T);
                    return false;
                }
            }

            obj = default(T);
            return false;
        }

        /// <summary>
        /// Deletes the key value pair with key.
        /// </summary>
        /// <param name="key">key</param>
        /// <exception cref="ArgumentException">Throws exception when key could not be found</exception>
        public static void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            if (Settings.ContainsKey(key))
            {
                Settings.Remove(key);
            }
            else
            {
                throw new ArgumentException("Key could not be found");
            }
        }


        /// <summary>
        /// Attempts to get the object associated with the key in LocalSettings
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="obj">Stored Value</param>
        /// <returns>Whether or not the object was retrieved</returns>
        private static bool TryGet(string key, out string obj)
        {
            if (string.IsNullOrEmpty(key))
            {
                obj = null;
                return false;
            }

            if (Settings.ContainsKey(key))
            {
                obj = (string)Settings[key];
                return true;
            }
            obj = null;
            return false;
        }
    }
}
