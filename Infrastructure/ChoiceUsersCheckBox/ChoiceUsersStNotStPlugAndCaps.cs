namespace StudCalculator.Infrastructure.ChoiceUsersCheckBox
{
    internal class ChoiceUsersStNotStPlugAndCaps
    {
        internal static bool ChoiceUsersStPulgAndCaps { get; set; }
        internal static bool ChoiceUsersNotStPlagAndCaps { get; set; }
        internal static  bool NonStandartPlugsCheckboxIsEnabled { get; set; }
        internal static bool StandartPlugsComboboxIsEnabled { get; set; }
        internal static bool StandartPlugsExecutionComboboxIsEnabled { get; set; }
        internal static bool NonStandartPlugsTextboxIsEnabled { get; set; }
        internal static bool StandartPlugsCheckboxIsEnabled { get; set; }

        internal virtual void ChoicesUsersStPulgAndCaps()
        {
            switch (ChoiceUsersStPulgAndCaps)
            {
                case true:
                {
                    NonStandartPlugsCheckboxIsEnabled = false;
                    StandartPlugsComboboxIsEnabled = true;
                    StandartPlugsExecutionComboboxIsEnabled = true;
                    break;
                }
                case false:
                {
                    NonStandartPlugsCheckboxIsEnabled = true;
                    StandartPlugsComboboxIsEnabled = false;
                    StandartPlugsExecutionComboboxIsEnabled = false;
                    break;
                }
            }
        }
    }
}
