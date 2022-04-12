using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTableScript : BaseTableScript
{
    //음식 오브젝트
    public GameObject Food;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //플레이어에게 음식을 주는 식재료 상자의 동작 
    public override void TableFunction(GameObject Character)
    {
        //플레이어가 아무것도 들고있지 않은 경우,
        if (Character.transform.GetChild(0).transform.childCount == 0)
        {
            //음식 오브젝트를 생성하여 플레이어의 자식으로 부착
            GameObject CopyObject = Instantiate(Food, Character.transform.GetChild(0).transform);

            CopyObject.transform.parent = Character.transform.GetChild(0);
        }
    }

    
}
