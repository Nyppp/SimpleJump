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
        //상자에 있는 물체를 플레이어가 가져갈 때 동작
        if (DropPoint.transform.childCount > 0)
        {
            if (Character.transform.GetChild(0).childCount == 0)
            {
                //음식일 경우, 조리중이 아닌 음식은 집을 수 있게 함
                if (DropPoint.transform.GetChild(0).GetComponent<BaseFood>() != null)
                {
                    if (DropPoint.transform.GetChild(0).GetComponent<BaseFood>().Grabable == true)
                    {
                        DropPoint.transform.GetChild(0).parent = Character.transform.GetChild(0);
                    }
                }

                else if (DropPoint.transform.GetChild(0).GetComponent<Dish>() != null)
                {
                    DropPoint.transform.GetChild(0).parent = Character.transform.GetChild(0);
                }
            }

            else if (Character.transform.GetChild(0).childCount > 0)
            {
                if (DropPoint.transform.GetChild(0).GetComponent<Dish>() != null)
                {
                    DropPoint.transform.GetChild(0).GetComponent<Dish>().PutInFood(Character.transform.GetChild(0).GetChild(0).GetComponent<BaseFood>());
                }
            }
        }

        //플레이어가 상자에 물체를 놓을 때 동작
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
