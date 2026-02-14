using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class ScoreDisplayManager : MonoBehaviour
{

    public ValueSetter title;
    public ValueSetter info;

    static public ScoreDisplayManager instance;
    void Start() {
        ScoreDisplayManager.instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RegisterScore(string deadCount, string distance, string time) {
        title.SetValue(deadCount);
        info.SetValue(distance, time);
    }
}
