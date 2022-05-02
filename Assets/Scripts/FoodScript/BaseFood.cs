using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFood : MonoBehaviour
{
    //����(Į��, ���� ��) �� ������� �Ѹ���� ���� ����� ��� mesh�迭 
    public Mesh[] MeshArray;
    private MeshFilter meshfilter;

    public bool Grabable = true;
    public bool Cutable = true;
    public bool Mixable = true;

    public bool Cooked = false;
    public float CookTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //�޽����͸� �̿��� ������Ʈ�� �޽� ����
        meshfilter = GetComponent<MeshFilter>();
        meshfilter.sharedMesh = MeshArray[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void CookFood()
    {
        CookTime -= Time.deltaTime;

        if (Cooked == false && CookTime < 0)
        {
            Grabable = true;
            Cooked = true;
            meshfilter.sharedMesh = MeshArray[1];
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
}
