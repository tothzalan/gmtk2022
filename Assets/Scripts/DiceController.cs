using UnityEngine;
using Random = System.Random;

public class DiceController : MonoBehaviour
{
    public int sideCount;

    public int RollDice()
    {
        Random r = new Random();

        // animation must be done by now
        return r.Next(1, sideCount + 1);
    }
}