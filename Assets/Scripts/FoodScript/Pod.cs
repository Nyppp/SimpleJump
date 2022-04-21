using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : Dish
{
    //화구에 이 시간보다 오래 있으면, 냄비에 불이 나면서 탄 음식이 됨
    public float BoilTime = 5;
    public float CurrentBoilTime;

    // Start is called before the first frame update
    void Start()
    {
        CurrentBoilTime = BoilTime;
    }

    // Update is called once per frame
    void Update()
    {
        //냄비를 소유한 부모 오브젝트가 화구가 아니라면, currentboiltime 원상복구.
        if (this.transform.parent.parent.gameObject.GetComponent<GasStove>() == null)
        {
            CurrentBoilTime = BoilTime;
        }

        else
        {
            if (CurrentBoilTime > 0)
            {
                CurrentBoilTime -= Time.deltaTime;
                Debug.Log("" + CurrentBoilTime);
            }
            else
            {
                Debug.Log("불이야!");
            }
        }
    }

    public override void PutInFood(BaseFood Food)
    {
        Debug.Log(""+DishPoint);
        if(DishPoint.transform.childCount == 0)
        {
            Food.transform.position = DishPoint.transform.position;
            Food.transform.parent = DishPoint.transform;
        }
    }
}
