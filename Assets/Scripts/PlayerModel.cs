using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    private int bullet;
    public int Bullet { get { return bullet; } set { bullet = value; CurBullet?.Invoke(bullet); } }
    public UnityAction<float> CurBullet;
}
