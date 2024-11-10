using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppYte.Migrations
{
    public partial class AddNewColumnDatLich : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenhNhan",
                columns: table => new
                {
                    mabn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenbn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sdt = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true),
                    gioitinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    tendn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    mk = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    trangthai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BenhNhan__7A2255F4EC77B831", x => x.mabn);
                });

            migrationBuilder.CreateTable(
                name: "ChiNhanh",
                columns: table => new
                {
                    machinhanh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiNhanh__B98FB2FB9F02B780", x => x.machinhanh);
                });

            migrationBuilder.CreateTable(
                name: "DangNhap",
                columns: table => new
                {
                    ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendn = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    mk = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    quyen = table.Column<int>(type: "int", nullable: true),
                    mand = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DangNhap__3213C8B737C80646", x => x.ma);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    makhoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenkhoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Khoa__30B01682250477C0", x => x.makhoa);
                });

            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    maloai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenloai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Loai__734B3AEA67D4DA62", x => x.maloai);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    mand = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true),
                    gioitinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    sdt = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    chucvu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hocham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hocvi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gioithieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    makhoa = table.Column<int>(type: "int", nullable: true),
                    machinhanh = table.Column<int>(type: "int", nullable: true),
                    tendn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    mk = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    quyen = table.Column<int>(type: "int", nullable: true),
                    anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangthai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NguoiDun__7A21B393C7BAA166", x => x.mand);
                    table.ForeignKey(
                        name: "FK__NguoiDung__machi__403A8C7D",
                        column: x => x.machinhanh,
                        principalTable: "ChiNhanh",
                        principalColumn: "machinhanh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__NguoiDung__makho__3F466844",
                        column: x => x.makhoa,
                        principalTable: "Khoa",
                        principalColumn: "makhoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    mabv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tieude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noidung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hinhanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngaydang = table.Column<DateTime>(type: "date", nullable: true),
                    maloai = table.Column<int>(type: "int", nullable: true),
                    mand = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BaiViet__7A2255EC4B636982", x => x.mabv);
                    table.ForeignKey(
                        name: "FK__BaiViet__maloai__48CFD27E",
                        column: x => x.maloai,
                        principalTable: "Loai",
                        principalColumn: "maloai",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__BaiViet__mand__49C3F6B7",
                        column: x => x.mand,
                        principalTable: "NguoiDung",
                        principalColumn: "mand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BenhAn",
                columns: table => new
                {
                    maba = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mabn = table.Column<int>(type: "int", nullable: false),
                    mabs = table.Column<int>(type: "int", nullable: false),
                    tieude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngaykham = table.Column<DateTime>(type: "datetime", nullable: false),
                    giokham = table.Column<DateTime>(type: "datetime", nullable: false),
                    mach = table.Column<double>(type: "float", nullable: false),
                    nhietdo = table.Column<double>(type: "float", nullable: false),
                    nhiptho = table.Column<double>(type: "float", nullable: false),
                    chieucao = table.Column<double>(type: "float", nullable: false),
                    cannang = table.Column<double>(type: "float", nullable: false),
                    bmi = table.Column<double>(type: "float", nullable: false),
                    thiluctrai = table.Column<double>(type: "float", nullable: false),
                    thilucphai = table.Column<double>(type: "float", nullable: false),
                    nhanapP = table.Column<double>(type: "float", nullable: false),
                    nhanapT = table.Column<double>(type: "float", nullable: false),
                    chuandoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ketqua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangthai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.BenhAn", x => x.maba);
                    table.ForeignKey(
                        name: "FK_dbo.BenhAn_dbo.BenhNhan_mabn",
                        column: x => x.mabn,
                        principalTable: "BenhNhan",
                        principalColumn: "mabn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.BenhAn_dbo.NguoiDung_mabs",
                        column: x => x.mabs,
                        principalTable: "NguoiDung",
                        principalColumn: "mand",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaKham",
                columns: table => new
                {
                    maca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngaykham = table.Column<DateTime>(type: "date", nullable: true),
                    hinhthuc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ca = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    mand = table.Column<int>(type: "int", nullable: true),
                    trangthai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CaKham__7A21F87DFBA45D2F", x => x.maca);
                    table.ForeignKey(
                        name: "FK__CaKham__mand__4CA06362",
                        column: x => x.mand,
                        principalTable: "NguoiDung",
                        principalColumn: "mand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    madanhgia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngay = table.Column<DateTime>(type: "date", nullable: true),
                    noidung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mand = table.Column<int>(type: "int", nullable: true),
                    mabn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DanhGia__7E089258038F1B8C", x => x.madanhgia);
                    table.ForeignKey(
                        name: "FK__DanhGia__mabn__534D60F1",
                        column: x => x.mabn,
                        principalTable: "BenhNhan",
                        principalColumn: "mabn",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DanhGia__mand__52593CB8",
                        column: x => x.mand,
                        principalTable: "NguoiDung",
                        principalColumn: "mand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiaChiKham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bs_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    city = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChiKham", x => x.id);
                    table.ForeignKey(
                        name: "FK__DiaChiKha__bs_id__6FE99F9F",
                        column: x => x.bs_id,
                        principalTable: "NguoiDung",
                        principalColumn: "mand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoiDap",
                columns: table => new
                {
                    ma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngayhoi = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngaytl = table.Column<DateTime>(type: "datetime", nullable: true),
                    dap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mand = table.Column<int>(type: "int", nullable: true),
                    mabn = table.Column<int>(type: "int", nullable: true),
                    trangthai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoiDap__3213C8B7CA4B4968", x => x.ma);
                    table.ForeignKey(
                        name: "FK__HoiDap__mabn__571DF1D5",
                        column: x => x.mabn,
                        principalTable: "BenhNhan",
                        principalColumn: "mabn",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__HoiDap__mand__5629CD9C",
                        column: x => x.mand,
                        principalTable: "NguoiDung",
                        principalColumn: "mand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatLich",
                columns: table => new
                {
                    madat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngaydat = table.Column<DateTime>(type: "date", nullable: true),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdt = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    hoten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true),
                    trangthai = table.Column<int>(type: "int", nullable: true),
                    maca = table.Column<int>(type: "int", nullable: true),
                    mabn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DatLich__0BE68C779C8183A2", x => x.madat);
                    table.ForeignKey(
                        name: "FK__DatLich__maca__4F7CD00D",
                        column: x => x.maca,
                        principalTable: "CaKham",
                        principalColumn: "maca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_maloai",
                table: "BaiViet",
                column: "maloai");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_mand",
                table: "BaiViet",
                column: "mand");

            migrationBuilder.CreateIndex(
                name: "IX_mabn",
                table: "BenhAn",
                column: "mabn");

            migrationBuilder.CreateIndex(
                name: "IX_mabs",
                table: "BenhAn",
                column: "mabs");

            migrationBuilder.CreateIndex(
                name: "IX_CaKham_mand",
                table: "CaKham",
                column: "mand");

            migrationBuilder.CreateIndex(
                name: "UQ__DangNhap__FB739DEF25E948C1",
                table: "DangNhap",
                column: "tendn",
                unique: true,
                filter: "[tendn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_mabn",
                table: "DanhGia",
                column: "mabn");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_mand",
                table: "DanhGia",
                column: "mand");

            migrationBuilder.CreateIndex(
                name: "IX_DatLich_maca",
                table: "DatLich",
                column: "maca");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChiKham_bs_id",
                table: "DiaChiKham",
                column: "bs_id");

            migrationBuilder.CreateIndex(
                name: "IX_HoiDap_mabn",
                table: "HoiDap",
                column: "mabn");

            migrationBuilder.CreateIndex(
                name: "IX_HoiDap_mand",
                table: "HoiDap",
                column: "mand");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_machinhanh",
                table: "NguoiDung",
                column: "machinhanh");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_makhoa",
                table: "NguoiDung",
                column: "makhoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "BenhAn");

            migrationBuilder.DropTable(
                name: "DangNhap");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "DatLich");

            migrationBuilder.DropTable(
                name: "DiaChiKham");

            migrationBuilder.DropTable(
                name: "HoiDap");

            migrationBuilder.DropTable(
                name: "Loai");

            migrationBuilder.DropTable(
                name: "CaKham");

            migrationBuilder.DropTable(
                name: "BenhNhan");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "ChiNhanh");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
