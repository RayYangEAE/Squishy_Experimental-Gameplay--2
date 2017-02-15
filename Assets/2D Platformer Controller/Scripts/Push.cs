using UnityEngine;
using System.Collections;

public class Push : MonoBehaviour {

	public float pushDistance;
	public Vector2 pushStrengthRight;
	public float CDtime;
	string objName;
	bool inCD=false;
	Animator anim;


	void Start () {
		objName = gameObject.name;
		anim = GetComponentInChildren<Animator>();
	}

	IEnumerator waitCD(){
		inCD = true;
		yield return new WaitForSeconds (CDtime);
		inCD = false;
	}

	void pushObj(int a){
		RaycastHit2D[] hit;
		hit= Physics2D.RaycastAll(transform.position, Vector2.right*a, pushDistance);
		for (int i=0; i<hit.Length; i++) {
			GameObject hitObj = hit [i].transform.gameObject;
			if ((hit [i].collider != null) && (hitObj.name != objName) && (hitObj.tag == "Player")) {
				hitObj.GetComponent<Rigidbody2D> ().AddForce (a * pushStrengthRight);
			}
			//Debug.Log (hitObj.name);
		}
	}

	public void pushLeft(){
		if (!inCD) {
			anim.SetTrigger ("Left");
			pushObj (-1);
			StartCoroutine(waitCD ());
		}
	}

	public void pushRight(){
		if (!inCD) {
			anim.SetTrigger ("Right");
			pushObj (1);
			StartCoroutine(waitCD ());
		}
	}

}
