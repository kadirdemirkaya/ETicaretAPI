namespace ETicaretAPI.persistence.Statics
{
    public static class StaticsProperties
    {
        public static string ProductImages = "ProductImages";
        public static string UserImages = "UserImages";

        public static class RoleNames
        {
            public static string User = "User";
            public static string Admin = "Admin";
            public static string Moderator = "Moderator";
            public static string CommunicationPerson = "CommunicationPerson";
        }

        public static class CurrnetUserName
        {
            public static Guid AppuserId;
        }
    }
}
