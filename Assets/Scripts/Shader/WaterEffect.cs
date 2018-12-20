//  Felix-Bang：WaterEffect
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　|　＼〈
//　　>ｰ ､_　ィ　 │ ／／
//　 / へ　　/　ﾉ＜| ＼＼
//　 ヽ_ﾉ　(_ ／　 │／／
//　　7　　　　　　|／
//　　＞―r￣￣`―＿/
// Describe：
// Createtime：

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace FelixBang
{
	public class WaterEffect : MonoBehaviour
	{
        #region 字段
        public int waveWidth=128;
        public int waveHeight=128;
        float[,] waveA;
        float[,] waveB;

        Texture2D tex_uv;
        Color[] colorBuffer;
        private bool isRun = true;
        private int sleepTime;

        #endregion

        #region Unity回调
        void Start () 
		{
            QualitySettings.vSyncCount = 0;

            waveA = new float[waveWidth, waveHeight];
            waveB = new float[waveWidth, waveHeight];
            tex_uv = new Texture2D(waveWidth, waveHeight);
            colorBuffer = new Color[waveWidth*waveHeight];
            GetComponent<Renderer>().material.SetTexture("_WaveTex", tex_uv);
            Thread th = new Thread(new ThreadStart(ComputeWave));
            th.Start();
        }
	
		void Update ()
		{
            sleepTime = (int)Time.deltaTime * 1000;
            tex_uv.SetPixels(colorBuffer);
            tex_uv.Apply();


            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 pos = transform.worldToLocalMatrix.MultiplyPoint(hit.point);
                    int w = (int)((pos.x + 0.5) * waveWidth);
                    int h = (int)((pos.y + 0.5) * waveHeight);
                    PutDrop(w,h);
                }
            }

           
          
		}

        private void OnDestroy()
        {
            isRun = false;
        }
        #endregion

        #region 方法
        private void PutDrop(int x,int y)
        {
            int radius = 20;
            float dist;

            for (int i = -radius; i < radius; i++)
            {
                for (int j = -radius; j < radius; j++)
                {
                    if((x+i>=0)&&(x+i<waveWidth-1)&&(y+j>=0)&&(y+j<waveHeight-1))
                    {
                        dist = Mathf.Sqrt(i * i + j * j);
                        if (dist < radius)
                            waveA[x + i, y + j] = Mathf.Cos(dist * Mathf.PI / radius);

                    }
                }
            }
        }


        private void ComputeWave()
        {
            while (isRun)
            {
                //从1到max-1 防止数组越界
                for (int w = 1; w < waveWidth - 1; w++)
                {
                    for (int h = 1; h < waveHeight - 1; h++)
                    {
                        waveB[w, h] = (waveA[w - 1, h] + waveA[w + 1, h]
                            + waveA[w, h + 1] + waveA[w, h - 1]
                            + waveA[w - 1, h + 1] + waveA[w - 1, h - 1]
                            + waveA[w + 1, h + 1] + waveA[w + 1, h - 1]) / 4 - waveB[w, h];

                        float value = waveB[w, h];
                        if (value > 1)
                            value = 1;
                        if (value < -1)
                            value = -1;

                        float offset_u = (waveB[w - 1, h] - waveB[w + 1, h]) / 2;
                        float offset_v = (waveB[w, h - 1] - waveB[w, h + 1]) / 2;

                        float r = offset_u / 2 + 0.5f;
                        float g = offset_v / 2 + 0.5f;

                        //tex_uv.SetPixel(w, h, new Color(r, g, 0));
                        colorBuffer[w + waveWidth * h] = new Color(r, g, 0);
                        waveB[w, h] -= waveB[w, h] * 0.0025f;
                    }
                }

               // tex_uv.Apply();
                float[,] temp = waveA;
                waveA = waveB;
                waveB = temp;
                Thread.Sleep(sleepTime);
            }

            
        }




        #endregion
    }
}
