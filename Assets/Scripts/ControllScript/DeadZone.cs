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
            //플레이어가 죽었다면 코루틴을 통해 5초 뒤 시작지점에서 부활
            case "Player":
                Debug.Log("플레이어 낙사");
                StartCoroutine(ReviveDelay(other.gameObject));
                break;

            //도구(접시, 소화기 등)이 바닥에 떨어졌다면 5초 뒤 원래 있던 자리로 재생성
            case "dish":
                Debug.Log("도구를 떨어트림");
                //TODO : 게임매니저가 도구들의 위치를 모두 알고 있고, 코루틴을 통해 재생성 해야함
                break;

            //그 외 음식은 모두 삭제시킴
            default:
                Destroy(other.gameObject);
                break;
        }
        
    }

    //플레이어 부활 처리에 대한 코루틴, DelayTime 이후에 spawnPoint로 플레이어를 이동시킴
    IEnumerator ReviveDelay(GameObject Player)
    {
        yield return new WaitForSecondsRealtime(DelayTime);
        GameManager.Instance.PlayerRevive(Player);
    }    
}
