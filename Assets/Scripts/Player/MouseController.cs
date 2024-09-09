using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform weapon;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothing = 5f;

    [SerializeField] private float sensitivity = 2f;

   [SerializeField] private Vector3 currentVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        offset = transform.position - player.position;
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
    }
                                       
    private void FixedUpdate() // ‏חאיעו FixedUpdate, גלוסעמ Update :)
    {
        if (sensitivity != PlayerPrefs.GetFloat("Sensitivity")) {
            sensitivity = PlayerPrefs.GetFloat("Sensitivity"); // :>
        }
        if (Cursor.lockState == CursorLockMode.Locked) {
            float horizontal = Input.GetAxis("Mouse X") * sensitivity;
            float vertical = -Input.GetAxis("Mouse Y") * sensitivity;

            vertical = Mathf.Clamp(vertical, -90, 90);

            player.Rotate(0, horizontal, 0);

            transform.Rotate(vertical, 0, 0);

            Vector3 targetPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothing * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        
         

        //weapon.rotation = transform.rotation;
    }
}
