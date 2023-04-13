using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnScanId = table.Column<int>(type: "int", nullable: true),
                    RegistrationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ogrn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNoContract = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_FileModel_InnScanId",
                        column: x => x.InnScanId,
                        principalTable: "FileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrespondentAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDetail_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDetail_ProfileId",
                table: "BankDetail",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_InnScanId",
                table: "Profiles",
                column: "InnScanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetail");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "FileModel");
        }
    }
}
