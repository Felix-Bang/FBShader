//  Felix-Bang：MVPTransform
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
	public class MVPTransform : MonoBehaviour
	{
	

        #region Unity回调
		void Start () 
		{
			
		}
	
		void Update ()
		{
            Matrix4x4 RM = new Matrix4x4();
            RM[0, 0] = Mathf.Cos(Time.realtimeSinceStartup);
            RM[0, 2] = Mathf.Sin(Time.realtimeSinceStartup);
            RM[1, 1] = 1;
            RM[2, 0] = -Mathf.Sin(Time.realtimeSinceStartup);
            RM[2, 2] = Mathf.Cos(Time.realtimeSinceStartup);
            RM[3, 3] = 1;

            Matrix4x4 SM = new Matrix4x4();
            SM[0, 0] = Mathf.Sin(Time.realtimeSinceStartup);
            SM[1, 1] = Mathf.Cos(Time.realtimeSinceStartup);
            SM[2, 2] = Mathf.Sin(Time.realtimeSinceStartup);
            SM[3, 3] = 1;

            Matrix4x4 mvp = Camera.main.projectionMatrix * Camera.main.worldToCameraMatrix * transform.localToWorldMatrix * SM;
            GetComponent<Renderer>().material.SetMatrix("mvp", mvp);
        }
        #endregion


	}
}
