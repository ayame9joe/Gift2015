using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MutingManager : MonoBehaviour {

	public static bool isMuting = true;

	public GameObject startingPanel;
	public GameObject mutingPanel;

	//public Toggle toggleYes;
	void Start()
	{

		//toggleYes.onValueChanged.AddListener(OnValueChanged);
	}

	public void OnMuting()
	{
		isMuting = true;
		startingPanel.SetActive (true);
		mutingPanel.SetActive (false);
	}

	public void OnNoMuting ()
	{
		isMuting = false;
		startingPanel.SetActive (true);
		mutingPanel.SetActive (false);
	}
	

}