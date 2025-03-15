using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;
    public UnityEvent<int> OnScoreChanged;

    public int endScore = 1;
    private int score = 0;

    private void Awake() {
        if(Instance == null) Instance = this;
    }

    public void AddScore(int amount) {
        score += amount;
        OnScoreChanged.Invoke(score);// ui update
        if(score == endScore) {
            SceneChanger.Instance.NextLevel();
        }
    }
}

