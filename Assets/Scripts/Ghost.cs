using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3 hauntOffset = new Vector3(-0.75f, -0.75f);

    Animator animator;
    IEnumerator moveCoroutine;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PauseAnimation()
    {
        animator.StartPlayback();
    }

    public void ResumeAnimation()
    {
        animator.StopPlayback();
    }

    public void TravelTo(InteractableObject hauntTarget)
    {
        if(moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = MoveToObject(hauntTarget);
        StartCoroutine(moveCoroutine);
    }

    IEnumerator MoveToObject(InteractableObject hauntTarget)
    {
        Vector3 current = transform.position;
        Vector3 target = hauntTarget.transform.position + hauntOffset;
        while(!Mathf.Approximately(Vector3.Distance(current, target), 0))
        {
            transform.position = Vector3.MoveTowards(current, target, moveSpeed * Time.deltaTime);
            current = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }
}
