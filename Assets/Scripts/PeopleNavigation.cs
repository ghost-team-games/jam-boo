using UnityEngine;

public class PeopleNavigation : MonoBehaviour
{
    public Vector3 EnterPosition;
    public Vector3 ExitPosition;

    Transform[] walkMarkers;

    private void Awake()
    {
        walkMarkers = GetComponentsInChildren<Transform>();
    }

    public Vector3 GetWanderDestination()
    {
        return walkMarkers[Random.Range(0, walkMarkers.Length)].position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
