using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{

    private UserAction action;

    void Start()
    {
        action = Director.getInstance().currentSceneController as UserAction;
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        action.move(x, y);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, Screen.height - 60, 100, 30), "reset"))
        {
            action.reset();
        }
        if (action.isGameover())
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "Gameover!\nYour final\nscore: " + action.getScore() + "\nClick to reset"))
            {
                action.reset();
            }
        }
        GUI.Label(new Rect(10, 30, 60, 30), "Score: " + action.getScore());
    }
}
