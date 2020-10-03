using UnityEngine;

public class TimerEndTestHandler : MonoBehaviour
{
    [SerializeField]
    Timer timer;


    void OnEnd()
    {
        Debug.Log("timer end!");
    }

    // Start is called before the first frame update
    void Start()
    {
        timer.SubscribeToTimerEnd(OnEnd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
