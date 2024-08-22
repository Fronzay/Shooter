using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    [SerializeField] int _forceValue;

    [SerializeField] float spreadAngle;


    private void Update() => Force();

    private void Force()
    {
        GetComponent<Rigidbody>().AddForce(GetRandomSpreadDirection() * _forceValue * Time.deltaTime);

    }

    Vector3 GetRandomSpreadDirection()
    {
        float spreadX = Random.Range(-spreadAngle / 2, spreadAngle / 2);
        float spreadY = Random.Range(-spreadAngle / 2, spreadAngle / 2);

        Vector3 spread = new Vector3(spreadX, spreadY, 0);
        Vector3 direction = transform.forward + transform.TransformDirection(spread);

        return direction.normalized;
    }
}

