﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Singleton that controls the game state
/// </summary>
public class GameController : MonoBehaviour {
    static GameController instance;
    public static GameController Instance {
        get {
            return instance;
        }
    }

    [SerializeField]
    Image healthBar;

    const int StartingHealth = 20;

    public int Health {
        get; private set;
    }

    void Awake() {
        instance = this;
        Health = StartingHealth;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReduceHealth() {
        Health--;

        if(Health <= 0) {
            LoseGame();
        }

        healthBar.fillAmount = (float)Health / (float)StartingHealth;
     }

    void LoseGame() {
        Debug.Log("Game lost");
    }
}
