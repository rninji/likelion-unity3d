using UnityEngine;

public class LegacyPlayer : MonoBehaviour
{
    public void LegacyMove(float x, float y, float z)
    {
        Debug.Log($"Legacy Player 이동 : {x}, {y}, {z}");
    }

    public void LegacyAttack()
    {
        Debug.Log("Legacy Attack");
    }
}
