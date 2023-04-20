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
                int edge1 = Convert.ToInt32(txtedge1.Text);
                int edge2 = Convert.ToInt32(txtedge2.Text);
                String[] c1 = vertices[edge1].Split('-');
                String[] c2 = vertices[edge2].Split('-');

                int xcoordinate1 = Convert.ToInt32(c1[0]);
                int ycoordinate1 = Convert.ToInt32(c1[1]);

                int xcoordinate2 = Convert.ToInt32(c2[0]);
                int ycoordinate2 = Convert.ToInt32(c2[1]);

                graph.DrawLine(new Pen(Brushes.Green, 3), (xcoordinate1 + 12), (ycoordinate1 + 12), (xcoordinate2 + 12), (float)(ycoordinate2 + 12));

                // calculate distance
                double x = (double)(xcoordinate2 - xcoordinate1);
                double y = (double)(ycoordinate2 - ycoordinate1);
                double d = Math.Sqrt(Math.Pow(x,2)+ Math.Pow(y,2));
                int a = (int)(xcoordinate1 +xcoordinate2)/2;
                int b = (int)(ycoordinate1 + ycoordinate2)/2-5;
                graph.DrawString(Math.Round(d,2).ToString(), new Font("Arial",12), Brushes .Maroon,a ,b);

                matrix[edge1, edge2] = Convert.ToInt32(d);
                matrix[edge2, edge1] = Convert.ToInt32(d);


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
                
                graph.DrawString(countnodes.ToString(), new Font("Arial", 12), Brushes.White, e.X + 14, e.Y + 14);
                //the number that will appear based on the counter of the nodes that been created
                vertices[countnodes] = e.X + "-" + e.Y;
                countnodes++;

                dataGridView1.Columns.Add("", (countnodes - 1).ToString());
                dataGridView1.AutoResizeColumns();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[countnodes - 1].HeaderCell.Value = (countnodes - 1).ToString();
                dataGridView1.AutoResizeRows();


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
