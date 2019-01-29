using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public static GameObject Player { get; private set; }

    float score;
    [SerializeField]
    Text scoreText;


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

    void Update ()
    {
        score += Time.deltaTime;
        scoreText.text = score.ToString("F2");
    }
}
