using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableItemCountable : CollectableItem
{
    public TextMeshProUGUI ItemCountText;
    public int ItemCount;
    public int ItemCountMax = 50;

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        ItemCount = 0;
        updateItemCountText();
    }

    protected override void actualLeftClick()
    {
        base.actualLeftClick();
        if (ItemCount < ItemCountMax)
        {
            ItemCount++;
        }
        updateItemCountText();
    }

    protected override void rightClick()
    {
        base.rightClick();
        if (ItemCount > 0)
        {
            ItemCount--;
        }
        updateItemCountText();
    }

    private void updateItemCountText()
    {
        ItemCountText.enabled = ItemCount > 0;
        ItemCountText.text = ItemCount.ToString();
        ItemAcquired = ItemCount > 0;
        selfButton.interactable = ItemCount > 0;
    }
}
