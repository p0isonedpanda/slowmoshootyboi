using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public static GameObject Player { get; private set; }

    float score;
    bool playing = true;
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
        if (!playing) return;
        score += Time.deltaTime;
        scoreText.text = score.ToString("F2");
    }

    public void EndGame()
    {
        // dun kill all enemy cause they know what they did >:(
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in enemies)
        {
            e.GetComponent<EnemyController>().Destroy();
        }

        playing = false;
    }
}
