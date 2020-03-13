using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.HDNManagementAPI.Migrations
{
    public partial class InitialHDNManagementDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HdnOption",
                columns: table => new
                {
                    HdnOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfHypotheek = table.Column<int>(nullable: false),
                    UseNHG = table.Column<bool>(nullable: false),
                    UseGivenFirstClient = table.Column<bool>(nullable: false),
                    UseGivenSecondClient = table.Column<bool>(nullable: false),
                    UseGivenTussenPersoon = table.Column<bool>(nullable: false),
                    UseOverbruggingBedrag = table.Column<bool>(nullable: false),
                    FirstClientName = table.Column<string>(nullable: true),
                    SecondClientName = table.Column<string>(nullable: true),
                    TussenPersoon = table.Column<string>(nullable: true),
                    OverbruggingBedrag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HdnOption", x => x.HdnOptionId);
                });

            migrationBuilder.CreateTable(
                name: "Omgeving",
                columns: table => new
                {
                    OmgevingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OmgevingNaam = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Omgeving", x => x.OmgevingId);
                });

            migrationBuilder.CreateTable(
                name: "Hdn",
                columns: table => new
                {
                    HdnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BerichtNaam = table.Column<string>(nullable: true),
                    BerichtLocatie = table.Column<string>(nullable: true),
                    HdnOptionId = table.Column<int>(nullable: true),
                    OmgevingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hdn", x => x.HdnId);
                    table.ForeignKey(
                        name: "FK_Hdn_HdnOption_HdnOptionId",
                        column: x => x.HdnOptionId,
                        principalTable: "HdnOption",
                        principalColumn: "HdnOptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hdn_Omgeving_OmgevingId",
                        column: x => x.OmgevingId,
                        principalTable: "Omgeving",
                        principalColumn: "OmgevingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    LabelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OmgevingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_Label_Omgeving_OmgevingId",
                        column: x => x.OmgevingId,
                        principalTable: "Omgeving",
                        principalColumn: "OmgevingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hdn_HdnOptionId",
                table: "Hdn",
                column: "HdnOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Hdn_OmgevingId",
                table: "Hdn",
                column: "OmgevingId");

            migrationBuilder.CreateIndex(
                name: "IX_Label_OmgevingId",
                table: "Label",
                column: "OmgevingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hdn");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "HdnOption");

            migrationBuilder.DropTable(
                name: "Omgeving");
        }
    }
}
