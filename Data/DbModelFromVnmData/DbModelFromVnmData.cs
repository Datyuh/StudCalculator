using System.Data.Entity;

namespace StudCalculator.Data.DbModelFromVnmData
{
    public class DbModelFromVnmData : DbContext
    {
        public DbModelFromVnmData()
            : base("name=DbModelFromVnmData")
        {
        }

        public virtual DbSet<OGK_StudCalculator_ATK_24_200_02_90> OGK_StudCalculator_ATK_24_200_02_90 { get; set; }
        public virtual DbSet<OGK_StudCalculator_ATK_26_18_13_96> OGK_StudCalculator_ATK_26_18_13_96 { get; set; }
        public virtual DbSet<OGK_StudCalculator_ATK_26_18_5_93> OGK_StudCalculator_ATK_26_18_5_93 { get; set; }
        public virtual DbSet<OGK_StudCalculator_Execution_All> OGK_StudCalculator_Execution_All { get; set; }
        public virtual DbSet<OGK_StudCalculator_GOST_28759_3_90> OGK_StudCalculator_GOST_28759_3_90 { get; set; }
        public virtual DbSet<OGK_StudCalculator_GOST_28759_4_90> OGK_StudCalculator_GOST_28759_4_90 { get; set; }
        public virtual DbSet<OGK_StudCalculator_GOSTs> OGK_StudCalculator_GOSTs { get; set; }
        public virtual DbSet<OGK_StudCalculator_Octagonal_Gasket> OGK_StudCalculator_Octagonal_Gasket { get; set; }
        public virtual DbSet<OGK_StudCalculator_OST_26_2041_96> OGK_StudCalculator_OST_26_2041_96 { get; set; }
        public virtual DbSet<OGK_StudCalculator_OST26_2008_83> OGK_StudCalculator_OST26_2008_83 { get; set; }
        public virtual DbSet<OGK_StudCalculator_OST26_2042_96> OGK_StudCalculator_OST26_2042_96 { get; set; }
        public virtual DbSet<OGK_StudCalculator_Oval_Gasket> OGK_StudCalculator_Oval_Gasket { get; set; }
        public virtual DbSet<OGK_StudCalculator_Type_11> OGK_StudCalculator_Type_11 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
