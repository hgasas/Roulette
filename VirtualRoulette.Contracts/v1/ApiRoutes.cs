namespace VirtualRoulette.Contracts.v1;

public static class ApiRoutes
{
    public const string Root = "api";
    
    public const string Version = "v1";
    
    public const string Base = Root + "/" + Version;

    public static class User
    {
        public const string Login = Base + "/login";
        
        public const string Bet = Base + "/bet";
        
        public const string Balance = Base + "/balance";
    }
}