namespace eFlash
{
    public static class Constant
    {
        #region Network Constants

        public const string serverAddress = "mysql.cs169.kaulana.com";
        public const string serverLogin = ""; // redacted
        public const string serverPass = "";  // redacted
        public const string serverDB = "";    // redacted

        public static char[] delimiter = { ',', ' ' };
        #endregion


        #region GUI Constants

        public const int cardWidth = 600;
		public const int cardHeight = 400;

		public const int windowWidth = 700;
		public const int windowHeight = 555;

        public const string QuizInOrder = "inorder";
        public const string QuizRerversedOrder = "reversed";
        public const string QuizRandomOrder = "random";

        #endregion


        #region Local Constants

        //Add Local Constants here.......
        public const string localAddress = "localhost";
        public const string localPort = "3308"; // nonstandard, default is 3306
        public const string localSocket = "eflashmysql";
        public const string localLogin = "root";
        public const string localPass = "";
        public const string localDB = "eflash";
		public static string eFlashRoot = eFlash.Utilities.AppHelper.GetPresentWorkingDirectory();
        public static string ePath = eFlashRoot + "\\Data\\Media\\";

		public const string textDeck = textFile;
		public const string imageDeck = imageFile;
		public const string soundDeck = soundFile;
		public const string noQuizDeck = "noQuiz";

        public const string textFile = "text";
        public const string imageFile = "image";
        public const string soundFile = "sound";
        public const string textEXT = ".doc";
        public const string imageEXT = ".jpg";
        public const string soundEXT = ".mp3";

		public const string questionPrefix = "[q]";
		public const string answerPrefix = "[a]";
		public const string nonePrefix = "[n]";

        #endregion

    }
}
