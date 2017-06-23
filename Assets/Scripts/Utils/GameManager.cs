﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerStopper {
	public PlayerInputReader playerInputReader;
	public Rigidbody playerRigidBody;
	public Animator playerAnimator;

	public void stop(){
		playerInputReader.enabled = false;
		playerRigidBody.velocity = Vector3.zero;
		playerAnimator.SetBool("isMoving", false);
	}
}

public class GameManager : MonoBehaviour
{
	static public GameManager instance = null;

	public GameObject gameOverDisplay;
	public string gameoverSceneName;
	public GameObject victoryDisplay;
	public string goodVictoryGameScene;
	public string badVictoryGameScene;

	public float sceneTransitionTime;

	public int numberOfItensInScene = 5;
	private int numberOfItensCollected = 0;

	public PlayerStopper playerStopper;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(this);
	}

	public void gameOver() {
		gameOverDisplay.SetActive(true);
		StartCoroutine(loadSceneWithDelay(gameoverSceneName, sceneTransitionTime));
		playerStopper.stop();
	}

	public void victory() {
		if(numberOfItensCollected >= numberOfItensInScene){
			victoryDisplay.SetActive(true);
			StartCoroutine(loadSceneWithDelay(goodVictoryGameScene, sceneTransitionTime));
			playerStopper.stop();
		} else {
			victoryDisplay.SetActive(true);
			StartCoroutine(loadSceneWithDelay(badVictoryGameScene, sceneTransitionTime));
			playerStopper.stop();
		}
	}

	public void changeScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	IEnumerator loadSceneWithDelay(string sceneName, float waitTime) {
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene(sceneName);
	}

	public void countItems(){
		numberOfItensCollected++;
	}
}