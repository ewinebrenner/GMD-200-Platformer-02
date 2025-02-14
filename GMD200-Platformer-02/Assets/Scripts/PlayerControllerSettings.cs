using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Player Settings")]
public class PlayerControllerSettings : ScriptableObject
{
    public float walkSpeed = 6.0f;
    public float jumpSpeed = 10.0f;
    public LayerMask groundLayer;
}
