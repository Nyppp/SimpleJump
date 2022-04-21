using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : Dish
{
    //ȭ���� �� �ð����� ���� ������, ���� ���� ���鼭 ź ������ ��
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
        //���� ������ �θ� ������Ʈ�� ȭ���� �ƴ϶��, currentboiltime ���󺹱�.
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
                Debug.Log("���̾�!");
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
