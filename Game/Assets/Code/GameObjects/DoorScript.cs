using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MAIN_GAME_OBJECT_SCRIPT
{
    [SerializeField] internal Transform teleport;
    [SerializeField] internal float opacityMeter;
    [SerializeField] internal float opacitySpeedFactor;
    [SerializeField] internal float opacityMeterShift;
    [SerializeField] internal bool increaseOpacity;
    [SerializeField] internal Color spriteColor;
    [SerializeField] static internal float transitionDuration = 2.5f;


    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_TELEPORT;
        base.set();
    }
    void Start()
    {
        set();
    }
    void Update()
    {
        COLOR2.flashing_in_out_self(transitionDuration, spriterender );
    }


}
