using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {

    private PlayerCharacter character;
    public Character.Weapon characterWeapon;

	// Use this for initialization
	void Start () {
        character = new PlayerCharacter(3, characterWeapon, gameObject.name);
        /*if (transform.tag.Equals("SwordPlayer")) {
            character = new PlayerCharacter(3, Character.Weapon.SWORD, gameObject.name);
        } else if (transform.tag.Equals("LancePlayer")) {
            character = new PlayerCharacter(3, Character.Weapon.LANCE, gameObject.name);
        } else if (transform.tag.Equals("BowPlayer")) {
            character = new PlayerCharacter(3, Character.Weapon.BOW, gameObject.name);
        }*/
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Character name: " + character.Name);
	}
}
