using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterControllerScript : MonoBehaviour
{
    [Header("変数管理用Prefab")]

    [Header("生成された目標地点")]
    public bool[] ClearSwitches;

    [Header("目標地点最大数")]
    public int maxPoints;

    [Header("敵の撃破数")]
    public float destroyEnemys;

    [Header("クリア時間")]
    public float clearTime;
}
