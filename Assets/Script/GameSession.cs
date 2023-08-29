using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;

    [SerializeField] AudioClip GameMusic;
    [SerializeField] float volume=0.2f;

    [SerializeField] TextMeshProUGUI LivesText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] int score = 0;

    
    bool musicPlay=false;

    void Awake()
    {
        if(musicPlay==false)
        {
             AudioSource.PlayClipAtPoint(GameMusic, Camera.main.transform.position,volume);
             musicPlay=true;
        }

        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
         
        LivesText.text=playerLives.ToString();
        ScoreText.text=score.ToString();
    }


   public void ProcessPlayerDeath()
   {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
   }


    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        ScoreText.text=score.ToString();
    }

     void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        LivesText.text=playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);

    }
}
