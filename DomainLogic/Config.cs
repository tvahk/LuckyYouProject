namespace DomainLogic
{
    public static class Config
    {
        public static int DefaultConnectionMinuteRate { get { return 50; } }
        public static int DefaultConnectionWeekRate { get { return 10000; } }
        public static string AdminUsername { get { return "luckyyou";  } }
        public static string AdminPassword { get { return "admin";  } }
    }
}
