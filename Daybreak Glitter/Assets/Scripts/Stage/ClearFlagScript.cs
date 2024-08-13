using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFlagScript : MonoBehaviour
{
    [Header("�ϐ��i�[�pPrefab")]public GameObject MasterController;
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

        //MasterPrefab��Switch����ɕύX
        MasterSC.ClearSwitches[clearCount] = ClearSW;
    }
}
