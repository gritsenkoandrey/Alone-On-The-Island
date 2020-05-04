using System.Collections.Generic;
using UnityEngine;


public sealed class TimeRemainingController : IExecute
{
    #region Fields

    // список отсчетчиков времени
    private readonly List<ITimeRemaining> _timeRemainings;

    #endregion


    #region ClassLifeCycless

    public TimeRemainingController()
    {
        _timeRemainings = TimeRemainingExtension.TimeRemainings;
    }

    #endregion


    #region Methods

    public void Execute()
    {
        var time = Time.deltaTime;
        // пробегаемся по всем отсчетчикам времени
        for (var i = 0; i < _timeRemainings.Count; i++)
        {
            // забираю один счетчик времени
            var obj = _timeRemainings[i];
            // отнимаю у него время
            obj.CurrentTime -= time;
            // 
            if (obj.CurrentTime <= 0.0f)
            {
                obj?.Method?.Invoke();
                // если нужно повторить
                if (!obj.IsRepeating)
                {
                    // удаление из списка обновляемых объектов
                    obj.RemoveTimeRemaining();
                }
                // назначаю новое время
                else
                {
                    obj.CurrentTime = obj.Time;
                }
            }
        }
    }

    #endregion
}