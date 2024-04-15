using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NGANHANG.DTO
{
    public class NhanVien
    {
        

        private string MANV;
        private string HO;
        private string TEN;
        private string DIACHI;
        private string PHAI;
        private string SODT;

        public NhanVien() { }

        public NhanVien(string MANV, string HO, string TEN, string DIACHI, string PHAI, string SODT)
        {
            this.MANV = MANV;
            this.HO = HO;
            this.TEN = TEN;
            this.DIACHI = DIACHI;
            this.PHAI = PHAI;
            this.SODT = SODT;
        }

        public NhanVien(DataRowView row)
        {
            MANV = (string)row["MANV"];
            HO = (string)row["HO"];
            TEN = (string)row["TEN"];
            DIACHI = (string)row["DIACHI"];
            PHAI = (string)row["PHAI"];
            SODT = (string)row["SODT"];
        }

        public string MaNV { get => MANV; set => MANV = value; }
        public string Ho { get => HO; set => HO = value; }
        public string Ten { get => TEN; set => TEN = value; }
        public string DiaChi { get => DIACHI; set => DIACHI = value; }
        public string Phai { get => PHAI; set => PHAI = value; }
        public string SoDT { get => SODT; set => SODT = value; }
    }
}
