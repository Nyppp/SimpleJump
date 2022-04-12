using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //�÷��̾� �̵��� ���� ������
    Rigidbody CharacterRigidBody;
    Vector3 MoveToVector;
    float RotationValue;
    float moveZ;
    float moveX;

    public float MoveSpeed = 1.0f;
    public float RotationSpeed = 1.0f;
    public float ThrowSpeed = 100.0f;
    public GameObject GrabPoint;



    //����ĳ���� ����
    RaycastHit Hit;
    public float HitDistance = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        CharacterRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame , ������ ������ �ʿ���� ����
    void Update()
    {
        moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

        //��ȣ�ۿ� : ����� �ݱ�, ���� �������� ��
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Interaction();
        }

        //�׼� : Į��, ��ȭ�� �߻� ��
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Action();
        }

        //Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    //��������, ������������ �ʿ��� ����
    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    //ĳ���� �̵��� ���� ó��
    void Move()
    {
        MoveToVector.Set(moveX, 0, moveZ);

        //�Է°��� ���� ����(x��� z��)�� ����ȭ ��Ų ����, �ð����� �̵� �ӵ��� ���� -> �����ӿ� �������� �̵�
        MoveToVector = MoveToVector.normalized * MoveSpeed * Time.deltaTime;

        CharacterRigidBody.MovePosition(transform.position + MoveToVector);
    }

    //ĳ���� ȸ���� ���� ó��
    void Turn()
    {
        if (moveX == 0 && moveZ == 0)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }

        //ȸ��ó��
        Quaternion newRotation = Quaternion.LookRotation(MoveToVector);

        //���� ���� ��������, ĳ���Ͱ� �ּ��� ȸ������ �̵��� ������ ���Ѵ�.
        CharacterRigidBody.rotation = Quaternion.Slerp(
            CharacterRigidBody.rotation, 
            newRotation, 
            RotationSpeed * Time.deltaTime
            );
    }

    void Interaction()
    {
        Vector3 CastPosition = transform.position - new Vector3(0, 0.5f, 0);
        //�ڽ��� ��ȣ�ۿ�
        if (Physics.Raycast(CastPosition, transform.forward, out Hit, HitDistance))
        {
            //����ĳ��Ʈ�� �ɸ� ������Ʈ�� ���� ���Ͷ��, �� ������ ������ �Լ� ����
            //TableFunction�� �����Լ���, �Ļ��Ǵ� �ڽ� Ŭ�������� ������ ��� ����
            if(Hit.transform.gameObject.GetComponent<BaseTableScript>() != null)
            {
                Hit.transform.gameObject.GetComponent<BaseTableScript>().TableFunction(this.gameObject);
            }

            //������Ʈ�� �����̶��, �� ������ �ֿ�
            if(Hit.transform.gameObject.CompareTag("Food"))
            {
                Hit.transform.parent = GrabPoint.transform;
            }
        }

        //���� ��ü�� ������� ��, ��������
        else if (GrabPoint.transform.childCount > 0)
        {
            GrabPoint.transform.GetChild(0).parent = null;
        }

    }

    //TODO : if character grabbing food, throw away.
    void Action()
    {
        //�׼� Ű(�� ��Ʈ��)�� ������ ��, ������ ��� �ִٸ� �÷��̾ ���� �������� ����
        if (GrabPoint.transform.childCount > 0)
        {
            Vector3 ThrowDirection = this.transform.forward + new Vector3(0, 0.2f, 0);
            GrabPoint.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(ThrowDirection.normalized * ThrowSpeed);
            GrabPoint.transform.GetChild(0).parent = null;
        }
        
        else
        {
            //�� �ܿ� ����� ����(Į��) ����
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