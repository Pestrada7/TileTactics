using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private EnemyCharacter enemyCharacter;

    // Use this for initialization
    void Start() {
        string[] enemyTypes = transform.tag.Split('-'); //first index is enemy type, second index is enemy color
        if (enemyTypes[0].Equals("Slime")) {
            if (enemyTypes[1].Equals("Red")) {
                enemyCharacter = new EnemyCharacter(2, Character.Weapon.SWORD, EnemyCharacter.EnemyType.SLIME, EnemyCharacter.ColorType.RED);
            } else if (enemyTypes[1].Equals("Green")) {
                enemyCharacter = new EnemyCharacter(2, Character.Weapon.SWORD, EnemyCharacter.EnemyType.SLIME, EnemyCharacter.ColorType.GREEN);
            } else {
                enemyCharacter = new EnemyCharacter(2, Character.Weapon.SWORD, EnemyCharacter.EnemyType.SLIME, EnemyCharacter.ColorType.BLUE);
            }
        } else if (enemyTypes[0].Equals("Bat")) {
            if (enemyTypes[1].Equals("Red")) {
                enemyCharacter = new EnemyCharacter(1, Character.Weapon.BOW, EnemyCharacter.EnemyType.BAT, EnemyCharacter.ColorType.RED);
            } else if (enemyTypes[1].Equals("Green")) {
                enemyCharacter = new EnemyCharacter(1, Character.Weapon.BOW, EnemyCharacter.EnemyType.BAT, EnemyCharacter.ColorType.GREEN);
            } else {
                enemyCharacter = new EnemyCharacter(1, Character.Weapon.BOW, EnemyCharacter.EnemyType.BAT, EnemyCharacter.ColorType.BLUE);
            }
        } else if (enemyTypes[0].Equals("Skeleton")) {
            if (enemyTypes[1].Equals("Red")) {
                enemyCharacter = new EnemyCharacter(2, Character.Weapon.LANCE, EnemyCharacter.EnemyType.SKELETON, EnemyCharacter.ColorType.RED);
            } else if (enemyTypes[1].Equals("Green")) {
                enemyCharacter = new EnemyCharacter(2, Character.Weapon.LANCE, EnemyCharacter.EnemyType.SKELETON, EnemyCharacter.ColorType.GREEN);
            } else {
                enemyCharacter = new EnemyCharacter(2, Character.Weapon.LANCE, EnemyCharacter.EnemyType.SKELETON, EnemyCharacter.ColorType.BLUE);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("Enemy type: " + enemyCharacter.EnemyAccessor);
    }
}
