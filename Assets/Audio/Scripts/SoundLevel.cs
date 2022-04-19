using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundLevel : MonoBehaviour
{
    public Slider _sound;
    //public Slider _music;
    public float _soundValue;
    //public float _musicValue;
    private void Start() {
        //GlobalCache.Inst.LoadData();
        //_soundValue = GlobalCache.Inst.SoundLevel;
        //_musicValue = GlobalCache.Inst.MusicLevel;
        _sound.value = _soundValue;
        //_music.value = _musicValue;
    }
    private void Update() {
        if(_soundValue != _sound.value) //|| _musicValue != _music.value)
            TryReload();
    }
    private void TryReload()
    {
        //GlobalCache.Inst.SoundLevel = _sound.value;
        //GlobalCache.Inst.MusicLevel = _music.value;
        _soundValue = _sound.value;
        //_musicValue = _music.value;
        //GlobalCache.Inst.SaveData();
        FindObjectOfType<AudioManager>().Reload();
    }
}
