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
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            Gameinstance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
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
        Score = 0;
        ScoreText.text = Score.ToString();

        //TODO : �ı⵵�� ��ġ�� �迭 Ȥ�� ����Ʈ �������� �����ϰ� ���� ����
    }

    //TODO : �ı⵵���� �߶��Ͽ� ������� �ռ� ������ ����Ʈ�� �ѷ�����
    //���ڸ��� �ִ� ������ ���� �����ϴ� �Լ�

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
    }

    public void PlayerRevive(GameObject Player)
    {
        Player.transform.position = SpawnPoint.transform.position;
    }
}
