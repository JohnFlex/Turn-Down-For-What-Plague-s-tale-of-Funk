using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ToolTip" , menuName = "Scriptable Objects / ToolTip", order = 0)]
public class ToolTipSO : ScriptableObject
{
    public Sprite[] toolTipImage;
    public string[] toolTipText;
    
}

