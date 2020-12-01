﻿using UnityEngine;

public sealed class Gun : Weapon
{
    //public Transform _hole;
    #region Methods

    public override void Fire()
    {
        // если можем стрелять, то стреляем
        if (!_isReady)
        {
            return;
        }

        // если у нас достаточно патронов то стреляем
        if (Clip.CountAmmunition <= 0)
        {
            return;
        }

        // todo pool object
        var temAmmunition = Instantiate(Ammunition, _barrelOne.position, _barrelOne.rotation);
        temAmmunition.AddForce(_barrelOne.forward * _force);
        FireAnimationOn();
        ShotSound();
        Instantiate(_particleSystem, _barrelOne.position, _barrelOne.rotation);

        //Ray ray = new Ray(_barrelOne.position, _barrelOne.forward);
        //if (Physics.Raycast(ray, out var hit, 100))
        //{
        //    Quaternion hitRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        //    Debug.DrawLine(_barrelOne.position, transform.forward, Color.red, 5);
        //    Instantiate(_particleSystem, _barrelOne.position, _barrelOne.rotation);
        //    //Instantiate(_hole, hit.point + (hit.normal * 0.01f), hitRotation);
        //}

        Clip.CountAmmunition--;
        _isReady = false;
        _timeRemaining.AddTimeRemaining();
        FireAnimationOff();
    }

    #endregion
}