using UnityEngine;

public class PeopleNavigation : MonoBehaviour
{
    public Vector3 EnterPosition;
    public Vector3 ExitPosition;

    Transform[] walkMarkers;
    Vector3 lastReturnedWalkMarker;

    private void Awake()
    {
        walkMarkers = GetComponentsInChildren<Transform>();
    }

    public Vector3 GetWanderDestination()
    {
        Vector3 marker;
        do
        {
            marker = walkMarkers[Random.Range(0, walkMarkers.Length)].position;
        }
        while(marker == lastReturnedWalkMarker);
        return (lastReturnedWalkMarker = marker);
    }
}
