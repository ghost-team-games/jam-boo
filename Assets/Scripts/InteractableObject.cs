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

    [Tooltip("To use an animator on a different object for haunting animation")]
    [SerializeField]
    Animator animatorOverride;

    [SerializeField]
    HauntIcon icon;

    public float cooldownTimer;
    public float animationLength;
    public float customFearAmount = 0;
    public Material redMaterial;
    public Material greenMaterial;

    private Animator animator;
    private bool cooldown;
    private Renderer rend;
    private Material baseMaterial;
    //private HauntIcon icon;

    // Start is called before the first frame update
    void Start()
    {
        // default to animator on the object
        animator = animatorOverride == null ? GetComponent<Animator>() : animatorOverride;
        cooldown = false;
        rend = GetComponent<Renderer>();
        baseMaterial = GetComponent<Renderer>().material;
        //icon = GetComponentInChildren<HauntIcon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        
        if (!state.Paused || tutorial.inTutorial)
        {
            if(cooldown == false)
            {
                Haunt();
            }
        }
    }

    void Haunt()
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

        if(customFearAmount > 0)
        {
            fear.IncreaseFearByAmount(customFearAmount);
        }
        else
        {
            fear.IncreaseFear();
        }
        state.HauntObject(this);
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
            icon.ShowHauntDisabledIcon();
            rend.material = redMaterial;
        }
        else
        {
            icon.ShowHauntEnabledIcon();
            rend.material = greenMaterial;
        }
    }

    private void OnMouseExit()
    {
        icon.HideIcon();
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
