﻿using System;


public static class Extention
{
    #region Methods

    // метод расширения
    public static T[] Concat<T>(this T[] x, T[] y)
    {
        if (x == null)
            throw new ArgumentNullException("x");
        if (y == null)
            throw new ArgumentNullException("y");
        var oldLen = x.Length;
        Array.Resize(ref x, x.Length + y.Length);
        Array.Copy(y, 0, x, oldLen, y.Length);
        return x;
    }

    #endregion
}