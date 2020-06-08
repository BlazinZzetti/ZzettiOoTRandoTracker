using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CollectableItem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    protected Image displayImage;
    protected Button selfButton;

    public bool UseListSprites = false;

    public bool ItemAcquired;
    public bool ItemIgnored;

    public Sprite Tier1Item;
    public Sprite Tier2Item;
    public Sprite Tier3Item;

    /// <summary>
    /// First Item should be disabled item, then order of items.
    /// </summary>
    public List<Sprite> Items = new List<Sprite>();
    private int ItemsSpriteIndex = 0;

    public Sprite Checked;
    public Sprite Ignore;

    protected bool isHeld;

    public enum ItemState
    {
        NotAcquired,
        Tier1,
        Tier2,
        Tier3
    }

    public ItemState CurrentItemState = ItemState.NotAcquired;

    // Use this for initialization
    protected virtual void Awake ()
    {
        displayImage = GetComponent<Image>();
        selfButton = GetComponent<Button>();
        selfButton.interactable = false;
        ItemAcquired = false;
        displayImage.sprite = Tier1Item;
        CurrentItemState = ItemState.NotAcquired;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = true;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            leftClick(eventData);
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            middleClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeld = false;
    }

    protected virtual void leftClick(PointerEventData eventData)
    {
        StartCoroutine(LeftClickToRightClickCheck(eventData));
    }

    private IEnumerator LeftClickToRightClickCheck(PointerEventData eventData)
    {
        var timeWaited = 0.0f;
        while (isHeld && timeWaited < 0.5f)
        {
            yield return new WaitForEndOfFrame();
            timeWaited += Time.deltaTime;
        }

        if (timeWaited >= 0.5f)
        {
            rightClick();
        }
        else
        {
            actualLeftClick();
        }
    }

    protected virtual void actualLeftClick()
    {
        if (UseListSprites)
        {
            if (ItemsSpriteIndex < Items.Count - 1)
            {
                ItemsSpriteIndex++;
            }
            UpdateItemSprite();
        }
        else
        {
            switch (CurrentItemState)
            {
                case ItemState.NotAcquired:
                    if (Tier1Item != null)
                    {
                        CurrentItemState = ItemState.Tier1;
                    }
                    break;
                case ItemState.Tier1:
                    if (Tier2Item != null)
                    {
                        CurrentItemState = ItemState.Tier2;
                    }
                    break;
                case ItemState.Tier2:
                    if (Tier3Item != null)
                    {
                        CurrentItemState = ItemState.Tier3;
                    }
                    break;
            }
            ItemAcquired = CurrentItemState != ItemState.NotAcquired;
            selfButton.interactable = CurrentItemState != ItemState.NotAcquired;            
        }
        UpdateItemSprite();
    }

    protected virtual void middleClick()
    {
        Debug.Log("Middle click");
    }

    protected virtual void rightClick()
    {
        if (UseListSprites)
        {
            if (ItemsSpriteIndex > 0)
            {
                ItemsSpriteIndex--;
            }
            UpdateItemSprite();
        }
        else
        {
            switch (CurrentItemState)
            {
                case ItemState.Tier1:
                    if (Tier1Item != null)
                    {
                        CurrentItemState = ItemState.NotAcquired;
                    }
                    break;
                case ItemState.Tier2:
                    if (Tier1Item != null)
                    {
                        CurrentItemState = ItemState.Tier1;
                    }
                    break;
                case ItemState.Tier3:
                    if (Tier2Item != null)
                    {
                        CurrentItemState = ItemState.Tier2;
                    }
                    break;
            }
            ItemAcquired = CurrentItemState != ItemState.NotAcquired;
            selfButton.interactable = CurrentItemState != ItemState.NotAcquired;
        }
        UpdateItemSprite();
    }

    private void UpdateItemSprite()
    {
        if (UseListSprites)
        {
            displayImage.sprite = Items[ItemsSpriteIndex];
            switch (ItemsSpriteIndex)
            {
                case 1:
                    CurrentItemState = ItemState.Tier1;
                    break;
                case 2:
                    CurrentItemState = ItemState.Tier2;
                    break;
                case 3:
                    CurrentItemState = ItemState.Tier3;
                    break;
                default://0 or > 3
                    if (ItemsSpriteIndex == 0)
                    {
                        CurrentItemState = ItemState.NotAcquired;
                    }
                    else
                    {
                        CurrentItemState = ItemState.Tier3;
                    }
                    break;
            }
            ItemAcquired = ItemsSpriteIndex > 0;
            selfButton.interactable = ItemsSpriteIndex > 0;
        }
        else
        {
            switch (CurrentItemState)
            {
                case ItemState.NotAcquired:
                    if (Tier1Item != null)
                    {
                        displayImage.sprite = Tier1Item;
                    }
                    break;
                case ItemState.Tier1:
                    if (Tier1Item != null)
                    {
                        displayImage.sprite = Tier1Item;
                    }
                    break;
                case ItemState.Tier2:
                    if (Tier2Item != null)
                    {
                        displayImage.sprite = Tier2Item;
                    }
                    break;
                case ItemState.Tier3:
                    if (Tier3Item != null)
                    {
                        displayImage.sprite = Tier3Item;
                    }
                    break;
            }
        }
    }
}
