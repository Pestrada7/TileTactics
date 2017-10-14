using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

    // Use this for initialization
    private Transform trans;
    private Vector3 goalPos;
    public bool enableMovementOptions;
    public float moveTime;
    private Transform[] children;

    public bool Selected
    {
        get;
        set;
    }

	void Start () {
        trans = GetComponent<Transform>();
        goalPos = trans.position;
        children = new Transform[4];
        children[0] = trans.Find("Up_Move");
        children[1] = trans.Find("Down_Move");
        children[2] = trans.Find("Left_Move");
        children[3] = trans.Find("Right_Move");
    }

    // Update is called once per frame
    void Update() {
        if (!Selected)
        {
            foreach (Transform child in children)
            {
                child.gameObject.SetActive(false);
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

    public bool moveUp()
    {
        if (children[0].gameObject.activeInHierarchy)
        {
            goalPos = trans.position + new Vector3(0, 0, 1);
            return true;
        }
        return false;
        
    }

    public bool moveDown()
    {
        if (children[1].gameObject.activeInHierarchy)
        {
            goalPos = trans.position + new Vector3(0, 0, -1);
            return true;
        }
        return false;

    }

    public bool moveRight()
    {
        if (children[3].gameObject.activeInHierarchy)
        {
            goalPos = trans.position + new Vector3(1, 0, 0);
            return true;
        }
        return false;
    }

    public bool moveLeft()
    {
        if (children[2].gameObject.activeInHierarchy)
        {
            goalPos = trans.position + new Vector3(-1, 0, 0);
            return true;
        }
        return false;
    }

}
