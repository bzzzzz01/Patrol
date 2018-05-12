using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UserAction
{
    bool isGameover();
    int getScore();
    void reset();
    void move(float x, float y);
}

