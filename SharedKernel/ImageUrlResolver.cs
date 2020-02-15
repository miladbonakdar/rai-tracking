namespace SharedKernel
{
    public static class EventImageUrlResolver
    {
        public static string Resolve(string key , bool isSmall = false)
        {
            if (isSmall)
                return $"{Constants.Constants.StaticFilesBase}/images/sm_{key}.png";
            return 
        }
    }
}