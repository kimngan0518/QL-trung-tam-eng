using DAO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAOService
{
    public class DAOThongKe
    {
        public DAOThongKe()
        {

        }

        public List<thisinh> GetThiSinhs()
        {
            List<thisinh> listThiSinhs = new List<thisinh>();
            using var dbcontext = new ApplicationContext();
            {
                
                var kq= (from ts in dbcontext.ThiSinh
                        join tg in dbcontext.ThamGia on ts.ID equals tg.ID
                        join td in dbcontext.TrinhDo on tg.maTrinhDo equals td.maTrinhDo
                        select new 
                        {
                            ID = ts.ID,
                            hoTen = ts.hoTen,
                            gioiTrinh = ts.gioiTrinh,
                            sdt = ts.sdt,
                            tenTrinhDo = td.tenTrinhDo
                        }


                    ).ToList();

                foreach (var thisinh in kq)
                {
                    thisinh data = new thisinh();
                    data.ID = thisinh.ID;
                    data.hoTen = thisinh.hoTen;
                    if (thisinh.gioiTrinh == true)
                    {
                        data.gioiTrinh = "Nữ";
                    }
                    else
                    {
                        data.gioiTrinh = "Nam";
                    }
                    data.sdt = thisinh.sdt;
                    data.tenTrinhDo = thisinh.tenTrinhDo;
                    listThiSinhs.Add(data);
                }
                return listThiSinhs;

            }

            

        }

        public ICollection<thisinh> GetThiSinhTheoTrinhDo(string tentrinhdo)
        {
            List<thisinh> listThiSinhs = new List<thisinh>();
            using var dbcontext = new ApplicationContext();
            {

                var kq = (from ts in dbcontext.ThiSinh
                          join tg in dbcontext.ThamGia on ts.ID equals tg.ID
                          join td in dbcontext.TrinhDo on tg.maTrinhDo equals td.maTrinhDo
                          where td.tenTrinhDo== tentrinhdo
                          select new
                          {
                              ID = ts.ID,
                              hoTen = ts.hoTen,
                              gioiTrinh = ts.gioiTrinh,
                              sdt = ts.sdt,
                              tenTrinhDo = td.tenTrinhDo
                          }


                    ).ToList();

                foreach (var thisinh in kq)
                {
                    thisinh data = new thisinh();
                    data.ID = thisinh.ID;
                    data.hoTen = thisinh.hoTen;
                    if (thisinh.gioiTrinh == true)
                    {
                        data.gioiTrinh = "Nam";
                    }
                    else
                    {
                        data.gioiTrinh = "Nữ";
                    }
                    data.sdt = thisinh.sdt;
                    data.tenTrinhDo = thisinh.tenTrinhDo;
                    listThiSinhs.Add(data);
                }
                return listThiSinhs;

            }

        }

        public class thisinh
        {
            public string ID { get; set; }
            public string hoTen { get; set; }

            public string gioiTrinh { get; set; }

            public string sdt { get; set; }
            public string tenTrinhDo { get; set; }
           

        }


        public ICollection<phongthi> GetPhongs()
        {
            List<phongthi> listPhongThi = new List<phongthi>();
            using var dbcontext = new ApplicationContext();
            {
               var kq= (from pt in dbcontext.PhongThi
                        join td in dbcontext.TrinhDo on pt.maTrinhDo equals td.maTrinhDo
                        select new
                        {
                            tenPhong= pt.tenPhong,
                            tenTrinhDo= td.tenTrinhDo,
                            caThi= pt.caThi
                        }

                    ).ToList();

                foreach (var phongthi in kq)
                {
                    phongthi data = new phongthi();
                    data.tenPhong = phongthi.tenPhong;
                    data.tenTrinhDo = phongthi.tenTrinhDo;
                    if (phongthi.caThi == true)
                    {
                        data.caThi = "Sáng";
                    }
                    else
                    {
                        data.caThi = "Chiều";
                    }
                    
                    listPhongThi.Add(data);
                }
                return listPhongThi;
            }

        }

        public ICollection<phongthi> GetPhongTheoTrinhDo(string tentrinhdo)
        {
            List<phongthi> listPhongThi = new List<phongthi>();
            using var dbcontext = new ApplicationContext();
            {
                var kq = (from pt in dbcontext.PhongThi
                          join td in dbcontext.TrinhDo on pt.maTrinhDo equals td.maTrinhDo
                          where td.tenTrinhDo== tentrinhdo
                          select new
                          {
                              tenPhong = pt.tenPhong,
                              tenTrinhDo = td.tenTrinhDo,
                              caThi = pt.caThi
                          }

                     ).ToList();

                foreach (var phongthi in kq)
                {
                    phongthi data = new phongthi();
                    data.tenPhong = phongthi.tenPhong;
                    data.tenTrinhDo = phongthi.tenTrinhDo;
                    if (phongthi.caThi == true)
                    {
                        data.caThi = "Sáng";
                    }
                    else
                    {
                        data.caThi = "Chiều";
                    }

                    listPhongThi.Add(data);
                }
                return listPhongThi;
            }

        }


        public class phongthi {
            public string tenPhong { get; set; }
            public string tenTrinhDo { get; set; }
            public string caThi { get; set; }


        }

        public ICollection<khoathi> GetKhoaThiTheoTrinhDo(string tentrinhdo)
        {
            using var dbcontext = new ApplicationContext();
            {
                return (from kt in dbcontext.KhoaThi
                        join tg in dbcontext.ThamGia on kt.maKhoaThi equals tg.maKhoaThi
                        join td in dbcontext.TrinhDo on tg.maTrinhDo equals td.maTrinhDo
                        where td.tenTrinhDo== tentrinhdo
                        select new khoathi 
                        {
                            tenKhoaThi = kt.tenKhoaThi,
                            tenTrinhDo = td.tenTrinhDo
                        }

                    ).Distinct().ToList();
            }

        }

        public ICollection<khoathi> GetKhoaThi()
        {
            using var dbcontext = new ApplicationContext();
            {
                return (from kt in dbcontext.KhoaThi
                        join tg in dbcontext.ThamGia on kt.maKhoaThi equals tg.maKhoaThi
                        join td in dbcontext.TrinhDo on tg.maTrinhDo equals td.maTrinhDo
                        select new khoathi
                        {
                            tenKhoaThi = kt.tenKhoaThi,
                            tenTrinhDo = td.tenTrinhDo
                        }

                    ).Distinct().ToList();
            }

        }

        public class khoathi
        {
            public string tenKhoaThi { get; set; }
            public string tenTrinhDo { get; set; }
 
        }


    }


    }

