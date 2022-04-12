using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTableScript : MonoBehaviour
{
    //음식을 둘 수 있는 공간
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
        //Debug.Log("이것은 기본 상자입니다.");
        //플레이어가 음식을 들고있으며 테이블에 음식이 없다면 그 음식을 테이블 위로 올림
        if(DropPoint.transform.childCount > 0)
        {
            if(Character.transform.GetChild(0).childCount == 0)
            {
                DropPoint.transform.GetChild(0).parent = Character.transform.GetChild(0);
            }
        }

        //음식을 들고있지 않고 테이블 위에 음식이 있다면
        //플레이어가 음식을 들게 함
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
