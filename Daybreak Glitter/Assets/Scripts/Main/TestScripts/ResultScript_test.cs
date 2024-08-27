using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript_test : MonoBehaviour
{
    public MasterControllerScript MasterSC;
    public bool ResultSW;
    int clearCount;
    float clearCheckStartCount;
    bool CheckSW;

    void Start()
    {

    }

    void Update()
    {
        if (CheckSW == false)
        {
            clearCheckStartCount += Time.deltaTime;
        }

        if (clearCheckStartCount > 1.0f)
        {
            CheckSW = true;

            ClearCheck();
        }
    }

    void ClearJudgement()
    {
        for (int i = 0; i < MasterSC.maxPoints; i++)
        {
            //Debug.Log(MasterSC.ClearSwitches[i]);
            if (MasterSC.ClearSwitches[i] == true)
            {
                clearCount++;
            }

            if (i == MasterSC.maxPoints - 1 && clearCount != MasterSC.maxPoints)
            {
                clearCount = 0;
            }
            if (clearCount == MasterSC.maxPoints)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }

    void ClearCheck()
    {
        ClearJudgement();
    }
}
