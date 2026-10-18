using System;
using System.Collections.Generic;
using System.Text;

public interface IDamagable
{
    public event Action OnDamageTaken;
    public void DamageTaken();
}