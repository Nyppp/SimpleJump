using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : Dish
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PutInFood(BaseFood Food)
    {
        Debug.Log(""+DishPoint);
        if(DishPoint.transform.childCount > 0)
        {
            Food.transform.position = DishPoint.transform.position;
            Food.transform.parent = DishPoint.transform;
        }
    }
}
