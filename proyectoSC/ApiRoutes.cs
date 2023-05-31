namespace proyectoSC
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Base = Root;

        public static class User
        {
            public const string Login = "login";
            public const string Recover = "recover";
            public const string Change = "change";  
        }
        public static class Files
        {
            public const string Parroquia = "parroquia";
            public const string Provincia = "provincia";
        }
    }
}
