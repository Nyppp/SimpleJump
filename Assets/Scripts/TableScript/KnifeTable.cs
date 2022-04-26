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
        //기본 테이블과 같은 동작(음식 올리기) 그러나 접시나 다른 오브젝트가 들어가지 않도록 함

        if(Character.transform.GetChild(0).childCount > 0)
        {
            if (Character.transform.GetChild(0).GetChild(0).GetComponent<BaseFood>() == null)
            {
                return;
            }
        }

        base.TableFunction(Character);
    }

    //칼질 키(좌 컨트롤) 누르면 칼질 시작, flag변수(UsingKnife)를 true로 만듦
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

    //flag가 on 상태일때, 칼질 하는중 동작
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

    //캐릭터가 도마 박스와 멀어지면 칼질 중단, 다시 좌 컨트롤을 눌러야 칼질 재개함
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
