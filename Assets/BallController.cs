using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject ScoreText;

    //スコアの初期化
    private int score = 0;

    // Use this for initialization
    void Start()
    {

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //Scoreオブジェクトの取得
        this.ScoreText = GameObject.Find("Score");

        //スコア表示
        this.ScoreText.GetComponent<Text>().text = "SCORE:" + score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

    }
    //当たったターゲットを判別し、スコアを加算
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
    

        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }

        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 5;
        }

        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 15;
        }

        //ScoreTextを更新
        this.ScoreText.GetComponent<Text>().text = "SCORE:" + score.ToString();

    }

}
