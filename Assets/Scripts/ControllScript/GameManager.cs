using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager Gameinstance = null;

    public Text ScoreText;
    public int Score;

    public GameObject SpawnPoint;


    void Awake()
    {
        if (null == Gameinstance)
        {
            //게임매니저 인스턴스가 없다면(게임 시작 시) 자신을 할당시킴
            Gameinstance = this;

            //씬이 전환되어도 파괴되지 않게 해주는 DontDestroyOnLoad 함수 사용
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //다른 씬으로 이동했을 때, 이미 게임매니저가 존재하면 자신을 파괴하고 쓰던 게임매니저 사용
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == Gameinstance)
            {
                return null;
            }
            return Gameinstance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //점수를 나타내는 변수
        Score = 0;
        ScoreText.text = Score.ToString();

        //TODO : 식기도구 위치를 배열 혹은 리스트 형식으로 저장하고 도구 생성
    }

    //TODO : 식기도구가 추락하여 사라지면 앞서 생성한 리스트를 둘러보며
    //빈자리가 있는 공간에 도구 생성하는 함수

    // Update is called once per frame
    void Update()
    {
        //점수를 계속 갱신해준다
        ScoreText.text = Score.ToString();
    }

    public void PlayerRevive(GameObject Player)
    {
        //플레이어가 낙사 한 경우, SpawnPoint로 다시 불러와준다.
        Player.transform.position = SpawnPoint.transform.position;
    }
}
