using UnityEngine;

public class Shop : MonoBehaviour {


	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLaucher;


	BuildManager buildManager;
	void Start ()
	{
		buildManager = BuildManager.instance;

	}

	public void SelectStandardTurret()
	{
		Debug.Log ("Standard Turret Selected");
		buildManager.SelectTurretToBuild (standardTurret);
	}

	public void SelectMissileLaucherTurret()
	{
		Debug.Log ("MissileLaucher Turret Selected");
		buildManager.SelectTurretToBuild (missileLaucher);
	}
}
