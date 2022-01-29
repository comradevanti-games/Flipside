using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class CoinSide : ScriptableObject
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;
    [SerializeField] private Side side;

    public float Velocity => velocity;
    public float JumpForce => jumpForce;
    public Side Side => side;
}

public enum Side
{
    HEAD,
    TAIL,
}
