using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Push))]
public class PlayerInput : MonoBehaviour
{
    private Player player;
	private Push push;

    private void Start()
    {
        player = GetComponent<Player>();
		push = GetComponent<Push> ();
    }

    private void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal_P1"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump_P1"))
        {
			player.JumpEvent();
        }

		if (Input.GetButtonDown ("PushLeft_P1")) {
			push.pushLeft ();
		}

		if (Input.GetButtonDown ("PushRight_P1")) {
			push.pushRight ();
		}

    }
}
