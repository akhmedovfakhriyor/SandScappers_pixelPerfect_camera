using UnityEngine;

public class Pixel : MonoBehaviour

{
    public float pixelsPerUnit = 36.0f;

    public Camera mainCamera;
    private float unitsPerPixelX;
    private float unitsPerPixelY;
    private float unitsPerPixelZ;

    public float CameraXangle = 30f;
    public float CameraYangle = 0f;
    public float CameraZangle = 0f;

    private void Awake()
    {
        CalculateUnitsPerPixel();
        UpdateOrthographicSize();
    }

    private void LateUpdate()
    {
        PixelSnap();
    }

    private void CalculateUnitsPerPixel()
    {
        float angleInRadiansX = Mathf.Deg2Rad * CameraXangle;
        float angleInRadiansY = Mathf.Deg2Rad * CameraYangle;

        unitsPerPixelZ = 1.0f / (pixelsPerUnit * Mathf.Sin(angleInRadiansX)/**Mathf.Cos(angleInRadiansY)*/);


        unitsPerPixelX = 1.0f / (pixelsPerUnit);
        unitsPerPixelY = 1.0f / (pixelsPerUnit * Mathf.Cos(angleInRadiansX));
    }

    private void UpdateOrthographicSize()
    {
    }

    private void PixelSnap()
    {
        if (mainCamera.orthographic)
        {
            mainCamera.transform.position = this.transform.position;

            Vector3 position = mainCamera.transform.position;
            position.z = RoundToNearestPixel(position.z, unitsPerPixelZ);
            
            position.x = RoundToNearestPixel(position.x, unitsPerPixelX);
            position.y = RoundToNearestPixel(position.y, unitsPerPixelY);

            mainCamera.transform.position = position;
            Debug.Log(position);

        }
    }

    private float RoundToNearestPixel(float position, float unitsPerPixel)
    {
        return Mathf.Round(position / unitsPerPixel) * unitsPerPixel;
    }
}


/*
using UnityEngine;

public class Pixel : MonoBehaviour
{

    public float pixelsPerUnit = 36.0f;
    public float snapSpeed = 5.0f;

    private Camera mainCamera;
    private float unitsPerPixelX;
    private float unitsPerPixelY;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        CalculateUnitsPerPixel();
        UpdateOrthographicSize();
    }

    private void LateUpdate()
    {
        SmoothPixelSnap();
    }

    private void CalculateUnitsPerPixel()
    {
        float angleInRadians = Mathf.Deg2Rad * transform.rotation.eulerAngles.x;
        unitsPerPixelX = 1.0f / pixelsPerUnit;
        unitsPerPixelY = 1.0f / (pixelsPerUnit * Mathf.Cos(angleInRadians));
    }

    private void UpdateOrthographicSize()
    {
        if (mainCamera.orthographic)
            mainCamera.orthographicSize = Screen.height / (pixelsPerUnit * 2.0f);
    }

    private void SmoothPixelSnap()
    {
        if (mainCamera.orthographic)
        {
            Vector3 position = mainCamera.transform.position;
            float targetX = RoundToNearestPixel(position.x, unitsPerPixelX);
            float targetY = RoundToNearestPixel(position.y, unitsPerPixelY);

            // Smoothly interpolate the camera's position towards the rounded pixel position
            position.x = Mathf.Lerp(position.x, targetX, Time.deltaTime * snapSpeed);
            position.y = Mathf.Lerp(position.y, targetY, Time.deltaTime * snapSpeed);

            // Apply pixel snapping
            position.x = RoundToNearestPixel(position.x, unitsPerPixelX);
            position.y = RoundToNearestPixel(position.y, unitsPerPixelY);

            mainCamera.transform.position = position;
        }
    }

    private float RoundToNearestPixel(float position, float unitsPerPixel)
    {
        return Mathf.Round(position / unitsPerPixel) * unitsPerPixel;
    }
}




*/

