namespace StudCalculator.Data.ModelsFromLotsman
{
    using System.Data.Entity;

    public class ModelsFromLotsman : DbContext
    {
        public ModelsFromLotsman()
            : base("name=ModelsFromLotsman")
        {
        }

        public virtual DbSet<dsAttributes> dsAttributes { get; set; }
        public virtual DbSet<rlTypesAndAttributes> rlTypesAndAttributes { get; set; }
        public virtual DbSet<stAttributes> stAttributes { get; set; }
        public virtual DbSet<stMain> stMain { get; set; }
        public virtual DbSet<stVersions> stVersions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dsAttributes>()
                .Property(e => e.stName)
                .IsUnicode(false);

            modelBuilder.Entity<dsAttributes>()
                .Property(e => e.stDefault)
                .IsUnicode(false);

            modelBuilder.Entity<dsAttributes>()
                .Property(e => e.txtList)
                .IsUnicode(false);

            modelBuilder.Entity<dsAttributes>()
                .HasMany(e => e.rlTypesAndAttributes)
                .WithRequired(e => e.dsAttributes)
                .HasForeignKey(e => e.inIdAttribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dsAttributes>()
                .HasMany(e => e.rlTypesAndAttributes1)
                .WithRequired(e => e.dsAttributes1)
                .HasForeignKey(e => e.inIdAttribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dsAttributes>()
                .HasMany(e => e.rlTypesAndAttributes2)
                .WithRequired(e => e.dsAttributes2)
                .HasForeignKey(e => e.inIdAttribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rlTypesAndAttributes>()
                .Property(e => e.stRule)
                .IsUnicode(false);

            modelBuilder.Entity<rlTypesAndAttributes>()
                .HasMany(e => e.stAttributes)
                .WithRequired(e => e.rlTypesAndAttributes)
                .HasForeignKey(e => e.inIdTypeAttr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rlTypesAndAttributes>()
                .HasMany(e => e.stAttributes1)
                .WithRequired(e => e.rlTypesAndAttributes1)
                .HasForeignKey(e => e.inIdTypeAttr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rlTypesAndAttributes>()
                .HasMany(e => e.stAttributes2)
                .WithRequired(e => e.rlTypesAndAttributes2)
                .HasForeignKey(e => e.inIdTypeAttr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stAttributes>()
                .Property(e => e.stValue)
                .IsUnicode(false);

            modelBuilder.Entity<stMain>()
                .Property(e => e.stKeyAttr)
                .IsUnicode(false);

            modelBuilder.Entity<stMain>()
                .HasMany(e => e.stVersions)
                .WithRequired(e => e.stMain)
                .HasForeignKey(e => e.inIdMain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stMain>()
                .HasMany(e => e.stVersions1)
                .WithRequired(e => e.stMain1)
                .HasForeignKey(e => e.inIdMain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stMain>()
                .HasMany(e => e.stVersions2)
                .WithRequired(e => e.stMain2)
                .HasForeignKey(e => e.inIdMain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stVersions>()
                .Property(e => e.stNumber)
                .IsUnicode(false);

            modelBuilder.Entity<stVersions>()
                .HasMany(e => e.stAttributes)
                .WithRequired(e => e.stVersions)
                .HasForeignKey(e => e.inIdVersion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stVersions>()
                .HasMany(e => e.stAttributes1)
                .WithRequired(e => e.stVersions1)
                .HasForeignKey(e => e.inIdVersion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stVersions>()
                .HasMany(e => e.stAttributes2)
                .WithRequired(e => e.stVersions2)
                .HasForeignKey(e => e.inIdVersion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stVersions>()
                .HasMany(e => e.stVersions1)
                .WithOptional(e => e.stVersions2)
                .HasForeignKey(e => e.inIdParentVersion);
        }
    }
}
