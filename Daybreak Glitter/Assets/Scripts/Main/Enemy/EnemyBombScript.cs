using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombScript : MonoBehaviour
{
    //���̃X�N���v�g�͔����̍U������ɃA�^�b�`����
    public GameObject MyEnemy;
    public float boomTime;
    void Start()
    {
        Invoke("Boom",boomTime);
    }

    void Boom()
    {
        Destroy(MyEnemy);
    }
}
