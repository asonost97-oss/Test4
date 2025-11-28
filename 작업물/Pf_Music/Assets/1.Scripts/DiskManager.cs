using UnityEngine;

public class DiskManager : MonoBehaviour
{
    float rollSpeed = -0.5f;

    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(0, 0, rollSpeed);
    }
}
