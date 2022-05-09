using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTableScript : MonoBehaviour
{
    //������ �� �� �ִ� ����
    public GameObject DropPoint;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TableFunction(GameObject Character)
    {
        //�÷��̾ ��ü�� ���� �Ǵ� ������ grabpoint�� ������
        GameObject grabPoint = Character.GetComponent<CharacterController>().GrabPoint;

        //���ڿ� �ִ� ��ü�� �÷��̾ ������ �� ����
        if (DropPoint.transform.childCount > 0)
        {
            if (grabPoint.transform.childCount == 0)
            {
                //������ ���, �������� �ƴ� ������ ���� �� �ְ� ��
                if (DropPoint.transform.GetChild(0).GetComponent<BaseFood>() != null)
                {
                    if (DropPoint.transform.GetChild(0).GetComponent<BaseFood>().Grabable == true)
                    {
                        DropPoint.transform.GetChild(0).parent = grabPoint.transform;
                    }
                }

                //���̺� ���� �ִ°� ������ ����� ó��
                else if (DropPoint.transform.GetChild(0).GetComponent<Dish>() != null)
                {
                    DropPoint.transform.GetChild(0).parent = grabPoint.transform;
                }

                else if(DropPoint.transform.GetChild(0).CompareTag("Grabable"))
                {
                    DropPoint.transform.GetChild(0).parent = grabPoint.transform;
                }
            }

            //�÷��̾ ������ �η� �� ��, ���̺� �̹� ���ð� ���� ���
            else if (grabPoint.transform.GetChild(0).GetComponent<BaseFood>() != null)
            {
                if (DropPoint.transform.GetChild(0).GetComponent<Dish>() != null)
                {
                    DropPoint.transform.GetChild(0).GetComponent<Dish>().PutInFood(grabPoint.transform.GetChild(0).GetComponent<BaseFood>());
                }
            }
        }

        //�÷��̾ ���ڿ� ��ü�� ���� �� ����
        else
        {
            if (grabPoint.transform.childCount > 0)
            {
                grabPoint.transform.GetChild(0).position = DropPoint.transform.position;
                grabPoint.transform.GetChild(0).parent = DropPoint.transform;
            }
        }
    }

    public virtual void TableAction(GameObject Character) { return; }
}
