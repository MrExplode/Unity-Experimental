using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zombie Settings", menuName = "Settings/Zombie Move Settings")]
public class ZombieSettings : ScriptableObject {

    public float NormalSpeed = 5.5f;
    public float ChaseSpeed = 7;
    public float ChaseDistance = 40;
}
