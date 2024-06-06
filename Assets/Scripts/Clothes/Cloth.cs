using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Cloth : MonoBehaviour, Interactable
{
    [SerializeField] Clothes_Base _base;
    [SerializeField] Light2D light;
    [SerializeField] SpriteRenderer sprite;

    public Clothes_Base Base { get { return _base; } }

    public void SetBase(Clothes_Base newBase)
    {
        _base = newBase;
        if (_base != null)
        {
            light.enabled = true;
            sprite.enabled = true;
            light.color = _base.GetColor();
            sprite.sprite = _base.Sprite;
        }
        else
        {
            light.enabled = false;
        }
    }

    public void TakeBase()
    {
        light.enabled = false;
        sprite.enabled = false;
        _base = null;
    }

    private void Start()
    {
        if (_base != null)
        {
            light.enabled = true;
            light.color = _base.GetColor();
            sprite.sprite = _base.Sprite;
        }
        else
        {
            light.enabled = false;
        }
        StartCoroutine(SwitchIntensity());
    }

    IEnumerator SwitchIntensity()
    {
        var dir = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (dir == 0)
            {
                light.intensity += 10 * Time.deltaTime;
                if (light.intensity >= 6)
                {
                    dir = 1;
                }
            }
            else
            {
                light.intensity -= 10 * Time.deltaTime;
                if (light.intensity <= 4)
                {
                    dir = 0;
                }
            }
        }
    }

    void Interactable.Interact(PlayerData data)
    {
        if (data.clothes[((int)_base.Type)] == null)
        {
            data.clothes[((int)_base.Type)] = _base;
            TakeBase();
        }
        else
        {
            var newBase = data.clothes[((int)_base.Type)];
            data.clothes[((int)_base.Type)] = _base;
            SetBase(newBase);
        }
    }
}
