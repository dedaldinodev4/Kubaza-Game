/*
 * @package Kubaza
 * @author Dedaldino Daniel
 * @version 0.0.1
 * @licence MIT
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour {

    AudioSource audioSource;

    Image image;

    BallonController bl;


    bool isTouched = false;

    int sprinteNumber = 0;



    void Start()
    {
        bl = transform.root.GetComponent<BallonController>();

        audioSource = transform.GetComponent<AudioSource>();

        image = GetComponent<Image>();

        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        color.a = Random.Range(0.6f, 1f);
        image.color = color;
        

    }

    public void OnTouch()
    {
        if (isTouched || bl.isOnMenu ) return;
        isTouched = true;
        bl.killedCount++;
        bl.ShowKilledText();
        audioSource.Play();
        StartCoroutine(ShowAnim());
        Destroy(gameObject, 0.6f);
    }

    IEnumerator ShowAnim()
    {
        image.sprite = bl.destrSp[sprinteNumber];
        sprinteNumber++;
        if(sprinteNumber == bl.destrSp.Length)
        {
            image.enabled = false;
            yield break;
        }

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ShowAnim());
        yield return null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bl.leackedCount--;
        bl.ShowLeackedSlider();
        Destroy(gameObject);
    }

}
