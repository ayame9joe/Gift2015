using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class StartManager : MonoBehaviour {

	Animator anim;
	AnimatorStateInfo currentState;

	public Image happy2015;
	public Text txtTapToContinue;

	public AudioClip bounce;

	public GameObject startingPanel;
	public GameObject mainPanel;

	bool canBeTouched;
	//public AudioClip cute;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();

		happy2015.gameObject.SetActive (false);
		txtTapToContinue.gameObject.SetActive (false);

		mainPanel.SetActive (false);

		if (MutingManager.isMuting) {
			if (!this.GetComponent<AudioSource>().mute)
			{
				this.GetComponent<AudioSource>().mute = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		if (currentState.nameHash == Animator.StringToHash ("Base Layer.Sing")) {
			happy2015.gameObject.SetActive (true);
			txtTapToContinue.gameObject.SetActive (true);
			canBeTouched = true;

		}
		//Debug.Log (this.transform.position.y);



	
	}

	public void OnTap()
	{
		if (canBeTouched)
		{
			mainPanel.SetActive (true);
			startingPanel.SetActive (false);
		}
	}

	/*void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Play Sound");
		audio.PlayOneShot(bounce);
	}*/
}
