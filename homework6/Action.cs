using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : ScriptableObject
{
    public bool enable = true;
    public bool destroy = false;

    public GameObject GameObject { get; set; }
    public ActionCallback Callback { get; set; }

    protected Action() { }

    public virtual void Start()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}
