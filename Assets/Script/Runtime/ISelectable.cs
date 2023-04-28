using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    public void Select(RaycastHit _result);
    public void Deselect();
}
