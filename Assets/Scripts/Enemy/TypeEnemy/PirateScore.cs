using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateScore : MonoBehaviour, IScoreble
{
    public void AddScore()
    {
        GameManager.Instance.score++;
        SetText();
    } 

    private void Start() => SetText();

    private void SetText()
    {
        GameManager.Instance.textScoreValue.text = $"Score: {GameManager.Instance.score}";

    }
}
