using UnityEngine;


public sealed class PlayerPrefData : IData<SerializableGameObject>
{
    #region Methods

    public SerializableGameObject Load(string path = null)
    {
        var result = new SerializableGameObject();

        var key = "Name";
        if (PlayerPrefs.HasKey(key))
        {
            result.Name = PlayerPrefs.GetString(key);
        }

        key = "PosX";
        if (PlayerPrefs.HasKey(key))
        {
            result.Pos.X = PlayerPrefs.GetFloat(key);
        }

        key = "PosY";
        if (PlayerPrefs.HasKey(key))
        {
            result.Pos.Y = PlayerPrefs.GetFloat(key);
        }

        key = "PosZ";
        if (PlayerPrefs.HasKey(key))
        {
            result.Pos.Z = PlayerPrefs.GetFloat(key);
        }

        key = "IsEnable";
        if (PlayerPrefs.HasKey(key))
        {
            result.isEnable = PlayerPrefs.GetString(key).TryBool();
        }

        return result;
    }

    public void Save(SerializableGameObject data, string path = null)
    {
        PlayerPrefs.SetString("Name", data.Name);
        PlayerPrefs.SetFloat("PosX", data.Pos.X);
        PlayerPrefs.SetFloat("PosY", data.Pos.Y);
        PlayerPrefs.SetFloat("PosZ", data.Pos.Z);
        PlayerPrefs.SetString("IsEnable", data.isEnable.ToString());

        PlayerPrefs.Save();
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey("IsEnable");
        PlayerPrefs.DeleteAll();
    }

    #endregion
}