using System;
using UnityEngine;


[Serializable]
public struct SerializableGameObject
{
    #region Fields

    public string Name;
    public SerializableVector3 Pos;
    public SerializableQuaternion Rot;
    public SerializableVector3 Scale;
    //todo иные компоненты для сохранения
    //public Component[] Components;
    public bool isEnable;

    #endregion


    #region Methods

    public override string ToString()
    {
        return $"Name = {Name}; isEnable = {isEnable}; Pos = ({Pos})";
    }

    #endregion
}

[Serializable]
public struct SerializableVector3
{
    #region Fields

    public float X;
    public float Y;
    public float Z;

    #endregion


    #region ClassLifeCycles

    public SerializableVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    #endregion


    #region Methods

    public static implicit operator Vector3(SerializableVector3 value)
    {
        return new Vector3(value.X, value.Y, value.Z);
    }

    public static implicit operator SerializableVector3(Vector3 value)
    {
        return new SerializableVector3(value.x, value.y, value.z);
    }

    public override string ToString()
    {
        return $"X = {X}, Y = {Y}, Z = {Z}";
    }

    #endregion
}

[Serializable]
public struct SerializableQuaternion
{
    #region Fields

    public float X;
    public float Y;
    public float Z;
    public float W;

    #endregion


    #region ClassLyfeCycles

    public SerializableQuaternion(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    #endregion


    #region Methods

    public static implicit operator Quaternion(SerializableQuaternion value)
    {
        return new Quaternion(value.X, value.Y, value.Z, value.W);
    }

    public static implicit operator SerializableQuaternion(Quaternion value)
    {
        return new SerializableQuaternion(value.x, value.y, value.z, value.w);
    }

    public override string ToString()
    {
        return $"X = {X}, Y = {Y}, Z = {Z}, W = {W}";
    }

    #endregion
}