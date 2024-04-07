using UnityEngine;
using System.Collections;

namespace commanastationwww.eternaltemple{
public class HideablePart : MonoBehaviour {
	
	//This script is to be assigned to an object that is in a group of objects that needs to be hidden simultaneously.
	//Assing this script to several objects, parent them to another one that contains "HideGroup" script.
	//Parent object must have a trigger-collider component (can be more than one) to cover all children.
	
	//For example, roof parts can be parented to a simple cube that contains "HideGroup" script and a trigger-collider.
	//This way roof will hide from camera as on piece.
	
	private Material mat;
	private float currentAlpha;
	
	private float fadeOutSpeed = 0.3f;	
	private float minAlpha = 0.03f;
	private float maxAlpha = 0.2f;
			
	void Start ()
		{			
			mat = GetComponent<Renderer>().material;
			currentAlpha = mat.GetFloat("_Cutoff");			
		}
	
	public void hide()
		{
			StopAllCoroutines();
			StartCoroutine(hideInterpolation());
		}
	
	public void unhide()
		{
			StopAllCoroutines();
			StartCoroutine(unhideInterpolation());
		}
	//A coroutine that unhides the object (changes "alpha cutoff" value of the material)
	IEnumerator unhideInterpolation()
	{	
		while (currentAlpha > minAlpha)
			{
				currentAlpha -= fadeOutSpeed * Time.deltaTime;
				mat.SetFloat("_Cutoff", currentAlpha);
				yield return null;
			}
	}
	
	//A coroutine that hides the object
	IEnumerator hideInterpolation()
	{			
		while (currentAlpha < maxAlpha)
			{
				currentAlpha += fadeOutSpeed * Time.deltaTime;					
				mat.SetFloat("_Cutoff", currentAlpha);				
				yield return null;
			}	
	}
			void Update ()
			{
				
			}
}
}

