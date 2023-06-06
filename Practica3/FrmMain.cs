using Practica3.CLASSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3
{
    public partial class FrmMain : Form
    {
        List<Thread> llThreadsCarWasher = new List<Thread>();

        Mutex exclusioMutua = new Mutex();

        List<ClCotxe>llCotxes = new List<ClCotxe>();
        List<ClCarWash>llCarWash = new List<ClCarWash>();

        

        int cantitatCarWash = 4;

        int cantitatcotxesperfila = 3;

        int segonspernetejarcotxe = 5;

        FrmMain frmPrincipal;

        delegate void delegacio();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            frmPrincipal = this;
            for(int i = 1; i <= cantitatCarWash; i++)
            {
                exclusioMutua.WaitOne();
                ClCarWash carWash = new ClCarWash(this,new Point(250,125*i),llCotxes);
                carWash.shaacabatnetejar += new EventHandler(refrescarllista);
                llCarWash.Add(carWash);
                llThreadsCarWasher.Add(new Thread(carWash.startTimer));
                llThreadsCarWasher[llThreadsCarWasher.Count - 1].Start();
                //System.Threading.Thread.Sleep(5);
                //Aqui hauria d'afegir el 
                exclusioMutua.ReleaseMutex();
            }
            pnlCotxesTotals.Location = new Point(800, 41);
        }

        private void refrescarllista(object sender, EventArgs e)
        {
            
            this.Invoke(new delegacio(borrarllista));
            
            
        }

        

        private void borrarllista()
        {
            
            pnlCotxesTotals.Controls.Clear();
            exclusioMutua.WaitOne();
            foreach (ClCotxe cotxe in llCotxes)
            {
                
                int cantitatactual = pnlCotxesTotals.Controls.Count;
                
                int posiciox = cantitatactual % cantitatcotxesperfila;
                int posicioy = cantitatactual / cantitatcotxesperfila;
                cotxe.panellFill.Location = new Point(posiciox * cotxe.panellFill.Size.Width, posicioy * cotxe.panellFill.Size.Height);
                pnlCotxesTotals.Controls.Add(cotxe.panellFill);
                
            }
            exclusioMutua.ReleaseMutex();

        }

        

        private void btnCrearCotxe_Click(object sender, EventArgs e)
        {
            exclusioMutua.WaitOne();
            ClCotxe cotxe = new ClCotxe(pnlCotxesTotals, segonspernetejarcotxe);
            llCotxes.Add(cotxe);
            exclusioMutua.ReleaseMutex();
        }

        private void rbBasic_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Text == "Basic")
            {
                segonspernetejarcotxe = 5;
            }
            if (((RadioButton)sender).Text == "Normal")
            {
                segonspernetejarcotxe = 10;
            }
            if (((RadioButton)sender).Text == "Extra")
            {
                segonspernetejarcotxe = 15;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ClCarWash m in llCarWash)
            {
                m.pararTimer();
            }
        }
    }
}
