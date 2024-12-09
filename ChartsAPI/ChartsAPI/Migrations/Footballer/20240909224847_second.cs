using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChartsAPI.Migrations.Footballer
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Footballer",
                columns: table => new
                {
                    footballerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    footballerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalGoal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footballer", x => x.footballerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Footballer");
        }
    }
}
