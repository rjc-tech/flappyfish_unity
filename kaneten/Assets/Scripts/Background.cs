using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左方向へ0.1ずつ移動させる
        transform.Translate(-0.1f, 0, 0);
        // 画像サイズ分左へ行った場合
        if (transform.position.x < -24f)
        {
            // 1画面分右に移動する
            transform.position = new Vector3(24f, 0, 0);
        }
    }
}
