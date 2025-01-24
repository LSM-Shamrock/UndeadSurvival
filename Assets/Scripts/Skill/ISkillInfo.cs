using System;
using UnityEngine;

public interface ISkillInfo
{
    public string Name { get; }
    public Sprite ProfileImage { get; }
    public string Description { get; }
    public string LevelupDescription { get; }
}
