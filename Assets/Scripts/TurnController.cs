using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:Assets/Scripts/TurnController.cs
public class TurnController : MonoBehaviour
{
========
public class CameraController : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

>>>>>>>> Player:Assets/Scripts/CameraController.cs
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<<< HEAD:Assets/Scripts/TurnController.cs
        
========
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
>>>>>>>> Player:Assets/Scripts/CameraController.cs
    }
}
