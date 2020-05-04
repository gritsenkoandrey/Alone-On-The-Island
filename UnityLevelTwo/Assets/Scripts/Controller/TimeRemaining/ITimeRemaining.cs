using System;


#region Interface ITimeRemaining

public interface ITimeRemaining
{
    // метод вызываемый при отсчете времени
    Action Method { get; }
    bool IsRepeating { get; }
    float Time { get; }
    float CurrentTime { get; set; }
}

#endregion