using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPositiion = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPositiion;
    }
}
//This follows the player as he moves throughout the scene, you have to offset the Z by -10 for this to
//work effectively. Otherwise, the camera looks at the blue background below the ground. So minor bug issue,
//, but it's fixed now :)
