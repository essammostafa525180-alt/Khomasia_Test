using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Baseline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "HadithAurdos",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Hid = table.Column<int>(type: "int", nullable: true),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Selid = table.Column<int>(type: "int", nullable: false),
            //        Sound = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Rawy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HadithAurdos", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HadithEnglishes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Hid = table.Column<int>(type: "int", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Sound = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Rawy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Hokm = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Selid = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HadithEnglishes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HadithFrenshes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Hid = table.Column<int>(type: "int", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Selid = table.Column<int>(type: "int", nullable: false),
            //        Sound = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Rawy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HadithFrenshes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HadithIndonicies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Hid = table.Column<int>(type: "int", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Selid = table.Column<int>(type: "int", nullable: false),
            //        Sound = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Rawy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HadithIndonicies", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HadithSharhs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Hid = table.Column<int>(type: "int", nullable: false),
            //        BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SharhWithSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SharhWithNoSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Selid = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HadithSharhs", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HadithTakhreejs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Selid = table.Column<int>(type: "int", nullable: false),
            //        Hid = table.Column<int>(type: "int", nullable: false),
            //        CatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BabName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ChapterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HadithTakhreejs", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HadithTurkies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Hid = table.Column<int>(type: "int", nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Sound = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Rawy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Hokm = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Selid = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HadithTurkies", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MustafaTawfeeqs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MustafaTawfeeqHadithID = table.Column<int>(type: "int", nullable: false),
            //        all = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MustafaTawfeeqs", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NarratorsCriticisms",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CriticName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CriticStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NarratorId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NarratorsCriticisms", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NarratorStudents",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NarratorId = table.Column<int>(type: "int", nullable: true),
            //        Kunya = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Honorific = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Lineage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NarratorStudents", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Partations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        HasHadithCollection = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Partations", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HadithCollections",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
            //        MainMenuEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        PartationId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HadithCollections", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_HadithCollections_Partations_PartationId",
            //            column: x => x.PartationId,
            //            principalTable: "Partations",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Classifications",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        FullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        CatNameTakhreej = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        Writer = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        FullWriterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        WriterDeath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        AboutBook = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        Definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Rank = table.Column<int>(type: "int", nullable: true),
            //        BooksNumber = table.Column<int>(type: "int", nullable: true),
            //        CoverImage = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
            //        Lang = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        StartId = table.Column<int>(type: "int", nullable: true),
            //        EndId = table.Column<int>(type: "int", nullable: true),
            //        DeathYear = table.Column<int>(type: "int", nullable: true),
            //        HadithCollectionId = table.Column<int>(type: "int", nullable: true),
            //        Status = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Classifications", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Classifications_HadithCollections_HadithCollectionId",
            //            column: x => x.HadithCollectionId,
            //            principalTable: "HadithCollections",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ClassificationIndex = table.Column<int>(type: "int", nullable: true),
            //        ClassificationId = table.Column<int>(type: "int", nullable: true),
            //        IsAvailable = table.Column<bool>(type: "bit", nullable: false),
            //        OldCatId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Books", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Books_Classifications_ClassificationId",
            //            column: x => x.ClassificationId,
            //            principalTable: "Classifications",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Babs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BookId = table.Column<int>(type: "int", nullable: true),
            //        BabIndex = table.Column<int>(type: "int", nullable: true),
            //        IsAvailable = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Babs", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Babs_Books_BookId",
            //            column: x => x.BookId,
            //            principalTable: "Books",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Hadiths",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OldCatId = table.Column<int>(type: "int", nullable: true),
            //        OldChapterId = table.Column<int>(type: "int", nullable: false),
            //        OldBabId = table.Column<int>(type: "int", nullable: true),
            //        OldHadithId = table.Column<int>(type: "int", nullable: true),
            //        HadithWithSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        HId = table.Column<int>(type: "int", nullable: false),
            //        SelId = table.Column<int>(type: "int", nullable: false),
            //        HadithWithNoSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Hokm = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        HidOld = table.Column<int>(type: "int", nullable: false),
            //        YusufTaraf = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        YusufMatn = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        HavingMp3 = table.Column<int>(type: "int", nullable: true),
            //        View = table.Column<int>(type: "int", nullable: true),
            //        LastViews = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        WordCount = table.Column<int>(type: "int", nullable: true),
            //        RawyId = table.Column<int>(type: "int", nullable: false),
            //        NewBabId = table.Column<int>(type: "int", nullable: true),
            //        BabId = table.Column<int>(type: "int", nullable: true),
            //        IsAvailable = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Hadiths", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Hadiths_Babs_BabId",
            //            column: x => x.BabId,
            //            principalTable: "Babs",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Babs_BookId",
            //    table: "Babs",
            //    column: "BookId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Books_ClassificationId",
            //    table: "Books",
            //    column: "ClassificationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Classifications_HadithCollectionId",
            //    table: "Classifications",
            //    column: "HadithCollectionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HadithCollections_PartationId",
            //    table: "HadithCollections",
            //    column: "PartationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Hadiths_BabId",
            //    table: "Hadiths",
            //    column: "BabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "HadithAurdos");

            //migrationBuilder.DropTable(
            //    name: "HadithEnglishes");

            //migrationBuilder.DropTable(
            //    name: "HadithFrenshes");

            //migrationBuilder.DropTable(
            //    name: "HadithIndonicies");

            //migrationBuilder.DropTable(
            //    name: "Hadiths");

            //migrationBuilder.DropTable(
            //    name: "HadithSharhs");

            //migrationBuilder.DropTable(
            //    name: "HadithTakhreejs");

            //migrationBuilder.DropTable(
            //    name: "HadithTurkies");

            //migrationBuilder.DropTable(
            //    name: "MustafaTawfeeqs");

            //migrationBuilder.DropTable(
            //    name: "NarratorsCriticisms");

            //migrationBuilder.DropTable(
            //    name: "NarratorStudents");

            //migrationBuilder.DropTable(
            //    name: "Babs");

            //migrationBuilder.DropTable(
            //    name: "Books");

            //migrationBuilder.DropTable(
            //    name: "Classifications");

            //migrationBuilder.DropTable(
            //    name: "HadithCollections");

            //migrationBuilder.DropTable(
            //    name: "Partations");
        }
    }
}
