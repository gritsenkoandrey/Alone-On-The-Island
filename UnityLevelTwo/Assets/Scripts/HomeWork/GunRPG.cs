public sealed class GunRPG : Weapon
{
    #region Methods

    public override void Fire()
    {
        if (!_isReady)
        {
            return;
        }
        if (Clip.CountAmmunition < 3)
        {
            return;
        }

        var temAmmunitionOne = Instantiate(AmmunitionRPG, _barrelOne.position, _barrelOne.rotation);
        temAmmunitionOne.AddForce(_barrelOne.forward * _force);
        Clip.CountAmmunition--;

        var temAmmunitionTwo = Instantiate(AmmunitionRPG, _barrelTwo.position, _barrelTwo.rotation);
        temAmmunitionTwo.AddForce(_barrelTwo.forward * _force);
        Clip.CountAmmunition--;

        var temAmmunitionThree = Instantiate(AmmunitionRPG, _barrelThree.position, _barrelThree.rotation);
        temAmmunitionThree.AddForce(_barrelThree.forward * _force);
        Clip.CountAmmunition--;

        FireAnimationOn();
        _isReady = false;
        _timeRemaining.AddTimeRemaining();
        FireAnimationOff();
    }

    #endregion
}