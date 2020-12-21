using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class UnitRenderer : MonoBehaviour
{
    public UnitSpriteSet SpriteSet;
    public SpriteRenderer Renderer;
    public Unit Unit;

    UnitState LastState = UnitState.IDLE;

    AnimFrame frame;

    // Start is called before the first frame update
    void Start()
    {
        frame = new AnimFrame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Unit.State != LastState)
        {
            frame.reset();
            LastState = Unit.State;
        }
        else
        {
            SpriteSet.UpdateFrame(frame, Unit.State);
            Debug.Log("Frame After Exit: "+frame.index);
        }

        if (Unit.IsMoving)
        {
            SetWalkingSprite();
        }
        else
        {
            SetIdleSprite();
        }
        SetFlips();
    }

    void SetWalkingSprite()
    {
        switch(Unit.Direction)
        {
            case 0:
                Renderer.sprite = SpriteSet.WalkNorth(frame.index);
                break;
            case 1:
                Renderer.sprite = SpriteSet.WalkNorthEast(frame.index);
                break;
            case 2:
                Renderer.sprite = SpriteSet.WalkEast(frame.index);
                break;
            case 3:
                Renderer.sprite = SpriteSet.WalkSouthEast(frame.index);
                break;
            case 4:
                Renderer.sprite = SpriteSet.WalkSouth(frame.index);
                break;
            case 5:
                Renderer.sprite = SpriteSet.WalkSouthEast(frame.index);
                break;
            case 6:
                Renderer.sprite = SpriteSet.WalkEast(frame.index);
                break;
            case 7:
                Renderer.sprite = SpriteSet.WalkNorthEast(frame.index);
                break;
        }
    }

    void SetIdleSprite()
    {
        switch (Unit.Direction)
        {
            case 0:
                Renderer.sprite = SpriteSet.IdleNorth();
                break;
            case 1:
                Renderer.sprite = SpriteSet.IdleNorthEast();
                break;
            case 2:
                Renderer.sprite = SpriteSet.IdleEast();
                break;
            case 3:
                Renderer.sprite = SpriteSet.IdleSouthEast();
                break;
            case 4:
                Renderer.sprite = SpriteSet.IdleSouth();
                break;
            case 5:
                Renderer.sprite = SpriteSet.IdleSouthEast();
                break;
            case 6:
                Renderer.sprite = SpriteSet.IdleEast();
                break;
            case 7:
                Renderer.sprite = SpriteSet.IdleNorthEast();
                break;
        }
    }

    void SetFlips()
    {
        if (Unit.Direction>4) Renderer.flipX = true;
        else Renderer.flipX = false;
    }
}
