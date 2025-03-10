using System;

namespace SharpBuilder.Abstract
{
  public abstract class SharpMaterialBuilder
  {
    protected bool Built { get; set; }

    protected void EnsureNotBuilt() {
      if (Built) {
        throw new Exception("Already called Build method, SharpBuilder Build methods can not be called twice.");
      }
    }

    protected void SetBuilt() {
      EnsureNotBuilt();
      Built = true;
    }
  }
}