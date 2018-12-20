//  Felix-Bang：Fishbone45
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
// Describe：鱼骨铺（45）
// Createtime：2018/11/22

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Felix
{
	public class Fishbone45 : MonoBehaviour
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
            if (aspect == 3)
            {
                meshObjs = new GameObject[2 * aspect];

                allVertices = new Vector3[9] {
                     new Vector3(-1,0,0),
                     new Vector3(-1,1,0),
                     new Vector3(-1,2,0),

                     new Vector3(0,0,0),
                     new Vector3(0,1,0),
                     new Vector3(0,2,0),

                     new Vector3(1,0,0),
                     new Vector3(1,1,0),
                     new Vector3(1,2,0),
                     };

                materials = new Material[2] {
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                };

                DrawThreeMeshes();
            }
            else if (aspect == 4)
            {
                meshObjs = new GameObject[2 * (aspect+1)];

                allVertices = new Vector3[18] {
                     new Vector3(-1.5f,0,0),
                     new Vector3(-1.5f,0.5f,0),
                     new Vector3(-1.5f,1.5f,0),
                     new Vector3(-1.5f,2.5f,0),
                     new Vector3(-1.5f,3,0),

                     new Vector3(-1,0,0),
                     new Vector3(-1,3,0),

                     new Vector3(0,0,0),
                     new Vector3(0,1,0),
                     new Vector3(0,2,0),
                     new Vector3(0,3,0),

                     new Vector3(1,0,0),
                     new Vector3(1,3,0),

                     new Vector3(1.5f,0,0),
                     new Vector3(1.5f,0.5f,0),
                     new Vector3(1.5f,1.5f,0),
                     new Vector3(1.5f,2.5f,0),
                     new Vector3(1.5f,3f,0),
                     };

                materials = new Material[4] {
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                };

                DrawFourMeshes();
            }
            else if (aspect == 5)
            {
                meshObjs = new GameObject[2 * aspect];

                allVertices = new Vector3[20] {
                     new Vector3(-2,0,0),
                     new Vector3(-2,1,0),
                     new Vector3(-2,2,0),
                     new Vector3(-2,3,0),
                     new Vector3(-1,0,0),
                     new Vector3(-1,1,0),
                     new Vector3(-1,2,0),
                     new Vector3(-1,3,0),
                     new Vector3(0,0,0),
                     new Vector3(0,1,0),
                     new Vector3(0,2,0),
                     new Vector3(0,3,0),
                     new Vector3(1,0,0),
                     new Vector3(1,1,0),
                     new Vector3(1,2,0),
                     new Vector3(1,3,0),
                     new Vector3(2,0,0),
                     new Vector3(2,1,0),
                     new Vector3(2,2,0),
                     new Vector3(2,3,0),
                     };

                materials = new Material[4] {
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                };

                DrawFiveMeshes();
            }
            else if (aspect == 6)
            {
                meshObjs = new GameObject[2 * aspect];

                allVertices = new Vector3[22] {
                     new Vector3(-2.5f,0,0),
                     new Vector3(-2.5f,0.5f,0),
                     new Vector3(-2.5f,1.5f,0),
                     new Vector3(-2.5f,2.5f,0),
                     new Vector3(-2.5f,3,0),

                     new Vector3(-2,0,0),
                     new Vector3(-2,3,0),

                     new Vector3(-1,0,0),
                     new Vector3(-1,3,0),

                     new Vector3(0,0,0),
                     new Vector3(0,1,0),
                     new Vector3(0,2,0),
                     new Vector3(0,3,0),

                     new Vector3(1,0,0),
                     new Vector3(1,3,0),

                     new Vector3(2,0,0),
                     new Vector3(2,3,0),

                     new Vector3(2.5f,0,0),
                     new Vector3(2.5f,0.5f,0),
                     new Vector3(2.5f,1.5f,0),
                     new Vector3(2.5f,2.5f,0),
                     new Vector3(2.5f,3,0),
                     };

                materials = new Material[6] {
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                    new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] },
                };

                DrawSixMeshes();
            }
            else
                return;
        }

        private void DrawThreeMeshes()
        {
            vertices = new Vector3[]
              {
                  allVertices[0],
                  allVertices[4],
                  allVertices[3],
              };

            uvs = new Vector2[]
              {
                  new Vector2(1/3f, 1),
                  new Vector2(1, 1),
                  new Vector2(2/3f, 0),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(0);

            vertices = new Vector3[]
              {
                  allVertices[0],
                  allVertices[1],
                  allVertices[5],
                  allVertices[4],
              };

            uvs = new Vector2[]
              {
                    new Vector2(0, 0),
                    new Vector2(1/3f, 1),
                    new Vector2(1, 1),
                    new Vector2(2/3f, 0),
              };

            triangles = new int[] { 0, 1, 2,0,2,3 };
            DrawMesh(1);

            vertices = new Vector3[]
              {
                   allVertices[1],
                   allVertices[2],
                   allVertices[5],
              };

            uvs = new Vector2[]
              {
                    new Vector2(0, 0),
                    new Vector2(1/3f, 1),
                    new Vector2(2/3f, 0),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(2);

            vertices = new Vector3[]
              {
                   allVertices[3],
                   allVertices[4],
                   allVertices[6],
              };

            uvs = new Vector2[]
              {
                    new Vector2(1/3f, 0),
                    new Vector2(0, 1),
                    new Vector2(2/3f, 1),
              };

            triangles = new int[] { 0, 1, 2 };

            DrawMesh(3);


            vertices = new Vector3[]
              {
                   allVertices[4],
                   allVertices[5],
                   allVertices[7],
                   allVertices[6],
              };

            uvs = new Vector2[]
              {
                    new Vector2(1/3f, 0),
                    new Vector2(0, 1),
                    new Vector2(2/3f, 1),
                    new Vector2(1, 0),

              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(4);

            vertices = new Vector3[]
              {
                   allVertices[5],
                   allVertices[8],
                   allVertices[7],
              };

            uvs = new Vector2[]
              {
                    new Vector2(1/3f, 0),
                    new Vector2(2/3f, 1),
                    new Vector2(1, 0),
              };

            triangles = new int[] { 0, 1, 2 };

            DrawMesh(5);
        }

        private void DrawFourMeshes()
        {
            vertices = new Vector3[]
             {
                  allVertices[5],
                  allVertices[8],
                  allVertices[7],
            };

            uvs = new Vector2[]
              {
                  new Vector2(0.5f, 1f),
                  new Vector2(1, 1),
                  new Vector2(0.75f, 0),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(0);

            vertices = new Vector3[]
              {
                  allVertices[0],
                  allVertices[1],
                  allVertices[9],
                  allVertices[8],
                  allVertices[5],
              };

            uvs = new Vector2[]
              {
                  new Vector2(0.125f, 0.5f),
                  new Vector2(0.25f, 1),
                  new Vector2(1, 1),
                  new Vector2(0.75f, 0),
                  new Vector2(0.25f, 0),
              };

            triangles = new int[] { 0, 1, 2, 0,2,3, 0,3,4 };
            DrawMesh(1);


            vertices = new Vector3[]
              {
                  allVertices[1],
                  allVertices[2],
                  allVertices[10],
                  allVertices[9],
              };

            uvs = new Vector2[]
              {
                  new Vector2(0, 0),
                  new Vector2(0.25f, 1),
                  new Vector2(1, 1),
                  new Vector2(0.75f, 0),
           
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(2);

            vertices = new Vector3[]
             {
                  allVertices[2],
                  allVertices[3],
                  allVertices[6],
                  allVertices[10],
             };

            uvs = new Vector2[]
              {
                  new Vector2(0, 0),
                  new Vector2(0.25f, 1),
                  new Vector2(0.5f, 1),
                  new Vector2(0.75f, 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            DrawMesh(3);

            vertices = new Vector3[]
              {
                  allVertices[3],
                  allVertices[4],
                  allVertices[6],
              };

            uvs = new Vector2[]
              {
                  new Vector2(0, 0),
                  new Vector2(0.125f, 0.5f),
                  new Vector2(0.25f, 0),
               
              };

            triangles = new int[] { 0, 1, 2};
            DrawMesh(4);

            vertices = new Vector3[]
              {
                  allVertices[7],
                  allVertices[8],
                  allVertices[11],
              };

            uvs = new Vector2[]
              {
                  new Vector2(0.25f, 0),
                  new Vector2(0, 1),
                  new Vector2(0.5f, 1),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(5);

            vertices = new Vector3[]
              {
                  allVertices[8],
                  allVertices[9],
                  allVertices[14],
                  allVertices[13],
                  allVertices[11],
              };

            uvs = new Vector2[]
              {
                  new Vector2(0.25f, 0),
                  new Vector2(0, 1),
                  new Vector2(0.75f, 1),
                  new Vector2(0.875f, 0.5f),
                  new Vector2(0.75f, 0),
              };

            triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };
            DrawMesh(6);

            vertices = new Vector3[]
            {
                  allVertices[9],
                  allVertices[10],
                  allVertices[15],
                  allVertices[14],
            };

            uvs = new Vector2[]
              {
                  new Vector2(0.25f, 0f),
                  new Vector2(0, 1),
                  new Vector2(0.75f, 1),
                  new Vector2(1, 0),
              };

            triangles = new int[] { 0, 1, 2 ,0,2,3};
            DrawMesh(7);

            vertices = new Vector3[]
            {
                  allVertices[10],
                  allVertices[12],
                  allVertices[16],
                  allVertices[15],
            };

            uvs = new Vector2[]
              {
                  new Vector2(0.25f, 0f),
                  new Vector2(0.5f, 1),
                  new Vector2(0.75f, 1),
                  new Vector2(1, 0),
              };

            triangles = new int[] { 0, 1, 2,0,2,3 };
            DrawMesh(8);

            vertices = new Vector3[]
            {
                  allVertices[12],
                  allVertices[17],
                  allVertices[16],
            };

            uvs = new Vector2[]
              {
                  new Vector2(0.75f, 0f),
                  new Vector2(0.875f, 0.5f),
                  new Vector2(1, 0),
              };

            triangles = new int[] { 0, 1, 2 };
            DrawMesh(9);
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

            if (aspect == 3)
            {
                if (i == 0 || i == 2)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[0];
                else if (i == 3 || i == 5)
                    meshObjs[i].AddComponent<MeshRenderer>().material = materials[1];
                else
                    meshObjs[i].AddComponent<MeshRenderer>().material = new Material(Shader.Find("Custom/OutLine1")) { mainTexture = images[0] };
            }
            else if (aspect == 4)
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
