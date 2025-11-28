using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 10f;

    void Start()
    {
        
               
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target == null)
        {
            return;
        }
        
        Vector3 playerFollow = new Vector3(target.position.x, target.position.y, transform.position.z);


        // 부드럽게 카메라 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerFollow, smoothSpeed * Time.deltaTime);


        // 카메라 위치 업데이트
        transform.position = smoothedPosition;
    }
}
