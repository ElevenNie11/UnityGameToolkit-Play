using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("伤害量")]
    public float damage = 10f;
    [Header("射程")]
    public float range = 100f;
    [Header("摄像机")]
    //为了从摄像机射出光线，我们必须要有一个关于摄像机的引用变量
    public Camera fpsCam;
    public ParticleSystem muzzleFlash; //粒子系统

    void Update()
    {
        //输入定义"Fire1"会自动映射到鼠标左键
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;   //用于保存射线打出的所有信息
        //此函数：如果击中目标则返回true，如果没有集中目标就返回false
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //查找被击中对象身上是否有Target.cs脚本(因为我们只需要在敌人身上挂载Target.cs脚本，建筑物等则不用)，而玩家在射击时，可能会打中建筑物，所以需要这个判断
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}


//射线检测
/*
    Physics.Raycast(
    fpsCam.transform.position,   //- 起点：摄像机的位置
    fpsCam.transform.forward,    //- 方向：摄像机正前方
    out hit,                     //- 输出：命中的信息存到hit变量里
    range                        //- 最大距离：射线只检测range米以内
)
*/