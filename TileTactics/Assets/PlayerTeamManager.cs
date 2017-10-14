using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamManager : MonoBehaviour {

    public GameObject selected;
    private int member;
    private GameObject[] team;
    private Movable moveSelected;
    private int wait;

	// Use this for initialization
	void Start () {
        wait = 0;
        team = GameObject.FindGameObjectsWithTag("Player");
        if (team.Length == 0)
        {
            Debug.Log("NO TEAM FOR PLAYER");
        }
        else
        {
            member = 0;
            selected = team[member];
            moveSelected = selected.GetComponent<Movable>();
            moveSelected.Selected = true;
        }
            
	}
	
	// Update is called once per frame
	void Update () {
        if (wait == 0)
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
            if (Input.GetKeyDown(KeyCode.W) || hitName == "Up_Move")
            {
                if (moveSelected.moveUp())
                {
                    wait = 10;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || hitName == "Down_Move")
            {
                if (moveSelected.moveDown())
                {
                    wait = 10;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) || hitName == "Left_Move")
            {
                if (moveSelected.moveLeft())
                {
                    wait = 10;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D) || hitName == "Right_Move")
            {
                if (moveSelected.moveRight())
                {
                    wait = 10;
                }
            }
        }
        else
        {
            wait--;
            if (wait == 1)
            {
                moveSelected.Selected = false;
                selected = nextMember();
            }
        }

    }

    GameObject nextMember()
    {
        if (member + 1 == team.Length)
        {
            member = 0;
        }
        else
            member += 1;

        moveSelected = team[member].GetComponent<Movable>();
        moveSelected.Selected = true;

        return team[member];
    }
}
