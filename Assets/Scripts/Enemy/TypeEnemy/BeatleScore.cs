using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatleScore : MonoBehaviour, IScoreble
{
    public void AddScore()
    {
        GameManager.Instance.score += 15;
        SetText();
    }

    private void Start() => SetText();

    private void SetText()
    {
        GameManager.Instance.textScoreValue.text = $"Score: {GameManager.Instance.score}";

    }
}
