namespace StudCalculator
{
    using System.ComponentModel.DataAnnotations;

    public class GOSTs
    {
        public int id { get; set; }

        [StringLength(50)]
        public string GOST { get; set; }

        [StringLength(50)]
        public string Exec_GOST33259 { get; set; }

        [StringLength(50)]
        public string Exec_GOST28759_3 { get; set; }

        [StringLength(50)]
        public string Exec_GOST28759_4 { get; set; }

        [StringLength(50)]
        public string Exec_ATK_26_18_13_96_Caps { get; set; }

        [StringLength(50)]
        public string Exec_ATK_26_18_13_96 { get; set; }

        [StringLength(50)]
        public string Nuts { get; set; }

        [StringLength(50)]
        public string Style { get; set; }

        [StringLength(50)]
        public string Caps { get; set; }

        [StringLength(50)]
        public string Material_Stud { get; set; }

        [StringLength(50)]
        public string Style_Stud { get; set; }

        [StringLength(50)]
        public string Material_Stud_ASME { get; set; }

        [StringLength(50)]
        public string Style_Stud_ASME { get; set; }
    }
}
