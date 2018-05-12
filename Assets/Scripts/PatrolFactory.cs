using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFactory : MonoBehaviour
{

    public GameObject PatrolPrefab = null;

    private List<GameObject> used = new List<GameObject>();
    private List<GameObject> free = new List<GameObject>();

    private void Awake()
    {
        PatrolPrefab = Instantiate(Resources.Load("Patrol") as GameObject);
        PatrolPrefab.SetActive(false);
    }

    public GameObject getPatrol()
    {
        GameObject newPatrol = null;
        if (free.Count > 0)
        {
            newPatrol = free[0].gameObject;
            newPatrol.SetActive(true);
            free.Remove(free[0]);
        }
        else
        {
            newPatrol = Instantiate(PatrolPrefab);
            newPatrol.SetActive(true);
        }
        used.Add(newPatrol);

        return newPatrol;
    }

    public void freePatrol(GameObject thePatrol)
    {
        GameObject tmp = null;
        foreach (GameObject patrol in used)
        {
            if (patrol.GetInstanceID() == thePatrol.GetInstanceID() )
            {
                tmp = patrol;
            }
        }
        if (tmp != null)
        {
            tmp.SetActive(false);
            free.Add(tmp);
            used.Remove(tmp);
        }
    }

}