using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeTable : BaseTableScript
{
    public Image CookBar;
    bool UsingKnife = false;

    public List<BaseFood> CutableFood;
    

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
    public override void TableAction(GameObject Character) 
    {

        Food = this.DropPoint.GetComponentInChildren<BaseFood>();

        if (Food != null && Food.Cooked == false && Food.Cutable == true)
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
            Food.CookFood();
            CookBar.transform.GetChild(0).GetComponent<Image>().fillAmount = 1.0f - ( Food.CookTime / 5.0f );

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
