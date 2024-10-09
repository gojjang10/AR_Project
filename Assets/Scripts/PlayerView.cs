using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bulletText;
    //[SerializeField] TextMeshProUGUI hpText;
    [SerializeField] Image curbullet;
    [SerializeField] Image curHP;
    [SerializeField] PlayerModel model;

    private void Update()
    {
        UpdateBullet(model.Bullet);
        UpdateHP(model.HP);
    }

    private void UpdateBullet(float bullet)
    {
        bulletText.text = $"{bullet}";
        curbullet.fillAmount = bullet / 30f;
    }

    private void UpdateHP(float hp)
    {
        //hpText.text = $"{hp} / 30";
        curHP.fillAmount = hp / 30f;
    }
}
