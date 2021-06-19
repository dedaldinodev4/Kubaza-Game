/**
* @package Kubaza
* @author Dedaldino Daniel
* @version 0.0.1
* @licence MIT
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour {

    public Text counterText;
    float timeCounter = 0f;


    /*public Image imageSprite;
    public Sprite[] textCount;
    int spriteCurrent = 0;
    */




    void Start()
    {
        timeCounter = 10f;
    }

    void Update ()
    {
        timeCounter -= Time.deltaTime;
        timeCounter = Mathf.FloorToInt(timeCounter % 60);
        counterText.text = timeCounter.ToString();

        if(timeCounter == 0)
        {
            counterText.text = "Aguarde";
            SceneManager.LoadScene(1);
        }
    }

    

    /* IEnumerator ShowCounter()
    {
        imageSprite.sprite = textCount[spriteCurrent];
        spriteCurrent++;
        if (spriteCurrent == textCount.Length)
        {
            imageSprite.enabled = false;
            yield break;
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(ShowCounter());
        yield return null;
    }*/




}


