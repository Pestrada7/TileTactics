using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

    // Use this for initialization
    private Transform trans;
    bool moving;
	void Start () {
        trans = GetComponent<Transform>();
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                moveUp();
            } else if (Input.GetKeyDown(KeyCode.A))
            {
                moveLeft();
            } else if (Input.GetKeyDown(KeyCode.S))
            {
                moveDown();
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                moveRight();
            }
        }
	}

    void moveUp()
    {
        trans.position = trans.position + new Vector3(0, 0, 1);
    }

    void moveDown()
    {
        trans.position = trans.position + new Vector3(0, 0, -1);
    }

    void moveRight()
    {
        trans.position = trans.position + new Vector3(1, 0, 0);
    }

    void moveLeft()
    {
        trans.position = trans.position + new Vector3(-1, 0, 0);
    }
}
