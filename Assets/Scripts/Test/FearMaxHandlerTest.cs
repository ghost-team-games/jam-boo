using UnityEngine;

public class FearMaxHandlerTest : MonoBehaviour
{
    [SerializeField]
    FearMeter fearMeter;

    // Start is called before the first frame update
    void Start()
    {
        fearMeter.SubscribeToFearAtMax(FearAtMax);
    }

    void FearAtMax()
    {
        Debug.Log("Fear at max");
    }
}
