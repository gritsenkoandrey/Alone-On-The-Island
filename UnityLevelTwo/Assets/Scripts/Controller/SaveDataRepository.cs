using UnityEngine;
using System.IO;


// Pattern Repository
public sealed class SaveDataRepository
{
    #region Fields

    private readonly IData<SerializableGameObject> _data;

    private const string _folderName = "DataSave";
    private const string _fileName = "data.bat";
    //путь следования от папки "DataSave" к файлу "data.bat"
    private readonly string _path;

    #endregion


    #region ClassLyfeCycles

    public SaveDataRepository()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _data = new PlayerPrefData();
        }
        else
        {
            _data = new JsonData<SerializableGameObject>();
            //_data = new StreamData();
            //_data = new PlayerPrefData();
            //_data = new XMLData();
            //_data = new BinarySerializationData<SerializableGameObject>();
            //_data = new SerializableXMLData<SerializableGameObject>();
        }

        _path = Path.Combine(Application.dataPath, _folderName);
    }

    #endregion


    #region Methods

    public void Save()
    {
        //проверка пути сохранения
        if (!Directory.Exists(Path.Combine(_path)))
        {
            //если его нет, то создаем путь
            Directory.CreateDirectory(_path);
        }

        var player = new SerializableGameObject
        {
            Pos = ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform.position,
            Name = "Save Game",
            isEnable = true
        };
        _data.Save(player, Path.Combine(_path, _fileName));
    }

    public void Load()
    {
        var file = Path.Combine(_path, _fileName);
        if (!File.Exists(file))
        {
            return;
        }
        var newPlayer = _data.Load(file);
        ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform.position = newPlayer.Pos;
        ServiceLocatorMonoBehaviour.GetService<CharacterController>().name = newPlayer.Name;
        ServiceLocatorMonoBehaviour.GetService<CharacterController>().gameObject.SetActive(newPlayer.isEnable);

        Debug.Log(newPlayer);
    }
    #endregion
}