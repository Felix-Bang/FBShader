using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _3DTriangle
{
    class Triangle3D
    {
        private Vector4 a, b, c;
        public Vector4 A, B, C;
        float dot;
        private bool culBack;


        public Triangle3D() { }
        public Triangle3D(Vector4 point1,Vector4 point2, Vector4 point3)
        {
            this.A = this.a = new Vector4(point1);
            this.B = this.b = new Vector4(point2);
            this.C = this.c = new Vector4(point3);
        }

        //利用矩阵乘法进行变换
        public void Tranform(Matriax4x4 m)
        {
            this.a = m.Mul(this.A);
            this.b = m.Mul(this.B);
            this.c = m.Mul(this.C);
        }

        //计算法向量
        public void CalculateLighting(Matriax4x4 _Object2World,Vector4 L)
        {
            this.Tranform(_Object2World);

            Vector4 U = this.b - this.a;
            Vector4 V= this.c - this.a;
            Vector4 normal = U.Cross(V);
            dot = normal.Normalized.Dot(L.Normalized);
            dot = Math.Max(0,dot);  //将点积限定到0-1的范围

            //摄像机（视线）向量
            Vector4 eye = new Vector4(0,0,-1,0);
            //判断是否剔除背面
            culBack = normal.Normalized.Dot(eye) < 0 ? true : false;

        }

        public void Draw(Graphics g,bool isLine)
        {
            //g.TranslateTransform(540,240);
            if (isLine)
                g.DrawLines(new Pen(Color.Yellow, 2), Get2DPontFArr());
            else
            {
                //如果不需要剔除
                if (!culBack)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(Get2DPontFArr());
                    int r = (int)(200 * dot) + 55;   //防止黑色是完全看不见
                    Color col = Color.FromArgb(r, r, r);
                    Brush br = new SolidBrush(col);
                    g.FillPath(br, path);
                }
            }
        }

        private PointF[] Get2DPontFArr()
        {
            PointF[] arr = new PointF[4];
            arr[0] = Get2DPointF(this.a);
            arr[1] = Get2DPointF(this.b);
            arr[2] = Get2DPointF(this.c);
            arr[3] = Get2DPointF(this.a);
            return arr;
        }


        private PointF Get2DPointF(Vector4 v)
        {
            PointF p = new PointF
            {
                X = (float)(v.x / v.w),
                Y = -(float)(v.y / v.w)
            };
            return p;
        }
    }
}
