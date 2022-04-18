using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTable : BaseTableScript
{
    bool UsingKnife = false;

    BaseFood Food;

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
        //�⺻ ���̺�� ���� ����(���� �ø���) �׷��� ���ó� �ٸ� ������Ʈ�� ���� �ʵ��� ��

        if(Character.transform.GetChild(0).childCount > 0)
        {
            if (Character.transform.GetChild(0).GetChild(0).GetComponent<BaseFood>() == null)
            {
                return;
            }
        }

        base.TableFunction(Character);
    }

    //Į�� Ű(�� ��Ʈ��) ������ Į�� ����, flag����(UsingKnife)�� true�� ����
    public void KnifeFunction(GameObject Character)
    {
        Food = this.transform.GetChild(0).GetChild(0).GetComponent<BaseFood>();
        if (Food != null && Food.Cooked == false)
        {
            Food.Grabable = false;
            UsingKnife = true;
        }
    }

    //flag�� on �����϶�, Į�� �ϴ��� ����
    private void OnCollisionStay(Collision collision)
    {
        if(UsingKnife == true)
        {
            Food.GetComponent<BaseFood>().CookFood();
        }
    }

    //ĳ���Ͱ� ���� �ڽ��� �־����� Į�� �ߴ�, �ٽ� �� ��Ʈ���� ������ Į�� �簳��
    private void OnCollisionExit(Collision collision)
    {
        if (UsingKnife == true)
        {
            UsingKnife = false;
        }
    }


}
