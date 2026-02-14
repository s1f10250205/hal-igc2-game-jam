using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


public class LifeType {
    public LifeType(Func<int, int> action) {
        this.action = action;
    }
    public string name;
    public Func<int, int> action;
}

public class Lifemanager : MonoBehaviour
{
    public Dictionary<string, LifeType> lifemap = new Dictionary<string, LifeType>();
    public void registerLifeType(string tag, Func<int, int> action) {
        LifeType lifeType = new LifeType(action);
        lifeType.name = tag;
        lifemap.Add(tag, lifeType);
    }
    public void addLife(string tag) {
        GameManager.instance.remainLives.Push(this.lifemap[tag]);
    }
    public void removeLife() {
        GameManager.instance.remainLives.Pop();
    }
    public int getRemainLifeCount() {
        return GameManager.instance.remainLives.Count;
    }
}
