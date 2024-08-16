using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmazonScore : MonoBehaviour, IScoreble
{
    public void AddScore()
    {
        GameManager.Instance.score += 5;
        SetText();
    }

    private void Start() => SetText();

    private void SetText()
    {
        GameManager.Instance.textScoreValue.text = $"Score: {GameManager.Instance.score}";

    }
}
