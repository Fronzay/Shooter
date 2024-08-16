using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisScore : MonoBehaviour, IScoreble
{
    public void AddScore()
    {
        GameManager.Instance.score += 20;
        SetText();
    }

    private void Start() => SetText();

    private void SetText()
    {
        GameManager.Instance.textScoreValue.text = $"Score: {GameManager.Instance.score}";

    }
}
