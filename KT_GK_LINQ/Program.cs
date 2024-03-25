using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_GK_LINQ
{
    class DanhMuc
    {
        public int ID { get; set; }
        public string TenDM { get; set; }
        public DanhMuc(int id, string tendm)
        {
            ID = id;
            TenDM = tendm;
        }
    }
    class TaiLieu
    {
        public int MaXB { get; set; }
        public string TenTL { get; set; }
        public string NhaPH { get; set; }
        public int ID { get; set; }
        public TaiLieu()
        {
        }
    }
    class Sach : TaiLieu
    {
        public string TenTG { get; set; }
        public int Sotrang { get; set; }
        public Sach(int maxb, string tentl, string nhaph, string tentg, int sotrang, int iddm)
        {
            MaXB = maxb;
            TenTL = tentl;
            NhaPH = nhaph;
            TenTG = tentg;
            Sotrang = sotrang;
            ID = iddm;
        }
    }
    class Bao : TaiLieu
    {
        public DateTime NgayPH { get; set; }
        public Bao(int maxb, string tentl, string nhaph, DateTime ngayph, int iddm)
        {
            MaXB = maxb;
            TenTL = tentl;
            NhaPH = nhaph;
            NgayPH = ngayph;
            ID = iddm;
        }
    }
    class Tapchi : TaiLieu
    {
        public int SoPH { get; set; }
        public int TrangPH { get; set; }
        public Tapchi(int maxb, string tentl, string nhaph, int soph, int trangph, int iddm)
        {
            MaXB = maxb;
            TenTL = tentl;
            NhaPH = nhaph;
            SoPH = soph;
            TrangPH = trangph;
            ID = iddm;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DanhMuc danhmuc1 = new DanhMuc(1, "Sach");
            DanhMuc danhmuc2 = new DanhMuc(257, "Bao");
            DanhMuc danhmuc3 = new DanhMuc(3, "Tapchi");

            Sach sach1 = new Sach(1, "Lap trinh C#", "Lap trinh VN", "Do Phu Huy", 300, 1);
            Sach sach2 = new Sach(2, "Lap trinh huong doi tuong", "Nguyen Hoang", "Pham Huy", 260, 1);

            Bao bao1 = new Bao(1, "Nganh IT thoi nay", "TopIT", new DateTime(2024, 7, 14), 257);
            Bao bao2 = new Bao(2, "Choi game co hai?", "VN Top", new DateTime(2024, 3, 28), 257);

            Tapchi tapchi1 = new Tapchi(1, "Doi tuyen quoc gia vn", "Sport VN", 62, 600, 3);
            Tapchi tapchi2 = new Tapchi(2, "Doi song VN", "Dayly VN", 25, 354, 3);

            List<TaiLieu> danhSachTaiLieu = new List<TaiLieu>()
            {
                sach1, sach2, bao1, bao2, tapchi1, tapchi2
            };

            Console.WriteLine("Nhap loai tai lieu: ");
            Console.WriteLine("1: Sach");
            Console.WriteLine("2: Bao");
            Console.WriteLine("3: Tap chi");
            int loaiTaiLieu = int.Parse(Console.ReadLine());

            var taiLieuTheoLoai = danhSachTaiLieu.Where(tl => tl.GetType().Name == GetTypeName(loaiTaiLieu));

            if (taiLieuTheoLoai.Any())
            {
                foreach (var taiLieu in taiLieuTheoLoai)
                {
                    Console.WriteLine(($"MaXB: {taiLieu.MaXB}, TenTL: {taiLieu.TenTL}, NhaPH: {taiLieu.NhaPH}"));
                }
            }
            else
            {
                Console.WriteLine("Khong co tai lieu thuoc loai da chon.");
            }

            Console.ReadLine();

            Console.WriteLine("Danh sách các bài báo có NgayPH trong tháng 3/2024:");
            var baiBaoThang3 = danhSachTaiLieu.Where(tl => tl is Bao && ((Bao)tl).NgayPH.Month == 3 && ((Bao)tl).NgayPH.Year == 2024);

            if (baiBaoThang3.Any())
            {
                foreach (var baiBao in baiBaoThang3)
                {
                    Console.WriteLine($"Tên bài báo: {baiBao.TenTL} \nNgày phát hành: {((Bao)baiBao).NgayPH}");
                }
            }
            else
            {
                Console.WriteLine("Không có bài báo nào được phát hành trong tháng 3/2024.");
            }

            Console.ReadLine();
        }

        static string GetTypeName(int loaiTaiLieu)
        {
            switch (loaiTaiLieu)
            {
                case 1:
                    return "Sach";
                case 2:
                    return "Bao";
                case 3:
                    return "Tapchi";
                default:
                    return string.Empty;
            }
        }


    }
}

