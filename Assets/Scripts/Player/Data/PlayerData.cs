using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/ Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Movement")]
    public float movementVelocity = 2f;
    public float decelerationRate = 1f;
}
