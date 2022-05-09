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
        //플레이어가 물체를 집게 되는 지점인 grabpoint를 가져옴
        GameObject grabPoint = Character.GetComponent<CharacterController>().GrabPoint;

        //상자에 있는 물체를 플레이어가 가져갈 때 동작
        if (DropPoint.transform.childCount > 0)
        {
            if (grabPoint.transform.childCount == 0)
            {
                //음식일 경우, 조리중이 아닌 음식은 집을 수 있게 함
                if (DropPoint.transform.GetChild(0).GetComponent<BaseFood>() != null)
                {
                    if (DropPoint.transform.GetChild(0).GetComponent<BaseFood>().Grabable == true)
                    {
                        DropPoint.transform.GetChild(0).parent = grabPoint.transform;
                    }
                }

                //테이블 위에 있는게 접시일 경우의 처리
                else if (DropPoint.transform.GetChild(0).GetComponent<Dish>() != null)
                {
                    DropPoint.transform.GetChild(0).parent = grabPoint.transform;
                }

                else if(DropPoint.transform.GetChild(0).CompareTag("Grabable"))
                {
                    DropPoint.transform.GetChild(0).parent = grabPoint.transform;
                }
            }

            //플레이어가 음식을 두려 할 때, 테이블에 이미 접시가 있을 경우
            else if (grabPoint.transform.GetChild(0).GetComponent<BaseFood>() != null)
            {
                if (DropPoint.transform.GetChild(0).GetComponent<Dish>() != null)
                {
                    DropPoint.transform.GetChild(0).GetComponent<Dish>().PutInFood(grabPoint.transform.GetChild(0).GetComponent<BaseFood>());
                }
            }
        }

        //플레이어가 상자에 물체를 놓을 때 동작
        else
        {
            if (grabPoint.transform.childCount > 0)
            {
                grabPoint.transform.GetChild(0).position = DropPoint.transform.position;
                grabPoint.transform.GetChild(0).parent = DropPoint.transform;
            }
        }
    }

    public virtual void TableAction(GameObject Character) { return; }
}
