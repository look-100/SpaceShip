using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;

    //两个背景的距离   18.4
    public float scrollDistance;

    void Update()
    {
        #region repeat方法
        //float dis = Mathf.Repeat(scrollSpeed * Time.time, 19.5f);
        // transform.position = startPos + scrollSpeed * Vector3.down * Time.deltaTime;
        #endregion

        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
        if (transform.position.y <= -scrollDistance)
        {
            transform.position = new Vector3(0, scrollDistance, 0);
        }

    }
}
