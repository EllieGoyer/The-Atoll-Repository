using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collectable", menuName = "ScriptableObject/New Collectable")]
public class Collectable : NotebookItem {
    public bool HideInJournal = false;
}
