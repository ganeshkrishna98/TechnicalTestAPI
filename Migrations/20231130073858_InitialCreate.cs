using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalTestAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentOutputs",
                columns: table => new
                {
                    Document_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Document_Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    File_Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Approval_Status = table.Column<string>(type: "varchar(50)", nullable: false),
                    Author_User_ID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Author_Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Last_Modified_User_ID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Last_Modified_User_Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Last_Accessed_User_Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Last_Accessed_User_ID = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentOutputs", x => x.Document_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentOutputs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
