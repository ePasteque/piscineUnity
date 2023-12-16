using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager _instance = null;
    public GameManager instance => _instance;

    public static bool[] isTaken;
    public static string[] nameLeaf;
    public static int nb_leaf = 0;
    public static int health = 3;
    public static int ttPoints = 0;
    private static int stage;
    private static string stageName;
    public static bool isNewGame = true;
    private static bool isInGame = false;
    public static int death = 0;
    private void Awake()
    {
        if (_instance == null && _instance != this)
        {
            Destroy(gameObject);
            return;
        } else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("ttPoints", ttPoints);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("death", death);
        PlayerPrefs.SetString("stage", "Stage1");
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddPoints(int points)
    {
        ttPoints += points;
    }

    public static void ResumeGame()
    {
        if (!isInGame)
            return;
        ttPoints = PlayerPrefs.GetInt("ttPoints");
        health = PlayerPrefs.GetInt("health");
        Debug.Log("health get: " + health);
        stageName = PlayerPrefs.GetString("stage");
        isNewGame = false;
        SceneManager.LoadScene(stageName);
    }

    public static void NewGame()
    {
        PlayerPrefs.DeleteAll();
        ttPoints = 0;
        health = 3;
        stage = 1;
        death = 0;
        isNewGame = true;
        isInGame = true;
        SceneManager.LoadScene("Stage1");
    }

    public static void GoToMenu()
    {
        GameObject[] leaves = GameObject.FindGameObjectsWithTag("Collectible");
        for (int i = 0; i < leaves.Length; i++)
        {
            PlayerPrefs.SetString("leaf" + i, leaves[i].name);
            if (leaves[i].GetComponent<SpriteRenderer>().enabled == false)
            {
                PlayerPrefs.SetInt("isTaken" + i, 1);
            }
            else
            {
                PlayerPrefs.SetInt("isTaken" + i, 0);
            }
        }
        PlayerPrefs.SetString("stage", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("ttPoints", ttPoints);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("death", death);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }

    public static void nextStage()
    {
        stage = int.Parse(SceneManager.GetActiveScene().name[5].ToString());
        stage++;
        if (stage > 3)
        {
            stage = 1;
        }
        PlayerPrefs.DeleteAll();
        nb_leaf = 0;
        ttPoints = 0;
        health = 3;
        PlayerPrefs.SetInt("ttPoints", ttPoints);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetString("stage", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Stage" + stage);
    }
}
