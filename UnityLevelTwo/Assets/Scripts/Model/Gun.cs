public sealed class Gun : Weapon
{
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
        var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
        temAmmunition.AddForce(_barrel.forward * _force);
        Clip.CountAmmunition--;
        _isReady = false;
        _timeRemaining.AddTimeRemaining();
    }

    #endregion
}