using UnityEngine;

public class FinishPlaneScript : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

	void OnCollisionEnter(Collision collision) => Loader.LoadScene(nextSceneName);
}
