using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : PooledObject
{
    SpriteRenderer render;
    public Sprite icon { get; private set; }
    public int id { get; private set; }
    public int count { get; private set; }
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    public void ResetData()
    {
        render.sprite = null;
        id = -1;
        count = -1;
    }
    public void SetItem(Sprite _icon, int _id, int _count)
    {
        this.icon = _icon;
        this.id = _id;
        this.count = _count;
        if(render == null)
            render = GetComponent<SpriteRenderer>();
        if(render != null)
            render.sprite = _icon;
    }
    public bool MinusItem(int minusItemCount)
    {
        if(count < minusItemCount )
            return false;
        count -= minusItemCount;
        return true;
    }
}
