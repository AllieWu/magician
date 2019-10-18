using UnityEngine;
using UnityEngine.UI;

public class MapSetController : MonoBehaviour
{
    public Sprite[] maps = null;  // imported sprites
    public GameObject imagecontainer = null;  // image object in hierarchy that holds the sprites
    private Image currentmap = null;  // current image

    // returns the next sprite from maps[]
    private Sprite GetNextMapSprite()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            //print($"maps[i].name={maps[i].name} && currentmap.sprite.name={currentmap.sprite.name}");
            if (maps[i].name == currentmap.sprite.name)  // account for looping back to 0 at the end of the array
                return (i == maps.Length - 1) ? maps[0] : maps[i + 1];
        }

        return null;  // return null by default, signaling error
    }


    // simply switches the image's sprite w/ next one in array
    public void SwitchMap()
    {
        currentmap.sprite = GetNextMapSprite();
    }


    private void Start()
    {
        // At the start, set up currentmap as the image component of our image object
        // To update the image with imported sprite objects, set currentmap.sprite = sprite
        currentmap = imagecontainer.GetComponent<Image>();
    }
}
