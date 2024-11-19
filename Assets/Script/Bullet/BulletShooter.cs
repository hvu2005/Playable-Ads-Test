using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.PlasticSCM.Editor.WebApi;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private ItemData[] itemBuff;
    private int currentItemBuff = 0;
    [SerializeField] private ObjectPooling bulletPool;
    [SerializeField] private float shootingRate;
    [SerializeField] private Vector3 centerPoint;
    [SerializeField] private float distanceBetweenBullet;
    private bool isSuperior;
    private float shootingRateCounter;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 2;
    }

    // Update is called once per frame
    void Update()
    {
        shootingRateCounter -= Time.deltaTime;
        if (InputManager.instance.isInteracting && shootingRateCounter <= 0f)
        {
            int sub = (level/2);
            // tinh offset vien dan dau tien sau do moi vien dan cach nhau 0.13 ( TH chan va TH le )
            float mostLeftBulletOffsetX = level % 2 == 0 ? (-0.0625f - distanceBetweenBullet * (float)(sub - 1)) : (-distanceBetweenBullet * (float)sub);
            //Debug.Log(mostLeftBulletOffsetX);
            //neu level == 2 thi offset vien dan dau tien = -0.0625
            float offset = centerPoint.x + mostLeftBulletOffsetX;
            if(!isSuperior)
            {
                ShootNormal(offset);
            }
            else
            {
                ShootSuperior(offset);
            }
            shootingRateCounter = shootingRate;
        }
        if(GameManager.instance.isObtaningItem)
        {
            UpgradingPower(itemBuff[currentItemBuff++]);
            GameManager.instance.isObtaningItem = false;
        }
    }
    private void UpgradingPower(ItemData itemBuff)
    {
        if(itemBuff.intoSuperior)
        {
            isSuperior = true;
            shootingRate = itemBuff.bonusAttackSpeed;
            level = itemBuff.bonusLevel;
            FindObjectOfType<PlayerBehave>().GetComponent<Animator>().SetTrigger("intoSuperior");
        }
        else
        {
            shootingRate -= itemBuff.bonusAttackSpeed;
            level += itemBuff.bonusLevel;
        }
    }
    private void ShootSuperior(float offset)
    {
        for (int i = 0; i < level;i++)
        {
            GameObject bullet= bulletPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.DOMoveX(transform.position.x + offset, 0.1f);
            offset += distanceBetweenBullet;
        }
    }
    private void ShootNormal(float offset)
    {
        for (int i = 0; i < level; i++)
        {
            GameObject bulletLeft = bulletPool.GetObject();
            bulletLeft.transform.position = transform.position + centerPoint;
            bulletLeft.transform.rotation = transform.rotation;
            bulletLeft.transform.DOMoveX(transform.position.x + offset, 0.05f);

            GameObject bulletRight = bulletPool.GetObject();
            bulletRight.transform.position = transform.position - centerPoint;
            bulletRight.transform.rotation = transform.rotation;
            bulletRight.transform.DOMoveX(transform.position.x - offset, 0.05f);

            offset += 0.13f;
        }
    }
}
//Center point -0.265f
//Moi vien dan cach nhau x = 0.13f => 1 nua vien dan cach 0.0625f