using System.Collections;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField]
    PeopleNavigation navigation;

    public float pauseBetweenWalking;
    public float walkSpeed = 0.5f;
    public float runSpeed = 3f;
    public float directionThreshold = 1f;

    Animator animator;
    IEnumerator travelCoroutine;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void EnterHouse()
    {
        transform.position = navigation.EnterPosition;
        WalkTo(navigation.GetWanderDestination());
    }

    public void ExitHouse()
    {
        WalkTo(navigation.ExitPosition, runSpeed, keepWandering:false);
    }

    public void Wander()
    {
        WalkTo(navigation.GetWanderDestination());
    }

    string GetAnimationTrigger(Vector3 toLocation)
    {
        Vector3 diff = toLocation - transform.position;
        if(diff == Vector3.zero)
        {
            return "stop";
        }

        if(diff.y > directionThreshold)
        {
            if(Mathf.Abs(diff.x) < directionThreshold)
            {
                return "up";
            }
            else if(diff.x > 0)
            {
                return "upRight";
            }
            else
            {
                return "upLeft";
            }
        }
        else if(diff.y < -directionThreshold)
        {
            if (Mathf.Abs(diff.x) < directionThreshold)
            {
                return "down";
            }
            else if (diff.x > 0)
            {
                return "downRight";
            }
            else
            {
                return "downLeft";
            }
        }
        else if(diff.x > 0)
        {
            return "right";
        }
        else
        {
            return "left";
        }
    }

    void WalkTo(Vector3 location, float? speed = null, bool keepWandering = true)
    {
        if(travelCoroutine != null)
        {
            StopCoroutine(travelCoroutine);
        }

        travelCoroutine = WalkCoroutine(location, speed, keepWandering);
        StartCoroutine(travelCoroutine);
    }

    IEnumerator WalkCoroutine(Vector3 location, float? speed = null, bool keepWandering = true)
    {
        float travelSpeed = speed ?? walkSpeed;
        Vector3 start = transform.position;
        animator.SetTrigger(GetAnimationTrigger(location));
        float timeToWalk = Vector3.Distance(start, location) / travelSpeed;
        float timer = 0;
        while(timer < timeToWalk)
        {
            transform.position = Vector3.Lerp(start, location, timer / timeToWalk);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = location;
        if(pauseBetweenWalking > 0)
        {
            animator.SetTrigger("stop");
            yield return new WaitForSeconds(pauseBetweenWalking);
        }
        if(keepWandering)
        {
            Wander();
        }
    }
}
