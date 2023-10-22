using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Animator anim;

    public int Id;

    private Vector3 startPos;

    public GameObject vfx;

    public bool canTouch = true;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Start()
    {

    }

    private void OnMouseDown()
    {
        if (!canTouch) return;

        GameManager.Instance.ListTargets.Add(this);
    }

    public void Return()
    {
        canTouch = true;

        transform.position = startPos;
    }

    public void DesTroyGameObject()
    {
        StartCoroutine(Wait(1));
    }

    IEnumerator Wait(int delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject vfxDestroy = Instantiate(vfx, transform.position, Quaternion.identity);
        Destroy(vfxDestroy, 1f);
        gameObject.SetActive(false);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
        GameManager.Instance.CheckLevelUp();
    }
}