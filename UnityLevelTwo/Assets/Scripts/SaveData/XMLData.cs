using System.Xml;
using UnityEngine;
using File = System.IO.File;


public sealed class XMLData : IData<SerializableGameObject>
{
    #region Methods

    public void Save(SerializableGameObject data, string path = "")
    {
        var xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("Player");
        xmlDoc.AppendChild(rootNode);

        var element = xmlDoc.CreateElement(Crypto.CryptoXOR("Name"));
        element.SetAttribute("value", Crypto.CryptoXOR(data.Name));
        rootNode.AppendChild(element);

        element = xmlDoc.CreateElement("PosX");
        element.SetAttribute("value", data.Pos.X.ToString());
        rootNode.AppendChild(element);

        element = xmlDoc.CreateElement("PosY");
        element.SetAttribute("value", data.Pos.Y.ToString());
        rootNode.AppendChild(element);

        element = xmlDoc.CreateElement("PosZ");
        element.SetAttribute("value", data.Pos.Z.ToString());
        rootNode.AppendChild(element);

        element = xmlDoc.CreateElement("IsEnable");
        element.SetAttribute("value", data.isEnable.ToString());
        rootNode.AppendChild(element);

        XmlNode userNode = xmlDoc.CreateElement("Info");
        var attribute = xmlDoc.CreateAttribute("Unity");
        attribute.Value = Application.unityVersion;
        userNode.Attributes.Append(attribute);
        userNode.InnerText = $"System Language: {Application.systemLanguage}";
        rootNode.AppendChild(userNode);

        xmlDoc.Save(path);
    }

    public SerializableGameObject Load(string path = "")
    {
        var result = new SerializableGameObject();
        if (!File.Exists(path))
        {
            return result;
        }

        using (var reader = new XmlTextReader(path))
        {
            while (reader.Read())
            {
                var key = Crypto.CryptoXOR("Name");
                if (reader.IsStartElement(key))
                {
                    result.Name = Crypto.CryptoXOR(reader.GetAttribute("value"));
                }

                key = "PosX";
                if (reader.IsStartElement(key))
                {
                    result.Pos.X = reader.GetAttribute("value").TrySingle();
                }

                key = "PosY";
                if (reader.IsStartElement(key))
                {
                    result.Pos.Y = reader.GetAttribute("value").TrySingle();
                }

                key = "PosZ";
                if (reader.IsStartElement(key))
                {
                    result.Pos.Z = reader.GetAttribute("value").TrySingle();
                }

                key = "IsEnable";
                if (reader.IsStartElement(key))
                {
                    result.isEnable = reader.GetAttribute("value").TryBool();
                }
            }
        }

        return result;
    }

    #endregion
}