using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;
	public Transform partToRot;

	private Transform target;
	private int wavepointIndex = 0;
	private float  turnSpeed = 10f;


	[HideInInspector]
	public float Speed;
	public float startHealth = 100f;
	public float health = 100;
	public int worth = 50;
	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;
	private bool isDead = false;

	void Start ()
	{
		target = Waypoints.points[0];
		Speed = startSpeed;
		health = startHealth;

	}

	public void TakeDamage (float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRot.rotation,lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRot.rotation = Quaternion.Euler(0f,rotation.y, 0f);

		transform.Translate (dir.normalized * startSpeed * Time.deltaTime,Space.World);

		if (Vector3.Distance (transform.position, target.position) <= 0.4f) 
		{

			GetNextWaypoint();

		}


	}



	void GetNextWaypoint()
	{

		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath ();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];

	}


	void EndPath() 
	{
		PlayerStats.Lives--;
		Destroy(gameObject);
	}

	void Die()
	{
		isDead = true;
		PlayerStats.Money += worth;
		//GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion)
		//Destroy(effect, 5f);
		Destroy(gameObject);
	}

}
