using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3.CLASSES
{
    internal class ClCotxe
    {
        //Cada cotxe tindra la mida de 60,60
        Image[] cotxes = { Properties.Resources.fiat_500_100verd, Properties.Resources.suv_100verd, Properties.Resources.jeep_100, Properties.Resources.limousine_100granat };

        int cantitatcotxesperfila = 3;

        Panel panellPare;
        public Panel panellFill;

        public PictureBox pictureBoxCotxe;
        public Label segonscotxe;

        public Int32 cantitatsegonscotxe;

        Random r = new Random();


        public ClCotxe(Panel xPanellPare , int xsegonsnetejacotxe)
        {
            panellPare = xPanellPare;

            panellFill = new Panel();
            panellFill.BorderStyle = BorderStyle.FixedSingle;

            pictureBoxCotxe = new PictureBox();
            pictureBoxCotxe.Image = cotxes[r.Next(0, cotxes.Length - 1)];
            pictureBoxCotxe.Location = new Point(0, 0);
            pictureBoxCotxe.SizeMode = PictureBoxSizeMode.StretchImage;

            segonscotxe = new Label();
            cantitatsegonscotxe = xsegonsnetejacotxe;
            segonscotxe.Text = cantitatsegonscotxe.ToString();
            segonscotxe.Location = new Point(pictureBoxCotxe.Size.Width, pictureBoxCotxe.Size.Height);

            panellFill.Size = new Size(pictureBoxCotxe.Size.Width + 20, pictureBoxCotxe.Size.Height + 20);

            panellFill.Controls.Add(pictureBoxCotxe);
            panellFill.Controls.Add(segonscotxe);

            int cantitatactual = panellPare.Controls.Count;

            int posiciox = cantitatactual% cantitatcotxesperfila;
            int posicioy = cantitatactual/ cantitatcotxesperfila;

            panellFill.Location = new Point(posiciox * panellFill.Size.Width, posicioy * panellFill.Size.Height);
            panellPare.Controls.Add(panellFill);
            
        }
    }
}
