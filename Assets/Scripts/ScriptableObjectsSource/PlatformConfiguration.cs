using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
	private float _movingSpeed;

	[SerializeField]
	private bool _sticky = true;

	[SerializeField]
	private bool _destroying;

	[SerializeField]
	private DestroyOptions _destroyOption;

	[SerializeField]
	private int _amount;

	[SerializeField]
	private bool _fading;

	[SerializeField]
	private float _activeTime;

	[SerializeField]
	private float _disabledTime;
}
