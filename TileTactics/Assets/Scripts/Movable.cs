using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

    // Use this for initialization
    private Transform trans;
    private Vector3 goalPos;
    private bool moving;
    public bool enableMovementOptions;
    public float moveTime;
    private Transform[] children;


	void Start () {
        trans = GetComponent<Transform>();
        moving = false;
        children = new Transform[4];
        children[0] = trans.Find("Up_Move");
        children[1] = trans.Find("Down_Move");
        children[2] = trans.Find("Left_Move");
        children[3] = trans.Find("Right_Move");
    }

    // Update is called once per frame
    void Update() {
        if (!moving)
        {
            string hitName = "";
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    hitName = hit.transform.name;
                }
            }
            
            if ((Input.GetKeyDown(KeyCode.W) || hitName == "Up_Move") && children[0].gameObject.activeInHierarchy)
            {
                moveUp();
            }
            else if ((Input.GetKeyDown(KeyCode.S) || hitName == "Down_Move") && children[1].gameObject.activeInHierarchy)
            {
                moveDown();
            }
            else if ((Input.GetKeyDown(KeyCode.A) || hitName == "Left_Move") && children[2].gameObject.activeInHierarchy)
            {
                moveLeft();
            }
            else if ((Input.GetKeyDown(KeyCode.D) || hitName == "Right_Move") && children[3].gameObject.activeInHierarchy)
            {
                moveRight();
            }
        }
        else
        {
            foreach (Transform child in children)
            {
                child.gameObject.SetActive(false);
            }
            if (trans.position == goalPos)
            {
                moving = false;
                foreach (Transform child in children)
                {
                    child.gameObject.SetActive(true);
                }
                if (trans.position.z > 2.5)
                    children[0].gameObject.SetActive(false);
                else if (trans.position.z < -2.5)
                    children[1].gameObject.SetActive(false);
                if (trans.position.x < -2.5)
                    children[2].gameObject.SetActive(false);
                else if (trans.position.x > 2.5)
                    children[3].gameObject.SetActive(false);
            }
            else
            {
                trans.position = Vector3.Slerp(trans.position, goalPos, Time.deltaTime * moveTime);
            }
        }
	}

    void moveUp()
    {
        goalPos = trans.position + new Vector3(0, 0, 1);
        moving = true;
    }

    void moveDown()
    {
        goalPos = trans.position + new Vector3(0, 0, -1);
        moving = true;
    }

    void moveRight()
    {
        goalPos = trans.position + new Vector3(1, 0, 0);
        moving = true;
    }

    void moveLeft()
    {
        goalPos = trans.position + new Vector3(-1, 0, 0);
        moving = true;
    }
}
