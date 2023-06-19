using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    public Animator hatAnimator;

    public List<GameObject> activeClothes = new List<GameObject>();

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
        foreach (GameObject clothingItem in activeClothes)
        {
            a = clothingItem.GetComponent<Animator>();
            a.SetFloat("Horizontal", movement.x);
            a.SetFloat("Vertical", movement.y);
            a.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    public void AddClothing(GameObject clothingItemPrefab)
    {

        GameObject clothingItem = Instantiate(clothingItemPrefab);
        activeClothes.Add(clothingItem);

        clothingItem.transform.SetParent(transform);
        clothingItem.transform.localPosition = Vector3.zero;
    }

}
