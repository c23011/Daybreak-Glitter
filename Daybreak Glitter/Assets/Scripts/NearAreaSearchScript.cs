using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearAreaSearchScript : MonoBehaviour
{
    public SphereCollider thisCol;
    public GameObject AreaObj;
    public AreaTest areaTestSC;
    public bool SearchSW;
    public bool CheckSW;

    void Start()
    {
        thisCol = this.GetComponent<SphereCollider>();
        SearchSW = true;
    }

    void Update()
    {
        if (SearchSW == true)
        {
            thisCol.radius += 1.0f;
        }

        if (CheckSW == true)
        {
            areaTestSC = AreaObj.GetComponent<AreaTest>();
            //Debug.Log(areaTestSC.ClearSW);
            if (areaTestSC.ClearSW == false)
            {
                //Debug.Log("NoClearArea");
                this.transform.LookAt(AreaObj.transform.position);
                thisCol.radius = 0.1f;
                SearchSW = false;
            }

            if (areaTestSC.ClearSW == true)
            {
                //Debug.Log("AlreadyClearArea");
                SearchSW = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Area")
        {
            AreaObj = other.gameObject;
            Debug.Log("Hit!!");
            CheckSW = true;

        }
    }
}