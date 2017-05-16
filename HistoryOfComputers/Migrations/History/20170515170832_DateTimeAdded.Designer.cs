using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HistoryOfComputers.Data;

namespace HistoryOfComputers.Migrations.History
{
    [DbContext(typeof(HistoryContext))]
    [Migration("20170515170832_DateTimeAdded")]
    partial class DateTimeAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HistoryOfComputers.Models.Article", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Image");

                    b.Property<int>("PeriodID");

                    b.Property<string>("Reference");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("ArticleID");

                    b.HasIndex("PeriodID");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("HistoryOfComputers.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleID");

                    b.Property<string>("CommentText");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.HasKey("CommentID");

                    b.HasIndex("ArticleID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("HistoryOfComputers.Models.Favorite", b =>
                {
                    b.Property<string>("FavoriteID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450);

                    b.Property<int>("ArticleID");

                    b.HasKey("FavoriteID");

                    b.HasIndex("ArticleID");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("HistoryOfComputers.Models.TimePeriod", b =>
                {
                    b.Property<int>("PeriodID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PeriodName");

                    b.HasKey("PeriodID");

                    b.ToTable("TimePeriod");
                });

            modelBuilder.Entity("HistoryOfComputers.Models.Article", b =>
                {
                    b.HasOne("HistoryOfComputers.Models.TimePeriod", "TimePeriod")
                        .WithMany("Articles")
                        .HasForeignKey("PeriodID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HistoryOfComputers.Models.Comment", b =>
                {
                    b.HasOne("HistoryOfComputers.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HistoryOfComputers.Models.Favorite", b =>
                {
                    b.HasOne("HistoryOfComputers.Models.Article", "Article")
                        .WithMany("Favorites")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
