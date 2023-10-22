     using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTargets : MonoBehaviour
{
    public List<Block> blocks;

    public List<GameObject> targetPos;

    private bool canCheck = false;

    public void Add(Block block)
    {
        if (blocks.Count < 3)
        {
            blocks.Add(block);

            block.canTouch = false;

            block.gameObject.transform.position = targetPos[blocks.IndexOf(block)].transform.position;

            if (blocks.Count == 3) canCheck = true;
        }
    }

    private bool CheckId()
    {
        if (blocks[0].Id == blocks[1].Id && blocks[0].Id == blocks[2].Id)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        if (canCheck)
        {
            canCheck = false;
            CheckBlock();
        }
    }

    private void RemoveFromList()
    {
        if (blocks.Count != 3) return;

        foreach (Block block in blocks)
        {
            if (block != null) block.Return();
        }
        blocks.Clear();
    }

    private void ClearList()
    {
        if (blocks.Count != 3) return;

        foreach (Block block in blocks)
        {
            if (block != null) block.DesTroyGameObject();
        }

        blocks.Clear();
        
    }

    private void CheckBlock()
    {
        if (blocks.Count != 3) return;

        if (!CheckId())
        {
            RemoveFromList();
        }
        else
        {
            ClearList();
        }
    }
}