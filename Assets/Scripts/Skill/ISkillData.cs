using System;
using UnityEngine;

public interface ISkillData
{
    public int Level { get; set; }
    public string Name { get; }
    public Sprite ProfileImage { get; }
    public string Description { get; }
    public string LevelupDescription { get; }
}
