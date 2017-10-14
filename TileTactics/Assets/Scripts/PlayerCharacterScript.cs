using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {

    private PlayerCharacter character;
    private bool attacking = false;

	// Use this for initialization
	void Start () {
        if (transform.tag.Equals("SwordPlayer")) {
            character = new PlayerCharacter(3, Character.Weapon.SWORD, gameObject.name);
        } else if (transform.tag.Equals("LancePlayer")) {
            character = new PlayerCharacter(3, Character.Weapon.LANCE, gameObject.name);
        } else if (transform.tag.Equals("BowPlayer")) {
            character = new PlayerCharacter(3, Character.Weapon.BOW, gameObject.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Character name: " + character.Name);
        
        if (Input.GetKeyDown(KeyCode.Return)) {
            attacking = true;
        }

        if (Input.GetKeyDown(KeyCode.Backspace)) {
            attacking = false;
            Debug.Log("Not attacking");
        }

        if (attacking) {
            Debug.Log("In attacking condition");
            if (Input.GetKeyDown(KeyCode.W)) {
                Debug.Log("Attacked North");
                attacking = false;
            } else if (Input.GetKeyDown(KeyCode.A)) {
                Debug.Log("Attacked West");
                attacking = false;
            } else if (Input.GetKeyDown(KeyCode.S)) {
                Debug.Log("Attacked South");
                attacking = false;
            } else if (Input.GetKeyDown(KeyCode.D)) {
                Debug.Log("Attacked East");
                attacking = false;
            }
        }
	}
}
