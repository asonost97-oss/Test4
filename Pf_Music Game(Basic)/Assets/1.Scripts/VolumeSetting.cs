using UnityEngine;

public interface IVolumeSetting
{
    void ApplyVolume(float linear);
}

public enum AudioChannel
{
    Master,
    Music,
    SFX,
    Voice
}
public class VolumeSetting
{
    
}
