using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [Header("��������X�e�[�W��Prefab")] public GameObject[] StageObjects;
    
    GameObject NowInstStage;//�������̃X�e�[�W�I�u�W�F�N�g

    [Header("�X�e�[�W�Ԃ̋���")] public int stageDistance;

    [Header("�ڕW�n�_�����\�ɂ���l")] public int pointDistance;

    [Header("�ڕW�n�_���������l")] public int maxPointDistance;

    [Header("�ڕW�n�_�ő�l")] public int maxAreaCount;

    [Header("�ڕW�n�_�̌�")] public int nowAreaCount;

    [Header("�e�ڕW�n�_���擾����")] public GameObject[] PointObjects;
    
    [Header("�ϐ��Ǘ��pPrefab")] public GameObject MasterControl;
    ClearFlagScript ClearFlagSC;

    float shufleNum;//�X�e�[�W�̃����_��������������ۂɎg���ϐ�
    float randomRot;//�����X�e�[�W�̃����_����]�p�ϐ�
    bool CreateSW;


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
        if (Input.GetKeyDown(KeyCode.LeftShift))
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
                //�ڕW�n�_�̐�����������ɗ��Ă����ꍇ
                if (nowAreaCount >= maxAreaCount)
                {
                    if (CreateSW == false)
                    {
                        stageStatus[z, x] = Random.Range(1, 4);

                        NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                                       new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                                       Quaternion.Euler(0, randomRot, 0)
                                       );
                    }
                }

                //�ڕW�n�_�̐�����������l�ȉ��̏ꍇ
                if (nowAreaCount < maxAreaCount)
                {
                    CreateSW = true;
                    //�ڕW�n�_�𐶐������Ȃ�
                    if (shufleNum < pointDistance)
                    {
                        CreateSW = false;
                        stageStatus[z, x] = Random.Range(1,4);
                        shufleNum++;
                    }

                    //�ڕW�n�_�𐶐�����̂�����
                    if (shufleNum >= pointDistance && shufleNum < maxPointDistance)
                    {
                        CreateSW = false;
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

                    if (nowAreaCount >= maxAreaCount)
                    {
                        nowAreaCount = maxAreaCount;
                    }

                    randomRot = Random.Range(0,4) * 90;
                    NowInstStage = Instantiate(StageObjects[stageStatus[z, x]],
                                               new Vector3((x * stageDistance), 0.0f, (z * stageDistance)),
                                               Quaternion.Euler(0, randomRot, 0)
                                               );

                    //�ڕW�n�_�������ɔz��Ɋi�[
                    if (StageObjects[stageStatus[z, x]] == StageObjects[0])
                    {
                        PointObjects[nowAreaCount - 1] = NowInstStage;
                        
                        //�e�ڕW�n�_�̐�������X�N���v�g���擾
                        ClearFlagSC = PointObjects[nowAreaCount - 1].GetComponent<ClearFlagScript>();

                        //MasterPrefab�Ɋe�ڕW�n�_��Switch���i�[
                        ClearFlagSC.clearCount = nowAreaCount - 1;
                    }
                }
                NowInstStage.transform.parent = this.transform;
            }
        }
    }
}
