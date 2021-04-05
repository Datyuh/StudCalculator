using System.Collections.ObjectModel;
using StudCalculator.Data.DBWork;
using StudCalculator.Infrastructure.ChoiceUsersCheckBox;

namespace StudCalculator.Infrastructure.EnterUsersData
{
    internal class EnterUsersPlugAndCaps
    {
        internal static double? PlugAndCapsNonSt { get; set; }
        internal static string PlugAndCapsStAtkOrOst { get; set; }
        internal static string PlugAndCapsStExecution { get; set; }
        internal static double? SumFlangeTextRead { get; set; }

        public virtual ObservableCollection<string> ExecutePlugsCollections()
        {
            switch (PlugAndCapsStAtkOrOst)
            {
                case "АТК 24.200.02-90":
                {
                    var executePlugsCollection = new DbCapsAtk242000290().ExecuteAtk24_200_02_90();
                    return executePlugsCollection;
                }
                case "OCT 26-2008-83":
                {
                    var executePlugsCollection = new DbCapsOST26_2008_83().ExecuteOst26_2008_83();
                    return executePlugsCollection;
                }
            }
            return new();
        }

        public virtual ObservableCollection<string> AllCapsCollection()
        {
            if (ChoiceUsersStNotStPlugAndCaps.ChoiceUsersStPulgAndCaps is true)
            {
                return new DbCapsAtk242000290().DbCapsCollection();
            }

            return new();
        }
    }
}
