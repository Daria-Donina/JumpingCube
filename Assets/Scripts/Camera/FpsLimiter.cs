using UnityEngine;

public class FpsLimiter : MonoBehaviour
{
    [SerializeField]
    private int FPS;

    void Awake()
    {
        QualitySettings.vSyncCount = 0; 
        Application.targetFrameRate = FPS;

    }    
}
