using System.IO;


public sealed class StreamData : IData<SerializableGameObject>
{
    #region Methods

    public SerializableGameObject Load(string path = null)
    {
        var result = new SerializableGameObject();

        using (var sr = new StreamReader(path))
        {
            while (!sr.EndOfStream)
            {
                result.Name = sr.ReadLine();
                result.Pos.X = sr.ReadLine().TrySingle();
                result.Pos.Y = sr.ReadLine().TrySingle();
                result.Pos.Z = sr.ReadLine().TrySingle();
                result.isEnable = sr.ReadLine().TryBool();
            }
        }

        return result;
    }

    public void Save(SerializableGameObject data, string path = null)
    {
        if (path == null)
        {
            return;
        }

        using (var sw = new StreamWriter(path))
        {
            sw.WriteLine(data.Name);
            sw.WriteLine(data.Pos.X);
            sw.WriteLine(data.Pos.Y);
            sw.WriteLine(data.Pos.Z);
            sw.WriteLine(data.isEnable);
        }
    }

    #endregion
}