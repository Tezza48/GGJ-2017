using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {
	float power=1000;
	float radius=10;
	float wallStrength=5;
	Rigidbody[] wallsRB;
	public GameObject debugSphere;

	// Use this for initialization
	void Start () {
		wallsRB = gameObject.GetComponentsInChildren<Rigidbody> ();

	}



	void OnCollisionEnter(Collision collision) {

		if (collision.relativeVelocity.magnitude > wallStrength) {
			gameObject.GetComponent<BoxCollider> ().isTrigger=true;
			Vector3 explosionPos = collision.contacts [0].point;
			if (debugSphere!=null)
			debugSphere.transform.position = explosionPos;

			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Rigidbody objRB in wallsRB) {
				objRB.isKinematic = false;
			}
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody>();

				if (rb != null && rb.tag=="wall")
					rb.AddExplosionForce(power, explosionPos, radius, 3.0F);

			}

		}
			

	}
}
