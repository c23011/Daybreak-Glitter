using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    //ステージで使うの変数
    public GameObject[] StageObjects;
    public int stageDistance;
    GameObject NowInstStage;
    float shufleNum;
    public int pointDistance;
    public int maxPointDistance;
    public int maxAreaCount;
    public int nowAreaCount;
    float randomRot;



    int[,] stageStatus = new int[10, 10] {//[y,x] //0→目標地点・1→地面・2→未定・3→未定・4→未定...
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0}
    };
    void Start()
    {
        StageDraw();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Test_c23011");
        }
    }

    void StageDraw()
    {
        for (int z = 1; z <= 8; z++)
        {
            for (int x = 1; x <= 8; x++)
            {
                //目標地点の生成数が上限値未満の場合
                if (nowAreaCount <= maxAreaCount)
                {
                    //目標地点を生成させない
                    if (shufleNum < pointDistance)
                    {
                        stageStatus[z, x] = Random.Range(1,4);
                        shufleNum++;
                    }

                    //目標地点を生成するのを許可
                    if (shufleNum >= pointDistance && shufleNum < maxPointDistance)
                    {
                        stageStatus[z, x] = Random.Range(0, 4);
                        shufleNum++;
                    }

                    //目標地点を強制生成
                    if (shufleNum >= maxPointDistance)
                    {
                        stageStatus[z, x] = 0;
                    }

                    //生成するStageが目標地点(0)の場合カウント+1、目標地点の生成許可カウントをリセット
                    if (stageStatus[z, x] == 0)
                    {
                        nowAreaCount++;
                        shufleNum = 0;
                    }

                    randomRot = Random.Range(0,4) * 90;
                    NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                                               new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                                               Quaternion.Euler(0, randomRot, 0)
                                               );
                }

                //目標地点の生成数が上限に来ていた場合
                if (nowAreaCount > maxAreaCount)
                {
                    stageStatus[z, x] = Random.Range(1,4);

                    NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                           new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                           Quaternion.Euler(0,randomRot,0)
                           );
                }

                NowInstStage.transform.parent = this.transform;
            }
        }
    }
}
