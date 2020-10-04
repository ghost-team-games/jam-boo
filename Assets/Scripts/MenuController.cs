using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Image fadeImage;

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int sceneNumber)
    {

        StartCoroutine(FadeOut(sceneNumber));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator FadeOut(int sceneNumber)
    {
        animator.SetBool("Fade", true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneNumber);
    }
}
