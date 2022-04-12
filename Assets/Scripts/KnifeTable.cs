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
        //기본 테이블과 같은 동작(음식 올리기)
        base.TableFunction(Character);
    }

    //칼질 키(좌 컨트롤) 누르면 칼질 시작, flag변수(UsingKnife)를 true로 만듦
    public void KnifeFunction(GameObject Character)
    {
        if(this.transform.GetChild(0).childCount > 0)
        {
            Debug.Log("칼질 시작");
            UsingKnife = true;
        }
    }

    //flag가 on 상태일때, 칼질 하는중 동작
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.GetComponent<CharacterController>() != null)
        {
            if (UsingKnife == true)
            {
                Debug.Log("칼질 하는 중");
            }
        }
    }

    //캐릭터가 도마 박스와 멀어지면 칼질 중단, 다시 좌 컨트롤을 눌러야 칼질 재개함
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.GetComponent<CharacterController>() != null)
        {
            if (UsingKnife == true)
            {
                Debug.Log("칼질 종료");
                UsingKnife = false;
            }
        }
    }


}
