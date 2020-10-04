using System.Collections;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    FearMeter fear;

    [SerializeField]
    GameState state;

    [SerializeField]
    Tutorial tutorial;

    [SerializeField]
    GameObject[] hideOnHaunt;

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
        
        if (!state.Paused || tutorial.inTutorial)
        {
            if (cooldown == false)
            {
                if(animator)
                {
                    HauntAnimation();
                }
                else
                {
                    StartCoroutine(CoolDownTimer(cooldownTimer));
                }
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
    }

    void HauntAnimation()
    {
        animator.SetTrigger("haunt");
        StartCoroutine(AnimationDelay(animationLength));
        foreach(GameObject hide in hideOnHaunt)
        {
            hide.SetActive(false);
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
        foreach(GameObject show in hideOnHaunt)
        {
            show.SetActive(true);
        }
        StartCoroutine(CoolDownTimer(cooldownTimer));
    }

    private IEnumerator CoolDownTimer(float coolDownTimer)
    {
        yield return new WaitForSeconds(coolDownTimer);
        cooldown = false;
    }
}
