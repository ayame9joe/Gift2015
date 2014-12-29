using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class PetController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler, IDragHandler
{
	// ----- Sound Effect -----
	public AudioClip cry;
	public AudioClip cute;
	public AudioClip jump;
	public AudioClip laugh;
	public AudioClip scream;


	// ----- GameObjects -----
	public GameObject Hand;
	public GameObject angryFace;

	// ----- Animator -----
	Animator anim;
	AnimatorStateInfo currentState;


	public static bool getAngry;


	// 
	int random;
	int temp;

	//
	int counter;
	int angryCounter;
	public static int numOfPop;
	int touchTime;
	int tempAngry;

	public static float angry;

	public static bool mouseDown;
	bool hasStartCount;
	bool canBeTouched;

	bool isTouching;
	bool isJumping;
	// Use this for initialization
	void Awake () {


		if (MutingManager.isMuting) {
			if (!this.GetComponent<AudioSource>().mute)
			{
				this.GetComponent<AudioSource>().mute = true;
			}
		}

		anim = GetComponent<Animator>();

		//StartCoroutine("AngryDecrease");
		
	}
	
	// Update is called once per frame
	void Update () {

		currentState = anim.GetCurrentAnimatorStateInfo (0);

		if (this.transform.localPosition.y > -95) {

			anim.Play("Falling");
		}
		else if (this.transform.localPosition.y > -100)
		{
			anim.Play("Fall On the Ground");
		}

		if (mouseDown) {

			touchTime++;

			if (touchTime < 10) {


				if (canBeTouched && !isJumping) 
				{

					if (tempAngry > 3)
					{

						angry++;
					}
						
					random = Random.Range (1, 6);
					if (random == temp) {
						do {
								random = Random.Range (1, 6);
						} while (random == temp);
					} else {
						temp = random;
					}

					if (angry < 4.5f)
					{
						switch (random) {
						case 1:
							anim.Play ("Rolling");
							audio.Stop();
							audio.PlayOneShot(laugh,20f);
							tempAngry ++;
						break;
						case 2:	
							anim.Play ("Nodding");
							audio.Stop();
							audio.PlayOneShot(jump, 20f);
							tempAngry ++;	
						break;
						case 3:
							anim.Play ("Show Love");
							audio.Stop();
							audio.PlayOneShot(cute, 20f);
							tempAngry ++;
							break;
						case 4:
							anim.Play ("Swirl");
							audio.Stop();
							audio.PlayOneShot(cute, 20f);
							tempAngry ++;	
							break;
						case 5:
							anim.Play ("Make Face");
							audio.Stop();
							audio.PlayOneShot(cute, 20f);
							tempAngry ++;	
							break;
						}
					}
					
					StopCount ();
										
				} 
			} 
			else {
				isTouching = true;
				Hand.SetActive (true);
				if (touchTime < 200)
				{
					anim.Play ("Anyway");
				}
				else
				{
					anim.Play("Shy");
				}
				StopCount ();
				
			}
		}
		else {
			isTouching = false;
			Hand.SetActive (false);
			if (touchTime > 10) {
				Hand.SetActive (false);
				anim.Play ("Idle");
								}
								
				touchTime = 0;
								
		}
		Debug.Log (Input.mousePosition.y);
		Hand.transform.position = Input.mousePosition;
						
		if ((angry > 5 || angry == 5)&&tempAngry > 0) {
			getAngry = true;
			audio.Stop();
			//anim.SetInteger ("randomNegativeAnimation", Random.Range(1,5));
			switch (Random.Range(1,5)) {
			case 1:
				anim.Play ("Angry");
				audio.PlayOneShot(scream,20f);
				break;
			case 2:	
				anim.Play ("Cry1");
				audio.PlayOneShot(cry, 20f);
				break;
			case 3:
				anim.Play ("Cry2");
				audio.PlayOneShot(cry, 20f);
				break;
			case 4:
				anim.Play ("Xiuxiu");
				audio.PlayOneShot(cry, 20f);
				break;
			}

			//angry = 0;
			tempAngry = 0;
		} 


		
		/*if(currentState.nameHash == Animator.StringToHash ("Base Layer.Angry"))
		{
			//Debug.Log("Angry!");
			if (!audio.isPlaying)
			{
				audio.PlayOneShot (scream, 20f);
			}

		}
		else if (currentState.nameHash == Animator.StringToHash ("Base Layer.Cry1"))
		{
			if (!audio.isPlaying)
			{
				audio.PlayOneShot (cry, 20f);
			}
		}
		else if (currentState.nameHash == Animator.StringToHash ("Base Layer.Cry2"))
		{
			if (!audio.isPlaying)
			{
				audio.PlayOneShot (cry, 20f);
			}
		}*/
		if (numOfPop < angry - 1) {
			GameObject go = Instantiate (angryFace, transform.position, transform.rotation) as GameObject;
			go.transform.localPosition = new Vector3 (Random.Range (160, 320), Random.Range (450, 550), 0);
			go.transform.localScale = new Vector3(1, 1, 1);
			go.transform.parent = GameObject.Find ("Main Panel").transform;	
			numOfPop++;
		}

		if (GameObject.Find ("angryFace(Clone)")) {
			
			
			if (numOfPop - angry == 0 || numOfPop - angry > 0) {
				Destroy (GameObject.Find ("angryFace(Clone)").gameObject);
				numOfPop--;
			}
			
		}




		if (currentState.nameHash == Animator.StringToHash ("Base Layer.Idle")) {
			canBeTouched = true;
			isJumping = false;
			anim.SetInteger ("randomNegativeAnimation", 0);
			getAngry = false;
			if (!hasStartCount)
			{
				hasStartCount = true;
				StartCoroutine ("StartCount");
			}
					
		} else {
			canBeTouched = false;
			StopCount();
		}

		if (counter > 10) {
			switch (Random.Range (0, 3)) {
				case 0:
				anim.Play ("Eat");
				break;
				case 1:
				anim.Play ("Sleep");
				break;
				case 2:
				anim.Play ("High Jump");
				break;
								
			}

			StopCount ();
		} 

		if (angry < 0) {
			angry = 0;		

		}

		if (this.transform.localPosition.y > -100) {

			this.transform.Translate (0, -2, 0);
		}


	
	}
		




	IEnumerator StartCount(){
		for (counter=0; counter>-1; counter++){
			yield return new WaitForSeconds(1);

			
		}
	}



	IEnumerator AngryDecrease(){
		for (angryCounter=0; angryCounter>-1; angryCounter++){
			yield return new WaitForSeconds(1f);
			angry -= 0.1f;


			
		}
	}
	
	void StopCount(){
		StopCoroutine("StartCount");
		hasStartCount = false;
		counter = 0;
	}

	public void OnPointerDown(PointerEventData eventData)
	{

		mouseDown = true;

		
	}
	
	public void OnPointerUp(PointerEventData eventData)
	{
	
		mouseDown = false;

		
	}

	
	public void OnDrag(PointerEventData eventData)
	{	
		isJumping = true;
		if (Input.mousePosition.y > 350 && !isTouching) {

			this.transform.position = new Vector3(
				this.transform.position.x,
				Input.mousePosition.y, 
				0);
		}
	
	}

	void FixedUpdate()
	{

		angry -= 0.1f;		

	}




}



