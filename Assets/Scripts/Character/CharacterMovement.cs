using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    Rigidbody2D rigidbody;
    [SerializeField] float speed = 5;
    [SerializeField] Canvas battleGui;

	// Use this for initialization
	void Start () {
        GameManager.INSTANCE.Events.OnUpdateEvent += OnUpdate;
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void OnUpdate () {
        if (GameManager.INSTANCE.InGui)
        {
            rigidbody.velocity = Vector2.zero;
        }
        else
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector2 velocity = new Vector2(h, v) * speed;
            rigidbody.velocity = velocity;
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.INSTANCE.SetGui(battleGui);
    }
    public void DoAction(int actionID)
    {

    }

    private void OnDestroy()
    {
        if(GameManager.INSTANCE != null)
            GameManager.INSTANCE.Events.OnUpdateEvent -= OnUpdate;
    }
}
