using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApiStudentGPA.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studentDbDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentDbDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subjectDbDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectDbDto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "studentSubjectDbDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SID = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubjectDbDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentSubjectDbDto_studentDbDto_SID",
                        column: x => x.SID,
                        principalTable: "studentDbDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentSubjectDbDto_subjectDbDto_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjectDbDto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentSubjectMarksDbDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubjectMarksDbDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentSubjectMarksDbDto_studentDbDto_StudentId",
                        column: x => x.StudentId,
                        principalTable: "studentDbDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentSubjectMarksDbDto_subjectDbDto_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjectDbDto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjectDbDto_SID",
                table: "studentSubjectDbDto",
                column: "SID");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjectDbDto_SubjectId",
                table: "studentSubjectDbDto",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjectMarksDbDto_StudentId",
                table: "studentSubjectMarksDbDto",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjectMarksDbDto_SubjectId",
                table: "studentSubjectMarksDbDto",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentSubjectDbDto");

            migrationBuilder.DropTable(
                name: "studentSubjectMarksDbDto");

            migrationBuilder.DropTable(
                name: "studentDbDto");

            migrationBuilder.DropTable(
                name: "subjectDbDto");
        }
    }
}
