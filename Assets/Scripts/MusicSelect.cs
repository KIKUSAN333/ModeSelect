using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSelect : MonoBehaviour
{
    //データベースに楽曲が追加されているか確認する//


    [SerializeField] MusicDataBase DataBase;
    [SerializeField] Text MusicNameText;
    [SerializeField] Text MusicLevelText;
    [SerializeField] Image MusicImage;

    AudioSource audio;

    int SelectMusicNumber;//選択曲の変数

    private void Start()//初期化
    {
        SelectMusicNumber = 0;
        audio = GetComponent<AudioSource>();
        MusicUpdata();
    }

    public void RightButtonPush()
    {
        Debug.Log("RightButtonPush");
        if (SelectMusicNumber < DataBase.MusicData.Length - 1)//データベースの要素の個数を超えないようにする
        {
            SelectMusicNumber++;
            MusicUpdata();
        }
    }

    public void LeftButtonPush()
    {
        Debug.Log("LeftButtonPush");
        if (SelectMusicNumber > 0)
        {
            SelectMusicNumber--;
            MusicUpdata();
        }
    }


    //音ゲー本体部分のシーンの名前を楽曲名にする必要あり
    public void ChoiceMusic()
    {
        string ChoiceSceneName = DataBase.MusicData[SelectMusicNumber].MusicName;   //データベースから楽曲名を持ってくる
        SceneManager.LoadScene(ChoiceSceneName);    //楽曲名と同じ名前のシーンをロードする
    }



    private void MusicUpdata()
    {

        audio.clip = DataBase.MusicData[SelectMusicNumber].Music;//データベースから楽曲を持ってくる
        audio.Play();

        //データベースから楽曲名,楽曲レベル,楽曲画像を持ってくる
        MusicNameText.text = DataBase.MusicData[SelectMusicNumber].MusicName;
        MusicLevelText.text = "Lv." + DataBase.MusicData[SelectMusicNumber].MusicLevel;
        MusicImage.sprite = DataBase.MusicData[SelectMusicNumber].MusicImage;

    }



}
