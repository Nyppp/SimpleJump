using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStove : BaseTableScript
{

    bool IsFire = false;

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
        //냄비인 경우에만 화구에 올릴 수 있음
        if (Character.transform.GetChild(0).childCount > 0)
        {
            if (Character.transform.GetChild(0).GetChild(0).GetComponent<Pod>() != null)
            {
                Character.transform.GetChild(0).GetChild(0).position = DropPoint.transform.position;
                Character.transform.GetChild(0).GetChild(0).parent = DropPoint.transform;
            }
        }

        
        else
        {
            if(Character.transform.GetChild(0).childCount == 0)
            {
                DropPoint.transform.GetChild(0).parent = Character.transform.GetChild(0);
            }
        }
    }


}
