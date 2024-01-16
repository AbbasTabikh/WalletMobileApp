using SQLite;

namespace EwalletMobileApp
{
    public static class Constants
    {
        private const string DBFileName = "EWalletApp.db3";
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
                                                SQLiteOpenFlags.Create |
                                                    SQLiteOpenFlags.Create;
        public static string DataBasePath => Path.Combine(FileSystem.AppDataDirectory, DBFileName);
    }
}
