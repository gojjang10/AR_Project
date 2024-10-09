using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    private int bullet;
    private int hp;
    public int Bullet { get { return bullet; } set { bullet = value; CurBullet?.Invoke(bullet); } }
    public int HP { get { return hp; } set { hp = value; CurHP?.Invoke(hp); } }

    public UnityAction<float> CurBullet;
    public UnityAction<float> CurHP;
}
