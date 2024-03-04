using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab0225_InitProject.Models;

public partial class TravelContext : DbContext
{
    public TravelContext(DbContextOptions<TravelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LabelKeyword> LabelKeyword { get; set; }

    public virtual DbSet<LabelManage> LabelManage { get; set; }

    public virtual DbSet<Spots> Spots { get; set; }

    public virtual DbSet<TagList> TagList { get; set; }

    public virtual DbSet<UniqueCity> UniqueCity { get; set; }

    public virtual DbSet<album> album { get; set; }

    public virtual DbSet<article> article { get; set; }

    public virtual DbSet<messageBoard> messageBoard { get; set; }

    public virtual DbSet<photo> photo { get; set; }

    public virtual DbSet<recommandBackup> recommandBackup { get; set; }

    public virtual DbSet<recommend> recommend { get; set; }

    public virtual DbSet<tags> tags { get; set; }

    public virtual DbSet<users> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LabelKeyword>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Result)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LabelManage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Class1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Class2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Class3)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Keyword)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ScenicSpotName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e._level)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Spots>(entity =>
        {
            entity.HasKey(e => e.ScenicSpotID).HasName("PK__Spots__C0F055A6CD3F11AB");

            entity.Property(e => e.ScenicSpotID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Class1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Class2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Class3)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionDetail)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.GeoHash)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Keyword)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OpenTime)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ParkingGeoHash)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ParkingInfo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParkingLat)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.ParkingLon)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PictureDescription1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PictureDescription2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PictureDescription3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PictureUrl1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PictureUrl2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PictureUrl3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PositionLat)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.PositionLon)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ScenicSpotName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TicketInfo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TravelInfo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e._Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e._Description)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e._level)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TagList>(entity =>
        {
            entity.HasKey(e => e.LabelId).HasName("PK__TagList__397E2BC3C66A4F98");

            entity.Property(e => e.TagClass)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.TagName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UniqueCity>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.city)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<album>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PK__album__97B4BE3701B725E2");

            entity.Property(e => e.AlbumName).HasMaxLength(10);

            entity.HasOne(d => d.User).WithMany(p => p.album)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_album_AlbumId");
        });

        modelBuilder.Entity<article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__article__9C6270E8CE555D33");

            entity.Property(e => e.ArticleState)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Contents).HasMaxLength(2500);
            entity.Property(e => e.Images)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.PublishTime).HasColumnType("datetime");
            entity.Property(e => e.Subtitle).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(20);
            entity.Property(e => e.TravelTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.article)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_UserId");
        });

        modelBuilder.Entity<messageBoard>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__messageB__C87C0C9C0C256017");

            entity.Property(e => e.Contents).HasMaxLength(2500);

            entity.HasOne(d => d.Article).WithMany(p => p.messageBoard)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_messageBoard_ArticleId");

            entity.HasOne(d => d.User).WithMany(p => p.messageBoard)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_messageBoard_UserId");
        });

        modelBuilder.Entity<photo>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__photo__21B7B5E268E1FC34");

            entity.Property(e => e.Haedshot)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.PhotoDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhotoTitle)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Album).WithMany(p => p.photo)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("fk_photo_AlbumId");
        });

        modelBuilder.Entity<recommandBackup>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.age)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.gender)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.interest1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.interest2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.interest3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.likeLocation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.likeWeather)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.userId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<recommend>(entity =>
        {
            entity.HasKey(e => e.LabelId).HasName("PK__recommen__397E2BC31BB2C878");

            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Interest)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Interest2)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Interest3)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Weather)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tags>(entity =>
        {
            entity.HasKey(e => e.LabelId).HasName("PK__tags__397E2BC3BD2DBFB8");

            entity.Property(e => e.LabelDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LabelName)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Article).WithMany(p => p.tags)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("fk_tags_ArticleId");
        });

        modelBuilder.Entity<users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__1788CC4CA2F24648");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Haedshot)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Interest).HasMaxLength(10);
            entity.Property(e => e.Introduction).HasMaxLength(150);
            entity.Property(e => e.Mail)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Nickname).HasMaxLength(32);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Pwd)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.SuperUser)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserName).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
