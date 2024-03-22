using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Define
{
	public enum UIEvent
	{
		Click,
		Pressed,
		PointerDown,
		PointerUp,
	}

	public enum Scene
	{
		Unknown,
		Dev,
		Game,
	}

	public enum Sound
	{
		Bgm,
		Effect,
		Speech,
		Max,
	}

    public const float Aya_BareHands		= 0;
	public const float Aya_Gun				= 0.33f;
    public const float Aya_Pistol			= 0.66f;
    public const float Aya_Snipe			= 1;

	public const float HyunWoo_BareHands	= 0;
	public const float HyunWoo_Glove		= 0.5f;
	public const float HyunWoo_Tonfa		= 1;

	public const float Jackie_OneHand		= 0;
	public const float Jackie_TwoHand		= 0.2f;
	public const float Jackie_Axe			= 0.4f;
	public const float Jackie_BareHands		= 0.6f;
	public const float Jackie_Dual			= 0.8f;
	public const float Jackie_Saw			= 1;


	public enum AnimState
	{
		Run,
		Wait,
		Q,
		W,
		E,
		R,
		D,
		Rest,
		Collect,
		Fishing,
		Operat,
		Open,
		Dance,
		CraftMetal,
		CraftFood,
		Arrive,
		Down,
		Down_Walk,
		Down_Dead,
	}

	public enum PlayerCharacterType
	{
		HyunWoo,
		Aya,
		Jackie,
	}

	public enum StatType
	{
		MaxHp,
		MaxMp,
		MaxExp,
		MoveSpeed,
		AtckSpeed,

	}



}
