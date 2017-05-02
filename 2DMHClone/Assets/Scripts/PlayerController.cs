using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject weapon;
    public Vector3 targetUp;
    public Vector3 targetDown;
    public Vector3 targetLeft;
    public Vector3 targetRight;
    public float step;
    public float moveSpeed = 5.0f;
    private bool facingUp = true;
    private bool facingDown = false;
    private bool facingLeft = false;
    private bool facingRight = false;
    private bool attacking = false;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        step = moveSpeed * Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            facingUp = false;
            facingDown = false;
            facingLeft = false;
            facingRight = true;
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * step, 0.0f, 0.0f));
        }

        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            facingUp = false;
            facingDown = false;
            facingLeft = true;
            facingRight = false;
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * step, 0.0f, 0.0f));
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            facingUp = true;
            facingDown = false;
            facingLeft = false;
            facingRight = false;
            transform.Translate(new Vector3(0.0f, Input.GetAxisRaw("Vertical") * step, 0.0f));
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            facingUp = false;
            facingDown = true;
            facingLeft = false;
            facingRight = false;
            transform.Translate(new Vector3(0.0f, Input.GetAxisRaw("Vertical") * step, 0.0f));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            attacking = true;
        }

        if(attacking)
        {
            MeeleAttack();
        } else
        {
            weapon.transform.position = Vector3.MoveTowards(weapon.transform.position, transform.position, step);
        }
    }

    public void MeeleAttack()
    {
        if(facingUp)
        {
            targetUp = transform.position + new Vector3(0, 1.0f, 0);
            weapon.transform.position = Vector3.MoveTowards(weapon.transform.position, targetUp, step);

            if (Vector3.Distance(weapon.transform.position, targetUp) < 0.1f)
            {
                attacking = false;
            }
        }
       if(facingDown)
        {
            targetDown = transform.position - new Vector3(0, 1.0f, 0);
            weapon.transform.position = Vector3.MoveTowards(weapon.transform.position, targetDown, step);

            if (Vector3.Distance(weapon.transform.position, targetDown) < 0.1f)
            {
                attacking = false;
            }
        }
        if (facingLeft)
        {
            targetLeft = transform.position - new Vector3(1.0f, 0, 0);
            weapon.transform.position = Vector3.MoveTowards(weapon.transform.position, targetLeft, step);

            if (Vector3.Distance(weapon.transform.position, targetLeft) < 0.1f)
            {
                attacking = false;
            }
        }
        if(facingRight)
        {
            targetRight = transform.position + new Vector3(1.0f, 0, 0);
            weapon.transform.position = Vector3.MoveTowards(weapon.transform.position, targetRight, step);

            if (Vector3.Distance(weapon.transform.position, targetRight) < 0.1f)
            {
                attacking = false;
            }
        }
    }

}
