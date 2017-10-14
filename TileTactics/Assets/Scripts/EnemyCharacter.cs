using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character {

    public enum EnemyType {
        SLIME,
        BAT,
        SKELETON
    }

    public enum ColorType {
        RED,
        GREEN,
        BLUE
    }

    public EnemyCharacter(int health, Weapon weapon, EnemyType enemyType, ColorType colorType) : base(health, weapon) {
        this.EnemyAccessor = enemyType;
        this.ColorAccessor = colorType;
    }

    public EnemyType EnemyAccessor {
        get;
        set;
    }

    public ColorType ColorAccessor {
        get;
        set;
    }
}

