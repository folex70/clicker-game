using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GM : MonoBehaviour
{
    public static int money;
    public static int level;//miner level
    public static int power;//power
    public static int miner;//another multiplier for dwarf
    public static float time;//expedition time 
    public static float timeMiner; //time for dwarf action
    public static float baseTimeMiner; //base time for dwarf action

    void Start()
    {
        power = 1;
        money = 0;
        miner = 1;
        time = 120;
        level = 1;
        timeMiner = 1;
        baseTimeMiner = 1;
    }


}
