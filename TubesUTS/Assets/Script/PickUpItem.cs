using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] float pickupDistance;
    [SerializeField] Transform player, itemContainer;

    private Transform itemTransform;
    private Inventory playerInventory;
    private Rigidbody rb;

    [SerializeField] private AudioSource pickUpSoundEffect;
    [SerializeField] private AudioSource dropSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = player.GetComponent<Inventory>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (playerInventory.IsEmpty() && distanceToPlayer.magnitude <= pickupDistance && Input.GetKeyDown(KeyCode.E)) PickUp();

        //Drop if equipped and "Q" is pressed
        if (!playerInventory.IsEmpty() && Input.GetKeyDown(KeyCode.Q)) Drop(); 
    }

    private void PickUp()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        itemTransform = this.transform;
        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        
        playerInventory.AddItem(itemTransform.gameObject);
        pickUpSoundEffect.Play();
    }

    private void Drop()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        transform.SetParent(null);
        
        playerInventory.RemoveItem();
        dropSoundEffect.Play();
        
    }
}
