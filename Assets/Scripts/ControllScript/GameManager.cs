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
            //���ӸŴ��� �ν��Ͻ��� ���ٸ�(���� ���� ��) �ڽ��� �Ҵ��Ŵ
            Gameinstance = this;

            //���� ��ȯ�Ǿ �ı����� �ʰ� ���ִ� DontDestroyOnLoad �Լ� ���
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //�ٸ� ������ �̵����� ��, �̹� ���ӸŴ����� �����ϸ� �ڽ��� �ı��ϰ� ���� ���ӸŴ��� ���
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
        //������ ��Ÿ���� ����
        Score = 0;
        ScoreText.text = Score.ToString();

        //TODO : �ı⵵�� ��ġ�� �迭 Ȥ�� ����Ʈ �������� �����ϰ� ���� ����
    }

    //TODO : �ı⵵���� �߶��Ͽ� ������� �ռ� ������ ����Ʈ�� �ѷ�����
    //���ڸ��� �ִ� ������ ���� �����ϴ� �Լ�

    // Update is called once per frame
    void Update()
    {
        //������ ��� �������ش�
        ScoreText.text = Score.ToString();
    }

    public void PlayerRevive(GameObject Player)
    {
        //�÷��̾ ���� �� ���, SpawnPoint�� �ٽ� �ҷ����ش�.
        Player.transform.position = SpawnPoint.transform.position;
    }
}
