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
    private SoundManager soundManager; //�T�E���h�}�l�[�W���[

    void Start()
    {
        // RectTransform �R���|�[�l���g���擾
        rectTransform = GetComponent<RectTransform>();//�A�X�y�N�g����Œ肳���邽�ߐe�I�u�W�F�N�g������̂�RectTransform���g��

        Debug.Log("Anchored Position: " + rectTransform.anchoredPosition.x);
        Debug.Log("World Position: " + rectTransform.position);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);//�m�[�c�̈ړ�

        //�z�[���h�m�[�c��Good����͂Ȃ�
        if (Input.GetKey(KeyCode.F) && -875 - (rectTransform.rect.width - 30) <= rectTransform.anchoredPosition.x && rectTransform.anchoredPosition.x <= -845 + (rectTransform.rect.width - 30))//����
        {
            Hold = true;
            OnClickButton_Great();
        }

        //�z�[���h�������ĂȂ�������̏���
        /*
        if (!Input.GetKey(KeyCode.F) && -875 - (rectTransform.rect.width - 30) <= rectTransform.anchoredPosition.x && rectTransform.anchoredPosition.x <= -845 + (rectTransform.rect.width - 30))//����
        {
            Miss();
        }
        */

        else if (Input.GetKey(KeyCode.F) && rectTransform.anchoredPosition.x <= -820 +(rectTransform.rect.width - 30) && !Hold)//�����~�X
        {
            Debug.Log("Fast_HoldMiss");
            Hold = true;
            Miss();
        }
        else if (rectTransform.anchoredPosition.x <= -900 - (rectTransform.rect.width - 30))//�x���~�X�ƃm�[�c����
        {
            if (!Hold) {
                Debug.Log("Late_HoldMiss");
                Miss();
            }
            Destroy(this.gameObject);//�m�[�c�폜
        }
    }

    void OnClickButton_Great()
    {

        //Debug.Log("Hold ,X Position: " + this.rectTransform.anchoredPosition.x + " Judgemnt_Great");

        holdCount_Great++;

        holdPosition = transform.position.x;
        // �����ŃG�t�F�N�g���o��(���y�щ��)
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
        // �����ŃG�t�F�N�g���o��(���y�щ��)
        soundManager.Play("MissSE");
        

        if (holdPosition < 0)
        {
            holdPosition *= -1;
        }
    }
}
