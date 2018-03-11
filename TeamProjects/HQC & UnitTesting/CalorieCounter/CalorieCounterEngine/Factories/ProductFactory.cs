﻿using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.DrinksModel;
using CalorieCounter.Models.FoodModel;

namespace CalorieCounter.Factories
{
    public class ProductFactory : IProductFactory
    {
        public IProduct CreateDrink(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g,
            int fatPer100g, int sugar = 0, int fiber = 0)
        {
            return new CustomDrink(name, caloriesPer100g, proteinPer100g, carbsPer100g, fatPer100g, sugar, fiber);
        }

        public IProduct CreateFoodProduct(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g,
            int fatPer100g, int sugar = 0, int fiber = 0)
        {
            return new CustomFoodProduct(name, caloriesPer100g, proteinPer100g, carbsPer100g, fatPer100g, sugar, fiber);
        }
    }
}