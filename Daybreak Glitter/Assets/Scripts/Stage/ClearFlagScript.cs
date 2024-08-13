using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFlagScript : MonoBehaviour
{
    [Header("•Ï”Ši”[—pPrefab")]public GameObject MasterController;
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

        //MasterPrefab‚ÌSwitch‚ğí‚É•ÏX
        MasterSC.ClearSwitches[clearCount] = ClearSW;
    }
}
