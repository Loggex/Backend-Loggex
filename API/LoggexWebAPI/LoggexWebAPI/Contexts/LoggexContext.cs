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

        public virtual DbSet<ImgVeiculo> ImgVeiculos { get; set; }
        public virtual DbSet<LogAlteracao> LogAlteracaos { get; set; }
        public virtual DbSet<Manutenco> Manutencoes { get; set; }
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
                optionsBuilder.UseSqlServer("Data Source=NOTE0111E6\\SQLEXPRESS; initial catalog=Loggex_BD; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ImgVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdImagem)
                    .HasName("PK__imgVeicu__EA9A71379FF651EF");

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
                    .HasConstraintName("FK__imgVeicul__idVei__5165187F");
            });

            modelBuilder.Entity<LogAlteracao>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__logAlter__3C7153CAFA59A406");

                entity.ToTable("logAlteracao");

                entity.Property(e => e.IdLog).HasColumnName("idLog");

                entity.Property(e => e.DataAlteracao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataAlteracao");

                entity.Property(e => e.EstadoAlteracao).HasColumnName("estadoAlteracao");

                entity.Property(e => e.IdPeca).HasColumnName("idPeca");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdPecaNavigation)
                    .WithMany(p => p.LogAlteracaos)
                    .HasForeignKey(d => d.IdPeca)
                    .HasConstraintName("FK__logAltera__idPec__656C112C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LogAlteracaos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__logAltera__idUsu__66603565");
            });

            modelBuilder.Entity<Manutenco>(entity =>
            {
                entity.HasKey(e => e.IdManutencao)
                    .HasName("PK__manutenc__D80217B2C32C6DCA");

                entity.ToTable("manutencoes");

                entity.Property(e => e.IdManutencao).HasColumnName("idManutencao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Manutencos)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__manutenco__idSit__5629CD9C");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Manutencos)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("FK__manutenco__idVei__571DF1D5");
            });

            modelBuilder.Entity<Motorista>(entity =>
            {
                entity.HasKey(e => e.IdMotorista)
                    .HasName("PK__motorist__F015F7A08456714B");

                entity.ToTable("motoristas");

                entity.HasIndex(e => e.Cnh, "UQ__motorist__D836175F234CC6CF")
                    .IsUnique();

                entity.Property(e => e.IdMotorista).HasColumnName("idMotorista");

                entity.Property(e => e.Cnh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cnh");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Motorista)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__motorista__idUsu__3F466844");
            });

            modelBuilder.Entity<Peca>(entity =>
            {
                entity.HasKey(e => e.IdPeca)
                    .HasName("PK__Pecas__B878B5E2064B65E4");

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
                    .HasConstraintName("FK__Pecas__idTipoPec__619B8048");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Pecas)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("FK__Pecas__idVeiculo__628FA481");
            });

            modelBuilder.Entity<Rota>(entity =>
            {
                entity.HasKey(e => e.IdRota)
                    .HasName("PK__rotas__E507090A57D97FE9");

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
                    .HasConstraintName("FK__rotas__idMotoris__5BE2A6F2");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Rota)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__rotas__idSituaca__59FA5E80");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Rota)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("FK__rotas__idVeiculo__5AEE82B9");
            });

            modelBuilder.Entity<Situaco>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacoe__12AFD19798E238EE");

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
                    .HasName("PK__tiposPec__99AFFE6D2FA1D8F4");

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
                    .HasConstraintName("FK__tiposPeca__idSit__5EBF139D");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tiposUsu__03006BFFB445F226");

                entity.ToTable("tiposUsuarios");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tiposUsu__A017BD9FC9CEF350")
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
                    .HasName("PK__tiposVei__25BB01DB3C1D70B6");

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
                    .HasName("PK__usuarios__645723A6C961C9BE");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164ECF3DAA3")
                    .IsUnique();

                entity.HasIndex(e => e.NumCelular, "UQ__usuarios__FE90CA9D46B605FD")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.ImgPerfil)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imgPerfil");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.NumCelular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numCelular");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuarios__idTipo__3B75D760");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo)
                    .HasName("PK__veiculos__8178EBE883728A1C");

                entity.ToTable("veiculos");

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
                    .HasConstraintName("FK__veiculos__idTipo__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
