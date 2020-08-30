using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThower : Weapon, IEnd
{

    public override void Fire()
    {
        if (!_isReady)
        {
            return;
        }

        if (Clip.CountAmmunition <= 0)
        {
            return;
        }

        // todo звук огнемета
        //_audioSource.clip = AudioClip;
        //_audioSource.Play();
    }

    public void End(object obj, EventArgs args)
    {
        //_audioSource.Stop();


    }

}