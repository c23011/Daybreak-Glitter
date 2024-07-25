using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameObject[] StageObjects;
    public int stageDistance;
    GameObject NowInstStage;
    float shufleNum;
    public int pointDistance;
    public int maxPointDistance;
    public int maxAreaCount;
    public int nowAreaCount;

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
                        Debug.Log("目標生成NG");
                        stageStatus[z, x] = Random.Range(1,4);
                        shufleNum++;
                    }

                    //目標地点を生成するのを許可
                    if (shufleNum >= pointDistance && shufleNum < maxPointDistance)
                    {
                        Debug.Log("目標生成OK");
                        stageStatus[z, x] = Random.Range(0, 4);
                    }

                    //目標地点を強制生成
                    if (shufleNum >= maxPointDistance)
                    {
                        stageStatus[z, x] = 0;
                    }

                    //生成するStageが目標地点(0)の場合カウント+1、目標地点の生成許可カウントをリセット
                    if (stageStatus[z, x] == 0)
                    {
                        Debug.Log("目標生成されたで");
                        nowAreaCount++;
                        shufleNum = 0;
                    }

                    NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                                               new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                                               Quaternion.identity
                                               );
                }

                //目標地点の生成数が上限に来ていた場合
                if (nowAreaCount > maxAreaCount)
                {
                    Debug.Log("もう目標生成されないで");
                    stageStatus[z, x] = Random.Range(1,4);

                    NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                           new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                           Quaternion.identity
                           );
                }

                NowInstStage.transform.parent = this.transform;
            }
        }
    }
}
