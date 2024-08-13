using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFlagScript : MonoBehaviour
{
    [Header("変数格納用Prefab")]public GameObject MasterController;
    MasterControllerScript MasterSC;
    public AreaTest AreaSC;

    public int clearCount;
    public bool ClearSW;
    void Start()
    {
        MasterSC = MasterController.GetComponent<MasterControllerScript>();
    }

    void Update()
    {
        ClearSW = AreaSC.ClearSW;

        //MasterPrefabのSwitchを常に変更
        MasterSC.ClearSwitches[clearCount] = ClearSW;
    }
}
