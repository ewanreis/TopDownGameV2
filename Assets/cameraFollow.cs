using UnityEngine;
// Kappa
public class cameraFollow : MonoBehaviour
{   public Transform target;
    [Range(0.0f, 1.0f)]
    public float smoothSpeed = 0.4f;
    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {   Vector3 desired = target.TransformPoint(new Vector3(0,0,-1)); // Camera's target position with the offset
        // Smoothing the camera movement
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothSpeed);
    }

} 

/*public Transform target;
    public float smoothSpeed = 12.5f;
    public Vector3 offset;
    private void LateUpdate()
    {
        Vector3 desired = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);
        transform.position = smoothed;
    }*/ // Old Code