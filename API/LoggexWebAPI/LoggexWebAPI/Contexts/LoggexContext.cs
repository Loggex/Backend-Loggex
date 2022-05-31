using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LoggexWebAPI.Domains;

#nullable disable

namespace LoggexWebAPI.Contexts
{
    public partial class LoggexContext : DbContext
    {
        public LoggexContext()
        {
        }

        public LoggexContext(DbContextOptions<LoggexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gestor> Gestors { get; set; }
        public virtual DbSet<ImgVeiculo> ImgVeiculos { get; set; }
        public virtual DbSet<LogAlteracao> LogAlteracaos { get; set; }
        public virtual DbSet<Motorista> Motoristas { get; set; }
        public virtual DbSet<Peca> Pecas { get; set; }
        public virtual DbSet<Rota> Rotas { get; set; }
        public virtual DbSet<Situaco> Situacoes { get; set; }
        public virtual DbSet<TiposPeca> TiposPecas { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<TiposVeiculo> TiposVeiculos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0111E6\\SQLEXPRESS; initial catalog=DB-Loggex; user Id=sa; pwd=Senai@132;");
                //optionsBuilder.UseSqlServer("Data Source=NOTE0113E3\\SQLEXPRESS; initial catalog=DB-Loggex; user Id=sa; pwd=Senai@132;");
                //optionsBuilder.UseSqlServer("Data Source= dbloggex.database.windows.net; initial catalog = DB_Loggex; user Id = Loggexadm; pwd = Senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Gestor>(entity =>
            {
                entity.HasKey(e => e.IdGestor)
                    .HasName("PK__gestor__7AEBF384BD674DE0");

                entity.ToTable("gestor");

                entity.HasIndex(e => e.Email, "UQ__gestor__AB6E6164411387C1")
                    .IsUnique();

                entity.Property(e => e.IdGestor).HasColumnName("idGestor");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Gestors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__gestor__idUsuari__4316F928");
            });

            modelBuilder.Entity<ImgVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdImagem)
                    .HasName("PK__imgVeicu__EA9A7137650D7B0B");

                entity.ToTable("imgVeiculos");

                entity.Property(e => e.IdImagem).HasColumnName("idImagem");

                entity.Property(e => e.EnderecoImagem)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("enderecoImagem");

                entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.ImgVeiculos)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("FK__imgVeicul__idVei__4BAC3F29");
            });

            modelBuilder.Entity<LogAlteracao>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__logAlter__3C7153CAD7BEA722");

                entity.ToTable("logAlteracao");

                entity.Property(e => e.IdLog).HasColumnName("idLog");

                entity.Property(e => e.DataAlteracao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataAlteracao");

                entity.Property(e => e.EstadoAlteracao).HasColumnName("estadoAlteracao");

                entity.Property(e => e.IdPeca).HasColumnName("idPeca");

                entity.HasOne(d => d.IdPecaNavigation)
                    .WithMany(p => p.LogAlteracaos)
                    .HasForeignKey(d => d.IdPeca)
                    .HasConstraintName("FK__logAltera__idPec__5BE2A6F2");
            });

            modelBuilder.Entity<Motorista>(entity =>
            {
                entity.HasKey(e => e.IdMotorista)
                    .HasName("PK__motorist__F015F7A08621269F");

                entity.ToTable("motoristas");

                entity.HasIndex(e => e.Cnh, "UQ__motorist__D836175FBA710190")
                    .IsUnique();

                entity.HasIndex(e => e.NumCelular, "UQ__motorist__FE90CA9DBE77096B")
                    .IsUnique();

                entity.Property(e => e.IdMotorista).HasColumnName("idMotorista");

                entity.Property(e => e.Cnh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cnh");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumCelular)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("numCelular");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Motorista)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__motorista__idUsu__3F466844");
            });

            modelBuilder.Entity<Peca>(entity =>
            {
                entity.HasKey(e => e.IdPeca)
                    .HasName("PK__Pecas__B878B5E2C77556D7");

                entity.Property(e => e.IdPeca).HasColumnName("idPeca");

                entity.Property(e => e.EstadoPeca).HasColumnName("estadoPeca");

                entity.Property(e => e.IdTipoPeca).HasColumnName("idTipoPeca");

                entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");

                entity.Property(e => e.ImgPeca)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imgPeca");

                entity.HasOne(d => d.IdTipoPecaNavigation)
                    .WithMany(p => p.Pecas)
                    .HasForeignKey(d => d.IdTipoPeca)
                    .HasConstraintName("FK__Pecas__idTipoPec__5812160E");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Pecas)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("FK__Pecas__idVeiculo__59063A47");
            });

            modelBuilder.Entity<Rota>(entity =>
            {
                entity.HasKey(e => e.IdRota)
                    .HasName("PK__rotas__E507090AA2114A3F");

                entity.ToTable("rotas");

                entity.Property(e => e.IdRota).HasColumnName("idRota");

                entity.Property(e => e.Carga)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("carga");

                entity.Property(e => e.DataChegada)
                    .HasColumnType("datetime")
                    .HasColumnName("dataChegada");

                entity.Property(e => e.DataPartida)
                    .HasColumnType("datetime")
                    .HasColumnName("dataPartida");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("destino");

                entity.Property(e => e.IdMotorista).HasColumnName("idMotorista");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");

                entity.Property(e => e.Origem)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("origem");

                entity.Property(e => e.PesoBrutoCarga)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("pesoBrutoCarga");

                entity.Property(e => e.VolumeCarga)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("volumeCarga");

                entity.HasOne(d => d.IdMotoristaNavigation)
                    .WithMany(p => p.Rota)
                    .HasForeignKey(d => d.IdMotorista)
                    .HasConstraintName("FK__rotas__idMotoris__52593CB8");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Rota)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__rotas__idSituaca__5070F446");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Rota)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("FK__rotas__idVeiculo__5165187F");
            });

            modelBuilder.Entity<Situaco>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacoe__12AFD197F3B13785");

                entity.ToTable("situacoes");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.TituloSituacao)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tituloSituacao");
            });

            modelBuilder.Entity<TiposPeca>(entity =>
            {
                entity.HasKey(e => e.IdTipoPeca)
                    .HasName("PK__tiposPec__99AFFE6D54D59466");

                entity.ToTable("tiposPecas");

                entity.Property(e => e.IdTipoPeca).HasColumnName("idTipoPeca");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.NomePeça)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomePeça");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.TiposPecas)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__tiposPeca__idSit__5535A963");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tiposUsu__03006BFF6EEAA51C");

                entity.ToTable("tiposUsuarios");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tiposUsu__A017BD9FCA8D153A")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<TiposVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVeiculo)
                    .HasName("PK__tiposVei__25BB01DB490754DB");

                entity.ToTable("tiposVeiculos");

                entity.Property(e => e.IdTipoVeiculo).HasColumnName("idTipoVeiculo");

                entity.Property(e => e.ModeloVeiculo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("modeloVeiculo");

                entity.Property(e => e.TipoCarreta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipoCarreta");

                entity.Property(e => e.TipoCarroceria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipoCarroceria");

                entity.Property(e => e.TipoVeiculo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipoVeiculo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__645723A670E990B8");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Cpf, "UQ__usuarios__D836E71F2A44C777")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.ImgPerfil)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imgPerfil");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuarios__idTipo__3A81B327");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo)
                    .HasName("PK__veiculos__8178EBE8C62183DF");

                entity.ToTable("veiculos");

                entity.HasIndex(e => e.Placa, "UQ__veiculos__0C057425303ED73F")
                    .IsUnique();

                entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");

                entity.Property(e => e.AnoFabricacao).HasColumnName("anoFabricacao");

                entity.Property(e => e.Chassi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("chassi");

                entity.Property(e => e.Cor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cor");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.EstadoVeiculo).HasColumnName("estadoVeiculo");

                entity.Property(e => e.IdTipoVeiculo).HasColumnName("idTipoVeiculo");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.Property(e => e.Quilometragem)
                    .HasColumnType("decimal(10, 1)")
                    .HasColumnName("quilometragem");

                entity.Property(e => e.Seguro).HasColumnName("seguro");

                entity.HasOne(d => d.IdTipoVeiculoNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.IdTipoVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__veiculos__idTipo__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
