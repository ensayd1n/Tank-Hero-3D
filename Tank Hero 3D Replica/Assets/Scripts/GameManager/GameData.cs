using UnityEngine.Serialization;

[System.Serializable]
public class GameData
{
   public int Level = 1;
   public int Money = 0;
   public float AmmoDamageValue = 1;
   public int AmmoDamageValueLevel = 1;
   public float AmmoFireDuration = 1;
   public int AmmoFireDurationLevel = 1;
   public int PropertiesLevelPrice = 20;
   public int AmmoFireDurationLevelPrice = 20;
   public int AmmoFireDamageValueLevelPrice = 20;
   public int BarrierBlockMinimumIndex = 1;
   public int BarrierBlockMaximumIndex = 5;

   public GameData(int level,int money ,float ammoDamageValue,float ammoFireDuration,int ammoDamageValueLevel,int ammoFireDurationLevel,int ammoFireDurationLevelPrice,int ammoFireDamageValueLevelPrice,int barrierBlockMinimumIndex,int barrierBlockMaximumIndex)
   {
      this.Level = level;
      this.Money = money;
      this.AmmoDamageValue = ammoDamageValue;
      this.AmmoFireDuration = ammoFireDuration;
      this.AmmoDamageValueLevel = ammoDamageValueLevel;
      this.AmmoFireDurationLevel = ammoFireDurationLevel;
      this.AmmoFireDurationLevelPrice = ammoFireDurationLevelPrice;
      this.AmmoFireDamageValueLevelPrice = ammoFireDamageValueLevelPrice;
      this.BarrierBlockMinimumIndex = barrierBlockMinimumIndex;
      this.BarrierBlockMaximumIndex = barrierBlockMaximumIndex;
   }
   
}
