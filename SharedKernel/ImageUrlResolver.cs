namespace SharedKernel
{
    public static class EventImageUrlResolver
    {
        public static string Resolve(string key , bool isSmall = false) =>
            isSmall ? 
                $"{Constants.Constants.StaticFilesBase}/images/sm_{key}.png" : 
                $"{Constants.Constants.StaticFilesBase}/images/{key}.png";
    }
}