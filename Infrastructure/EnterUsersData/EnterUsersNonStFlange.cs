using StudCalculator.Infrastructure.ChoiceUsersCheckBox;

namespace StudCalculator.Infrastructure.EnterUsersData
{
    public static class EnterUsersNonStFlange
    {
        public static double? SimilarFlangeNonSt { get; set; }
        public static double? FirstFlangeNonSt { get; set; }
        public static double? SecondFlangeNonSt { get; set; }

        public static double? SimilarFlangesNonSt()
        {
            if (ChoiceUsersNotStFlang.ChoiceUsersSameNotStFlang is false)
            {
                return SimilarFlangeNonSt = null;
            }

            return SimilarFlangeNonSt;
        }

        public static double? DifferentFlangesNonSt()
        {
            if (ChoiceUsersNotStFlang.ChoiceUsersDiffNonStFlang is false)
                return FirstFlangeNonSt = SecondFlangeNonSt = null;
            return null;
        }
    }
}
