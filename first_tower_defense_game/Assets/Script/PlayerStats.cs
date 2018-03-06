using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney =  200;
	public static int Lives;
	public int startLives = 12;

	public static int Rounds = 0;

	void Start () 
	{
		Lives = startLives;
		Money = startMoney;

		Rounds = 0;
	}

}
