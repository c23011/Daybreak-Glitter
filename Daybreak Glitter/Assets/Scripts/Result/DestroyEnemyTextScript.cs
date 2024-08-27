using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemyTextScript : MonoBehaviour
{
    public MasterControllerScript MasterSC;
    public Text ResultText;
    string DestroyCount;
    void Start()
    {
        DestroyCount = "" + MasterSC.destroyEnemys;
        ResultText.text = DestroyCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
