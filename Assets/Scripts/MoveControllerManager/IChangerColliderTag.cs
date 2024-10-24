using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangerColliderTag
{
    public void AmEnemyNow();
    public void AmPlayerNow();

    public virtual void AmPlayerOnTopOfEnemyNow()
    {
        
    }
    
}
