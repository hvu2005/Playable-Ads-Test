using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    //[SerializeField] private InputData _data;
    public bool canAction { get; set;} =  true;
    public bool isInteracting { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAction)
        {
            return;
        }

        isInteracting = Input.GetMouseButton(0);
    }
}
