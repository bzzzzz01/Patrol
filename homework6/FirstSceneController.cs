using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour, SceneController, UserAction
{
    GameObject plane, player;
    public PatrolActionManager patrolActionManager;
    public ScoreRecorder scoreRecorder;
    public PatrolFactory patrolFactory;
    //public EventManager eventManager;
    
    private float speed = 10;
    private bool gameover = false;

    private List<GameObject> patroling = new List<GameObject>();
    private List<GameObject> catching = new List<GameObject>();

    void OnEnable()
    {
        EventManager.OnAddPatrol += AddPatrol;
    }
    void OnDisable()
    {
        EventManager.OnAddPatrol -= AddPatrol;
    }


    void Awake()
    {
        Director director = Director.getInstance();
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
    }

    public void LoadResources()
    {
        plane = Instantiate(Resources.Load("Plane") as GameObject);
        plane.transform.position = new Vector3(0, -0.5f, 0);
        player = Instantiate(Resources.Load("Player") as GameObject);
    }

    void Start()
    {
        patrolFactory = Singleton<PatrolFactory>.Instance;
        scoreRecorder = Singleton<ScoreRecorder>.Instance;
        //patrolActionManager = Singleton<PatrolActionManager>.Instance;
    }

    void Update()
    {
        GameObject tmp1 = null;
        GameObject tmp2 = null;
        foreach (GameObject patrol in patroling)
        {
            if (Vector3.Distance(patrol.transform.position, player.transform.position) <= 5)
            {
                tmp1 = patrol;
                patrolActionManager.CatchPlayer(patrol);
            }
        }
        if (tmp1 != null)
        {
            catching.Add(tmp1);
            patroling.Remove(tmp1);
        }
        foreach (GameObject patrol in catching)
        {
            if (Vector3.Distance(patrol.transform.position, player.transform.position) <= 1)
            {
                gameover = true;
            }
            if (Vector3.Distance(patrol.transform.position, player.transform.position) > 5)
            {
                tmp2 = patrol;
                patrolActionManager.Patrol(patrol);
                scoreRecorder.addScore();
            }
        }
        if (tmp2 != null)
        {
            patroling.Add(tmp2);
            catching.Remove(tmp2);
        }

    }

    void AddPatrol()
    {
        GameObject thePatrol = patrolFactory.getPatrol();
        patroling.Add(thePatrol);
        thePatrol.transform.position = new Vector3(Random.Range(0f, 10f), 0, Random.Range(0f, 10f));
        patrolActionManager.Patrol(thePatrol);
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public void move(float x, float y)
    {
        if (!gameover)
        {
            player.transform.Translate(x * speed * Time.deltaTime, 0, y * speed * Time.deltaTime);
        }
    }

    public int getScore()
    {
        return scoreRecorder.getScore();
    }

    public bool isGameover()
    {
        return gameover;
    }

    public void reset()
    {
        foreach (GameObject patrol in patroling)
        {
            patrolFactory.freePatrol(patrol);
        }
        patroling.Clear();
        foreach (GameObject patrol in catching)
        {
            patrolFactory.freePatrol(patrol);
        }
        catching.Clear();

        gameover = false;
        scoreRecorder.reset();
    }

}
