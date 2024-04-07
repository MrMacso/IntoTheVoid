using UnityEngine;
using System.Collections;

namespace commanastationwww.eternaltemple{
public class HideSelf : MonoBehaviour {

        //This script is to be assigned to an individual object that needs to be hidden.
        //If you need to hide several objects as one piece, please use "HideGroup" and "HideablePart" scripts.
	
	private int collisionEntriesCounter = 0;	//counter of entries and exits to the trigger. Allows to have multiple triggers (colliders)

	private Material mat;
	private float currentAlpha;	
	
	public bool hideable = true;
	private float hidingSpeed = 0.3f;
	private float minAlpha = 0.03f;
	private float maxAlpha = 0.2f;

		
	void Start () {
		
	mat = GetComponent<Renderer>().material;
	currentAlpha = mat.GetFloat("_Cutoff");
	
	}
	
	//A coroutine that unhides object (changes "alpha cutoff" value of the material)
	IEnumerator unideInterpolation()
	{				
		
		while (currentAlpha > minAlpha)
			{
				currentAlpha -= hidingSpeed * Time.deltaTime;					
				mat.SetFloat("_Cutoff", currentAlpha);				
				yield return null;
			}
				
	}
	
	//A coroutine that hides object 
	IEnumerator hideInterpolation()
	{		
					
		while (currentAlpha < maxAlpha)
			{
				currentAlpha += hidingSpeed * Time.deltaTime;				
				mat.SetFloat("_Cutoff", currentAlpha);				
				yield return null;
			}	
					
	}
	
			
	void OnTriggerEnter(Collider other)
		{	
			if (hideable == false) return;
			
			if (other.gameObject.tag == "MainCamera")
				collisionEntriesCounter++;	
				StopAllCoroutines();
				StartCoroutine (hideInterpolation());	
		}
				
	void OnTriggerExit(Collider other)
		{				
			if (hideable == false) return;
			
			if (other.gameObject.tag == "MainCamera")
				collisionEntriesCounter--;
			
			if (collisionEntriesCounter > 0)
						{
							return;
						}	
						
				StopAllCoroutines();	
				StartCoroutine (unideInterpolation());
				
				collisionEntriesCounter = 0;					
		}
				
			void Update () {
		}

}
}

