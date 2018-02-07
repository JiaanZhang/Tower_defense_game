using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {


	public static BuildManager instance;

	void Awake()
	{
		if (instance != null) 
		{
			Debug.LogError ("More than one BuildManger in scene!");	
		}

		instance = this;
	}

	public GameObject standardTurretPrefab;
	public GameObject missileLaucherPrefab;

	public GameObject buildEffect;

	private TurretBlueprint turretToBuild;


	public bool CanBuild {   get { return turretToBuild != null;} }
	public bool HasMoney {   get { return PlayerStats.Money >= turretToBuild.cost;} }

	public void BuidTurretOn (Node node)
	{
		if (PlayerStats.Money < turretToBuild.cost) 
		{
			Debug.Log ("Not enough money");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;

		GameObject turret = (GameObject)Instantiate (turretToBuild.prefab, node.GetBuildPosition(), node.transform.rotation);
		node.turret = turret;


		GameObject effect = (GameObject)Instantiate (buildEffect, node.GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);
		Debug.Log ("Turret build Money left: " +  PlayerStats.Money );
	}

	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
	}


}
