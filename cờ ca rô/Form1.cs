using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cờ_ca_rô
{
    
    public partial class Form1 : Form
    {
       
        public Graphics grs;
        Caro_Chess caro_chess = new Caro_Chess();
        public Form1()
        {
            InitializeComponent();
            grs = pnl1.CreateGraphics();
           
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            caro_chess.VeBanCo(grs);
            caro_chess.VeLaiQuanCo(grs);
           
        }

        private void pnl1_MouseClick(object sender, MouseEventArgs e)
        {
           
                      
            caro_chess.DanhCo(grs, e.X, e.Y);
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 abv = new Form2();
            abv.Show();
        }
    }
}
