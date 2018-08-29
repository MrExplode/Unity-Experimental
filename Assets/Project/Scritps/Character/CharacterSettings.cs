using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSettings", menuName = "Settings/Character Move Settings")]
public class CharacterSettings : ScriptableObject {

    public float Speed = 10f;
    public float TurnSmoothing = 20f;
}
