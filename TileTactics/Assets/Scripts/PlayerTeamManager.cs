using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamManager : MonoBehaviour {

    public GameObject selected;
    private int member;
    private GameObject[] team;
    private Movable moveSelected;
    private int wait;
    public Material attackTile;
    public Material moveTile;
    public Material dodgeTile;

    public CharAction ActionAccessor {
        get;
        set;
    }

    public enum CharAction {
        MOVING,
        ATTACKING,
        DODGING
    }

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
            this.ActionAccessor = CharAction.MOVING;
            moveSelected = selected.GetComponent<Movable>();
            moveSelected.Selected = true;
        }
            
	}
	
	// Update is called once per frame
	void Update () {
        if (wait == 0)
        {
            string hitName = "";

            if (Input.GetKeyDown(KeyCode.Return)) {
                this.ActionAccessor = CharAction.ATTACKING;

                for (int i = 0; i < selected.transform.childCount; i++) {
                    GameObject square = selected.transform.GetChild(i).gameObject;
                    MeshRenderer meshRenderer = square.GetComponent<MeshRenderer>();
                    meshRenderer.material = attackTile;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                this.ActionAccessor = CharAction.DODGING;

                for (int i = 0; i < selected.transform.childCount; i++) {
                    GameObject square = selected.transform.GetChild(i).gameObject;
                    MeshRenderer meshRenderer = square.GetComponent<MeshRenderer>();
                    meshRenderer.material = dodgeTile;
                }
            }
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                this.ActionAccessor = CharAction.MOVING;

                for (int i = 0; i < selected.transform.childCount; i++) {
                    GameObject square = selected.transform.GetChild(i).gameObject;
                    MeshRenderer meshRenderer = square.GetComponent<MeshRenderer>();
                    meshRenderer.material = moveTile;
                }
            }

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
                if (this.ActionAccessor == CharAction.MOVING) {
                    if (moveSelected.moveUp()) {
                        wait = 10;
                    }
                } else if (this.ActionAccessor == CharAction.ATTACKING) {

                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || hitName == "Down_Move")
            {
                if (this.ActionAccessor == CharAction.MOVING) {
                    if (moveSelected.moveDown()) {
                        wait = 10;
                    }
                } else if (this.ActionAccessor == CharAction.ATTACKING) {

                }
            }
            else if (Input.GetKeyDown(KeyCode.A) || hitName == "Left_Move")
            {
                if (this.ActionAccessor == CharAction.MOVING) {
                    if (moveSelected.moveLeft()) {
                        wait = 10;
                    }
                } else if (this.ActionAccessor == CharAction.ATTACKING) {

                }
            }
            else if (Input.GetKeyDown(KeyCode.D) || hitName == "Right_Move")
            {
                if (this.ActionAccessor == CharAction.MOVING) {
                    if (moveSelected.moveRight()) {
                        wait = 10;
                    }
                } else if (this.ActionAccessor == CharAction.ATTACKING) {

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
