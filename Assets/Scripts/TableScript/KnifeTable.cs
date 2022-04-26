using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeTable : BaseTableScript
{
    public Image CookBar;
    bool UsingKnife = false;

    BaseFood Food;

    // Start is called before the first frame update
    void Start()
    {
        CookBar.GetComponent<Image>().enabled = false;
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
            CookBar.GetComponent<Image>().enabled = true;
            CookBar.transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
    }

    //flag�� on �����϶�, Į�� �ϴ��� ����
    private void OnCollisionStay(Collision collision)
    {
        if(UsingKnife == true)
        {
            Food.GetComponent<BaseFood>().CookFood();
            CookBar.transform.GetChild(0).GetComponent<Image>().fillAmount = 1.0f - ( Food.GetComponent<BaseFood>().CookTime / 5.0f );

            if (Food.GetComponent<BaseFood>().Cooked == true)
            {
                CookBar.GetComponent<Image>().enabled = false;
                CookBar.transform.GetChild(0).GetComponent<Image>().enabled = false;
            }

        }
    }

    //ĳ���Ͱ� ���� �ڽ��� �־����� Į�� �ߴ�, �ٽ� �� ��Ʈ���� ������ Į�� �簳��
    private void OnCollisionExit(Collision collision)
    {
        if (UsingKnife == true)
        {
            UsingKnife = false;
            CookBar.GetComponent<Image>().enabled = false;
            CookBar.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }


}
