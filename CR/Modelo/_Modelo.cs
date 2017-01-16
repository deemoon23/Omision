namespace CR.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class _Modelo : DbContext
    {
        public _Modelo()
            : base("name=ModeloIngresos")
        {
        }

        public virtual DbSet<cat_organismos2> cat_organismos2 { get; set; }
        public virtual DbSet<localidades> localidades { get; set; }
        public virtual DbSet<Omisiones> Omisiones { get; set; }
        public virtual DbSet<organismos> organismos { get; set; }
        public virtual DbSet<tasasOmisiones> tasasOmisiones { get; set; }
        public virtual DbSet<tasasOmisionesInterinato> tasasOmisionesInterinato { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.idTipoGenera)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.C_ServMedico)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.C_FondoPens)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.C_GastosInfra)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.C_SeguroVida)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.C_SeguroRetiro)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.C_CortoPlazo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.C_Prendario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_ServMedico)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_FondoPens)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_CortoPlazo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_Prendario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_Indemniza)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_AyudaFune)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_GastosAdmin)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_GastosInfra)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_PensionMin)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_Fovisssteson)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_SeguroVida)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.A_SeguroRetiro)
                .HasPrecision(10, 2);

            modelBuilder.Entity<cat_organismos2>()
                .Property(e => e.S_minimo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<localidades>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<localidades>()
                .Property(e => e.zona)
                .IsUnicode(false);

            modelBuilder.Entity<localidades>()
                .HasMany(e => e.cat_organismos2)
                .WithRequired(e => e.localidades)
                .HasForeignKey(e => e.idLocalidad)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Omisiones>()
            //    .Property(e => e.empleado)
            //    .IsUnicode(false);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.folio)
                .IsUnicode(false);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.tipoCobro)
                .IsUnicode(false);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.Localidad)
                .IsUnicode(false);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.Organismo)
                .IsUnicode(false);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.csm)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.cfp)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.ccp)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.cpren)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.csv)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.csr)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.cgi)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.tcuotas)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.importeC)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.asm)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.afp)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.acp)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.apren)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.asv)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.asr)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.agi)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.afovi)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.apm)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.aaf)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.aig)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.aga)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.taporta)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.importeA)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.tasa)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.tmoratorio)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.tmes)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Omisiones>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Omisiones>()
              .Property(e => e.apellidoP)
              .IsUnicode(false);

            modelBuilder.Entity<Omisiones>()
              .Property(e => e.apellidoM)
              .IsUnicode(false);

            modelBuilder.Entity<organismos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tasasOmisiones>()
                .Property(e => e.tasa)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tasasOmisionesInterinato>()
                .Property(e => e.tasa)
                .HasPrecision(18, 6);
        }
    }
}
