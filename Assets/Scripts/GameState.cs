using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool Paused { get; private set; }

    private void Awake()
    {
        Paused = false;
    }

    public void Play()
    {
        Paused = false;
    }

    public void Pause()
    {
        Paused = true;

    }
}
