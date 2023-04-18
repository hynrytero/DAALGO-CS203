using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS203
{
    public partial class Form1 : Form
    {
        //global variables
        bool stopcreate;
        int[,] matrix; //serve as the adjacent matrix
        int countnodes;//counter
        String[] vertices;//nodes
        Graphics graph;
        public Form1()
        {

            InitializeComponent();
            setclear();
        }
        //method to set
       public void setclear()
        {
             //set the initialization of variables to clear
             graph = picgraph.CreateGraphics();
            stopcreate = false;
            matrix = new int[50, 50];
            vertices = new string[50];
            countnodes = 0;

        }

        private void txtedge2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnadjacentnodes_Click(object sender, EventArgs e)
        {
            if (stopcreate == true)
            {

                //set or define the adjacent of tw

            }



        }

        private void btncreatenodes_Click(object sender, EventArgs e)
        {
            stopcreate = false;
        }

        private void picgraph_MouseClick(object sender, MouseEventArgs e)
        {
            //when you click the mouse at the leftside
            if(e.Button==MouseButtons.Left && stopcreate!=true)
            {
                Rectangle rect = new Rectangle(e.X, e.Y, 35, 37);

                //define the location of x and y coordinate and the size 
                //of the nodes that created
                graph.FillEllipse(Brushes.Black, rect);

                //the number and color of the nodes
                countnodes++;
                graph.DrawString(countnodes.ToString(), new Font("Arial", 12), Brushes.White, e.X + 14, e.Y + 14);
                //the number that will appear based on the counter of the nodes that been created

            }
            else
            {
                stopcreate = true;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setclear();
        }
    }
}
