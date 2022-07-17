using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    [SerializeField]
    public int sideCount = 6;
    [SerializeField]
    public List<Sprite> faces;

    public Image image;
    private Animator _animator;
    public Animator Animator => _animator;
    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _animator.enabled = true;
    }

    // public void Update()
    // {
    //     if (_stopped)
    //         return;
    //     gameObject.transform.localScale = new Vector2(0.2f, 0.2f);
    //     var color = image.color;
    //     color.a = 1.0f;
    //     image.color = color;
    //
    //     image.sprite = faces[RollDice() - 1];
    // }

    // IEnumerator Rollin()
    // {
    //     List<int> rolls = new List<int>();
    //     for(int i = 0; i < 10; i++) {
    //         rolls.Add(RollDice());
    //     }
    //     _lastRolled = rolls[rolls.Count - 1];
    //     
    //     foreach(int roll in rolls)
    //     {
    //         image.sprite = faces[roll];
    //         _lastRolled = roll;
    //         yield return new WaitForSeconds(0.125f);
    //     }
    // }

    public int RollDice()
    {
        Animator.enabled = false;
        
        Random r = new Random();
        int value = r.Next(0, sideCount);

        image.sprite = faces[value];
        
        return value + 1;
    }
}