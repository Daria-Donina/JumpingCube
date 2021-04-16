using UnityEngine;

public class FinishPlaneScript : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    void OnTriggerEnter(Collider other) => Loader.LoadScene(nextSceneName);
}
