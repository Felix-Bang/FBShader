//  Felix-Bang：Herringbone
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
//　 /＞―r￣￣`ｰ―＿-/
// Describe：人字铺
// Createtime：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Felix
{
	public class Herringbone : MonoBehaviour
	{
        #region 字段
        [SerializeField]private Texture[] images;
        [SerializeField] private int aspect = 2;           //单块砖的长 ：宽比
        private int side;
        private float uvUnit;
   
        //---------- 顶点属性 ----------
        private Vector3[] vertices;//顶点数
        private Vector2[] uvs;//uvs坐标
        private int[] triangles;//三角形索引
        //---------- 顶点属性 ----------
        #endregion

        #region Unity回调
        void Start ()
        {
            if (aspect < 2)
                return;

            side = 2 * aspect;
            uvUnit = 1.0f / aspect;

            DrawMeshesH1();
            DrawMeshesV1();
            DrawMeshesH2();
            DrawMeshesV2();
            transform.localPosition = new Vector3(-4,-4,0);
        }
        #endregion

        #region 方法
        private void DrawMeshesH1()
        {
            GameObject[] meshObjs = new GameObject[aspect];

            for (int i = 0, iMax = meshObjs.Length; i < iMax; i++)
            {
                vertices = new Vector3[]
                {
                    new Vector3(0, i, 0),
                    new Vector3(0, i + 1, 0),
                    new Vector3(iMax - i, i + 1, 0),
                    new Vector3(iMax - i, i, 0)
                };

                uvs = new Vector2[]
                {
                    new Vector2(uvUnit * i, 0),
                    new Vector2(uvUnit * i, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0)
                };
             
                InitializeMesh(meshObjs[i], "Horizontal_A" + i);
            }
        }

        private void DrawMeshesV1()
        {
            GameObject[] meshObjs = new GameObject[side];
            
            for (int i = 0, iMax = meshObjs.Length; i < iMax; i++)
            {
                if (i < aspect)
                {
                    vertices = new Vector3[] 
                    {
                        new Vector3(i, iMax - i, 0),
                        new Vector3(i + 1, iMax - i, 0),
                        new Vector3(i + 1, aspect - i, 0),
                        new Vector3(i, aspect - i, 0)
                    };

                    uvs = new Vector2[] 
                    {
                        new Vector2(0, 0),
                        new Vector2(0, 1),
                        new Vector2(1, 1),
                        new Vector2(1, 0)
                    };
                }
                else
                {
                    vertices = new Vector3[] 
                    {
                        new Vector3(i, iMax - i, 0),
                        new Vector3(i + 1, iMax - i, 0),
                        new Vector3(i + 1, 0, 0),
                        new Vector3(i, 0, 0)
                    };

                    uvs = new Vector2[] 
                    {
                        new Vector2(0, 0),
                        new Vector2(0, 1),
                        new Vector2(2-uvUnit * i, 1),
                        new Vector2(2 - uvUnit * i, 0)
                    };
                }

                InitializeMesh(meshObjs[i], "Vertical_A" + i);
            }
        }

        private void DrawMeshesH2()
        {
            GameObject[] meshObjs = new GameObject[side-1];
            
            for (int i = 0, iMax=meshObjs.Length; i < iMax; i++)
            {
                if (i < aspect)
                {
                    vertices = new Vector3[]
                    {
                        new Vector3(i + 1, (side - i) - 1, 0),
                        new Vector3(i + 1, side - i, 0),
                        new Vector3((i + 1) + aspect, side - i, 0),
                        new Vector3((i + 1) + aspect, side - i - 1, 0)
                    };

                    uvs = new Vector2[] 
                    {
                        new Vector2(0, 0),
                        new Vector2(0, 1),
                        new Vector2(1, 1),
                        new Vector2(1, 0)
                    };
                }
                else
                {
                    vertices = new Vector3[] 
                    {
                        new Vector3(i + 1, side - i - 1, 0),
                        new Vector3(i + 1, side - i, 0),
                        new Vector3(side, side - i, 0),
                        new Vector3(side, side - i - 1, 0),
                    };

                    uvs = new Vector2[] 
                    {
                        new Vector2(0, 0),
                        new Vector2(0, 1),
                        new Vector2(1-(i - aspect+1) * uvUnit, 1),
                        new Vector2(1-(i - aspect+1) * uvUnit, 0)
                    };
                }

                InitializeMesh(meshObjs[i], "Horizontal_B" + i);
            }
        }

        private void DrawMeshesV2()
        {
            GameObject[] meshObjs = new GameObject[aspect-1];

            for (int i = 0, iMax=meshObjs.Length; i < iMax; i++)
            {
                vertices = new Vector3[] 
                {
                     new Vector3(i + 1 + aspect, side, 0),
                     new Vector3(i + 1 + aspect + 1, side, 0),
                     new Vector3(i + 1 + aspect + 1, side - i - 1, 0),
                     new Vector3(i + 1 + aspect, side - i - 1, 0),
                };

                uvs = new Vector2[]
                {
                    new Vector2(1 -(i+1)*uvUnit, 0),
                    new Vector2(1 -(i+1)*uvUnit, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0)
                };

                InitializeMesh(meshObjs[i], "Vertical_B" + i);
            }
        }

        private void InitializeMesh(GameObject meshObj, string index)
        {
            meshObj = new GameObject { name = index };
            meshObj.transform.parent = this.transform;
            meshObj.AddComponent<MeshFilter>().mesh = DrawMesh();
            meshObj.AddComponent<MeshCollider>();
            //int ra = Random.Range(0,4);
            Material material = new Material(Shader.Find("Unlit/Transparent")) { mainTexture = images[0] };

            meshObj.AddComponent<MeshRenderer>().material = material;
        }

        private Mesh DrawMesh()
        {
            triangles = new int[] { 0, 1, 2 , 0, 2, 3 };

            Mesh mesh = new Mesh
            {
                vertices = vertices,
                uv = uvs,
                triangles = triangles
            };

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }
        #endregion
    }
}
