using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    //�X�e�[�W�Ŏg���̕ϐ�
    public GameObject[] StageObjects;
    public int stageDistance;
    GameObject NowInstStage;
    float shufleNum;
    public int pointDistance;
    public int maxPointDistance;
    public int maxAreaCount;
    public int nowAreaCount;
    float randomRot;



    int[,] stageStatus = new int[10, 10] {//[y,x] //0���ڕW�n�_�E1���n�ʁE2������E3������E4������...
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0}
    };
    void Start()
    {
        StageDraw();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Test_c23011");
        }
    }

    void StageDraw()
    {
        for (int z = 1; z <= 8; z++)
        {
            for (int x = 1; x <= 8; x++)
            {
                //�ڕW�n�_�̐�����������l�����̏ꍇ
                if (nowAreaCount <= maxAreaCount)
                {
                    //�ڕW�n�_�𐶐������Ȃ�
                    if (shufleNum < pointDistance)
                    {
                        stageStatus[z, x] = Random.Range(1,4);
                        shufleNum++;
                    }

                    //�ڕW�n�_�𐶐�����̂�����
                    if (shufleNum >= pointDistance && shufleNum < maxPointDistance)
                    {
                        stageStatus[z, x] = Random.Range(0, 4);
                        shufleNum++;
                    }

                    //�ڕW�n�_����������
                    if (shufleNum >= maxPointDistance)
                    {
                        stageStatus[z, x] = 0;
                    }

                    //��������Stage���ڕW�n�_(0)�̏ꍇ�J�E���g+1�A�ڕW�n�_�̐������J�E���g�����Z�b�g
                    if (stageStatus[z, x] == 0)
                    {
                        nowAreaCount++;
                        shufleNum = 0;
                    }

                    randomRot = Random.Range(0,4) * 90;
                    NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                                               new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                                               Quaternion.Euler(0, randomRot, 0)
                                               );
                }

                //�ڕW�n�_�̐�����������ɗ��Ă����ꍇ
                if (nowAreaCount > maxAreaCount)
                {
                    stageStatus[z, x] = Random.Range(1,4);

                    NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                           new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                           Quaternion.Euler(0,randomRot,0)
                           );
                }

                NowInstStage.transform.parent = this.transform;
            }
        }
    }
}
