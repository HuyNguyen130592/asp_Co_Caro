using cờ_ca_rô;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cờ_ca_rô
{
    class Ban_Co
    {
        int _SoDong;
        int _SoCot;
        
        public int SoDong
        {
            get
            {
                return _SoDong;
            }
            set
            {
                _SoDong = value;
            }
        }
        public int SoCot
        {
            get
            {
                return _SoCot;
            }
            set
            {
                _SoCot = value;

            }
        }
        public Ban_Co(int sodong, int socot)
        {
            _SoCot = socot;
            _SoDong = sodong;
        }
        
        public Point TinhViTri(double i,double j)
        {
            Point p = new Point(); ;
            int a;
            int b;
            
            if (i % 25 != 0)
            {
                a = (int)i/25+1; }
            else
            {
                return p;
            }
            if(j % 25 != 0)
            {
             b = (int)j/25+1;
            }
            else
            {
                return p;
            }
            p = new Point(a,b);
            return p;
        }
        

        

    }
}
