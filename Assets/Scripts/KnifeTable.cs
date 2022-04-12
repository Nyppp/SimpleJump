using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTable : BaseTableScript
{
    bool UsingKnife = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TableFunction(GameObject Character)
    {
        //�⺻ ���̺�� ���� ����(���� �ø���)
        base.TableFunction(Character);
    }

    //Į�� Ű(�� ��Ʈ��) ������ Į�� ����, flag����(UsingKnife)�� true�� ����
    public void KnifeFunction(GameObject Character)
    {
        if(this.transform.GetChild(0).childCount > 0)
        {
            Debug.Log("Į�� ����");
            UsingKnife = true;
        }
    }

    //flag�� on �����϶�, Į�� �ϴ��� ����
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.GetComponent<CharacterController>() != null)
        {
            if (UsingKnife == true)
            {
                Debug.Log("Į�� �ϴ� ��");
            }
        }
    }

    //ĳ���Ͱ� ���� �ڽ��� �־����� Į�� �ߴ�, �ٽ� �� ��Ʈ���� ������ Į�� �簳��
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.GetComponent<CharacterController>() != null)
        {
            if (UsingKnife == true)
            {
                Debug.Log("Į�� ����");
                UsingKnife = false;
            }
        }
    }


}
