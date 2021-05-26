using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatScreenLogic : MonoBehaviour {

	[SerializeField] private Text gameScore, highScore;
	public static string levelFinished;

	// Start is called before the first frame update
	void Start() {
		switch(levelFinished) {
			case "Recycle":
				textSetup(GameLogic.recycleScore, "RecycleRecord");
				break;
			case "Reduce":
				textSetup(GameLogic_Reduce.reduceScore, "ReduceRecord");
				break;
		}
	}

	public void textSetup(int score, string levelRecord) {
		if(score > PlayerPrefs.GetInt(levelRecord)) {
			PlayerPrefs.SetInt(levelRecord, score);
		}
		gameScore.text = "Puntaje de esta partida:\n" + score;
		highScore.text = "Puntaje récord:\n" + PlayerPrefs.GetInt(levelRecord);
	}

	public void PlayAgain() {
		SceneManager.LoadScene(levelFinished);
	}

	public void GotoMenu() {
		SceneManager.LoadScene("LevelSelection");		
	}
}




