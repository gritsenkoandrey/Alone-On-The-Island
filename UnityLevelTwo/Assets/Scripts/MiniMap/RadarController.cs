using UnityEngine;


public sealed class RadarController : BaseController, IInitialization, IExecute
{
    //todo добавить, чтобы разные состояния ботов отображались разным цветом
    #region Fields

    private Radar _radar;

    #endregion


    #region Methods

    public void Initialization()
    {
        _radar = Object.FindObjectOfType<Radar>();
    }

    public void Execute()
    {
        Draw();
    }

    private void Draw()
    {
        if (Time.frameCount % 2 == 0)
        {
            _radar.DrawRadarDots();
        }
    }

    #endregion
}