using System.Collections.ObjectModel;
using StudCalculator.Data.DBWork;

namespace StudCalculator.Infrastructure.EnterUsersData
{
    public static class EnterUsersGostStandrt
    {
        private static readonly DbWorkGost33259 DbWorkGost33259 = new();
        private static readonly DbGost28759_3_90 DbGost28759390 = new();
        private static readonly DbGost28759_4_90 DbGost28759490 = new();
        private static readonly DbAtk26_18_13_96 DbAtk26181396 = new();
        public static string GostNamber { get; set; }
        public static string TapeGost33259 { get; set; }
        public static string Pn { get; set; }
        public static string ExecutionGost { get; set; }
        public static string Dn { get; set; }
        public static bool TypeFlangeIsEnabled { get; set; }
        public static ObservableCollection<string> ExecutionGostData { get; set; }
        public static ObservableCollection<string> ExecutionDnData { get; set; }
        public static ObservableCollection<string> ExecutionPnData { get; set; }

        public static void EnterUsersGostStandrts()
        {
            switch (GostNamber)
            {
                case "ГОСТ 33259-2015 Ряд 1":
                {
                    ExecutionGostData = DbWorkGost33259.ExecGost33259();
                    ExecutionDnData = DbWorkGost33259.ExecutionDn33259();
                    ExecutionPnData = DbWorkGost33259.ExecutionPn33259();
                    break;
                }
                case "ГОСТ 28759.3-90":
                {
                    ExecutionGostData = DbGost28759390.ExecuteExecutionsCollection();
                    ExecutionDnData = DbGost28759390.ExecuteDnCollection();
                    ExecutionPnData = DbGost28759390.ExecutePnCollection(); 
                    break;
                }
                case "ГОСТ 28759.4-90":
                {
                    ExecutionGostData = DbGost28759490.ExecuteExecutionsCollection();
                    ExecutionDnData = DbGost28759490.ExecuteDnCollection();
                    ExecutionPnData = DbGost28759490.ExecutePnCollection();
                    break;
                }
                case "АТК-26-18-13-96":
                {
                    ExecutionGostData = DbAtk26181396.ExecuteExecutionsCollection();
                    ExecutionDnData = DbAtk26181396.ExecuteDnCollection();
                    ExecutionPnData = DbAtk26181396.ExecutePnCollection();
                    break;
                }
            }
        }

        public static ObservableCollection<string> TapeGost()
        {
            if (GostNamber.Equals("ГОСТ 33259-2015 Ряд 1"))
            {
                return new DbWorkGost33259().ExecutionType33259();
            }
            return new();
        }

        public static bool TypeFlangesIsEnabled()
        {
            if (GostNamber.Equals("ГОСТ 33259-2015 Ряд 1"))
            {
                return true;
            }
            return false;
        }
    }
}
