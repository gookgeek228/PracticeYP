using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticeYP.Models;

public partial class YpContext : DbContext
{
    public YpContext()
    {
    }

    public YpContext(DbContextOptions<YpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserJuri> UserJuris { get; set; }

    public virtual DbSet<UserModer> UserModers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=YP;Username=postgres;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.IdAction).HasName("actions_pk");

            entity.ToTable("actions");

            entity.Property(e => e.IdAction)
                .ValueGeneratedNever()
                .HasColumnName("id_action");
            entity.Property(e => e.Actions)
                .HasColumnType("character varying")
                .HasColumnName("actions");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.IdJury1).HasColumnName("id_jury_1");
            entity.Property(e => e.IdJury2).HasColumnName("id_jury_2");
            entity.Property(e => e.IdJury3).HasColumnName("id_jury_3");
            entity.Property(e => e.IdJury4).HasColumnName("id_jury_4");
            entity.Property(e => e.IdJury5).HasColumnName("id_jury_5");
            entity.Property(e => e.IdModer).HasColumnName("id_moder");
            entity.Property(e => e.IdWinner).HasColumnName("id_winner");
            entity.Property(e => e.TimeStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_start");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Actions)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("actions_events_fk");

            entity.HasOne(d => d.IdJury1Navigation).WithMany(p => p.ActionIdJury1Navigations)
                .HasForeignKey(d => d.IdJury1)
                .HasConstraintName("actions_user_juri_fk");

            entity.HasOne(d => d.IdJury5Navigation).WithMany(p => p.ActionIdJury5Navigations)
                .HasForeignKey(d => d.IdJury5)
                .HasConstraintName("actions_user_juri_fk_5");

            entity.HasOne(d => d.IdModerNavigation).WithMany(p => p.Actions)
                .HasForeignKey(d => d.IdModer)
                .HasConstraintName("actions_user_moders_fk");

            entity.HasOne(d => d.IdWinnerNavigation).WithMany(p => p.Actions)
                .HasForeignKey(d => d.IdWinner)
                .HasConstraintName("actions_users_fk");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity).HasName("newtable_pk");

            entity.ToTable("cities");

            entity.Property(e => e.IdCity)
                .ValueGeneratedNever()
                .HasColumnName("id_city");
            entity.Property(e => e.CityImage).HasColumnName("city_image");
            entity.Property(e => e.CityName)
                .HasColumnType("character varying")
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("country_pk");

            entity.ToTable("countries");

            entity.Property(e => e.IdCountry)
                .ValueGeneratedNever()
                .HasColumnName("id_country");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Code2).HasColumnName("code2");
            entity.Property(e => e.EnglishName)
                .HasColumnType("character varying")
                .HasColumnName("english_name");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("events_pk");

            entity.ToTable("events");

            entity.Property(e => e.IdEvent)
                .ValueGeneratedNever()
                .HasColumnName("id_event");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.EventName)
                .HasColumnType("character varying")
                .HasColumnName("event_name");
            entity.Property(e => e.IdCity).HasColumnName("id_city");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("events_cities_fk");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("gendet_pk");

            entity.ToTable("gender");

            entity.Property(e => e.IdGender)
                .HasColumnType("character varying")
                .HasColumnName("id_gender");
            entity.Property(e => e.GenderName)
                .HasColumnType("character varying")
                .HasColumnName("gender_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("role_pk");

            entity.ToTable("role");

            entity.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("id_role");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.IdSector).HasName("sectors_pk");

            entity.ToTable("sectors");

            entity.Property(e => e.IdSector)
                .ValueGeneratedNever()
                .HasColumnName("id_sector");
            entity.Property(e => e.SectorName)
                .HasColumnType("character varying")
                .HasColumnName("sector_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("members_pk");

            entity.ToTable("users");

            entity.Property(e => e.IdUsers)
                .ValueGeneratedNever()
                .HasColumnName("id_users");
            entity.Property(e => e.Birthdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdGender)
                .HasColumnType("character varying")
                .HasColumnName("id_gender");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("users_countries_fk");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("users_gender_fk");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("users_role_fk");
        });

        modelBuilder.Entity<UserJuri>(entity =>
        {
            entity.HasKey(e => e.IdJuri).HasName("user_juri_pk");

            entity.ToTable("user_juri");

            entity.Property(e => e.IdJuri)
                .ValueGeneratedNever()
                .HasColumnName("id_juri");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.IdUsers).HasColumnName("id_users");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.UserJuris)
                .HasForeignKey(d => d.IdSector)
                .HasConstraintName("user_juri_sectors_fk");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.UserJuris)
                .HasForeignKey(d => d.IdUsers)
                .HasConstraintName("user_juri_users_fk");
        });

        modelBuilder.Entity<UserModer>(entity =>
        {
            entity.HasKey(e => e.IdModer).HasName("user_moders_pk");

            entity.ToTable("user_moders");

            entity.Property(e => e.IdModer)
                .ValueGeneratedNever()
                .HasColumnName("id_moder");
            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.IdUsers).HasColumnName("id_users");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.UserModers)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("user_moders_events_fk");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.UserModers)
                .HasForeignKey(d => d.IdSector)
                .HasConstraintName("user_moders_sectors_fk");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.UserModers)
                .HasForeignKey(d => d.IdUsers)
                .HasConstraintName("user_moders_users_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
