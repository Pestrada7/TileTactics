using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character {

    public PlayerCharacter(int health, Weapon weapon, string name) : base(health, weapon) {
        this.Name = name;
    }

    public string Name {
        get;
        set;
    }


}
