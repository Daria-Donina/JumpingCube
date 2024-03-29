﻿using UnityEngine.SceneManagement;

public static class Loader {
	public static void LoadScene(string sceneName) {
		if (sceneName == "DefaultScene") {
			LoadNextScene();
		}
		else {
			SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
		}
	}

	public static void LoadScene(int sceneIndex)
	{
		SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
	}

	public static void LoadNextScene() {
		SceneManager.LoadSceneAsync(
				SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
	}
}
