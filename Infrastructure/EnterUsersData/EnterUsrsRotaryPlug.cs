using System.Collections.ObjectModel;
using StudCalculator.Data.DBWork;
using StudCalculator.Infrastructure.ChoiceUsersCheckBox;

namespace StudCalculator.Infrastructure.EnterUsersData
{
    internal class EnterUsrsRotaryPlug
    {
        public static double? RotaryPlugNonSt { get; set; }
        public static string RotaryPlugSt { get; set; }

        protected internal virtual ObservableCollection<string> RotaryPlugsStFromBase()
        {
            if (ChoiceUsersStOrNotStRotPlug.ChoiceUsersStRotPlug is true)
            {
                var rotaryPlugsStFromBase = new DbRotarPylugATK_26_18_5_93().ExecuteAtk_26_18_5_93();
                return rotaryPlugsStFromBase;
            }
            return new();
        }
    }
}
