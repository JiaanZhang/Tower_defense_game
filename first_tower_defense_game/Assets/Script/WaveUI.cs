using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveUI  : MonoBehaviour {

	public Text waveText;



	// Update is called once per frame
	void Update () {


		waveText.text = "WAVE:" + PlayerStats.Rounds.ToString ();
	}
}