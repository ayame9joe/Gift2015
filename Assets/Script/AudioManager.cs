using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

	//public GameObject mutingPanel;
	public AudioClip leco;
	// Use this for initialization
	void Start () {

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		//audio.PlayOneShot(leco, 20f);
		if (MutingManager.isMuting) {
			if (!this.GetComponent<AudioSource>().mute)
			{
				this.GetComponent<AudioSource>().mute = true;
			}
		}
		else 
		{
			Debug.Log("Play music!");
			if (this.GetComponent<AudioSource>().mute)
			{
				this.GetComponent<AudioSource>().mute = false;
				if (!audio.isPlaying)
				{
					audio.loop = true;
					audio.clip = leco;
					audio.Play();
				}
			}

		}
	
	}
}
