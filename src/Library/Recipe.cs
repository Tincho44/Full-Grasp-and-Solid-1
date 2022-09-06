//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }

        public double GetProductionCosto()
        {
            double Insumos =0;
            double Equipamiento =0;

            foreach (Step step in this.steps)
            {
                Insumos = Insumos + step.Quantity;
                Equipamiento = Equipamiento + step.Time * step.Equipment.HourlyCost;

            }

            return Insumos + Equipamiento;
        }

        /*

            En este caso se uso los principios de SRP y el patron Expert. El de SRP por que cada clase tiene que tener solo una responsabilidad
            y el de Expert por que cada clase tiene la informacion primordial para ejecutar las tareas que ejecuta. Osea que la clase
            tiene asignada la responsabilidad que tiene segun su informacion.
            
        */


    }
}