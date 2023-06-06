using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Practica3.CLASSES
{
    internal class ClCarWash
    {
        Timer tm = new Timer();
        Button btnArrancarCarWash = new Button();
        PictureBox pictureBoxCotxe = new PictureBox();
        Panel p = new Panel();

        private Mutex exclusioMutua = new Mutex();

        ClCotxe cotxe = null;
        List<ClCotxe> llCotxes;

        FrmMain frPare;

        Label labelcontador = new Label();
        Int32 contadornumero = 0;

        delegate void delegacio();

        public event EventHandler shaacabatnetejar;

        public ClCarWash(FrmMain xForm, Point xPoint, List<ClCotxe>xllCotxes)
        {
            frPare = xForm;
            llCotxes = xllCotxes;

            p.Location = xPoint;
            p.Size = new Size(200, 100);
            p.BorderStyle = BorderStyle.FixedSingle;

            pictureBoxCotxe.Size = new Size(150, 75);
            pictureBoxCotxe.Location = new Point(0, 0);
            pictureBoxCotxe.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Controls.Add(pictureBoxCotxe);

            //Arranquem el boto en verd per que no tenim arrancat encara el car wash
            btnArrancarCarWash.BackColor = Color.Red;
            btnArrancarCarWash.Text = "Parar";
            btnArrancarCarWash.Location = new Point(xPoint.X + 215, xPoint.Y + 50);
            btnArrancarCarWash.Size = new Size(75, 35);
            btnArrancarCarWash.Click += BtnArrancarCarWash_Click;
            
            btnArrancarCarWash.FlatStyle = FlatStyle.Flat;

            frPare.Controls.Add(p);
            frPare.Controls.Add(btnArrancarCarWash);

            labelcontador.Location = new Point(10, pictureBoxCotxe.Bottom);
            labelcontador.BorderStyle = BorderStyle.FixedSingle;
            labelcontador.AutoSize = true;
            labelcontador.BringToFront();

            p.Controls.Add(labelcontador);

            initimer();
        }

        private void BtnArrancarCarWash_Click(object sender, EventArgs e)
        {
            if(((Button)sender).BackColor == Color.LimeGreen) //Si te el color verd sabrem que ara mateix esta parat i s'haura de fer una altre cosa
            {
                btnArrancarCarWash.BackColor = Color.Red;
                btnArrancarCarWash.Text = "Parar";
                
                startTimer();
            }
            else //Voldra dir que tindra el color vermell
            {
                btnArrancarCarWash.BackColor = Color.LimeGreen;
                btnArrancarCarWash.Text = "Arrancar";
                pararTimer();
                
            }
        }

        private void initimer()
        {
            tm.Interval = 1000;
            tm.Elapsed += new ElapsedEventHandler(rentarcotxe);
        }

        private void rentarcotxe(object sender, System.Timers.ElapsedEventArgs e)
        {
            tm.Stop();
            exclusioMutua.WaitOne();
            if (cotxe == null)
            {
                agafarcotxe();
                //Agafar cotxe
                if(cotxe != null)
                {
                    pictureBoxCotxe.Image = cotxe.pictureBoxCotxe.Image;
                    pictureBoxCotxe.SizeMode = PictureBoxSizeMode.StretchImage;
                    frPare.Invoke(new delegacio(assignartext));
                    shaacabatnetejar(this, EventArgs.Empty);

                }
            }
            else
            {
                frPare.Invoke(new delegacio(restarcontador));
                //Descontar 1 segon timer total rentat, si contador == 0
                if(contadornumero == 0)
                {
                    frPare.Invoke(new delegacio(treurecotxerentacotxes));

                    shaacabatnetejar(this,EventArgs.Empty);
                    
                    cotxe = null;

                }
            }
            exclusioMutua.ReleaseMutex();
            tm.Start();

        }

        private void assignartext()
        {
            labelcontador.Text = contadornumero.ToString();
        }

        private void treurecotxerentacotxes()
        {
            pictureBoxCotxe.Image = null;
            labelcontador.Text = "";
        }

        private void restarcontador()
        {
            contadornumero--;
            labelcontador.Text = contadornumero.ToString();
        }
        private void agafarcotxe()
        {
            exclusioMutua.WaitOne();
            if (llCotxes.Count > 0)
            {
                //exclusioMutua.WaitOne();
                cotxe = llCotxes[0];
                contadornumero = cotxe.cantitatsegonscotxe;
                if(cotxe != null)
                {
                    llCotxes.Remove(cotxe);
                }
                
                    
                //exclusioMutua.ReleaseMutex();
                
            }
            exclusioMutua.ReleaseMutex();
        }

        public void startTimer()
        {
            tm.Start();
        }

        public void pararTimer()
        {
            tm.Stop();
        }
    }
}
