using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public Transform target;

    public float scrollSpeed = 0.1f;

    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) // 타겟이 없으면 실행하지 않음
        {
            return;
        } 

        transform.position = target.position;

        float offsetX = (target.position.x * scrollSpeed) % 1f;

        float offsetY = (target.position.y * scrollSpeed) % 1f;

        // 새 오프셋 적용
        mat.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
