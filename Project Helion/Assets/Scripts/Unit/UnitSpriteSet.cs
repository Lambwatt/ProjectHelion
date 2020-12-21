using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpriteSet : MonoBehaviour
{
    public Sprite[] Sprites;
    public int WalkLength = 1;
    public float FrameTime = 0.5f;

    public int WalkNorthIndex;
    public int WalkNorthEastIndex;
    public int WalkEastIndex;
    public int WalkSouthEastIndex;
    public int WalkSouthIndex;

    //Update frame of animation. Return true if animation completed a cycle
    public bool UpdateFrame(AnimFrame frame, UnitState state)
    {
        bool finishedCycle = false;
        frame.time += Time.deltaTime;
        if (frame.time >= FrameTime)
        {
            Debug.Log("Initial Frame Index: " + frame.index);
            frame.time %= FrameTime;
            Debug.Log("New Frame Index: " + frame.index);
            if (++frame.index == WalkLength)
                finishedCycle = true;

            frame.index %= WalkLength;
        }
        return finishedCycle;
    }

    public Sprite IdleNorth()
    {
        return Sprites[0];
    }

    public Sprite IdleNorthEast()
    {
        return Sprites[1];
    }

    public Sprite IdleEast()
    {
        return Sprites[2];
    }

    public Sprite IdleSouthEast()
    {
        return Sprites[3];
    }

    public Sprite IdleSouth()
    {
        return Sprites[4];
    }

    public Sprite WalkNorth(int index)
    {
        return Sprites[WalkNorthIndex+(index%WalkLength)];
    }

    public Sprite WalkNorthEast(int index)
    {
        return Sprites[WalkNorthEastIndex + (index % WalkLength)];
    }

    public Sprite WalkEast(int index)
    {
        return Sprites[WalkEastIndex + (index % WalkLength)];
    }

    public Sprite WalkSouthEast(int index)
    {
        return Sprites[WalkSouthEastIndex + (index % WalkLength)];
    }

    public Sprite WalkSouth(int index)
    {
        return Sprites[WalkSouthIndex + (index % WalkLength)];
    }
}
