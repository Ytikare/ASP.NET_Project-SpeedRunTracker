namespace SpeedRunTracker.Common
{
    public static class EntityValidataions
    {
        public static class GameValidations
        {
            public const int TitleMaxLenght = 50;
            public const int TitleMinLength = 2;

            public const int ImgUrlMaxLength = 2000;
        }

        public static class SpeedRunValidations
        {
            public const int MaxSpeedRunVideoUrlLenght = 200;

            public const int MaxDisqualificationReasonLenght = 2000;
            public const int MinDisqualificationReasonLenght = 10;
        }

        public static class CategoryValidations
        {
            public const int MaxNameLenght = 20;
        }

        public static class GenreValidations
        {
            public const int MaxTypeLenght = 25;
        }

        public static class UserValidations
        {
            public const int MinUsernameLenght = 3;
            public const int MaxUsernameLenght = 40;
        }
    }
}
