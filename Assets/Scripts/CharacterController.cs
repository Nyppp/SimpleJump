using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //플레이어 이동에 관한 변수들
    Rigidbody CharacterRigidBody;
    Vector3 MoveToVector;
    float RotationValue;
    float moveZ;
    float moveX;

    public float MoveSpeed = 1.0f;
    public float RotationSpeed = 1.0f;
    public float ThrowSpeed = 100.0f;
    public GameObject GrabPoint;



    //레이캐스팅 변수
    RaycastHit Hit;
    public float HitDistance = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        CharacterRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame , 물리적 반응이 필요없는 연산
    void Update()
    {
        moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

        //상호작용 : 식재료 줍기, 물건 내려놓기 등
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Interaction();
        }

        //액션 : 칼질, 소화기 발사 등
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Action();
        }

        //Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    //물리연산, 고정프레임이 필요한 연산
    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    //캐릭터 이동에 대한 처리
    void Move()
    {
        MoveToVector.Set(moveX, 0, moveZ);

        //입력값에 대한 벡터(x축과 z축)를 정규화 시킨 다음, 시간값과 이동 속도를 곱함 -> 프레임에 독립적인 이동
        MoveToVector = MoveToVector.normalized * MoveSpeed * Time.deltaTime;

        CharacterRigidBody.MovePosition(transform.position + MoveToVector);
    }

    //캐릭터 회전에 대한 처리
    void Turn()
    {
        if (moveX == 0 && moveZ == 0)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }

        //회전처리
        Quaternion newRotation = Quaternion.LookRotation(MoveToVector);

        //선형 구면 보간으로, 캐릭터가 최소의 회전으로 이동할 방향을 구한다.
        CharacterRigidBody.rotation = Quaternion.Slerp(
            CharacterRigidBody.rotation, 
            newRotation, 
            RotationSpeed * Time.deltaTime
            );
    }

    void Interaction()
    {
        Vector3 CastPosition = transform.position - new Vector3(0, 0.5f, 0);
        //박스와 상호작용
        if (Physics.Raycast(CastPosition, transform.forward, out Hit, HitDistance))
        {
            //레이캐스트에 걸린 오브젝트가 상자 액터라면, 그 상자의 고유한 함수 실행
            //TableFunction은 가상함수로, 파생되는 자식 클래스마다 각자의 기능 존재
            if(Hit.transform.gameObject.GetComponent<BaseTableScript>() != null)
            {
                Hit.transform.gameObject.GetComponent<BaseTableScript>().TableFunction(this.gameObject);
            }

            //오브젝트가 음식이라면, 그 음식을 주움
            if(Hit.transform.gameObject.CompareTag("Food"))
            {
                Hit.transform.parent = GrabPoint.transform;
            }
        }

        //현재 물체를 들고있을 때, 내려놓음
        else if (GrabPoint.transform.childCount > 0)
        {
            GrabPoint.transform.GetChild(0).parent = null;
        }

    }

    //TODO : if character grabbing food, throw away.
    void Action()
    {
        //액션 키(좌 컨트롤)를 눌렀을 때, 음식을 들고 있다면 플레이어가 보는 방향으로 던짐
        if (GrabPoint.transform.childCount > 0)
        {
            Vector3 ThrowDirection = this.transform.forward + new Vector3(0, 0.2f, 0);
            GrabPoint.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(ThrowDirection.normalized * ThrowSpeed);
            GrabPoint.transform.GetChild(0).parent = null;
        }
        
        else
        {
            //그 외에 식재료 손질(칼질) 동작
            Vector3 CastPosition = transform.position - new Vector3(0, 0.5f, 0);
            if (Physics.Raycast(CastPosition, transform.forward, out Hit, HitDistance))
            {
                if(Hit.transform.gameObject.GetComponent<KnifeTable>() != null)
                {
                    Hit.transform.gameObject.GetComponent<KnifeTable>().KnifeFunction(this.gameObject);
                }
            }
        }
    }
}