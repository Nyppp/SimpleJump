using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTable : BaseTableScript
{
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
        if(Character.transform.GetChild(0).childCount > 0)
        {
            if (Character.transform.GetChild(0).GetChild(0).GetComponent<Dish>() != null)
            {
                Dish CurrentDish = Character.transform.GetChild(0).GetChild(0).GetComponent<Dish>();
                if (CurrentDish.transform.GetChild(0).childCount > 0)
                {
                    Debug.Log("접시 / 냄비에 담긴 음식 버림");
                    Destroy(CurrentDish.transform.GetChild(0).GetChild(0).gameObject);
                }
            }

            else
            {
                //음식을 버리는 쓰레기통 동작
                Destroy(Character.transform.GetChild(0).GetChild(0).gameObject);
            }
        }
    }
}
