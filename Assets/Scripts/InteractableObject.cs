using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    public float cooldownTimer;
    public float animationLength;

    private Animator animator;
    private bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        if (cooldown == false)
        {
            //UnityEngine.Debug.Log("clicked");
            animator.SetBool("Haunt", true);
            StartCoroutine(AnimationDelay(animationLength));           
            cooldown = true;
        }
    }

    private IEnumerator AnimationDelay(float animationLength)
    {
        yield return new WaitForSeconds(animationLength);
        animator.SetBool("Haunt", false);
        StartCoroutine(CoolDownTimer(cooldownTimer));
    }

    private IEnumerator CoolDownTimer(float coolDownTimer)
    {
        yield return new WaitForSeconds(coolDownTimer);
        cooldown = false;
    }
}
