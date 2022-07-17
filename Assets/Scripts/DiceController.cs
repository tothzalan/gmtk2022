using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Collections;

public class DiceController : MonoBehaviour
{
    [SerializeField]
    public int sideCount = 6;
    [SerializeField]
    public List<Sprite> faces;
    [SerializeField]
    public GameObject obj;

    private SpriteRenderer _renderer;
    private int _lastRolled;

    private bool _started = false;

    public void RollAndAnimation()
    {
        if(!_started) {
            _started = true;
            _renderer = obj.GetComponent<SpriteRenderer>();

            obj.transform.localScale = new Vector2(0.2f, 0.2f);
            var color = _renderer.color;
            color.a = 1.0f;
            _renderer.color = color;

            List<int> rolls = new List<int>();
            for(int i = 0; i < 10; i++) {
                rolls.Add(RollDice());
            }
            _lastRolled = rolls[rolls.Count - 1];
            StartCoroutine(Rollin(rolls));
            _renderer.sprite = faces[_lastRolled];
        }
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !_started)
        {
            RollAndAnimation();
        }
    }

    IEnumerator Rollin(List<int> rolls)
    {
        foreach(int roll in rolls)
        {
            _renderer.sprite = faces[roll];
            yield return new WaitForSeconds(0.125f);
        }
    }

    public int RollDice()
    {
        Random r = new Random();
        return r.Next(0, sideCount);
    }
}