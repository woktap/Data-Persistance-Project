using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public static MenuUIHandler MenuUIHandler;
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text BestScore;
    public Text ScoreText;
    public GameObject GameOverText;

    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

   
    
    // Start is called before the first frame update
    void Start()
    {
        MenuUIHandler = new MenuUIHandler();


        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        BestScoreLoad();
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
                
            }
        }
        else if (m_GameOver)
        {
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                MenuUIHandler.Exite();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void AddPoint(int point)
    {
        
        m_Points += point;
        GameManager.Instance.playerScore = m_Points;
        ScoreText.text = $"Score : {m_Points}";
        BestScoreSave(m_Points);
    }

    

   public void BestScoreLoad()
    {
        GameManager.Instance.LoadPlayerInfo();
        int bestScore = GameManager.Instance.bestScore;
        string bestPlayerName = GameManager.Instance.bestPlayerName;
        BestScore.text = "Best score: " + bestPlayerName + ": " + bestScore;
       
        
    }

    public void BestScoreSave(int m_Points)
    {
        int bestScore = GameManager.Instance.bestScore;
        string bestPlayerName = GameManager.Instance.bestPlayerName;
        string newBestPlayer = GameManager.Instance.playerName;
        
        
        if (m_Points > bestScore)
        {
            GameManager.Instance.bestScore = m_Points;
            GameManager.Instance.bestPlayerName = newBestPlayer;
            GameManager.Instance.SavePlayerInfo();
        }
    }

    public void GameOver()
    {
        
        GameManager.Instance.SavePlayerInfo();
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
