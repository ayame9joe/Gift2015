using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AngryPop : MonoBehaviour {


	public float fireRate = 0.5F;
	private float nextFire = 0.5F;

		
		// Update is called once per frame
	void Update () {
		// && 
		if ((PetController.angry > 5 || PetController.angry == 5)) {
			this.transform.Translate(0, 200 * Time.deltaTime, 0);
			if (this.transform.localScale.x < 1.2f)
			{
				this.transform.localScale += new Vector3(.01f , .01f, 1);
			}
		}
		else
		{
		
			//tempColor = this.GetComponent<Image>().color;


		}
		
		if (this.transform.localPosition.y > 400) {
			Destroy(this.gameObject);	
			PetController.numOfPop--;
			PetController.angry = 0;
		}


	
	}
}
