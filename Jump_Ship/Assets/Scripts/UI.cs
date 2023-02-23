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

    KeyCode use_ability_1 = KeyCode.Z;
    KeyCode use_ability_2 = KeyCode.X;
    KeyCode use_ability_3 = KeyCode.C;

    // Start is called before the first frame update
    void Start()
    {
       
        ability_amount_1 = 3;
        ability_amount_2 = 3;
        ability_amount_3 = 3;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        UseAbility();
    }

    void UpdateText()
    {
        if(ability_amount_1 > 0 || ability_amount_2 > 0 || ability_amount_3 > 0)
        {

            for (int i = 0; i < ability_text.Count; i++)
            {
                ability_text[0].text = ability_amount_1.ToString();
                ability_text[1].text = ability_amount_2.ToString();
                ability_text[2].text = ability_amount_3.ToString();
            }
        }

        else
        {
            for (int i = 0; i < ability_text.Count; i++)
            {
                ability_text[i].text = "0";
            }
        }
    }

    void UseAbility()
    {

        if (Input.GetKeyDown(use_ability_1))
        {
            ability_amount_1 -= 1;
        }

        else if (Input.GetKeyDown(use_ability_2))
        {
            ability_amount_2 -= 1;
        }

        else if (Input.GetKeyDown(use_ability_3))
        {
            ability_amount_3 -= 1;
        }
    }
}
