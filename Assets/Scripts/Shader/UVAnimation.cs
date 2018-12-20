//  Felix-Bang：UVAnimation
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
	public class UVAnimation : MonoBehaviour
	{
        public int row;                         //行
        public int column;                      //列 
        public int fps;                         //速率
        
        private int currentIndex;
        IEnumerator Start () 
		{
            Material mat = GetComponent<Renderer>().material;
            float scale_x = 1.0f / column;
            float scale_y = 1.0f / row;

            while (true)
            {

                float offset_x = currentIndex % column * scale_x;
                float offset_y = currentIndex / row  * scale_y;
                Debug.Log("当前索引： "+currentIndex + "     X偏移： " + currentIndex % column + "     y偏移： " + currentIndex / row);
                mat.SetTextureOffset("_MainTex", new Vector2(offset_x, offset_y));
                mat.SetTextureScale("_MainTex", new Vector2(scale_x, scale_y));
                yield return new WaitForSeconds(1.0f / fps);
                currentIndex = (++currentIndex) % (row * column);
            }


        
		}
	
		void Update ()
		{
			
		}
     



        #region 方法
        #endregion
	}
}
