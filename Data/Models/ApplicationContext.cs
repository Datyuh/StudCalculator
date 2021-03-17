namespace StudCalculator
{
    using System.Data.Entity;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
        }

        public virtual DbSet<ATK_24_200_02_90> ATK_24_200_02_90 { get; set; }
        public virtual DbSet<ATK_26_18_13_96> ATK_26_18_13_96 { get; set; }
        public virtual DbSet<ATK_26_18_5_93> ATK_26_18_5_93 { get; set; }
        public virtual DbSet<Execution_All> Execution_All { get; set; }
        public virtual DbSet<GOST_28759_3_90> GOST_28759_3_90 { get; set; }
        public virtual DbSet<GOST_28759_4_90> GOST_28759_4_90 { get; set; }
        public virtual DbSet<GOSTs> GOSTs { get; set; }
        public virtual DbSet<Octagonal_Gasket> Octagonal_Gasket { get; set; }
        public virtual DbSet<OST_26_2041_96> OST_26_2041_96 { get; set; }
        public virtual DbSet<OST26_2008_83> OST26_2008_83 { get; set; }
        public virtual DbSet<OST26_2042_96> OST26_2042_96 { get; set; }
        public virtual DbSet<Oval_Gasket> Oval_Gasket { get; set; }
        public virtual DbSet<Type_11> Type_11 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
