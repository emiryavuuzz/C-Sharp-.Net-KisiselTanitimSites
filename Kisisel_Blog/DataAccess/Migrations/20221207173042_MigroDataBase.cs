using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigroDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Linkedin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Github = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProfilPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DahaOnceCalistigiYerler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kurumAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CalistigiRutbe = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CalistigiAlan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IseGirisTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    IstenCikisTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsYeriKonumu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsYeriLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DahaOnceCalistigiYerler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DahaOnceCalistigiYerler_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Egitim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BolumAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MezuniyetYili = table.Column<DateTime>(type: "datetime", nullable: false),
                    BaslamaYili = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Egitim_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjeAmaci = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ProjeSeviyesi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjeninYapıldigiKurum = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjeAlanAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjePhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YapilisTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeler_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sertifikalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SertifikaAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VerenKurum = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AlinanTarih = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sertifikalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sertifikalar_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServisAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ServisAciklama = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ServisFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servisler_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yetenekler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YetenekAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TecrubeYili = table.Column<int>(type: "int", nullable: false),
                    BilgiOrani = table.Column<decimal>(type: "money", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetenekler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yetenekler_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DahaOnceCalistigiYerler_UsersId",
                table: "DahaOnceCalistigiYerler",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_UsersId",
                table: "Egitim",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_UsersId",
                table: "Projeler",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Sertifikalar_UsersId",
                table: "Sertifikalar",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Servisler_UsersId",
                table: "Servisler",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Yetenekler_UsersId",
                table: "Yetenekler",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DahaOnceCalistigiYerler");

            migrationBuilder.DropTable(
                name: "Egitim");

            migrationBuilder.DropTable(
                name: "Projeler");

            migrationBuilder.DropTable(
                name: "Sertifikalar");

            migrationBuilder.DropTable(
                name: "Servisler");

            migrationBuilder.DropTable(
                name: "Yetenekler");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
