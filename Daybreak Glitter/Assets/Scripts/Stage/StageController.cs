using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [Header("生成するステージのPrefab")] public GameObject[] StageObjects;
    
    GameObject NowInstStage;//生成時のステージオブジェクト

    [Header("ステージ間の距離")] public int stageDistance;

    [Header("目標地点生成可能にする値")] public int pointDistance;

    [Header("目標地点強制生成値")] public int maxPointDistance;

    [Header("目標地点最大値")] public int maxAreaCount;

    [Header("目標地点の個数")] public int nowAreaCount;

    [Header("各目標地点を取得する")] public GameObject[] PointObjects;
    
    [Header("変数管理用Prefab")] public GameObject MasterControl;
    ClearFlagScript ClearFlagSC;

    float shufleNum;//ステージのランダム生成を許可する際に使う変数
    float randomRot;//生成ステージのランダム回転用変数
    bool CreateSW;


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
        if (Input.GetKeyDown(KeyCode.LeftShift))
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
                //目標地点の生成数が上限に来ていた場合
                if (nowAreaCount >= maxAreaCount)
                {
                    if (CreateSW == false)
                    {
                        stageStatus[z, x] = Random.Range(1, 4);

                        NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                                       new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                                       Quaternion.Euler(0, randomRot, 0)
                                       );
                    }
                }

                //目標地点の生成数が上限値以下の場合
                if (nowAreaCount < maxAreaCount)
                {
                    CreateSW = true;
                    //目標地点を生成させない
                    if (shufleNum < pointDistance)
                    {
                        CreateSW = false;
                        stageStatus[z, x] = Random.Range(1,4);
                        shufleNum++;
                    }

                    //目標地点を生成するのを許可
                    if (shufleNum >= pointDistance && shufleNum < maxPointDistance)
                    {
                        CreateSW = false;
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

                    if (nowAreaCount >= maxAreaCount)
                    {
                        nowAreaCount = maxAreaCount;
                    }

                    randomRot = Random.Range(0,4) * 90;
                    NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                                               new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                                               Quaternion.Euler(0, randomRot, 0)
                                               );

                    //目標地点生成時に配列に格納
                    if (StageObjects[stageStatus[z, x]] == StageObjects[0])
                    {
                        PointObjects[nowAreaCount - 1] = NowInstStage;
                        
                        //各目標地点の制圧判定スクリプトを取得
                        ClearFlagSC = PointObjects[nowAreaCount - 1].GetComponent<ClearFlagScript>();

                        //MasterPrefabに各目標地点のSwitchを格納
                        ClearFlagSC.clearCount = nowAreaCount - 1;
                    }
                }
                NowInstStage.transform.parent = this.transform;
            }
        }
    }
}
