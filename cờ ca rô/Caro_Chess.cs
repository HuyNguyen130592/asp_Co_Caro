using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cờ_ca_rô
{
    class Caro_Chess
    {
        public O_Co[,] Mang_O_Co;
        public O_Co oco = new O_Co() ;
        public Ban_Co ban_co;
        public int Luot_Di;
        public bool SanSang = true;
        public Stack<O_Co> Cac_Nuoc_Da_Di = new Stack<O_Co> { };
        public Stack<O_Co> Cac_Nuoc_Di_Lai = new Stack<O_Co> { };
        public Caro_Chess()
        {
            Luot_Di = 1;
            ban_co = new Ban_Co(20, 20);
            Mang_O_Co = new O_Co[20, 20];
            KhoiTaoMangOCo();
        }
        public void KhoiTaoMangOCo()
        {
            for (int i = 1; i < ban_co.SoCot; i++)
            {
                for (int j = 1; j < ban_co.SoDong; j++)
                {
                    Point p = new Point(i, j);
                    Mang_O_Co[i, j] = new O_Co(p, 0);
                   
                   

                }

            }
            return;
        }
        public bool DanhCo(Graphics g, double x, double y)
        {
            
            Point p = new Point();
            p = ban_co.TinhViTri(x, y);
            Point p0 = new Point(0, 0);
            SolidBrush slb;
            if (p != p0)
            {
                if (Mang_O_Co[p.X, p.Y].SoHuu == 0)
                {
                    if (Luot_Di==1)
                    {
                         slb = new SolidBrush(Color.White); 
                    }
                    else
                    {
                        slb = new SolidBrush(Color.Black);
                    }
                    VeQuanCo(g, p,slb);
                    Mang_O_Co[p.X, p.Y].SoHuu = Luot_Di;
                    Cac_Nuoc_Da_Di.Push(Mang_O_Co[p.X, p.Y]);
                    if (DuyetChienThang(Mang_O_Co[p.X, p.Y])==false)
                    {
                        ThongBaoKetQua(Luot_Di);
                    }
                    if (Luot_Di == 1)
                    {
                        Luot_Di = 2;
                    }
                    else
                    {
                        Luot_Di = 1;
                    }

                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public void VeQuanCo(Graphics g, Point p, SolidBrush slbs)
        {

                Point p1 = new Point(p.X * 25 - 25, p.Y * 25 - 25);
                g.FillEllipse(slbs, p1.X, p1.Y, 24, 24);
           
        }
        public void VeBanCo(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1f);
            Point p1 = new Point();
            Point p2 = new Point();
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;
           
            for (int i = 0; i <= ban_co.SoDong; i++)
            {

                x1 = i * oco.chieucao;
                y1 = 0;
                x2 = x1;
                y2 = ban_co.SoDong * oco.chieurong;
                p1 = new Point(x1, y1);
                p2 = new Point(x2, y2);
                g.DrawLine(pen, p1, p2);

            }
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
            for (int j = 0; j <= ban_co.SoDong; j++)
            {
                x1 = 0;
                y1 = j * oco.chieucao;
                x2 = ban_co.SoDong * oco.chieurong;
                y2 = y1;
                p1 = new Point(x1, y1);
                p2 = new Point(x2, y2);
                g.DrawLine(pen, p1, p2);

            }

        }
        public void VeLaiQuanCo(Graphics g)
        {
            SolidBrush slb;
            foreach (O_Co quanco in Cac_Nuoc_Da_Di)
            {
                if(quanco.SoHuu==1)
                {
                    slb = new SolidBrush(Color.White);

                }
                else
                {
                    slb = new SolidBrush(Color.Black);
                }
                VeQuanCo(g, quanco.ViTri,slb);
            }
        }
        #region duyetchienthang
            public bool DuyetDungTren(O_Co oco)
            {
                for (int j = oco.ViTri.Y - 1; j >= oco.ViTri.Y - 4; j--)
                {
                    if (Mang_O_Co[oco.ViTri.X, j].SoHuu != oco.SoHuu)
                    {
                        return false;
                    }
               
                }
                return true;
            }
            public bool DuyetDungDuoi(O_Co oco)
            {
                for (int j = oco.ViTri.Y + 1; j <= oco.ViTri.Y + 4; j++)
                {
                    if (Mang_O_Co[oco.ViTri.X, j].SoHuu != oco.SoHuu)
                    {
                        return false;
                    }
                }
                return true;
            }
            public bool DuyetNgangTrai(O_Co oco)
            {
                for (int i = oco.ViTri.X - 1; i >= oco.ViTri.X - 4; i--)
                {
                    if (Mang_O_Co[i, oco.ViTri.Y].SoHuu != oco.SoHuu)
                    {
                        return false;
                    }
                }
                return true;
            } 
            public bool DuyetNgangPhai(O_Co oco)
            {
                for (int i = oco.ViTri.X + 1; i <= oco.ViTri.X + 4; i++)
                {
                    if (Mang_O_Co[i, oco.ViTri.Y].SoHuu != oco.SoHuu)
                    {
                        return false;
                    }
                }
                return true;
            }
            public bool DuyetPhaiTren(O_Co oco)
            {
                int a1 = 1;
                while (a1 <= 4)
                {
                    if (Mang_O_Co[oco.ViTri.X + a1, oco.ViTri.Y + a1].SoHuu != oco.SoHuu)
                    {
                        return false;
                    }
                    a1++;
                }
                return true;
            }
            public bool DuyetTraiDuoi(O_Co oco)
            {
                int a2 = 1;
                while (a2 <= 4)
                {
                    if (Mang_O_Co[oco.ViTri.X - a2, oco.ViTri.Y - a2].SoHuu != oco.SoHuu)
                    {
                        return false;

                    }
                    a2++;
                }
                return true;
            }
            public bool DuyetPhaiDuoi(O_Co oco)
            {
                int a3 = 1;
                while (a3 <= 4)
                {
                    if (Mang_O_Co[oco.ViTri.X + a3, oco.ViTri.Y - a3].SoHuu != oco.SoHuu)
                    {
                        return false;
                    }
                    a3++;
                }
                return true;
            }
            public bool DuyetTraiTren(O_Co oco)
            {
                int a4 = 1;
                while (a4 <= 4)
                {
                    if (Mang_O_Co[oco.ViTri.X - a4, oco.ViTri.Y + a4].SoHuu != oco.SoHuu)
                    {
                        return false;

                    }
                    a4++;
                }
                return true;
            }
        #endregion

        public bool DuyetChienThang( O_Co oco)
        {
            if(DuyetDungDuoi(oco)||DuyetDungTren(oco) || DuyetNgangPhai(oco) || DuyetNgangTrai(oco) || DuyetPhaiDuoi(oco) || DuyetPhaiTren(oco) || DuyetTraiDuoi(oco) || DuyetTraiTren(oco))
            {
                return false;
            }
            
            
            return true;
        }

        public void ThongBaoKetQua(int luotdi)
        {
            switch (luotdi)
            {
                case 1:
                    MessageBox.Show("Chúc Mừng người chơi 1 đã chiến thắng");
                    break;
                case 2:
                    MessageBox.Show("Chúc mứng người chơi 2 đã chiến thắng");
                    break;    

            }
        }
    }
}
