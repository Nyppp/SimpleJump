using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTableScript : BaseTableScript
{
    //���� ������Ʈ
    public GameObject Food;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�÷��̾�� ������ �ִ� ����� ������ ���� 
    public override void TableFunction(GameObject Character)
    {
        //�÷��̾ �ƹ��͵� ������� ���� ���,
        if (Character.transform.GetChild(0).transform.childCount == 0)
        {
            //���� ������Ʈ�� �����Ͽ� �÷��̾��� �ڽ����� ����
            GameObject CopyObject = Instantiate(Food, Character.transform.GetChild(0).transform);

            CopyObject.transform.parent = Character.transform.GetChild(0);
        }
    }

    
}
