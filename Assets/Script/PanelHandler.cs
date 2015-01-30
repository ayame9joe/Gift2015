using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class PanelHandler : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{	
	public GameObject Niuniu ;
	public GameObject Body;
	public GameObject Eyes;
	public Text tutorial;
	bool mouseDown;
	public AudioClip tick;
	public void OnPointerDown(PointerEventData eventData)
	{
		if (!PetController.mouseDown) {

			//GameObject.Find("Niuniu").GetComponent<Animator>().Play("Idle");
			Niuniu.SetActive(false);
			Body.SetActive(true);
			Eyes.SetActive(true);
			mouseDown = true;
			//Eyes.transform.position = Vector3.MoveTowards(Eyes.transform.position, )
			//GameObject.Find("Niuniu").GetComponent<Image>().

					
		}
		else
		{
			Niuniu.SetActive(true);
			Body.SetActive(false);
			Eyes.SetActive(false);
		}
		
		
	}
	

	public void OnPointerUp(PointerEventData eventData)
	{
		Niuniu.SetActive(true);
		Body.SetActive(false);
		Eyes.SetActive(false);
		mouseDown = false;
		
	}


	void Awake ()
	{
		if (MutingManager.isMuting) {
			if (!this.GetComponent<AudioSource>().mute)
			{
				this.GetComponent<AudioSource>().mute = true;
			}
		}
		//Eyes.transform.position = new Vector3 (0, -100, 0);
	}
	void Update ()
	{

		if (mouseDown) {
			//Eyes.transform.Translate(
			//	new Vector3((Input.mousePosition.x - Eyes.transform.position.x) * 0.02f,
			 //           (Input.mousePosition.y - Eyes.transform.position.y) * 0.2f,
			 //           0));
			if(PetController.tutorialIndex == 4)
			{
				tutorial.text = "不断互动会有什么结果";
				PetController.tutorialIndex++;
			}
			//Eyes.transform.position = new Vector3(Mathf.Lerp(Eyes.transform.position.x, (Input.mousePosition.x - Eyes.transform.position.x) * 0.02f, Time.deltaTime), Mathf.Lerp(Eyes.transform.position.x, (Input.mousePosition.y - Eyes.transform.position.y) * 0.02f, Time.deltaTime),0);
			audio.PlayOneShot(tick, 2f);
			Eyes.transform.localPosition = new Vector3((Input.mousePosition.x - Eyes.transform.position.x) * 0.02f,
			                                                (Input.mousePosition.y - Eyes.transform.position.y) * 0.02f - 100,
			                                     0);
		}

		if (Niuniu.activeSelf)
		{

			Body.SetActive(false);
			Eyes.SetActive(false);
			//mouseDown = false;
		}
	}




}