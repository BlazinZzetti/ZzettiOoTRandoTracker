using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItemManager : MonoBehaviour
{
    public CollectableItem Sticks;
    public CollectableItem Nuts;
    public CollectableItem Bombs;
    public CollectableItem Bow;
    public CollectableItem FireArrow;
    public CollectableItem IceArrow;
    public CollectableItem LightArrow;
    public CollectableItem Slingshot;
    public CollectableItem Ocarina;
    public CollectableItem Bombchu;
    public CollectableItem Hookshot;
    public CollectableItem Boomarang;
    public CollectableItem LensOfTruth;
    public CollectableItem MagicBeans;
    public CollectableItem Hammer;
    public CollectableItem DinsFire;
    public CollectableItem FoaresWind;
    public CollectableItem NayrusLove;
    public CollectableItem ChildSword;
    public CollectableItem MasterSword;
    public CollectableItem BiggoronSword;
    public CollectableItem DekuShield;
    public CollectableItem HylianShield;
    public CollectableItem MirrorShield;
    public CollectableItem StrengthUpgrade;
    public CollectableItem GoronTunic;
    public CollectableItem ZoraTunic;
    public CollectableItem Scale;
    public CollectableItem IronBoots;
    public CollectableItem HoverBoots;
    public CollectableItem ZeldasLullaby;
    public CollectableItem EponasSong;
    public CollectableItem SariasSong;
    public CollectableItem SunSong;
    public CollectableItem SongOfTime;
    public CollectableItem SongOfStorms;
    public CollectableItem Bottle;
    public CollectableItem Minuet;
    public CollectableItem Borolo;
    public CollectableItem Seranade;
    public CollectableItem Prelude;
    public CollectableItem Nocturn;
    public CollectableItem LightSongLol;
    public CollectableItem Wallet;
    public CollectableItem Magic;
    public CollectableItem Skulltula;
    public CollectableItem GerudoCard;
    public CollectableItem StoneOfAgony;
    public CollectableItem ForestClear;
    public CollectableItem FireClear;
    public CollectableItem WaterClear;
    public CollectableItem SpiritClear;
    public CollectableItem ShadowClear;
    public CollectableItem FreeClear;
    public CollectableItem DekuClear;
    public CollectableItem CavernClear;
    public CollectableItem JabuClear;

    public bool HasExplosives
    {
        get { return Bombs.ItemAcquired || Bombchu.ItemAcquired; }
    }

    public bool HasShieldAdult
    {
        get { return HylianShield.ItemAcquired || MirrorShield.ItemAcquired; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
