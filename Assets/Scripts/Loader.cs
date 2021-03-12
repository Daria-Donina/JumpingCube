using UnityEngine.SceneManagement;

public static class Loader
{
	public static void LoadScene(string sceneName) => 
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
}
