using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitTable : BaseTableScript
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
        //플레이어가 물체를 들고있고 그것이 접시이고, 조리된 음식이라면 점수 증가
        if (Character.transform.GetChild(0).childCount > 0)
        {
            if (Character.transform.GetChild(0).GetChild(0).GetComponent<Dish>() != null)
            {
                Dish CurrentDish = Character.transform.GetChild(0).GetChild(0).GetComponent<Dish>();
                if (CurrentDish.transform.GetChild(0).childCount > 0)
                {
                    Destroy(CurrentDish.transform.GetChild(0).GetChild(0).gameObject);
                    ++GameManager.Instance.Score;
                }
            }
        }
    }
}
