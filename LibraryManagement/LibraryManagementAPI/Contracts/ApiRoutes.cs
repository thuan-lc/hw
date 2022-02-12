namespace LibraryManagementAPI.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Base = Root + "/v{version:apiVersion}";

        public const string V1 = "1";
        public const string V2 = "2";
        public static class Identity
        {
            public const string ControllerRoute = Base + "/identity";
            public const string Login = ControllerRoute + "/login";
            public const string Refresh = ControllerRoute + "/refresh";
            public const string Register = ControllerRoute + "/register";
        }

        public static class Books
        {
            public const string ControllerRoute = Base + "/books";
            public const string GetAll = ControllerRoute;
            public const string GetById = ControllerRoute + "/{bookId}";
            public const string Create = ControllerRoute;
            public const string Update = ControllerRoute + "/{bookId}";
            public const string Delete = ControllerRoute + "/{bookId}";
        }

        public static class Orders
        {
            public const string ControllerRoute = Base + "/orders";
            public const string GetAll = ControllerRoute;
            public const string GetByUser = ControllerRoute + "/{userId}";
            public const string Create = ControllerRoute;
            public const string Update = ControllerRoute;
            public const string Delete = ControllerRoute + "/{TransId}";
        }

        public static class Test
        {
            public const string ControllerRoute = Base + "/test";
            public const string TestGet = ControllerRoute + "/get";
            public const string TestPost = ControllerRoute + "/post";
        }
    }
}
