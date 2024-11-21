using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;

    [Header("Reference Resolution")]
    [SerializeField] private float referenceWidth;
    [SerializeField] private float referenceHeight;

    private float targetAspect;

    void Awake()
    {
        mainCamera = Camera.main;
        targetAspect = referenceWidth / referenceHeight;

        AdjustCamera();
    }
    void AdjustCamera()
    {
        float screenAspect = (float)Screen.width / Screen.height;
        if (mainCamera.orthographic)
        {
            float scaleHeight = targetAspect / screenAspect;

            if (scaleHeight > 1f)
            {
                mainCamera.orthographicSize *= scaleHeight;
            }
        }
        else
        {
            mainCamera.fieldOfView = CalculateFieldOfView(screenAspect);
        }
    }

    float CalculateFieldOfView(float screenAspect)
    {
        float defaultFOV = 60f;
        float fovAdjustmentFactor = targetAspect / screenAspect;
        return Mathf.Clamp(defaultFOV * fovAdjustmentFactor, 40f, 100f);
    }
}