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

    public GameObject player;
    public UnityEngine.Vector3 refPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameManager.instance = this;
        DontDestroyOnLoad(this);
    }

    void Start() {
        refPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playing) {
            clock += Time.deltaTime;
        }   
    }

    public void displayScore() {
        string dead = $"{deathCount}";
        string distance = $"{(refPoint-player.transform.position).magnitude}";
        string time = this.getFormatedTime(this.clock);
        ScoreDisplayManager.instance.RegisterScore(dead, distance, time);
    }

    public string getFormatedTime(float useclock) {
        int sec_ = (int)(useclock / 1000.0);
        int upoint = (int)(useclock % 1000);
        int sec = (int)(useclock % 3600);
        int minutes = (int)(useclock / 60);
        return $"{minutes}:{sec}.{upoint%1000}";
    }

    public bool playing = false;
    public float clock = 0;
    public void TimerStart() {
        playing = true;
    }
}
