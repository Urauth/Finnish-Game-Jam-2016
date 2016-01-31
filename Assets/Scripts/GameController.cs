﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

	public static System.Random jamRandomer = new System.Random(666);

	Dictionary<string, List<Word>> wordsByClient;

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
		WordGenerator.CreateWordPool();

		RitualHandler.Instance.DistributeWords();
        RitualHandler.Instance.NewRitual();	
	}

	// Update is called once per frame
	void Update () {
		GameUI.Instance.IncreaseHealthBarFill(Time.deltaTime * 0.01f);

		if(EnemySpawner.Instance.IsBossWave) {
			if(GameUI.Instance.GetHealthBarFill() >= 1.0f) {
				EnemySpawner.Instance.KillBoss();
			}
		}
	}

    public void ReduceHealth(int amount) {
        Health -= amount;

        if(Health <= 0) {
            LoseGame();
        }

        GameUI.Instance.SetHealthBarFill((float)Health / (float)StartingHealth);
     }

    void LoseGame() {
        Debug.Log("Game lost");
    }
}
