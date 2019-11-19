using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{


	const float scale = 25.0f;	
	const float height = 8.0f;
	
	
	public GameObject originObject;
	
	float y = 0.05f;
	

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
        if (transform.position.x < -scale)
        {
            // 1画面分右に移動する
            //transform.position = new Vector3(scale, transform.position.y, 0);
            
             //GameObjectを削除
             Object.Destroy(gameObject, 0f);
          
        }
        
    }
}
