using Script.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skilltree : MonoBehaviour
{
    public GameObject[] skils;
    public GameObject skillTreeWindow;


    public Button skillButton1;
    public Button skillButton2;
    public Button skillButton3;

    public Text skillText1;
    public Text skillText2;
    public Text skillText3;

    public GameObject player;
    public PlayerStats playerStats;
    public Projectals projectals;
    public GameObject blades;
    public GameObject gun;
    
    void Start()
    {
        skillText1.text = "Upgrade Stats" +"Player Health: +10" + "Player Speed: +10" ;
        skillText2.text = "Upgrade Weapon";
        skillText3.text = "Skill: Blades";

        skillTreeWindow.SetActive(false);

        skillButton1.onClick.AddListener(() => SkillTreeWindow(1));
        skillButton2.onClick.AddListener(() => SkillTreeWindow(2));
        skillButton3.onClick.AddListener(() => SkillTreeWindow(3));

    }

    public void SkillTreeWindow( int number)
    {
        ShowSkillTree();



        switch (number)
        {
            case 1:
                playerStats.maxHealth += 10;
                playerStats.speed += 10;
                HideSkillTree();
                break;

            case 2:
                playerStats.projectalSpeed += 10;
                playerStats.cooldown -= 0.03f;
                playerStats.damage += 5;
                HideSkillTree();
                break;

            case 3:
                if ( blades == true ) 
                { 
                    blades.SetActive(true);
                }
                else if (blades == false)
                {
                    gun.SetActive(true);
                }
                HideSkillTree();
                break;
        }
    }

    void HideSkillTree()
    {
        Time.timeScale = 1f;
        skillTreeWindow.SetActive(false);
    }

    void ShowSkillTree()
    {
        Time.timeScale = 0f;
        skillTreeWindow.SetActive(true);
    }

}
