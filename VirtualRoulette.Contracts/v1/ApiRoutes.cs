namespace VirtualRoulette.Contracts.v1;

public static class ApiRoutes
{
    public const string Root = "api";

    public const string Version = "v1";

    public const string Base = Root + "/" + Version;

    public static class User
    {
        public const string Root = Base + "/user";
        
        public const string Login = Root + "/login";

        public const string Bet = Root + "/bet";

        public const string Balance = Root + "/balance";

        public const string GameHistory = Root + "/game-history";
    }

    public static class Jackpot
    {
        public const string Root = Base + "/jackpot";
    }

}