namespace NovaHarvest.Core.Systems;

public enum TimeOfDay
{
    Day,
    Night
}

public sealed class WorldTime
{
    public int Day { get; private set; } = 1;

    public int Hour { get; private set; } = 8;

    public int Minute { get; private set; } = 0;

    public TimeOfDay CurrentPeriod =>
        IsNight()
            ? TimeOfDay.Night
            : TimeOfDay.Day;

    public event Action? DayStarted;

    public event Action? NightStarted;

    public event Action? NewDay;

    public bool IsNight()
    {
        if (Hour >= 19 && Minute >= 30)
            return true;

        if (Hour < 4)
            return true;

        if (Hour == 4 && Minute < 30)
            return true;

        return false;
    }

    public void AdvanceMinutes(int minutes)
    {
        if (minutes < 0)
            throw new ArgumentOutOfRangeException(
                nameof(minutes));

        for (var i = 0; i < minutes; i++)
        {
            var previousPeriod =
                CurrentPeriod;

            Minute++;

            if (Minute >= 60)
            {
                Minute = 0;
                Hour++;
            }

            if (Hour >= 24)
            {
                Hour = 0;
            }

            var currentPeriod =
                CurrentPeriod;

            if (previousPeriod != currentPeriod)
            {
                if (currentPeriod == TimeOfDay.Night)
                {
                    NightStarted?.Invoke();
                }
                else
                {
                    DayStarted?.Invoke();
                }
            }

            CheckNewDay();
        }
    }

    private void CheckNewDay()
    {
        if (Hour != 4 || Minute != 30)
            return;

        Day++;

        NewDay?.Invoke();
        DayStarted?.Invoke();
    }

    public void StartNextDay()
    {
        Day++;

        Hour = 4;
        Minute = 30;

        NewDay?.Invoke();
        DayStarted?.Invoke();
    }

    public string GetFormattedTime()
    {
        return $"{Hour:00}:{Minute:00}";
    }
}   