using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : Dish
{
    //ȭ���� �� �ð����� ���� ������, ���� ���� ���鼭 ź ������ ��
    public float BoilTime = 7.0f;
    public float CurrentBoilTime;

    // Start is called before the first frame update
    void Start()
    {
        CurrentBoilTime = BoilTime;
    }

    // Update is called once per frame
    void Update()
    {
        //���� ������ �θ� ������Ʈ�� ���ױⰡ �ƴ϶��, currentboiltime ���󺹱�.
        if (this.transform.parent.parent.gameObject.GetComponent<Kneader>() != null)
        {
            CurrentBoilTime -= Time.deltaTime;
        }
    }

    public override void PutInFood(BaseFood Food)
    {
        if(DishPoint.transform.childCount == 0)
        {
            Food.transform.position = DishPoint.transform.position;
            Food.transform.parent = DishPoint.transform;
        }
    }
}
