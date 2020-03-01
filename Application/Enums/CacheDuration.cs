namespace Application.Enums
{
    public enum CacheDuration
    {
        FromMin5 = 5 * 60,
        FromMin10 = 10 * 60,
        FromMin15 = 15 * 60,
        FromMin20 = 20 * 60,
        FromMin30 = 30 * 60,
        FromHour1 = 60 * 60,
        FromHour2 = FromHour1 * 2,
        FromHour4 = FromHour1 * 4,
        FromHour8 = FromHour1 * 8,
        FromHour16 = FromHour1 * 16,
        FromDay1 = FromHour1 * 24,
        FromDay2 = FromDay1 * 2,
        FromDay4 = FromDay1 * 4,
        FromDay8 = FromDay1 * 8,
        FromDay16 = FromDay1 * 16,
        FromMonth1 = FromDay1 * 30,
        Eternal = 0,
    }
}