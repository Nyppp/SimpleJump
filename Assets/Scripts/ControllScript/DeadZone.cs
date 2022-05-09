using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public float DelayTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //�÷��̾ �׾��ٸ� �ڷ�ƾ�� ���� 5�� �� ������������ ��Ȱ
            case "Player":
                Debug.Log("�÷��̾� ����");
                StartCoroutine(ReviveDelay(other.gameObject));
                break;

            //����(����, ��ȭ�� ��)�� �ٴڿ� �������ٸ� 5�� �� ���� �ִ� �ڸ��� �����
            case "dish":
                Debug.Log("������ ����Ʈ��");
                //TODO : ���ӸŴ����� �������� ��ġ�� ��� �˰� �ְ�, �ڷ�ƾ�� ���� ����� �ؾ���
                break;

            //�� �� ������ ��� ������Ŵ
            default:
                Destroy(other.gameObject);
                break;
        }
        
    }

    //�÷��̾� ��Ȱ ó���� ���� �ڷ�ƾ, DelayTime ���Ŀ� spawnPoint�� �÷��̾ �̵���Ŵ
    IEnumerator ReviveDelay(GameObject Player)
    {
        yield return new WaitForSecondsRealtime(DelayTime);
        GameManager.Instance.PlayerRevive(Player);
    }    
}
