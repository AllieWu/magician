using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game Object representation of an item
public class Drop : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
        renderer.transform.localScale = new Vector2(0.25f, 0.25f);
    }

}
