using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dish : MonoBehaviour
{
    //음식을 둘 수 있는 공간
    public GameObject DishPoint;

    //접시에 담긴 음식 리스트
    List<BaseFood> FoodList = new List<BaseFood>();

    // Start is called before the first frame update
    void Start()
    {
        //접시에 음식이 담길 지점
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
            //중복된 음식은 접시에 담을 수 없음
            foreach(BaseFood FindFood in FoodList)
            {
                if(FindFood == Food)
                {
                    return;
                }
            }
            
            //음식을 접시에 담고, 리스트에 원소 추가 -> 레시피 제출 시 음식 내용을 비교하기 위해서
            Food.transform.position= DishPoint.transform.position;
            Food.transform.parent = DishPoint.transform;
            FoodList.Add(Food);

        }
    }

    private void FixedUpdate()
    {
        //플레이어가 음식을 들거나, 상자에 올려져 있을 때 물리적 충돌을 방지하기 위해 콜라이더와 리지드바디를 끔
        if (this.transform.parent != null)
        {
            //음식이 가속중이었다면 제로벡터를 통해 중단시킴
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;

            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<Rigidbody>().useGravity = false;

            //부모 오브젝트에 계속 따라다니도록 함
            this.transform.position = this.transform.parent.gameObject.transform.position;
        }

        else
        {
            //땅에 떨어지게 되는 경우 콜라이더와 리지드바디를 킴
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
