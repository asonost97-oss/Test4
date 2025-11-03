using UnityEngine;

public class CDRotate : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
