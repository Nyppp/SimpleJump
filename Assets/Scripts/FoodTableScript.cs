using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTableScript : BaseTableScript
{

    public GameObject Food;
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
        if (Character.transform.GetChild(0).transform.childCount == 0)
        {
            GameObject CopyObject = Instantiate(Food, Character.transform.GetChild(0).transform);

            CopyObject.transform.parent = Character.transform.GetChild(0);
        }
    }

    
}
