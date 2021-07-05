using System.Collections;
using UnityEngine;

public class FinishPlaneScript : MonoBehaviour 
{
    [SerializeField]
    private string nextSceneName = "DefaultScene";

    [SerializeField]
    private float timeBeforeLoading = 0.2f;

    void OnTriggerEnter(Collider other) {
        StartCoroutine(DelayedLoading());
    }

    IEnumerator DelayedLoading() {
        yield return new WaitForSeconds(timeBeforeLoading);
        Loader.LoadScene(nextSceneName);
    }
}

