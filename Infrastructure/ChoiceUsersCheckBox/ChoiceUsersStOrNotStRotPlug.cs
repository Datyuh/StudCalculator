namespace StudCalculator.Infrastructure.ChoiceUsersCheckBox
{
    internal class ChoiceUsersStOrNotStRotPlug
    {
        public static bool ChoiceUsersStRotPlug { get; set; }
        public static bool ChoiceUsersNotStRotPlug { get; set; }
        public static bool NonStandartRotaryPlugsCheckboxIsEnabled { get; set; }
        public static bool StandartRotaryPlugsCheckboxIsEnabled { get; set; }
        public static bool NonStandartRotaryPlugsTextboxIsEnabled { get; set; }
        public static bool StandartRotaryPlugsComboboxIsEnabled { get; set; }

        protected internal virtual void CheckedUsersChoiceChBoxStRot()
        {
            switch (ChoiceUsersStRotPlug)
            {
                case true:
                {
                    StandartRotaryPlugsCheckboxIsEnabled = true;
                    NonStandartRotaryPlugsCheckboxIsEnabled = false;
                    StandartRotaryPlugsComboboxIsEnabled = true;
                    break;
                }
                case false:
                {
                    StandartRotaryPlugsComboboxIsEnabled = false;
                    NonStandartRotaryPlugsCheckboxIsEnabled = true;
                    break;
                }
            }
        }

        protected internal virtual void CheckedUsersChoiceChBoxNotRot()
        {
            switch (ChoiceUsersNotStRotPlug)
            {
                case true:
                {
                    StandartRotaryPlugsCheckboxIsEnabled = false;
                    NonStandartRotaryPlugsTextboxIsEnabled = true;
                    break;
                }
                case false:
                {
                    StandartRotaryPlugsCheckboxIsEnabled = true;
                    NonStandartRotaryPlugsTextboxIsEnabled = false;
                    break;
                }
            }
        }
    }
}
