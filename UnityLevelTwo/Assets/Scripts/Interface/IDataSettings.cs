#region Interface IData
public interface IDataSettings<T>
{
    void Save(T value);
    T Load();
    void SetOptions(string path);
}

#endregion