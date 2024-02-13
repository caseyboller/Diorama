using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public Animator animator;
    public float transitionTime;

    public void ToMainMenu()
    {
        StartCoroutine(TransitionToLevel("MainMenu"));
    }    
    
    public void ToSakura()
    {
        StartCoroutine(TransitionToLevel("Sakura"));
    }

    public void ToTorii()
    {
        StartCoroutine(TransitionToLevel("Torii"));
    }

    IEnumerator TransitionToLevel(string level)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
}
