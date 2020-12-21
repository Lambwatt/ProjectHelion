using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFrame
{
    public float time;
    public int index;

    public void reset()
    {
        time = 0.0f;
        index = 0;
    }

    public void step()
    {
        time += Time.deltaTime;
    }
}
