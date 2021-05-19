using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static DrawIfAttribute;

[CreateAssetMenu(fileName = "PlatformConfiguration", menuName = "Custom/Platform")]
public class PlatformConfiguration : ScriptableObject
{
	public bool Moving => _moving;
	public float MovingSpeed => _movingSpeed;
	public bool Sticky => _sticky;
	public bool Destroying => _destroying;
	public DestroyOptions DestroyOption => _destroyOption;
	public int Amount => _amount;
	public bool Fading => _fading;
	public float ActiveTime => _activeTime;
	public float DisabledTime => _disabledTime;


	[SerializeField]
	private bool _moving;

	[SerializeField]
	[DrawIf(nameof(_moving), true)]
	private float _movingSpeed;

	[SerializeField]
	[DrawIf(nameof(_moving), true)]
	private bool _sticky = true;

	[SerializeField]
	private bool _destroying;

	[SerializeField]
	[DrawIf(nameof(_destroying), true)]
	private DestroyOptions _destroyOption;

	[SerializeField]
	[DrawIf(nameof(_destroying), true)]
	private int _amount;

	[SerializeField]
	private bool _fading;

	[SerializeField]
	[DrawIf(nameof(_fading), true)]
	private float _activeTime;

	[SerializeField]
	[DrawIf(nameof(_fading), true)]
	private float _disabledTime;
}
