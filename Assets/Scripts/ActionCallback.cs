using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionEventType : int { Started, Compeleted }

public interface ActionCallback
{
    void ActionEvent(Action source, GameObject gameObjectParam = null, ActionEventType events = ActionEventType.Compeleted,
                     int intParam = 0, string strParam = null);
}
