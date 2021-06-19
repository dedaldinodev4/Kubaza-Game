/**
 * @package Kubaza
 *@author Dedaldino Daniel
 * @licence 0.0.1
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void NextScene ()
    {
        SceneManager.LoadScene(2);
    }

    public void PreviousScene ()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void ExitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
	

}
