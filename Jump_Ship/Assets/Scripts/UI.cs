using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> ability_text;

    int ability_amount_1;
    int ability_amount_2;
    int ability_amount_3;
    int minus_one;

    KeyCode use_ability_1 = KeyCode.Z;
    KeyCode use_ability_2 = KeyCode.X;
    KeyCode use_ability_3 = KeyCode.C;

    public float countdown;
    float timer_1, timer_2, timer_3;
    bool start_countdown;


    // Start is called before the first frame update
    void Start()
    {
        ability_amount_1 = 3;
        ability_amount_2 = 3;
        ability_amount_3 = 3;
        minus_one = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        UseAbility();

        if (start_countdown)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                // Only return the value to 1 once the timer runs out.
                minus_one = 1;
                start_countdown = false;
            }
        }
    }

    void UpdateText()
    {
        if (ability_amount_1 > 0 || ability_amount_2 > 0 || ability_amount_3 > 0)
        {
            ability_text[0].text = ability_amount_1.ToString();
            ability_text[1].text = ability_amount_2.ToString();
            ability_text[2].text = ability_amount_3.ToString();
        }
    }

    void UseAbility()
    {
        // Abilities can only be used if the ability amount is still above zero
        if (Input.GetKeyDown(use_ability_1) && ability_amount_1 > 0)
        {
            // When an ability is used minus one to the stock amount then set the minus_one to zero so that the player can't use it consecutively
            ability_amount_1 -= minus_one;

            start_countdown = true;
            timer_1 = 3f;
            minus_one = 0;

            // Set the countdown timer to the timer associated with the ability
            if (countdown <= 0)
            {
                countdown = timer_1;
            }
        }

        else if (Input.GetKeyDown(use_ability_2) && ability_amount_2 > 0)
        {
            ability_amount_2 -= minus_one;

            start_countdown = true;
            timer_2 = 5f;
            minus_one = 0;

            if (countdown <= 0)
            {
                countdown = timer_2;
            }

        }

        else if (Input.GetKeyDown(use_ability_3) && ability_amount_3 > 0)
        {
            ability_amount_3 -= minus_one;

            start_countdown = true;
            timer_3 = 10f;
            minus_one = 0;

            if (countdown <= 0)
            {
                countdown = timer_3;
            }
        }
    }


}
