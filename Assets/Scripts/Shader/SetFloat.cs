//  Felix-Bang：SetFloat
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
	public class SetFloat : MonoBehaviour
	{

        float dis = -1;
        float r = 0.1f;
        #region Unity回调
		void Start () 
		{
            
        }
	
		void Update ()
		{
            dis += Time.deltaTime * 0.1f;
            GetComponent<Renderer>().material.SetFloat("dis", dis);
            GetComponent<Renderer>().material.SetFloat("r", r);
        }
        #endregion



        #region 方法
        #endregion
	}
}
