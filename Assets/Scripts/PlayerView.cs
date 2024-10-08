using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bulletText;
    [SerializeField] Image curbullet;
    [SerializeField] PlayerModel model;

    private void Update()
    {
        UpdateBullet(model.Bullet);
    }

    private void UpdateBullet(float bullet)
    {
        bulletText.text = $"Bullet : {bullet} / 30";
        curbullet.fillAmount = bullet / 30f;
    }
}
