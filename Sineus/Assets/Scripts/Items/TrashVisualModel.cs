using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashVisualModel : MonoBehaviour
{
    [SerializeField] private ItemType m_type;

    public ItemType Type => m_type;
}
