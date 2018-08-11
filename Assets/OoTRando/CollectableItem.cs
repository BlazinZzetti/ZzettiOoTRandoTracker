using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CollectableItem : MonoBehaviour, IPointerClickHandler
{
    protected Image displayImage;
    protected Button selfButton;

    public bool ItemAcquired;
    public bool ItemIgnored;

    public Sprite Tier1Item;
    public Sprite Tier2Item;
    public Sprite Tier3Item;

    public Sprite Checked;
    public Sprite Ignore;

    public enum ItemState
    {
        NotAcquired,
        Tier1,
        Tier2,
        Tier3
    }

    public ItemState CurrentItemState = ItemState.NotAcquired;

    // Use this for initialization
    void Awake ()
    {
        displayImage = GetComponent<Image>();
        selfButton = GetComponent<Button>();
        selfButton.interactable = false;
        ItemAcquired = false;
        displayImage.sprite = Tier1Item;
        CurrentItemState = ItemState.NotAcquired;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            leftClick();
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

    protected virtual void leftClick()
    {
        switch (CurrentItemState)
        {
            case ItemState.NotAcquired:
                CurrentItemState = ItemState.Tier1;
                ItemAcquired = true;
                selfButton.interactable = true;
                displayImage.sprite = Tier1Item;
                break;
            case ItemState.Tier1:
                if (Tier2Item != null)
                {
                    CurrentItemState = ItemState.Tier2;
                    ItemAcquired = true;
                    selfButton.interactable = true;
                    displayImage.sprite = Tier2Item;
                }
                break;
            case ItemState.Tier2:
                if (Tier3Item != null)
                {
                    CurrentItemState = ItemState.Tier3;
                    ItemAcquired = true;
                    selfButton.interactable = true;
                    displayImage.sprite = Tier3Item;
                }
                break;
        }
    }

    protected virtual void middleClick()
    {
        Debug.Log("Middle click");
    }

    protected virtual void rightClick()
    {
        switch (CurrentItemState)
        {
            case ItemState.Tier1:
                CurrentItemState = ItemState.NotAcquired;
                ItemAcquired = false;
                selfButton.interactable = false;
                displayImage.sprite = Tier1Item;
                break;
            case ItemState.Tier2:
                if (Tier1Item != null)
                {
                    CurrentItemState = ItemState.Tier1;
                    ItemAcquired = true;
                    selfButton.interactable = true;
                    displayImage.sprite = Tier1Item;
                }
                break;
            case ItemState.Tier3:
                if (Tier2Item != null)
                {
                    CurrentItemState = ItemState.Tier2;
                    ItemAcquired = true;
                    selfButton.interactable = true;
                    displayImage.sprite = Tier2Item;
                }
                break;
        }
    }
}
