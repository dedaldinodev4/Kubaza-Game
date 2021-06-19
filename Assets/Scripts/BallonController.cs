/*
 * @package Kubaza
 * @author Dedaldino Daniel
 * @version 0.0.1
 * @licence MIT
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BallonController : MonoBehaviour {

    [SerializeField]
    GameObject balloonPrefab;

    [HideInInspector]
    public int killedCount;
    [SerializeField]
    Text killedText;

    [HideInInspector]
    public int leackedCount;
    public Slider leackedSlider;

    float killerNumber = 10f;




    //* Span *//

    float spawnDelay = 0.7f;
    [SerializeField]
    float velocity = 80f;
    bool gameIsOver = false;
    public bool isOnWinner = false;
    public bool isOnMenu = false;
   

    //* life *//
    int maxLife = 10;
    int curLife;

    Rigidbody2D rb;
    AudioSource audioSource;

    
    public Sprite[] destrSp;

    [SerializeField]
    GameObject menuObj;

    [SerializeField]
    GameObject winnerPanel;

    [SerializeField]
    GameObject losePanel;

    //* Data Level Completed *//
    [SerializeField]
    Text BalloonsText;
    [SerializeField]
    Text LifeText;

    [SerializeField]
    Text TextGameOver;


    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        curLife = maxLife;
        leackedCount = maxLife;

        StartCoroutine(Spawn());
    }

    //* Span Method *//
    IEnumerator Spawn ()
    {
        
        SpawnBalloon();
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawn());
        yield return null;

    }

    //* SpanBallon Method *//
    void SpawnBalloon ()
    {
        Vector2 spawnPosition = new Vector2(Screen.width * Random.Range(0.1f, 0.9f), -200f);

        GameObject obj = Instantiate(balloonPrefab, spawnPosition, transform.rotation, transform);
        rb = obj.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, velocity);
        velocity *= 1.0001f;
        spawnDelay *= 0.999f;

    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        menuObj.SetActive(false);
        Time.timeScale = 1.0f;
        isOnMenu = false;

    }

    public void RepeatGame()
    {
        winnerPanel.SetActive(false);
        isOnWinner = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowKilledText()
    {
        killedText.text = ""+killedCount;
        BalloonsText.text = "" + killedCount;
        TextGameOver.text = "" + killedCount;

        if(killedCount == killerNumber && !isOnWinner)
        {
            isOnWinner = true;
            winnerPanel.SetActive(true);
            audioSource.Play();
            Time.timeScale = 0.0f;
        }
    }

    public void ShowLeackedSlider()
    {
        leackedSlider.value = leackedCount;
        
        
        curLife--;
        LifeText.text = "" + curLife;
        if (curLife == 0 && leackedCount == 0)
        {
            gameIsOver = true;
            losePanel.SetActive(true);
            audioSource.Play();
            Time.timeScale = 0.0f;
        }

    }

    public void StartMenu()
    {
        if (gameIsOver) return;
        if(!isOnMenu)
        {
            menuObj.SetActive(true);
            isOnMenu = true;
            Time.timeScale = 0.0f;
        } else
        {
            menuObj.SetActive(false);
            Time.timeScale = 1.0f;
            isOnMenu = false;
        }
    }


    public void ShowNextLevel()
    {
        velocity = velocity * 1.5f;
        killerNumber += killerNumber;
        
    }

   

    

    
}
