using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class V001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeenStatus = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_FromId",
                        column: x => x.FromId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_ToId",
                        column: x => x.ToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "CreatedFrom", "IsActive", "IsArchived", "LoginId", "Mobile", "Name", "Password", "UpdatedAt", "UpdatedBy", "UpdatedFrom" },
                values: new object[] { new Guid("fadede5d-1c91-4d95-92e4-f447ea6edade"), "Dhaka, Banlgadesh", new DateTime(2021, 1, 11, 11, 20, 14, 580, DateTimeKind.Local).AddTicks(9776), new Guid("00000000-0000-0000-0000-000000000000"), "", true, false, "user1@gmail.com", "013xxxxxxxx", "User 1", "8cb2237d0679ca88db6464eac60da96345513964", null, new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "CreatedFrom", "IsActive", "IsArchived", "LoginId", "Mobile", "Name", "Password", "UpdatedAt", "UpdatedBy", "UpdatedFrom" },
                values: new object[] { new Guid("52315bc2-0192-43da-88ec-669076082158"), "Dhaka, Banlgadesh", new DateTime(2021, 1, 11, 11, 20, 14, 586, DateTimeKind.Local).AddTicks(9285), new Guid("00000000-0000-0000-0000-000000000000"), "", true, false, "user2@gmail.com", "013xxxxxxxx", "User 2", "8cb2237d0679ca88db6464eac60da96345513964", null, new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromId",
                table: "Messages",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToId",
                table: "Messages",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginId",
                table: "Users",
                column: "LoginId",
                unique: true,
                filter: "[LoginId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
