using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : Action
{
    public Vector3 direction;
    public float speed;

    public static PatrolAction getAction(Vector3 direction, float speed)
    {
        PatrolAction action = CreateInstance<PatrolAction>();
        action.direction = direction;
        action.speed = speed;
        return action;
    }

    public override void Start() { }
    
    public override void Update()
    {
        this.GameObject.transform.position += direction * speed * Time.deltaTime;
        if (this.GameObject.transform.position.x > 10 || this.GameObject.transform.position.x < -10 ||
            this.GameObject.transform.position.z > 10 || this.GameObject.transform.position.z < -10)
        {
            float tmp = direction.x;
            direction.x = direction.z;
            direction.z = -tmp;
        }

    }

}