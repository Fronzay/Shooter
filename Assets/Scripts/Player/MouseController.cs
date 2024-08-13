using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class MouseController : MonoBehaviour
{
   public Transform player;  // Трансформ игрока, за которым будет следовать камера
   public Transform weapon;  // Трансформ игрока, за которым будет следовать камера
    public Vector3 offset;     // Смещение камеры относительно игрока
    public float smoothing = 5f;  // Скорость плавного перемещения камеры

    public float sensitivity = 2f; // Чувствительность мыши для вращения камеры

    private Vector3 currentVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        offset = transform.position - player.position;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensitivity;
        float vertical = -Input.GetAxis("Mouse Y") * sensitivity;

        vertical = Mathf.Clamp(vertical, -90, 90);

        player.Rotate(0, horizontal, 0);

        transform.Rotate(vertical, 0, 0);

        Vector3 targetPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothing * Time.deltaTime);
        transform.position = smoothedPosition;

        //weapon.rotation = transform.rotation;
    }
}
