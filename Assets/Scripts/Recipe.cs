using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe Data", menuName = "Scriptable Object/Recipe Data", order = int.MaxValue)]


public class Recipe : ScriptableObject
{

    [SerializeField]
    private string FoodName;
    public string GetFoodName { get { return FoodName; } }

    [SerializeField]
    private List<BaseFood> CombinedFood;
    public List<BaseFood> GetCombinedFood { get { return CombinedFood; } }
}
