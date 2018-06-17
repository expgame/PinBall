using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//スコア表示用のテキスト
	private GameObject scoreText;

	//得点加算用の変数
	private int score = 0;


	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.scoreText = GameObject.Find("ScoreText");

			}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameOverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}  
	}
	
		//ボールの衝突判定
	void OnCollisionEnter(Collision other) {
		//スコア処理を追加
		if (other.gameObject.tag == "SmallCloudTag") {
			score += 10;
			scoreText.GetComponent<Text> ().text = score.ToString ();

		} else if (other.gameObject.tag == "LargeCloudTag") {
			score += 20;
			scoreText.GetComponent<Text> ().text = score.ToString ();

		} else if (other.gameObject.tag == "LargeStarTag") {
			score += 50;
			scoreText.GetComponent<Text> ().text = score.ToString ();
		}
	}		
}
