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
        }
    }

    //flag가 on 상태일때, 칼질 하는중 동작
    private void OnCollisionStay(Collision collision)
    {
        if(UsingKnife == true)
        {
            Food.GetComponent<BaseFood>().CookFood();
        }
    }

    //캐릭터가 도마 박스와 멀어지면 칼질 중단, 다시 좌 컨트롤을 눌러야 칼질 재개함
    private void OnCollisionExit(Collision collision)
    {
        if (UsingKnife == true)
        {
            UsingKnife = false;
        }
    }


}
