using UnityEngine;
using System.Collections;

/*
 * キャラクター周りのスクリプト
 * 
 */
public class FishScript : MonoBehaviour
{
    public AudioClip FlyAudioClip;
    // public AudioClip DeathAudioClip, ScoredAudioClip;
    public float RotateUpSpeed = 1, RotateDownSpeed = 1;
    // public GameObject IntroGUI, DeathGUI;
    public float VelocityPerJump = 3;
    public float XSpeed = 1;

    // 初期処理
    void Start()
    {

    }

    FlappyYAxisTravelState flappyYAxisTravelState;

    enum FlappyYAxisTravelState
    {
        GoingUp, GoingDown
    }

    Vector3 FishRotation = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
            Application.Quit();

            MoveFishOnXAxis();
            if (WasTouchedOrClicked())
            {
                BoostOnYAxis();
                // ゲーム開始時のGUIはなし
                // IntroGUI.SetActive(false);
            }
    }

    void FixedUpdate()
    {
        FixFlappyRotation();
    }

    // ジャンプボタン判定
    bool WasTouchedOrClicked()
    {
        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonDown(0) || 
            (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            return true;
        else
            return false;
    }

    // 右に移動
    void MoveFishOnXAxis()
    {
        transform.position += new Vector3(Time.deltaTime * XSpeed, 0, 0);
    }

    // ジャンプ処理
    void BoostOnYAxis()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, VelocityPerJump);
        // 効果音
        GetComponent<AudioSource>().PlayOneShot(FlyAudioClip);
    }

    // ジャンプ時と落下時の挙動
    private void FixFlappyRotation()
    {
        if (GetComponent<Rigidbody2D>().velocity.y > 0) flappyYAxisTravelState = FlappyYAxisTravelState.GoingUp;
        else flappyYAxisTravelState = FlappyYAxisTravelState.GoingDown;

        float degreesToAdd = 0;

        switch (flappyYAxisTravelState)
        {
            case FlappyYAxisTravelState.GoingUp:
                degreesToAdd = 6 * RotateUpSpeed;
                break;
            case FlappyYAxisTravelState.GoingDown:
                degreesToAdd = -3 * RotateDownSpeed;
                break;
            default:
                break;
        }

        FishRotation = new Vector3(0, 0, Mathf.Clamp(FishRotation.z + degreesToAdd, -90, 45));
        transform.eulerAngles = FishRotation;
    }


    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            if (col.gameObject.tag == "Pipeblank") //pipeblank is an empty gameobject with a collider between the two pipes
            {
                GetComponent<AudioSource>().PlayOneShot(ScoredAudioClip);
                ScoreManagerScript.Score++;
            }
            else if (col.gameObject.tag == "Pipe")
            {
                FlappyDies();
            }
        }
    }
    */

    /*
    // キャラクターが障害物に当たった時の処理
    void OnCollisionEnter2D(Collision2D col)
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            if (col.gameObject.tag == "Floor")
            {
                FlappyDies();
            }
        }
    }
    */
    /*
    // キャラクター死亡処理
    void FlappyDies()
    {
        GameStateManager.GameState = GameState.Dead;
        DeathGUI.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(DeathAudioClip);
    }
    */
}
