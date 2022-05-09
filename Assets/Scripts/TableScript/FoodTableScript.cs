using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTableScript : BaseTableScript
{
    //���� ������Ʈ
    public GameObject Food;

    public AnimationClip Openning;
    public float AnimationSpeed;
    Animation BoxOpenAnimation;

    // Start is called before the first frame update
    void Start()
    {
        BoxOpenAnimation = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�÷��̾�� ������ �ִ� ����� ������ ���� 
    public override void TableFunction(GameObject Character)
    {
        GameObject grabPoint = Character.GetComponent<CharacterController>().GrabPoint;
        //�÷��̾ �ƹ��͵� ������� ���� ���,
        if (grabPoint.transform.childCount == 0)
        {
            //���� ������Ʈ�� �����Ͽ� �÷��̾��� �ڽ����� ����
            GameObject CopyObject = Instantiate(Food, grabPoint.transform);
            CopyObject.transform.parent = grabPoint.transform;
            
            BoxOpenAnimation.clip = Openning;
            BoxOpenAnimation["Take 001"].speed = AnimationSpeed;
            BoxOpenAnimation.Play();
        }
    }
}