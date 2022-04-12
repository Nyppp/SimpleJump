using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTableScript : MonoBehaviour
{
    //������ �� �� �ִ� ����
    public GameObject DropPoint;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TableFunction(GameObject Character)
    {
        //Debug.Log("�̰��� �⺻ �����Դϴ�.");
        //�÷��̾ ������ ��������� ���̺� ������ ���ٸ� �� ������ ���̺� ���� �ø�
        if(DropPoint.transform.childCount > 0)
        {
            if(Character.transform.GetChild(0).childCount == 0)
            {
                DropPoint.transform.GetChild(0).parent = Character.transform.GetChild(0);
            }
        }

        //������ ������� �ʰ� ���̺� ���� ������ �ִٸ�
        //�÷��̾ ������ ��� ��
        else
        {
            if (Character.transform.GetChild(0).childCount > 0)
            {
                Character.transform.GetChild(0).GetChild(0).position = DropPoint.transform.position;
                Character.transform.GetChild(0).GetChild(0).parent = DropPoint.transform;
            }
        }
    }

    
}
