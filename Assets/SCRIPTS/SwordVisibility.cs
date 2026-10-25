using UnityEngine;

public class SwordVisibility : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Start() renders the sword at the start of the game and hides it
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        HideSword();
    }
    //ShowSword() shows the sword in the game
    public void ShowSword()
    {
        spriteRenderer.enabled = true;
    }
    //HideSword() hides the sword so that the player has to press right mouse button or x to attack 
    //, and that it's not constantly out.
    public void HideSword() 
    {
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
