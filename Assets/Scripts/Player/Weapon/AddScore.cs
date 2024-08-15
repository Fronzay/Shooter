using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void Start() => SetText();

    public void AddScoreKill(int valueAddScore)
    {
        GameManager.Instance.score += valueAddScore;
        SetText();
    }
    
    public void AddScoreTypeEnemy(Collider col)
    {
        if ( col.TryGetComponent(out TypePirate pirate) )
        {
            AddScoreKill(1);
        }
    }

    private void SetText()
    {
        GameManager.Instance.textScoreValue.text = $"Score: {GameManager.Instance.score}";

    }
}
