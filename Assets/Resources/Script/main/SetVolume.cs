using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
 
    public AudioMixer audioMixer;    // 进行控制的Mixer变量
    public Image BGMIcon;
    public Image VoiceIcon;
    public Image SoundEffectIcon;
    public Sprite OffIcon;
    public Sprite OnIcon;
 
    public void SetMasterVolume(float volume)    // 控制主音量的函数
    {
        audioMixer.SetFloat("MasterVolume", volume);
        // MasterVolume为我们暴露出来的Master的参数
    }

    public void SetBGMVolume(float volume)    // 控制背景音乐音量的函数
    {
        if(volume == -40f){
          volume = -80f;
          BGMIcon.sprite = OffIcon;
        }else{
          BGMIcon.sprite = OnIcon;
        }
        audioMixer.SetFloat("BGMVolume", volume);
        // BGMVolume为我们暴露出来的BGM的参数
    }

    public void SetSoundEffectVolume(float volume)    // 控制音效音量的函数
    {
        if(volume == -40f){
          volume = -80f;
          SoundEffectIcon.sprite = OffIcon;
        }else{
          SoundEffectIcon.sprite = OnIcon;
        }
        audioMixer.SetFloat("SoundEffectVolume", volume);
        // SoundEffectVolume为我们暴露出来的SoundEffect的参数
    }

    public void SetVoiceVolume(float volume)    // 控制舰娘语音音量的函数
    {
        if(volume == -40f){
          volume = -80f;
          VoiceIcon.sprite = OffIcon;
        }else{
          VoiceIcon.sprite = OnIcon;
        }
        audioMixer.SetFloat("VoiceVolume", volume);
        // VoiceVolume为我们暴露出来的Voice的参数
    }

    public void SetKCListVolume(float volume)    // 控制任务娘的函数（暂定，可能以后会直接控制开关）
    {
        if(volume == -40f){
          volume = -80f;
        }
        audioMixer.SetFloat("SetKCListVolume", volume);
        // SetKCListVolume为我们暴露出来的KCList的参数
    }
}
