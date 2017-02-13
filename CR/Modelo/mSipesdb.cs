namespace CR.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mSipesdb : DbContext
    {
        public mSipesdb()
            : base("name=mSipesdb")
        {
        }

        public virtual DbSet<trabajadores> trabajadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tafiliacion)
                .HasPrecision(18, 0);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tpension)
                .HasPrecision(18, 0);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tconsecutivo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tpensionado)
                .HasPrecision(18, 0);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tpaterno)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tmaterno)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tnombre)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tsexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.talergia)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tenfercronica)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tdomicilio)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.ttelefonop)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.ttelefonoo)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tobservaciones)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tfotografia)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tusuariored)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tusuariosql)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tmotmed)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tmotmed1)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tcoloniaalfa)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tusertoma)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.tuserexpide)
                .IsUnicode(false);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.sueldo_ingresos)
                .HasPrecision(19, 4);

            modelBuilder.Entity<trabajadores>()
                .Property(e => e.generacion)
                .IsUnicode(false);
        }
    }
}
