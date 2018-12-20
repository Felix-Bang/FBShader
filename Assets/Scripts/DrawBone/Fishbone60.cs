//  Felix-Bang：Fishbone60
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：鱼骨铺（60）
// Createtime：2018/11/22

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Felix
{
	public class Fishbone60 : MonoBehaviour
	{
        #region 字段
        [SerializeField] private Texture[] images;
        [SerializeField] private int aspect = 3;           //单块砖的长 ：宽比
        //---------- 顶点属性 ----------
        private GameObject[] meshObjs;
        private Vector3[] allVertices;
        private Vector3[] vertices;//顶点数
        private Vector2[] uvs;//uvs坐标
        private int[] triangles;//三角形索引
        private Material[] materials;
        //---------- 顶点属性 ----------
        #endregion
        #region Unity回调
        void Start () 
		{
            InitMeshesInfo();       
        }
        #endregion

        #region 方法
       

        private void InitMeshesInfo()
        {
            float x1, x2, x3, x4, x5;
            float y1, y2, y3, y4, y5;
            if (aspect == 3)
            {
                x1 = (float)(-2.25 + 0.25 * Math.Sqrt(3));
                x2 = (float)(-Math.Sqrt(3));
                x3 = 0f;
                x4 = (float)(Math.Sqrt(3));
                x5 = (float)(2.25 - 0.25 * Math.Sqrt(3));


                y1 = 0;
                y2 = (float)(2.25 - 0.75 * Math.Sqrt(3));
                y3 = 1;
                y4 = (float)(3.25 - 0.75 * Math.Sqrt(3));
                y5 = 2;
            }
            else if (aspect == 4)
            {
                x1 = (float)(-3 + Math.Sqrt(3) / 4);
                x2 = (float)(-Math.Sqrt(3));
                x3 = 0f;
                x4 = (float)(Math.Sqrt(3));
                x5 = (float)(3 - Math.Sqrt(3) / 4);


                y1 = 0;
                y2 = (float)(2.25 - Math.Sqrt(3));
                y3 = 1;
                y4 = (float)(3.25 - Math.Sqrt(3));
                y5 = 2;
            }
            else
            {
                x1 = 0;
                x2 = 0;
                x3 = 0;
                x4 = 0;
                x5 = 0;
                y1 = 0;
                y2 = 0;
                y3 = 0;
                y4 = 0;
                y5 = 0;
            }


            meshObjs = new GameObject[8];

            allVertices = new Vector3[15] {
                     new Vector3(x1,y1,0),
                     new Vector3(x1,y2,0),
                     new Vector3(x1,y4,0),
                     new Vector3(x1,y5,0),

                     new Vector3(x2,y1,0),
                     new Vector3(x2,y5,0),

                     new Vector3(x3,y1,0),
                     new Vector3(x3,y3,0),
                     new Vector3(x3,y5,0),

                      new Vector3(x4,y1,0),
                     new Vector3(x4,y5,0),

                     new Vector3(x5,y1,0),
                     new Vector3(x5,y2,0),
                     new Vector3(x5,y4,0),
                     new Vector3(x5,y5,0),
                     };

            materials = new Material[4] {
                    new Material(Shader.Find("Mobile/Diffuse")) { mainTexture = images[0] },
                    new Material(Shader.Find("Mobile/Diffuse")) { mainTexture = images[0] },
                    new Material(Shader.Find("Mobile/Diffuse")) { mainTexture = images[0] },
                    new Material(Shader.Find("Mobile/Diffuse")) { mainTexture = images[0] },
                };

            if (aspect == 3)
                DrawThreeMeshes();
            else if (aspect == 4)
                DrawFourMeshes();
            else
                return;
        }

        private void DrawThreeMeshes()
        {
            vertices = new Vector3[]
              {
                  allVertices[4],
                  allVertices[7],
                  allVertices[6],
              };

            uvs = new Vector2[]
              {
                  new Vector2((float)(1-Math.Sqrt(3)*4/9), 1),
                  new Vector2(1, 1),
                  new Vector2((float)(1-Math.Sqrt(3)/9), 0),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(0);

            vertices = new Vector3[]
              {
                  allVertices[0],
                  allVertices[1],
                  allVertices[8],
                  allVertices[7],
                  allVertices[4],
              };

            uvs = new Vector2[]
              {
                    new Vector2((float)(0.5f-5*Math.Sqrt(3)/18), (float)(0.75*Math.Sqrt(3)-1.25f)),
                    new Vector2((float)(Math.Sqrt(3)/9f), 1),
                    new Vector2(1, 1),
                    new Vector2((float)(1 - Math.Sqrt(3)/9f), 0),
                    new Vector2((float)(1 - 5 * Math.Sqrt(3)/9f), 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };
            DrawMesh(1);

            vertices = new Vector3[]
              {
                   allVertices[1],
                   allVertices[2],
                   allVertices[5],
                   allVertices[8],
              };

            uvs = new Vector2[]
              {
                    new Vector2(0, 0),
                    new Vector2((float)(Math.Sqrt(3)/9f), 1),
                    new Vector2((float)(1 - Math.Sqrt(3)*4/9f), 1),
                    new Vector2((float)(1 - Math.Sqrt(3)/9f), 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(2);

            vertices = new Vector3[]
              {
                   allVertices[2],
                   allVertices[3],
                   allVertices[5],
              };

            uvs = new Vector2[]
              {
                    new Vector2(0, 0),
                    new Vector2((float)(0.5f-5*Math.Sqrt(3)/18), (float)(0.75*Math.Sqrt(3)-1.25f)),
                    new Vector2((float)(1 - 5 * Math.Sqrt(3)/9f), 0),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(3);

            vertices = new Vector3[]
            {
                  allVertices[6],
                  allVertices[7],
                  allVertices[9],
            };

            uvs = new Vector2[]
              {
                  new Vector2((float)(Math.Sqrt(3)/9f), 0),
                  new Vector2(0, 1),
                  new Vector2((float)(4*Math.Sqrt(3)/9), 1),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(4);

            vertices = new Vector3[]
            {
                  allVertices[7],
                  allVertices[8],
                  allVertices[12],
                  allVertices[11],
                  allVertices[9],
            };

            uvs = new Vector2[]
              {
                    new Vector2((float)(Math.Sqrt(3)/9f), 0),
                    new Vector2(0, 1),
                    new Vector2((float)(1 - Math.Sqrt(3)/9f), 1),
                    new Vector2((float)(0.75f+5*Math.Sqrt(3)/36), (float)(0.375*Math.Sqrt(3)-0.625f)),
                    new Vector2((float)(5* Math.Sqrt(3)/9f), 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };
            DrawMesh(5);

            vertices = new Vector3[]
             {
                   allVertices[8],
                   allVertices[10],
                   allVertices[13],
                   allVertices[12],
                  
             };

            uvs = new Vector2[]
              {
                    new Vector2((float)(Math.Sqrt(3)/9f), 0),
                    new Vector2((float)(4 * Math.Sqrt(3)/9f), 1),
                    new Vector2((float)(1 - Math.Sqrt(3)/9f), 1),
                    new Vector2(1 , 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(6);

            vertices = new Vector3[]
             {
                   allVertices[10],
                   allVertices[14],
                   allVertices[13],
             };

            uvs = new Vector2[]
             {
                    new Vector2((float)(5 * Math.Sqrt(3)/9f), 0),
                    new Vector2((float)(0.75f+5*Math.Sqrt(3)/36), (float)(0.375*Math.Sqrt(3)-0.625f)),
                    new Vector2(1, 0),
             };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(7);
        }

        private void DrawFourMeshes()
        {
            vertices = new Vector3[]
              {
                  allVertices[4],
                  allVertices[7],
                  allVertices[6],
              };

            uvs = new Vector2[]
              {
                  new Vector2((float)(1-Math.Sqrt(3)/3), 1),
                  new Vector2(1, 1),
                  new Vector2((float)(1-Math.Sqrt(3)/12), 0),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(0);

            vertices = new Vector3[]
              {
                  allVertices[0],
                  allVertices[1],
                  allVertices[8],
                  allVertices[7],
                  allVertices[4],
              };

            uvs = new Vector2[]
              {
                    new Vector2((float)(0.25f-5*Math.Sqrt(3)/48), (float)(Math.Sqrt(3)-1.25f)),
                    new Vector2((float)(Math.Sqrt(3)/12f), 1),
                    new Vector2(1, 1),
                    new Vector2((float)(1 - Math.Sqrt(3)/12f), 0),
                    new Vector2((float)(1 - 5 * Math.Sqrt(3)/12f), 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };
            DrawMesh(1);

            vertices = new Vector3[]
              {
                   allVertices[1],
                   allVertices[2],
                   allVertices[5],
                   allVertices[8],
              };

            uvs = new Vector2[]
              {
                    new Vector2(0, 0),
                    new Vector2((float)(Math.Sqrt(3)/12f), 1),
                    new Vector2((float)(1 - Math.Sqrt(3)/3f), 1),
                    new Vector2((float)(1 - Math.Sqrt(3)/12f), 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(2);

            vertices = new Vector3[]
              {
                   allVertices[2],
                   allVertices[3],
                   allVertices[5],
              };

            uvs = new Vector2[]
              {
                    new Vector2(0, 0),
                    new Vector2((float)(0.25f-5*Math.Sqrt(3)/48), (float)(Math.Sqrt(3)-1.25f)),
                    new Vector2((float)(1 - 5 * Math.Sqrt(3)/12f), 0),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(3);

            vertices = new Vector3[]
            {
                  allVertices[6],
                  allVertices[7],
                  allVertices[9],
            };

            uvs = new Vector2[]
              {
                  new Vector2((float)(Math.Sqrt(3)/12f), 0),
                  new Vector2(0, 1),
                  new Vector2((float)(Math.Sqrt(3)/3), 1),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(4);

            vertices = new Vector3[]
            {
                  allVertices[7],
                  allVertices[8],
                  allVertices[12],
                  allVertices[11],
                  allVertices[9],
            };

            uvs = new Vector2[]
              {
                  new Vector2((float)(Math.Sqrt(3)/12f), 0),
                  new Vector2(0, 1),
                  new Vector2((float)(1 - Math.Sqrt(3)/12f), 1),
                  new Vector2((float)(0.75f+5*Math.Sqrt(3)/48), (float)(Math.Sqrt(3)-1.25f)),
                  new Vector2((float)(5* Math.Sqrt(3)/12f), 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };
            DrawMesh(5);

            vertices = new Vector3[]
             {
                   allVertices[8],
                   allVertices[10],
                   allVertices[13],
                   allVertices[12],

             };

            uvs = new Vector2[]
              {
                    new Vector2((float)(Math.Sqrt(3)/12f), 0),
                    new Vector2((float)(Math.Sqrt(3)/3f), 1),
                    new Vector2((float)(1 - Math.Sqrt(3)/12f), 1),
                    new Vector2(1 , 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(6);

            vertices = new Vector3[]
             {
                   allVertices[10],
                   allVertices[14],
                   allVertices[13],
             };

            uvs = new Vector2[]
             {
                    new Vector2((float)(5 * Math.Sqrt(3)/12f), 0),
                    new Vector2((float)(0.75f+5*Math.Sqrt(3)/48), (float)(Math.Sqrt(3)-1.25f)),
                    new Vector2(1, 0),
             };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(7);
        }


        private void DrawFiveMeshes()
        {
            vertices = new Vector3[] {
                allVertices[4],
                allVertices[9],
                allVertices[8],
            };
            uvs = new Vector2[]{
                new Vector2(3/5f,1),
                new Vector2(1, 1),
                new Vector2(4/5f, 0),
            };
            triangles = new int[] { 0, 1, 2,};
            DrawMesh(0);

            vertices = new Vector3[] {
                allVertices[0],
                allVertices[10],
                allVertices[9],
                allVertices[4],
            };
            uvs = new Vector2[]{
                new Vector2(1/5f,1),
                new Vector2(1, 1),
                new Vector2(4/5f, 0),
                new Vector2(2/5f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3};
            DrawMesh(1);

            vertices = new Vector3[]
            {
                allVertices[0],
                allVertices[1],
                allVertices[11],
                allVertices[10],
            };
            uvs = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1/5f, 1),
                new Vector2(1, 1),
                new Vector2(4/5f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(2);

            vertices = new Vector3[]
            {
                allVertices[1],
                allVertices[2],
                allVertices[7],
                allVertices[11],
            };
            uvs = new Vector2[]
            {
                new Vector2(1/5f, 0),
                new Vector2(2/5f, 1),
                new Vector2(4/5f, 1),
                new Vector2(1, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(3);

            vertices = new Vector3[] {
                allVertices[2],
                allVertices[3],
                allVertices[7],
            };
            uvs = new Vector2[]{
                new Vector2(0,0),
                new Vector2(1/5f, 1),
                new Vector2(2/5f, 0),
            };
            triangles = new int[] { 0, 1, 2 };
            DrawMesh(4);

            vertices = new Vector3[] {
                allVertices[8],
                allVertices[9],
                allVertices[12],
            };
            uvs = new Vector2[]{
                new Vector2(1/5f, 0),
                new Vector2(0, 1),
                new Vector2(2/5f, 1),
            };
            triangles = new int[] { 0, 1, 2, };
            DrawMesh(5);

            vertices = new Vector3[] {
                allVertices[9],
                allVertices[10],
                allVertices[16],
                allVertices[12],
            };
            uvs = new Vector2[]{
                new Vector2(1/5f,0),
                new Vector2(0, 1),
                new Vector2(4/5f, 1),
                new Vector2(3/5f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(6);

            vertices = new Vector3[]
            {
                allVertices[10],
                allVertices[11],
                allVertices[17],
                allVertices[16],
            };
            uvs = new Vector2[]
            {
                new Vector2(1/5f, 0),
                new Vector2(0, 1),
                new Vector2(4/5f, 1),
                new Vector2(1, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(7);

            vertices = new Vector3[]
            {
                allVertices[11],
                allVertices[15],
                allVertices[18],
                allVertices[17],
            };
            uvs = new Vector2[]
            {
                new Vector2(1/5f, 0),
                new Vector2(2/5f, 1),
                new Vector2(4/5f, 1),
                new Vector2(1, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(8);

            vertices = new Vector3[] {
                allVertices[15],
                allVertices[19],
                allVertices[18],
            };
            uvs = new Vector2[]{
                new Vector2(3/5f, 0),
                new Vector2(4/5f, 1),
                new Vector2(1, 0),
            };
            triangles = new int[] { 0, 1, 2 };
            DrawMesh(9);
        }

        private void DrawSixMeshes()
        {
            vertices = new Vector3[] {
                allVertices[7],
                allVertices[10],
                allVertices[9],
            };
            uvs = new Vector2[]{
                new Vector2(2/3f,1),
                new Vector2(1, 1),
                new Vector2(5/6f, 0),
            };
            triangles = new int[] { 0, 1, 2, };
            DrawMesh(0);

            vertices = new Vector3[] {
                allVertices[5],
                allVertices[11],
                allVertices[10],
                allVertices[7],
            };
            uvs = new Vector2[]{
                new Vector2(1/3f,1),
                new Vector2(1, 1),
                new Vector2(5/6f, 0),
                new Vector2(0.5f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(1);

            vertices = new Vector3[]
            {
                allVertices[0],
                allVertices[1],
                allVertices[12],
                allVertices[11],
                allVertices[5],
            };
            uvs = new Vector2[]
            {
                new Vector2(1/12f, 0.5f),
                new Vector2(1/6f, 1),
                new Vector2(1, 1),
                new Vector2(5/6f, 0),
                new Vector2(1/6f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 , 0, 3, 4};
            DrawMesh(2);

            vertices = new Vector3[]
            {
                allVertices[1],
                allVertices[2],
                allVertices[8],
                allVertices[12],
            };
            uvs = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1/6f, 1),
                new Vector2(2/3f, 1),
                new Vector2(5/6f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(3);

            vertices = new Vector3[]
            {
                allVertices[2],
                allVertices[3],
                allVertices[6],
                allVertices[8],
            };
            uvs = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1/6f, 1),
                new Vector2(1/3f, 1),
                new Vector2(0.5f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(4);

            vertices = new Vector3[] {
                allVertices[3],
                allVertices[4],
                allVertices[6],
            };
            uvs = new Vector2[]{
                new Vector2(0,0),
                new Vector2(1/12f, 0.5f),
                new Vector2(1/6f, 0),
            };
            triangles = new int[] { 0, 1, 2 };
            DrawMesh(5);

            vertices = new Vector3[] {
                allVertices[9],
                allVertices[10],
                allVertices[13],
            };
            uvs = new Vector2[]{
                new Vector2(1/6f, 0),
                new Vector2(0, 1),
                new Vector2(1/3f, 1),
            };
            triangles = new int[] { 0, 1, 2, };
            DrawMesh(6);

            vertices = new Vector3[] {
                allVertices[10],
                allVertices[11],
                allVertices[15],
                allVertices[13],
            };
            uvs = new Vector2[]{
                new Vector2(1/6f, 0),
                new Vector2(0, 1),
                new Vector2(2/3f, 1),
                new Vector2(0.5f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(7);

            vertices = new Vector3[]
            {
                allVertices[11],
                allVertices[12],
                allVertices[18],
                allVertices[17],
                allVertices[15],
            };
            uvs = new Vector2[]
            {
                new Vector2(1/6f, 0),
                new Vector2(0, 1),
                new Vector2(5/6f, 1),
                new Vector2(11/12f, 0.5f),
                new Vector2(5/6f, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 , 0, 3, 4};
            DrawMesh(8);

            vertices = new Vector3[]
            {
                allVertices[12],
                allVertices[14],
                allVertices[19],
                allVertices[18],
            };
            uvs = new Vector2[]
            {
                new Vector2(1/6f, 0),
                new Vector2(1/3f, 1),
                new Vector2(5/6f, 1),
                new Vector2(1, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(9);

            vertices = new Vector3[]
            {
                allVertices[14],
                allVertices[16],
                allVertices[20],
                allVertices[19],
            };
            uvs = new Vector2[]
            {
                new Vector2(0.5f, 0),
                new Vector2(2/3f, 1),
                new Vector2(5/6f, 1),
                new Vector2(1, 0),
            };
            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(10);

            vertices = new Vector3[] {
                allVertices[16],
                allVertices[21],
                allVertices[20],
            };
            uvs = new Vector2[]{
                new Vector2(5/6f, 0),
                new Vector2(11/12f, 0.5f),
                new Vector2(1, 0),
            };
            triangles = new int[] { 0, 1, 2 };
            DrawMesh(11);
        }

        private void DrawMesh(int i)
        {
            Mesh mesh = new Mesh
            {
                vertices = vertices,
                uv = uvs,
                triangles = triangles
            };

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            meshObjs[i] = new GameObject { name = "Mesh_" + i };
            meshObjs[i].transform.parent = this.transform;
            meshObjs[i].AddComponent<MeshFilter>().mesh = mesh;
            meshObjs[i].AddComponent<MeshCollider>();

            if (aspect == 3 || aspect == 4)
            {
                if (i == 0 || i == 2)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[0];
                else if (i == 1 || i == 3)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[1];
                else if (i == 4 || i == 6)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[2];
                else if (i == 5 || i == 7)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[3];
                else
                    meshObjs[i].AddComponent<MeshRenderer>().material = new Material(Shader.Find("Mobile/Diffuse")) { mainTexture = images[0] };
            }
            else if(aspect == 5)
            {
                if (i == 0 || i == 3)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[0];
                else if (i == 1 || i == 4)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[1];
                else if (i == 5 || i == 8)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[2];
                else if (i == 6 || i == 9)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[3];
                else
                    meshObjs[i].AddComponent<MeshRenderer>().material = new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] };
            }
            else if (aspect == 6)
            {
                if (i == 0 || i == 3)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[0];
                else if (i == 1 || i == 4)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[1];
                else if (i == 2 || i == 5)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[2];
                else if (i == 6 || i == 9)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[3];
                else if (i == 7 || i == 10)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[4];
                else if (i == 8 || i == 11)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[5];
                else
                    meshObjs[i].AddComponent<MeshRenderer>().material = new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] };
            }
        }

        
        #endregion


    }
}
