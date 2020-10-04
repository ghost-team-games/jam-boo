using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyBehaviour : MonoBehaviour
{
    [SerializeField]
    Tutorial tutorial;

    Person[] family;

    private void Awake()
    {
        family = GetComponentsInChildren<Person>();
    }

    private void Start()
    {
        if (!tutorial.inTutorial)
        {
            MoveIn();
        }
    }

    public void MoveIn()
    {
        foreach(Person person in family)
        {
            person.EnterHouse();
        }
    }

    public void PauseWandering()
    {
        foreach(Person person in family)
        {
            person.Pause();
        }
    }

    public void ResumeWandering()
    {
        foreach(Person person in family)
        {
            person.Play();
        }
    }

    public void RunAway()
    {
        foreach(Person person in family)
        {
            person.ExitHouse();
        }
    }
}
