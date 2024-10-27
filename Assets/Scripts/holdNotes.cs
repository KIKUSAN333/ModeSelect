using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdNotes : MonoBehaviour
{
    float moveSpeed = 5.0f;
    public float holdPosition;

    private RectTransform rectTransform;

    public static int holdCount_Great = 0;
    public static int holdCount_Miss = 0;

    bool Hold = false;

    [SerializeField]
    private SoundManager soundManager; //サウンドマネージャー

    void Start()
    {
        // RectTransform コンポーネントを取得
        rectTransform = GetComponent<RectTransform>();//アスペクト比を固定させるため親オブジェクトがあるのでRectTransformを使う

        Debug.Log("Anchored Position: " + rectTransform.anchoredPosition.x);
        Debug.Log("World Position: " + rectTransform.position);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);//ノーツの移動

        //ホールドノーツのGood判定はなし
        if (Input.GetKey(KeyCode.F) && -875 - (rectTransform.rect.width - 30) <= rectTransform.anchoredPosition.x && rectTransform.anchoredPosition.x <= -845 + (rectTransform.rect.width - 30))//判定
        {
            Hold = true;
            OnClickButton_Great();
        }

        //ホールド中押してなかったらの処理
        /*
        if (!Input.GetKey(KeyCode.F) && -875 - (rectTransform.rect.width - 30) <= rectTransform.anchoredPosition.x && rectTransform.anchoredPosition.x <= -845 + (rectTransform.rect.width - 30))//判定
        {
            Miss();
        }
        */

        else if (Input.GetKey(KeyCode.F) && rectTransform.anchoredPosition.x <= -820 +(rectTransform.rect.width - 30) && !Hold)//早いミス
        {
            Debug.Log("Fast_HoldMiss");
            Hold = true;
            Miss();
        }
        else if (rectTransform.anchoredPosition.x <= -900 - (rectTransform.rect.width - 30))//遅いミスとノーツ消去
        {
            if (!Hold) {
                Debug.Log("Late_HoldMiss");
                Miss();
            }
            Destroy(this.gameObject);//ノーツ削除
        }
    }

    void OnClickButton_Great()
    {

        //Debug.Log("Hold ,X Position: " + this.rectTransform.anchoredPosition.x + " Judgemnt_Great");

        holdCount_Great++;

        holdPosition = transform.position.x;
        // ここでエフェクトを出す(音及び画面)
        soundManager.Play("HoldGreatSE");


        if (holdPosition < 0)
        {
            holdPosition *= -1;
        }

    }



    void Miss()
    {

        //Debug.Log("Hold ,X Position: " + this.rectTransform.anchoredPosition.x + " Judgemnt_Miss");

        holdCount_Miss++;

        holdPosition = transform.position.x;
        // ここでエフェクトを出す(音及び画面)
        soundManager.Play("MissSE");
        

        if (holdPosition < 0)
        {
            holdPosition *= -1;
        }
    }
}
