using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character {

    public enum Weapon {
        SWORD,
        LANCE,
        BOW
    }

	public Character(int health, Weapon weapon) {
        this.Health = health;
        this.weaponAccessor = weapon;
        this.Dodge = true;
    }

    public int Health {
        get;
        set;
    }

    public Weapon weaponAccessor {
        get;
        set;
    }

    public bool Dodge {
        get;
        set;
    }
}
