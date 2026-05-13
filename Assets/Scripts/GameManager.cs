using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }

    public float initialgamespeed = 5f;
    public float gamespeedincrease = 0.1f;
    public float gamespeed { get; private set; }


    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button retryButton;

    public TextMeshProUGUI gameovertext;
    public TextMeshProUGUI scoretext;
    public Button retrybutton;

    private Player player;
    private Spawner spawner;

    private float score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
           Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        
        NewGame();
    }

    public void NewGame()
    {
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        
        gamespeed = initialgamespeed;
        score = 0f;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameovertext.gameObject.SetActive(false);
        retrybutton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gamespeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameovertext.gameObject.SetActive(true);
        retrybutton.gameObject.SetActive(true);
    }

    private void Update()
    {
        gamespeed += gamespeedincrease * Time.deltaTime;
        score += gamespeed * Time.deltaTime;
        scoretext.text = Mathf.FloorToInt(score).ToString("D5");
    }

}
