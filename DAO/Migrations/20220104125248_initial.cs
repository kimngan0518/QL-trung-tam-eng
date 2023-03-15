using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaoVien",
                columns: table => new
                {
                    maGV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenGV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoVien", x => x.maGV);
                });

            migrationBuilder.CreateTable(
                name: "KhoaThi",
                columns: table => new
                {
                    maKhoaThi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenKhoaThi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngayThi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaThi", x => x.maKhoaThi);
                });

            migrationBuilder.CreateTable(
                name: "ThiSinh",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    hoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gioiTrinh = table.Column<bool>(type: "bit", nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    noiSinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThiSinh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrinhDo",
                columns: table => new
                {
                    maTrinhDo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTrinhDo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinhDo", x => x.maTrinhDo);
                });

            migrationBuilder.CreateTable(
                name: "PhongThi",
                columns: table => new
                {
                    maPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    caThi = table.Column<bool>(type: "bit", nullable: false),
                    maTrinhDo = table.Column<int>(type: "int", nullable: false),
                    maKhoaThi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongThi", x => x.maPhong);
                    table.ForeignKey(
                        name: "FK_PhongThi_KhoaThi_maKhoaThi",
                        column: x => x.maKhoaThi,
                        principalTable: "KhoaThi",
                        principalColumn: "maKhoaThi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhongThi_TrinhDo_maTrinhDo",
                        column: x => x.maTrinhDo,
                        principalTable: "TrinhDo",
                        principalColumn: "maTrinhDo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThamGia",
                columns: table => new
                {
                    maKhoaThi = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ngayThamGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    maTrinhDo = table.Column<int>(type: "int", nullable: false),
                    trangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamGia", x => new { x.ID, x.maKhoaThi });
                    table.ForeignKey(
                        name: "FK_ThamGia_KhoaThi_maKhoaThi",
                        column: x => x.maKhoaThi,
                        principalTable: "KhoaThi",
                        principalColumn: "maKhoaThi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThamGia_ThiSinh_ID",
                        column: x => x.ID,
                        principalTable: "ThiSinh",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThamGia_TrinhDo_maTrinhDo",
                        column: x => x.maTrinhDo,
                        principalTable: "TrinhDo",
                        principalColumn: "maTrinhDo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoiThi",
                columns: table => new
                {
                    maGV = table.Column<int>(type: "int", nullable: false),
                    maPhong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoiThi", x => new { x.maGV, x.maPhong });
                    table.ForeignKey(
                        name: "FK_CoiThi_GiaoVien_maGV",
                        column: x => x.maGV,
                        principalTable: "GiaoVien",
                        principalColumn: "maGV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoiThi_PhongThi_maPhong",
                        column: x => x.maPhong,
                        principalTable: "PhongThi",
                        principalColumn: "maPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KetQua",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    maPhong = table.Column<int>(type: "int", nullable: false),
                    sbd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diemNghe = table.Column<float>(type: "real", nullable: false),
                    diemNoi = table.Column<float>(type: "real", nullable: false),
                    diemDoc = table.Column<float>(type: "real", nullable: false),
                    diemViet = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQua", x => new { x.ID, x.maPhong });
                    table.ForeignKey(
                        name: "FK_KetQua_PhongThi_maPhong",
                        column: x => x.maPhong,
                        principalTable: "PhongThi",
                        principalColumn: "maPhong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KetQua_ThiSinh_ID",
                        column: x => x.ID,
                        principalTable: "ThiSinh",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoiThi_maPhong",
                table: "CoiThi",
                column: "maPhong");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_maPhong",
                table: "KetQua",
                column: "maPhong");

            migrationBuilder.CreateIndex(
                name: "IX_PhongThi_maKhoaThi",
                table: "PhongThi",
                column: "maKhoaThi");

            migrationBuilder.CreateIndex(
                name: "IX_PhongThi_maTrinhDo",
                table: "PhongThi",
                column: "maTrinhDo");

            migrationBuilder.CreateIndex(
                name: "IX_ThamGia_maKhoaThi",
                table: "ThamGia",
                column: "maKhoaThi");

            migrationBuilder.CreateIndex(
                name: "IX_ThamGia_maTrinhDo",
                table: "ThamGia",
                column: "maTrinhDo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoiThi");

            migrationBuilder.DropTable(
                name: "KetQua");

            migrationBuilder.DropTable(
                name: "ThamGia");

            migrationBuilder.DropTable(
                name: "GiaoVien");

            migrationBuilder.DropTable(
                name: "PhongThi");

            migrationBuilder.DropTable(
                name: "ThiSinh");

            migrationBuilder.DropTable(
                name: "KhoaThi");

            migrationBuilder.DropTable(
                name: "TrinhDo");
        }
    }
}
