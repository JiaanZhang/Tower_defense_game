using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text roundsTexts;

	void OnEnable()
	{
		roundsTexts.text = PlayerStats.Rounds.ToString ();
	}

	public void Retry()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}


	public void Menu()
	{
		Debug.Log ("Go to menu");
	}

}
