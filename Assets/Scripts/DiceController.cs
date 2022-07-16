using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DiceController : MonoBehaviour
{
    [SerializeField]
    public int sideCount = 6;
    [SerializeField]
    public List<Sprite> faces;
    [SerializeField]
    public GameObject obj;

    private bool _started = false;

    public void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !_started)
        {
            _started = true;

            var renderer = obj.GetComponent<SpriteRenderer>();
            obj.transform.localScale = new Vector2(0.2f, 0.2f);
            var color = renderer.color;
            color.a = 1.0f;
            renderer.color = color;
            for(int i = 0; i < 20; i++) {
                int rolled = RollDice();
                renderer.sprite = faces[rolled - 1];
            }
            _started = false;
        } 
    }

    public int RollDice()
    {
        Random r = new Random();

        // animation must be done by now
        return r.Next(1, sideCount + 1);
    }
}