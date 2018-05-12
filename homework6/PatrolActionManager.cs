using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolActionManager : ActionManager, ActionCallback
{
    public float speed = 1;
    public FirstSceneController sceneController;
    public GameObject player;
    public PatrolAction patrolAction;
    public CatchAction catchAction;

    protected new void Start()
    {
        sceneController = Director.getInstance().currentSceneController as FirstSceneController;
        sceneController.patrolActionManager = this;
        player = sceneController.getPlayer();

        patrolAction = PatrolAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), speed);
        catchAction = CatchAction.getAction(player, speed);
        
    }

    protected new void Update()
    {
        base.Update();
    }

    public void Patrol(GameObject patrol)
    {
        patrolAction = PatrolAction.getAction(new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f)), speed);
        this.RunAction(patrol, patrolAction, this);
    }

    public void CatchPlayer(GameObject patrol)
    {
        catchAction = CatchAction.getAction(player, speed);
        this.RunAction(patrol, catchAction, this);
    }

    public void ActionEvent(Action source, GameObject gameObjectParam = null, ActionEventType events = ActionEventType.Compeleted,
                        int intParam = 0, string strParam = null) { }

}