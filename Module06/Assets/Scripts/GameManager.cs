using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager _instance = null;
    public GameManager instance => _instance;

    public static int nb_keys = 0;
    public static bool isSpoted = false;
    public static bool isGameOver = false;
    public static bool getCaugth = false;
    [SerializeField] private Texture2D gameOverTexture;
    [SerializeField] private Texture2D winTexture;
    [SerializeField] private AudioSource deathAudio;
    [SerializeField] private AudioSource winAudio;
    private float timer = 0f;
    private float timeMax = 3f;
    private void Awake()
    {
        // if (_instance == null && _instance != this)
        // {
        //     Destroy(gameObject);
        //     return;
        // } else
        // {
        //     _instance = this;
        // }
        // DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (getCaugth) {
            // GameObject.Find("JohnLemon").SetActive(false);
             timer += Time.deltaTime;
            if (timer >= timeMax)
            {
                timer = 0f;
                SceneManager.LoadScene(0);
                getCaugth = false;
            }
        }
    }

    public void endGame(bool win)
    {
        if (win)
        {
            winAudio.Play();
            GameObject.Find("EndGame").GetComponent<EndGame>().end(winTexture);
        } else
        {
            deathAudio.Play();
            GameObject.Find("EndGame").GetComponent<EndGame>().end(gameOverTexture);
        }
        isGameOver = true;
    }
}
