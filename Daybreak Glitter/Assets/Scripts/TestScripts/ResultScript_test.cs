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

    void Start()
    {

    }

    void Update()
    {
        Invoke("ClearCheck", 1.0f);
    }

    void ClearJudgement()
    {
        if (ResultSW == true)
        {
            for (int i = 0; i < MasterSC.maxPoints; i++)
            {
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
                    SceneManager.LoadScene("ResultTest");
                }
            }
        }
    }

    void ClearCheck()
    {
        ClearJudgement();

        ResultSW = true;
    }
}
