using UnityEngine;

public class PlayerPrefsSessionLoader : ISessionDataLoader
{
    private static string KeyLastInput = "user.lastInput";

    public SessionData LoadData()
    {
        string savedValue = PlayerPrefs.GetString(KeyLastInput);
        SessionData loadedData = new SessionData(savedValue);
        return loadedData;
    }

    public void SaveData(SessionData data)
    {
        PlayerPrefs.SetString(KeyLastInput, data.LastInputValue);
    }
}
