using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public static GameObject Player { get; private set; }

    void Awake ()
    {
        if (Instance != null)
            throw new System.Exception();
        
        Instance = this;
    }

    void Start ()
    {
        Player = GameObject.Find("Player");
    }
}
