using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float minX, maxX;

    void Start()
    {
        CalculateBounds();
    }

    void CalculateBounds()
    {
        Camera cam = Camera.main;

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        minX = -halfWidth + 0.4f;
        maxX = halfWidth - 0.4f;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        transform.position = pos;
    }
}
