using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover: MonoBehaviour
{
    [SerializeField] private CraftingMenu m_Menu;
    public int num;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        m_Menu.ItemSelected(num);
    }
}
