using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatioPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1Text;
    private Animator animator;
    private AnimationClip[] animationClip;

    void Start()
    {
        animator = player1Text.GetComponent<Animator>();
        animationClip = animator.runtimeAnimatorController.animationClips;
        Debug.Log("该对象有" + animationClip.Length + "个动画");
        foreach (AnimationClip a in animationClip)//遍历获取所有该对象的动画名
        {
            Debug.Log(a.name);
        }
    }

    public void showAnimation(int player, string text)
    {
        switch (player)
        {
            case 1:
                animator = player1Text.GetComponent<Animator>();
                player1Text.GetComponent<Text>().text = text;
                break;
            case 2:
            case 3:
            case 4:
            default:
                break;
        }
        animator.Play(animationClip[0].name);   //播放动画
        animator.Update(0);         //刷新0层的动画，默认新建的动画在0层。
        GetAnimatorInfo();
    }

    void GetAnimatorInfo()
    {
        string name = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;//获取当前播放动画的名称
        Debug.Log("当前播放的动画名为：" + name);
        float length = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;//获取当前动画的时间长度
        Debug.Log("播放动画的长度：" + length);
    }
}
