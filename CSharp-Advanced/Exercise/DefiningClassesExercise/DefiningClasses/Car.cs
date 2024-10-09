using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {

        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.weight = -1;
            this.color = "n/a";
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine, color)
        {
            this.weight = weight;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }       
        }
        public override string ToString()
        {
            string ds = engine.Displacement.ToString();
            
            if(engine.Displacement == -1)
            {
                ds = "n/a";
            }
            
            string w = weight.ToString();
            
            if(weight == -1)
            {
                w = "n/a";
            }

            return $"{model}:{Environment.NewLine}" +
                $"  {engine.Model}:{Environment.NewLine}" +
                $"    Power: {engine.Power}{Environment.NewLine}" +
                $"    Displacement: {ds}{Environment.NewLine}" +
                $"    Efficiency: {engine.Efficiency}{Environment.NewLine}" +
                $"  Weight: {w}{Environment.NewLine}" +
                $"  Color: {color}";
        }
    }
}
