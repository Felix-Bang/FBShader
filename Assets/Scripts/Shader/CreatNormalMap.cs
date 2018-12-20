//  Felix-Bang：CreatNormalMap
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
// Describe：
// Createtime：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class CreatNormalMap : MonoBehaviour
	{
        #region 字段
        public Texture2D tex0;
        public Texture2D tex1;
        #endregion

        #region Unity回调
		void Start () 
		{
            for (int h = 1; h < 255; h++)
            {
                for (int w = 1; w < 255 ; w++)
                {
                    float uLeft = tex0.GetPixel(w - 1, h).r;
                    float uRight = tex0.GetPixel(w + 1, h).r;
                    float u = uRight - uLeft;
                    float vTop = tex0.GetPixel(w, h - 1).r;
                    float vBottom = tex0.GetPixel(w, h + 1).r;
                    float v = vBottom - vTop;

                    Vector3 vector_u = new Vector3(1, 0, u);
                    Vector3 vector_v = new Vector3(0, 1, v);

                    Vector3 n = Vector3.Cross(vector_u, vector_v).normalized;

                    float r = n.x * 0.5f + 0.5f;
                    float g = n.y * 0.5f + 0.5f;
                    float b = n.z * 0.5f + 0.5f;

                    tex1.SetPixel(w,h,new Color(r,g,b));
                }
            }

            tex1.Apply(false);
		}
	
		void Update ()
		{
			
		}
        #endregion

        #region 方法
        #endregion
	}
}
