using ClothingItems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    public Animator hatAnimator;

    public List<ClothingItem> activeClothes = new List<ClothingItem>();

    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        AnimateClothes();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void AnimateClothes()
    {
        Animator a = null;
        foreach (ClothingItem clothingItem in activeClothes)
        {
            a = clothingItem.animator;
            a.SetFloat("Horizontal", movement.x);
            a.SetFloat("Vertical", movement.y);
            a.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    public void AddClothing(GameObject clothingItemPrefab)
    {

        GameObject clothingItemGO = Instantiate(clothingItemPrefab);
        ClothingItem clothingItem = clothingItemGO.GetComponent<ClothingItem>();
        activeClothes.Add(clothingItem);

        clothingItem.transform.SetParent(transform);
        clothingItem.transform.localPosition = Vector3.zero;
        //clothingItem.id;
    }

    public ClothingItem FindClothing(ItemID id)
    {
        ClothingItem foundItem = null;
        foreach (ClothingItem item in activeClothes)
        {
            if (item.id == id)
            {
                foundItem = item;
                break;
            }
        }

        return foundItem;
    }

    public bool RemoveItem(ItemID id)   //removes item from the list of active clothes and destroys it
    {
        ClothingItem foundItem = FindClothing(id);
        if (foundItem != null)
        {
            activeClothes.Remove(foundItem);
            Destroy(foundItem.gameObject);
            return true;
        }
        return false;
    }

}
