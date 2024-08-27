using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ClearFlagScript : MonoBehaviour
{
    [Header("�ϐ��i�[�pPrefab")]public GameObject MasterController;
    MasterControllerScript MasterSC;
    public AreaTest AreaSC;

    public int clearCount;
    public bool ClearSW;
    bool changeSW;
    float startTimer;
    void Start()
    {
        MasterSC = MasterController.GetComponent<MasterControllerScript>();
    }

    void Update()
    {
        if (changeSW == false)
        {
            startTimer += Time.deltaTime;
        }

        if (startTimer > 1.0f)
        {
            changeSW = true;
        }

        if (changeSW == true)
        {
            ClearSW = AreaSC.ClearSW;

            //MasterPrefab��Switch����ɕύX
            MasterSC.ClearSwitches[clearCount] = ClearSW;
        }
    }
}
