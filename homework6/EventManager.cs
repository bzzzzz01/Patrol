using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void AddPatrol();
    public static event AddPatrol OnAddPatrol;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(10, Screen.height - 100, 100, 30), "Add Patrol"))
        {
            if (OnAddPatrol != null)
            {
                OnAddPatrol();
            }
        }
    }
}
