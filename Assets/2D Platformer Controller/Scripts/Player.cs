using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public Vector2 jumpSpeed;
	int jumpCount=0;
    private Vector2 directionalInput;
	private GameObject[] Winner;
	private string WinnerName;


    private void Update()
    {
		transform.Translate (directionalInput.x*0.1f, 0.0f, 0.0f);

		if (Input.GetKeyDown ("r")) {
			SceneManager.LoadSceneAsync ("test1");
		}

    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

	void OnCollisionEnter2D(Collision2D coll){
		jumpCount = 0;
		if (coll.gameObject.tag == "Ground") {
			Winner = GameObject.FindGameObjectsWithTag("Player");
			for (int i=0; i<Winner.Length; i++){
				if (Winner [i] != gameObject) {
					WinnerName = Winner [i].name;
					Debug.Log ("The Winner Is: " + WinnerName);
					GameObject.Find("WinningText").GetComponent<Text>().text = "The Winner Is: " + WinnerName;
				}
				if (Winner [i].GetComponent<PlayerInput> () != null){
					Winner [i].GetComponent<PlayerInput> ().enabled = false;
				} else {
				Winner [i].GetComponent<PlayerInput_P2> ().enabled = false;
				}
			}
		}
	}

	public void JumpEvent(){
		if (jumpCount < 2) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (jumpSpeed);
			jumpCount++;
		}
	}


}
