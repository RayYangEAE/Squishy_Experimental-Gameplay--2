using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Push))]
public class PlayerInput_P2 : MonoBehaviour {

	private Player player;
	private Push push;

	private void Start()
	{
		player = GetComponent<Player>();
		push = GetComponent<Push> ();
	}

	private void Update()
	{
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal_P2"), Input.GetAxisRaw("Vertical"));
		player.SetDirectionalInput(directionalInput);

		if (Input.GetButtonDown("Jump_P2"))
		{
			player.JumpEvent();
		}
			
		if (Input.GetButtonUp ("PushLeft_P2")) {
			push.pushLeft ();
		}

		if (Input.GetButtonUp ("PushRight_P2")) {
			push.pushRight ();
		}

	}

}
