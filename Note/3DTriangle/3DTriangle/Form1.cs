using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DTriangle
{
    public partial class Form1 : Form
    {
        int degree;                                 // 旋转角度
        Triangle3D t;                               // 3D三角形
        Matriax4x4 m_scale;                         // 缩放矩阵
        Matriax4x4 m_rotationX;                     // X旋转矩阵
        Matriax4x4 m_rotationY;                     // Y旋转矩阵
        Matriax4x4 m_rotationZ;                     // Z旋转矩阵
        Matriax4x4 m_view;                          // 摄像机矩阵
        Matriax4x4 m_projection;                    // 投影矩阵

        Cube cube;
        public Form1()
        {
            InitializeComponent();
            m_scale = new Matriax4x4();
            m_scale[1, 1] = 250;
            m_scale[2, 2] = 250;
            m_scale[3, 3] = 250;
            m_scale[4, 4] = 1;

            cube = new Cube();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Vector4 a = new Vector4(0, 0.5f, 0, 1);
            Vector4 b = new Vector4(0.5f, -0.5f, 0, 1);
            Vector4 c = new Vector4(-0.5f, -0.5f, 0, 1);
            t = new Triangle3D(a,b,c);

            m_view = new Matriax4x4();
            m_view[1, 1] = 1;
            m_view[2, 2] = 1;
            m_view[3, 3] = 1;
            m_view[4, 3] = 250;
            m_view[4, 4] = 1;

            m_projection = new Matriax4x4();
            m_projection[1, 1] = 1;
            m_projection[2, 2] = 1;
            m_projection[3, 3] = 1;
            m_projection[3, 4] = 1.0 / 250;
            m_projection[4, 4] = 0;

            m_rotationX = new Matriax4x4();
            m_rotationY = new Matriax4x4();
            m_rotationZ = new Matriax4x4();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //绘制三角形
            //t.Draw(e.Graphics);

            //绘制Cube
            cube.Draw(e.Graphics, this.checkLine.Checked);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            degree++;
            double radian = Math.PI * degree / 180;

            // ---------------- X -----------------------
            m_rotationX[1, 1] = 1;
            m_rotationX[2, 2] = Math.Cos(radian);
            m_rotationX[2, 3] = Math.Sin(radian);
            m_rotationX[3, 2] = -Math.Sin(radian);
            m_rotationX[3, 3] = Math.Cos(radian);
            m_rotationX[4, 4] = 1;
            // ---------------- Y -----------------------
            m_rotationY[1, 1] = Math.Cos(radian);
            m_rotationY[1, 3] = Math.Sin(radian);
            m_rotationY[2, 2] =1;
            m_rotationY[3, 1] = -Math.Sin(radian);
            m_rotationY[3, 3] = Math.Cos(radian);
            m_rotationY[4, 4] = 1;
            // ---------------- Z -----------------------
            m_rotationZ[1, 1] = Math.Cos(radian);
            m_rotationZ[1, 2] = Math.Sin(radian);
            m_rotationZ[2, 1] = -Math.Sin(radian);
            m_rotationZ[2, 2] = Math.Cos(radian);
            m_rotationZ[3, 3] = 1;
            m_rotationZ[4, 4] = 1;



            if (this.checkBox1.Checked)
            {
                Matriax4x4 tX = m_rotationX.Transpose();
                m_rotationX = m_rotationX.Mul(tX);
            }

            if (this.checkBox2.Checked)
            {
                Matriax4x4 tY = m_rotationY.Transpose();
                m_rotationY = m_rotationY.Mul(tY);
            }

            if (this.checkBox3.Checked)
            {
                Matriax4x4 tZ = m_rotationZ.Transpose();
                m_rotationZ = m_rotationZ.Mul(tZ);
            }

            Matriax4x4 mAll = m_rotationX.Mul(m_rotationY.Mul(m_rotationZ));
            Matriax4x4 m = m_scale.Mul(mAll);

            //计算光照              光照向量
            // t.CalculateLighting(m, new Vector4(-1, 1, -1, 0));

            cube.CalculateLighting(m, new Vector4(-1, 1, -1, 0));

            Matriax4x4 mv = m.Mul(m_view);
            Matriax4x4 mvp = mv.Mul(m_projection);
            //t.Tranform(mvp);
            cube.Transform(mvp);
            this.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            m_view[4, 3] = (sender as TrackBar).Value;
        }
    }
}
