using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreIndicator : MonoBehaviour {

    TMP_Text textBox;

    void Start() {
        ScoreManager.Instance.OnScoreChanged.AddListener(UpdateScore);
        textBox = GetComponent<TMP_Text>();
    }

    void UpdateScore(int newScore) {
        textBox.text = newScore.ToString();
    }
}
