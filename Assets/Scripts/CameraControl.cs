using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 minPos, maxPos;

    
    void FixedUpdate()
    {
       Follow();
       

    }
    void Follow(){
        Vector3 targetPosition = target.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x),
            Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y),
            Mathf.Clamp(targetPosition.z, minPos.z, maxPos.z)
        );
        transform.position = boundPosition;
    }
}