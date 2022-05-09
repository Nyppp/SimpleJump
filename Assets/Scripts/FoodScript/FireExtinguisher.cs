using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot()
    {
        Debug.Log("��ȭ�� �߻���");
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
