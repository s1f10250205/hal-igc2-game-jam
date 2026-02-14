using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class GameManager : MonoBehaviour
{
    //インスタンスたち
    static public GameManager instance;
    public Lifemanager lifemanager;

    //状態たち
    public float deathCount;
    public Stack<LifeType> remainLives = new Stack<LifeType>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameManager.instance = this;
    }

    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
