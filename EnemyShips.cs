using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShips : Character
{

    Animator anim;
    SpriteRenderer sr;
    float timer;
    Color originalColor;

    internal UIMgr uiMgr;
    internal Transform playerTrans = null;
    public int score;
    public virtual void Start()
    {
        //获取组件
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.material.color;
        uiMgr = GameObject.FindGameObjectWithTag("UIMgr").GetComponent<UIMgr>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public virtual void OnEnable()
    {
        //GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet" || other.tag == "PlayerBullet3_break")
        {
            HpDecline();
        }
    }

    //血量下降
    public override void HpDecline()
    {
        if (hp > 1)
            StartCoroutine(AttackedFlash());
        hp--;
        if (hp <= 0)
        {
            //DisplayScoreText();
            // Destroy(GetComponent<BoxCollider2D>());
            // Destroy(GetComponent<Rigidbody2D>());
            GetComponent<Collider2D>().enabled = false;
            //GetComponent<Rigidbody2D>().enabled = false;
            anim.SetTrigger("isDie");
            StopCoroutine(AttackedFlash());
            //CreateProp();

        }
    }

    //受伤红闪
    IEnumerator AttackedFlash()
    {
        sr.material.color = Color.red;
        yield return new WaitForSeconds(0.06f);
        sr.material.color = originalColor;
    }

    public void Recovery()
    {
        if (transform.position.y <= -9.5f)
        {
            MoreObjectPool.instance.ReturnPool(gameObject);
            // Debug.Log("回收敌人");
        }
    }

    //死亡后产生道具
    public GameObject CreateProp()
    {
        int num = (Random.Range(0, 100) / 10);
        GameObject propGo;
        if (num < 2)
        {
            int rand = Random.Range(0, 100);
            if (rand < 25)
            {
                propGo = MoreObjectPool.instance.GetGameObjectPool("Prop_upFull");
                propGo.transform.position = transform.position;
                propGo.transform.rotation = Quaternion.identity;
            }
            else if (rand >= 25 && rand < 50)
            {
                propGo = MoreObjectPool.instance.GetGameObjectPool("Prop_barrier");
                propGo.transform.position = transform.position;
                propGo.transform.rotation = Quaternion.identity;
            }
            else if (rand >= 50 && rand < 75)
            {
                propGo = MoreObjectPool.instance.GetGameObjectPool("Prop_recovery");
                propGo.transform.position = transform.position;
                propGo.transform.rotation = Quaternion.identity;
            }
            else
            {
                propGo = MoreObjectPool.instance.GetGameObjectPool("Prop_up");
                propGo.transform.position = transform.position;
                propGo.transform.rotation = Quaternion.identity;
            }
            return propGo;
        }
        else
        {
            return null;
        }
    }

    //敌人死亡后显示分数  播放爆炸声音
    public void DisplayScoreText()
    {
        AudioManager.PlayEnemyExpAudio();
        GameObject scoreGo = MoreObjectPool.instance.GetGameObjectPool("ScoreText");
        scoreGo.GetComponentInChildren<TextMesh>().text = score.ToString();
        //scoreGo.GetComponent<TextMesh>().text = score.ToString();
        scoreGo.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, 0);

    }

    //回到对象池并增加分数
    public override void Destroy()
    {
        uiMgr.AddScore(score);
        MoreObjectPool.instance.ReturnPool(gameObject);
    }

    //追踪玩家的位置
    public void FollowShoot(Transform shootPoint)
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan((shootPoint.position.y - playerTrans.position.y)
        / (shootPoint.position.x - playerTrans.position.x));
        if (shootPoint.position.x - playerTrans.position.x < 0)
            angle = angle + 90;
        else
            angle = angle - 90;
        shootPoint.localEulerAngles = new Vector3(0, 0, angle);
    }

}
