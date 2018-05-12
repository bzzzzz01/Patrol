using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAction : Action
{
    public GameObject gameObject;
    public float speed;

    public static CatchAction getAction(GameObject gameObject, float speed)
    {
        CatchAction action = CreateInstance<CatchAction>();
        action.gameObject = gameObject;
        action.speed = speed;
        return action;
    }

    public override void Start() { }

    public override void Update()
    {
        this.GameObject.transform.position = Vector3.MoveTowards(this.GameObject.transform.position, gameObject.transform.position, speed * 0.5f * Time.deltaTime);

    }

}