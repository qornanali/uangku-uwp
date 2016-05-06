using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Uangku_UWP;

namespace Uangku_UWP.Migrations
{
    [DbContext(typeof(DBHelper))]
    [Migration("20160506033007_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Uangku_UWP.Item", b =>
                {
                    b.Property<Guid>("itemId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("amount");

                    b.Property<string>("dateTime");

                    b.Property<string>("desc");

                    b.Property<int>("itemType");

                    b.HasKey("itemId");
                });
        }
    }
}
