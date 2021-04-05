namespace StudCalculator.Infrastructure.ChoiceUsersCheckBox
{
    public class ChoiceUsersNotStFlang
    {
        public static bool ChoiceUsersSameNotStFlang { get; set; }
        public static bool ChoiceUsersDiffNonStFlang { get; set; }
        public static bool NonStandartSameFlangeTexboxIsEnabled { get; set; }
        public static bool NonStandartSameFlangeCheckedIsEnabled { get; set; }
        public static bool NonStandartDifferentFlangeTexboxIsEnabled { get; set; }
        public static bool NonStandartDifferentFlangeCheckedIsEnabled { get; set; }

        public virtual void NonStSameFlanges()
        {
            switch (ChoiceUsersSameNotStFlang)
            {
                case true:
                {
                    NonStandartSameFlangeTexboxIsEnabled = true;
                    NonStandartSameFlangeCheckedIsEnabled = true;
                    NonStandartDifferentFlangeCheckedIsEnabled = false;
                    break;
                }
                case false:
                {
                    NonStandartSameFlangeTexboxIsEnabled = false;
                    NonStandartDifferentFlangeCheckedIsEnabled = true;
                    break;
                }
            }
        }

        public virtual void NonStDifferentFlanges()
        {
            switch (ChoiceUsersDiffNonStFlang)
            {
                case true:
                {
                    NonStandartDifferentFlangeTexboxIsEnabled = true;
                    NonStandartDifferentFlangeCheckedIsEnabled = true;
                    NonStandartSameFlangeCheckedIsEnabled = false;
                    break;
                }
                case false:
                {
                    NonStandartDifferentFlangeTexboxIsEnabled = false;
                    NonStandartSameFlangeCheckedIsEnabled = true;
                    break;
                }
            }
        }
    }
}
