using UnityEngine;

public class ViewportManipulator : MonoBehaviour
{
    public float pixelsPerUnit = 32f;
    public float maxPixelOffset = 1f;  // Maximum allowed pixel offset from the center
    private Camera mainCamera;

    private Vector3 lastCameraPosition;
    private Vector3 cameraMovement;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        lastCameraPosition = transform.position;
        cameraMovement = Vector3.zero;
        SetViewport(0.2f, 0.2f, 0.6f, 0.6f);
    }

    void Update()
    {
        Vector3 cameraPosition = transform.position;
        float targetX = Mathf.Round(cameraPosition.x * pixelsPerUnit) / Screen.width;
        float targetY = Mathf.Round(cameraPosition.y * pixelsPerUnit) / Screen.height;

        float viewportCenterX = mainCamera.rect.x + mainCamera.rect.width / 2;
        float viewportCenterY = mainCamera.rect.y + mainCamera.rect.height / 2;

        float pixelOffsetX = Mathf.Abs(viewportCenterX - targetX);
        float pixelOffsetY = Mathf.Abs(viewportCenterY - targetY);

        if (pixelOffsetX >= maxPixelOffset || pixelOffsetY >= maxPixelOffset)
        {
            float moveAmount = maxPixelOffset * (1f / pixelsPerUnit);
            float angle = Mathf.Atan2(targetY - viewportCenterY, targetX - viewportCenterX);

            float newViewportCenterX = viewportCenterX + moveAmount * Mathf.Cos(angle);
            float newViewportCenterY = viewportCenterY + moveAmount * Mathf.Sin(angle);

            float newViewportX = newViewportCenterX - mainCamera.rect.width / 2;
            float newViewportY = newViewportCenterY - mainCamera.rect.height / 2;

            SetViewport(newViewportX, newViewportY, mainCamera.rect.width, mainCamera.rect.height);

            // Calculate camera movement based on viewport movement
            float deltaX = (newViewportCenterX - viewportCenterX) * Screen.width;
            float deltaY = (newViewportCenterY - viewportCenterY) * Screen.height;

            cameraMovement = new Vector3(deltaX, deltaY, 0f);
            lastCameraPosition = transform.position;
        }

        // Move the camera based on the viewport movement
        transform.Translate(cameraMovement, Space.World);
        lastCameraPosition = transform.position;
    }

    void SetViewport(float x, float y, float width, float height)
    {
        mainCamera.rect = new Rect(x, y, width, height);
    }
}
