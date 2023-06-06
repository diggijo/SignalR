using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavascriptHook : MonoBehaviour
{
    [SerializeField] private SpriteRenderer squareSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            TintRed();
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            TintGreen();
        }
    }

    public void TintRed()
    {
        squareSpriteRenderer.color = Color.red;
    }

    public void TintGreen()
    {
        squareSpriteRenderer.color = Color.green;
    }
}
