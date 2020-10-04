using UnityEngine;

public class Ghost : MonoBehaviour
{
    Animator animator;

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
}
