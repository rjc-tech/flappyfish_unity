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
	const float passSpace = 3f;
	
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
    
        FishScoreManager.addPoint(1);
        Debug.Log(FishScoreManager.getScore());
        
       // 前回Updateからの経過時間を加算
       timeElapsed += Time.deltaTime;

		// 経過時間が障害物生成間隔以上ならば新しい障害物を生成
        if(timeElapsed >= createInterval) {
     		// ObstacleプレハブをGameObject型で取得
        	GameObject obj = (GameObject)Resources.Load ("Obstacle1");
        	obj.tag = "Obstacle1";
        	GameObject obj2 = (GameObject)Resources.Load ("Obstacle2");
        	obj2.tag = "Obstacle2";
        	// Obstacleプレハブを元に、インスタンスを生成
        	float y = Random.value * 10 - 5f;
        	
        	if(y > 4.0f){
        		y = 4.0f;
        	} else if (y < -1.0f) {
        		y = -1.0f;
        	}
        	
        	Instantiate (obj, new Vector3(25.0f,y,4.0f), Quaternion.identity);
        	
        	Instantiate (obj2, new Vector3(25.0f,y - passSpace,4.0f), Quaternion.identity);
      
        	// 経過時間をリセット
            timeElapsed = 0;
        }
       
    }
		
    
}
