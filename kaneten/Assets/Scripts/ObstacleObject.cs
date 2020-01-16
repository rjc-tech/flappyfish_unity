using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 障害物生成クラス
public class ObstacleObject : MonoBehaviour
{

	public GameObject originObject;
	
	// 障害物生成間隔時間[s]
	const float createInterval = 1.5f;
	
	// 通過可能領域
	const float passSpace = 4.5f;
	
	// 画面高さ
	const float screenHeight = 10f;
	
	
	// 経過時間
    public float timeElapsed;
	
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if (GameStateManager.GameState != GameState.Playing)
        { 
           return;
        }
        
       // 前回Updateからの経過時間を加算
       timeElapsed += Time.deltaTime;

		// 経過時間が障害物生成間隔以上ならば新しい障害物を生成
        if(timeElapsed >= createInterval) {
     		// ObstacleプレハブをGameObject型で取得
        	GameObject obj_a = (GameObject)Resources.Load ("Obstacle1");
        	GameObject obj_b = (GameObject)Resources.Load ("Obstacle1");
        	GameObject obj_c = (GameObject)Resources.Load ("Obstacle1");
        	GameObject obj_d = (GameObject)Resources.Load ("Obstacle1");
        	obj_a.tag = "Obstacle1";
        	obj_b.tag = "Obstacle1";
        	obj_c.tag = "Obstacle1";
        	obj_d.tag = "Obstacle1";
        	
        	GameObject obj2 = (GameObject)Resources.Load ("Obstacle2");
        	obj2.tag = "Obstacle2";
        	
        	// 下障害物
        	float underY = Random.value * 3 - 5f;
        	// 上障害物は下障害物から+passSpace
        	float upperY = underY + passSpace;
       	
        	Instantiate (obj_a, new Vector3(25.0f,upperY+3,4.0f), Quaternion.identity);
        	Instantiate (obj_b, new Vector3(25.0f,upperY+2,4.0f), Quaternion.identity);
        	Instantiate (obj_c, new Vector3(25.0f,upperY+1,4.0f), Quaternion.identity);
        	Instantiate (obj_d, new Vector3(25.0f,upperY,4.0f), Quaternion.identity);
        	
        	Instantiate (obj2, new Vector3(25.0f,underY,4.0f), Quaternion.identity);
      
        	// 経過時間をリセット
            timeElapsed = 0;
        }
       
    }
		
    
}
