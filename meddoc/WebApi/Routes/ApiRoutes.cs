namespace WebApi.Routes
{
    public class ApiRoutes
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";

        public class UserProfiles
        {
            public const string IdRoute = "id";
        }

        public class Posts
        {
            public const string GetById = "{id}";
        }

        public class UserProfile
        {
            public const string GetUserProfileById = "{id}";
        }
    }
}
