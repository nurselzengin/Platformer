using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using Sequence = DG.Tweening.Sequence;
using TMPro;

public class DoTween : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;

    void Start()
    {
        levelText.text = "Level" + LevelManager.level;
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(2, 2, 1), 1f));
        mySequence.Append(transform.DOScale(new Vector3(0, 0, 1), 1f));
        mySequence.OnComplete(DestroyText);

    }

    void DestroyText()
    { 
        Destroy(gameObject);
    }
}
