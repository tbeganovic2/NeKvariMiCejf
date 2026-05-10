using UnityEngine;
using System;

public class CupScript : MonoBehaviour
{
    public int coffeeAmount;

    public Animator animator;
    
    //public bool MoveCoffeeToMouth - Trigger
    //public bool DecreaseCoffee - Trigger
    //public bool IncreaseCoffee - Trigger

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (GameManagerScript.Instance.playState != GameManagerScript.PlayState.Idle)
        {
            return;
        }

        if (coffeeAmount <= 0)
        {
            //Add shaking action to represent empty cup
        }
        //initiate coffee drinking animation
        animator.SetTrigger("TriggerCoffeeDrink");
        GameManagerScript.Instance.DrinkCoffee();
    }
}
