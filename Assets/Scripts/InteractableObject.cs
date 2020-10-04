﻿using System.Collections;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    FearMeter fear;

    public float cooldownTimer;
    public float animationLength;
    public float customFearAmount = 0;
    public Material redMaterial;
    public Material greenMaterial;

    private Animator animator;
    private bool cooldown;
    private Renderer rend;
    private Material baseMaterial;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cooldown = false;
        rend = GetComponent<Renderer>();
        baseMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        if (cooldown == false)
        {
            animator.SetBool("Haunt", true);
            StartCoroutine(AnimationDelay(animationLength));           
            cooldown = true;
            if (customFearAmount > 0)
            {
                fear.IncreaseFearByAmount(customFearAmount);
            }
            else
            {
                fear.IncreaseFear();
            }
        }
    }

    private void OnMouseOver()
    {
        if(cooldown)
        {
            rend.material = redMaterial;
        }
        else
        {
            rend.material = greenMaterial;
        }
    }

    private void OnMouseExit()
    {
        rend.material = baseMaterial; 
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