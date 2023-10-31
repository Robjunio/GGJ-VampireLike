using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record
{
    public int id { get; private set; }
    public string owner { get; private set; }
    public string ownerName { get; private set; }
    public int points { get; private set; }
    public string timeSpent { get; private set; }
    public int enemiesKilled { get; private set; }
    public string skillsList { get; private set; }

    public Record(object[] parameters)
    {
        this.id = int.Parse(parameters[0].ToString());
        this.owner = parameters[1].ToString();
        this.ownerName = parameters[2].ToString();
        this.points = int.Parse(parameters[3].ToString());
        this.timeSpent = parameters[4].ToString();
        this.enemiesKilled = int.Parse(parameters[5].ToString());
        this.skillsList = parameters[6].ToString();
    }
}
