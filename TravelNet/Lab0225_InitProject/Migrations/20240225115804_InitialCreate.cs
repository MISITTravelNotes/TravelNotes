using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab0225_InitProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelKeyword",
                columns: table => new
                {
                    Result = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LabelManage",
                columns: table => new
                {
                    ScenicSpotName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Class1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Class2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Class3 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    _level = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Keyword = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "recommandBackup",
                columns: table => new
                {
                    userId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    gender = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    age = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    likeWeather = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: true),
                    interest1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    interest2 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    interest3 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    likeLocation = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "recommend",
                columns: table => new
                {
                    LabelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Weather = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    Interest = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Interest2 = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Interest3 = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Location = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recommen__397E2BC31BB2C878", x => x.LabelId);
                });

            migrationBuilder.CreateTable(
                name: "Spots",
                columns: table => new
                {
                    ScenicSpotID = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    ScenicSpotName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    _Address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    TravelInfo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    OpenTime = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PictureUrl1 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PictureDescription1 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PictureUrl2 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PictureDescription2 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PictureUrl3 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PictureDescription3 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PositionLon = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    PositionLat = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    GeoHash = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Class1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Class2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Class3 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    _level = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ParkingInfo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ParkingLon = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    ParkingLat = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    ParkingGeoHash = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TicketInfo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Keyword = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    _Description = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    DescriptionDetail = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Spots__C0F055A6CD3F11AB", x => x.ScenicSpotID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Phone = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Mail = table.Column<string>(type: "varchar(254)", unicode: false, maxLength: 254, nullable: true),
                    Gender = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Pwd = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Haedshot = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    SuperUser = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__1788CC4CA2F24648", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AlbumName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateTime = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__album__97B4BE3701B725E2", x => x.AlbumId);
                    table.ForeignKey(
                        name: "fk_album_AlbumId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PublishTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    TravelTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Images = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: true),
                    PageView = table.Column<int>(type: "int", nullable: true),
                    ArticleState = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__article__9C6270E8CE555D33", x => x.ArticleId);
                    table.ForeignKey(
                        name: "fk_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PhotoDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PhotoPath = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    UploadDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    Haedshot = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__photo__21B7B5E268E1FC34", x => x.PhotoId);
                    table.ForeignKey(
                        name: "fk_photo_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "album",
                        principalColumn: "AlbumId");
                });

            migrationBuilder.CreateTable(
                name: "messageBoard",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    MessageTime = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__messageB__C87C0C9C0C256017", x => x.MessageId);
                    table.ForeignKey(
                        name: "fk_messageBoard_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "ArticleId");
                    table.ForeignKey(
                        name: "fk_messageBoard_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    LabelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    LabelName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    LabelDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tags__397E2BC3BD2DBFB8", x => x.LabelId);
                    table.ForeignKey(
                        name: "fk_tags_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "ArticleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_album_UserId",
                table: "album",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_article_UserId",
                table: "article",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_messageBoard_ArticleId",
                table: "messageBoard",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_messageBoard_UserId",
                table: "messageBoard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_photo_AlbumId",
                table: "photo",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_ArticleId",
                table: "tags",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelKeyword");

            migrationBuilder.DropTable(
                name: "LabelManage");

            migrationBuilder.DropTable(
                name: "messageBoard");

            migrationBuilder.DropTable(
                name: "photo");

            migrationBuilder.DropTable(
                name: "recommandBackup");

            migrationBuilder.DropTable(
                name: "recommend");

            migrationBuilder.DropTable(
                name: "Spots");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
