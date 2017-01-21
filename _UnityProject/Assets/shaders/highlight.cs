using UnityEngine;
using System.Collections;



public class highlight : MonoBehaviour {
	public Color hightlight=Color.green;
	public Color norm;

	public Material[] mats;

	void Start(){
		mats = gameObject.GetComponent<Renderer> ().materials;
	
		norm = mats [0].color;
	}

		void OnTriggerEnter(Collider other) {
			if (other.tag == "Player") {
				mats [0].color = hightlight;
			}
		}
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			mats [0].color = norm;
		}
	}
}
