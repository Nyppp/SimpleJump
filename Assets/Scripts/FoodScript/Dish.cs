using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dish : MonoBehaviour
{
    //������ �� �� �ִ� ����
    public GameObject DishPoint;

    //���ÿ� ��� ���� ����Ʈ
    List<BaseFood> FoodList = new List<BaseFood>();

    // Start is called before the first frame update
    void Start()
    {
        //���ÿ� ������ ��� ����
        DishPoint = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void PutInFood(BaseFood Food)
    {
        if(Food.Cooked == true)
        {
            //�ߺ��� ������ ���ÿ� ���� �� ����
            foreach(BaseFood FindFood in FoodList)
            {
                if(FindFood == Food)
                {
                    return;
                }
            }
            
            //������ ���ÿ� ���, ����Ʈ�� ���� �߰� -> ������ ���� �� ���� ������ ���ϱ� ���ؼ�
            Food.transform.position= DishPoint.transform.position;
            Food.transform.parent = DishPoint.transform;
            FoodList.Add(Food);

        }
    }

    private void FixedUpdate()
    {
        //�÷��̾ ������ ��ų�, ���ڿ� �÷��� ���� �� ������ �浹�� �����ϱ� ���� �ݶ��̴��� ������ٵ� ��
        if (this.transform.parent != null)
        {
            //������ �������̾��ٸ� ���κ��͸� ���� �ߴܽ�Ŵ
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;

            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<Rigidbody>().useGravity = false;

            //�θ� ������Ʈ�� ��� ����ٴϵ��� ��
            this.transform.position = this.transform.parent.gameObject.transform.position;
        }

        else
        {
            //���� �������� �Ǵ� ��� �ݶ��̴��� ������ٵ� Ŵ
            this.GetComponent<Collider>().enabled = true;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BaseFood>() != null)
        {
            collision.gameObject.transform.parent = this.transform;

            FoodList.Add(collision.gameObject.GetComponent<BaseFood>());
        }
    }
}
