using UnityEngine;

public class CardStats : MonoBehaviour
{
    [SerializeField, Tooltip("Ataque de la carta"), Range(1, 9)] // Muestra campos en el inspector con explicación
    private int attack;

    public int GetAttack()
    {
        return attack;
    }
}
