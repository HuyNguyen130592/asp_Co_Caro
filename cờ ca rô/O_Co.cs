using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cờ_ca_rô
{
    class O_Co
    {
        public  int _ChieuRong = 25;
        public   int _ChieuCao = 25;
        int _SoHuu;
        Point _ViTri;
       
        public Point ViTri
        {
            get { return _ViTri; }
            set { _ViTri = value; }
        }
        public int chieucao
        {
            get { return _ChieuCao; }
        }
        public int chieurong
        {
            get { return _ChieuRong; }
        }
        public int SoHuu
        {
            get
            {
                return _SoHuu;
            }
            set
            {
                _SoHuu = value;
            }
        }
       public O_Co() { }
       public O_Co(Point p, int sohuu)
        {
           this._ViTri = p;
           this._SoHuu = sohuu;
        }
    }
}
