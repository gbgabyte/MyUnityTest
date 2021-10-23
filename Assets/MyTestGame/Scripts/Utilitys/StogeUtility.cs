using Framework;
using UnityEngine;

namespace TestGame
{
    public interface IStogeUtility : IUtility
    {

    }

    public class StogeUtility : AbstractUtility, IStogeUtility
    {
        public void SaveValue(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public void SaveValue(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public int GetValue(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public bool GetValue(string key, bool defaultValue = false)
        {
            var value = PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);
            return value == 1;
        }
    }
}