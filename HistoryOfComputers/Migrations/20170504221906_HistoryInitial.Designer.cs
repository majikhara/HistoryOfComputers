using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HistoryOfComputers.Data;

namespace HistoryOfComputers.Migrations
{
    [DbContext(typeof(HistoryContext))]
    [Migration("20170504221906_HistoryInitial")]
    partial class HistoryInitial
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
        }
    }
}
