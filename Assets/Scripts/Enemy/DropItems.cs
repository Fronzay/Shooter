using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    [SerializeField] private GameObject medkitPrefab;
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private GameObject ammoPrefab;

    private const float dropChance = 25;
    public void Drop(Transform position)
    {
        float randomValue = Random.Range(0, 50);

        Debug.Log(randomValue);

        if (randomValue <= dropChance)
        {
            int itemType = Random.Range(0, 2);

            GameObject itemToDrop = null;

            switch (itemType)
            {
                case 0:
                    itemToDrop = medkitPrefab;
                    break;
                case 1:
                    itemToDrop = shieldPrefab;
                    break;
                
            }

            if (itemToDrop != null)
            {
                Instantiate(itemToDrop, position.position, Quaternion.identity);
            }
        }
    }
}
