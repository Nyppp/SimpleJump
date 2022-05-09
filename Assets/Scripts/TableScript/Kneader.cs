using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kneader : BaseTableScript
{
    
    bool IsFire = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TableFunction(GameObject Character)
    {
        GameObject grabPoint = Character.GetComponent<CharacterController>().GrabPoint;

        //������ ��쿡�� ȭ���� �ø� �� ����
        if (grabPoint.transform.childCount > 0)
        {
            Pod pod = grabPoint.transform.GetChild(0).GetComponent<Pod>();
            if (pod != null)
            {
                pod.transform.position = DropPoint.transform.position;
                pod.transform.parent = DropPoint.transform;
            }
        }

        
        else
        {
            if(grabPoint.transform.childCount == 0)
            {
                DropPoint.transform.GetChild(0).parent = grabPoint.transform;
            }
        }
    }

    public override void TableAction(GameObject Character)
    {
        //������ �ְ� ������ ������ �����ð� ���� ����ũ�� �Ǿ� ��ȯ
        return;
    }


}
