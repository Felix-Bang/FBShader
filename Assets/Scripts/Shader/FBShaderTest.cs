//  Felix-Bang：FBShaderTest
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
	public class FBShaderTest : MonoBehaviour
	{

        #region Unity回调
		void Start () 
		{
            GetComponent<Renderer>().material.SetVector("_SecondColor",new Vector4(1,0,0,1));
		}
	
		void Update ()
		{
			
		}
        #endregion

        #region 事件回调
        #endregion

        #region 方法
        #endregion
	}
}
