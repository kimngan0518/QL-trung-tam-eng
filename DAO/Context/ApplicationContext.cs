using DAO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Context
{
    public class ApplicationContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.\TINO ;Initial Catalog=TrungTamTiengAnh; Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          

            builder.Entity<ThiSinh>().ToTable("ThiSinh");

            builder.Entity<PhongThi>().ToTable("PhongThi");

            builder.Entity<KhoaThi>().ToTable("KhoaThi");

            builder.Entity<TrinhDo>().ToTable("TrinhDo");

            builder.Entity<GiaoVien>().ToTable("GiaoVien");

            builder.Entity<KetQua>().HasKey(pk => new { pk.ID, pk.maPhong });
            builder.Entity<KetQua>().HasOne(kq => kq.phongThi)
                                   .WithMany(ts => ts.dsKetQua);

            builder.Entity<KetQua>().HasOne(kq => kq.thiSinh)
                                   .WithMany(pt => pt.dsKetQua);

            builder.Entity<ThamGia>().HasKey(pk => new { pk.ID, pk.maKhoaThi });
            builder.Entity<ThamGia>().HasOne(tg => tg.khoaThi)
                                  .WithMany(ts => ts.dsThamGia);

            builder.Entity<ThamGia>().HasOne(tg => tg.thiSinh)
                                   .WithMany(pt => pt.dsThamGia);

            builder.Entity<CoiThi>().HasKey(pk => new { pk.maGV, pk.maPhong });
            builder.Entity<CoiThi>().HasOne(tg => tg.phongThi)
                                  .WithMany(ts => ts.dsCoiThi);

            builder.Entity<CoiThi>().HasOne(tg => tg.giaoVien)
                                   .WithMany(pt => pt.dsCoiThi);

        }

        public DbSet<ThiSinh> ThiSinh { get; set; }
        public DbSet<PhongThi> PhongThi { get; set; }
        public DbSet<KhoaThi> KhoaThi { get; set; }
        public DbSet<TrinhDo> TrinhDo { get; set; }
        public DbSet<GiaoVien> GiaoVien { get; set; }
        public DbSet<KetQua> KetQua { get; set; }
        public DbSet<CoiThi> CoiThi { get; set; }
        public DbSet<ThamGia> ThamGia { get; set; }
    }
}
