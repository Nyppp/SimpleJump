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
        GameObject grabPoint = Character.GetComponent<CharacterController>().GrabPoint;

        Dish CurrentDish = grabPoint.transform.GetChild(0).GetComponent<Dish>();

        if(CurrentDish != null)
        {
            if (CurrentDish.transform.GetChild(0).childCount > 0)
            {
                Destroy(CurrentDish.DishPoint.transform.GetChild(0).gameObject);
                ++GameManager.Instance.Score;
            }
        }

        
    }
}
