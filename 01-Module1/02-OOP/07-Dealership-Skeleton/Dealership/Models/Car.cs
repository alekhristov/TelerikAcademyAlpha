﻿using System.Collections.Generic;
using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;
using System;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private int seats;

        public Car(string make, string model, decimal price, int seats) : base(make, model, price)
        {
            this.Seats = seats;
            this.Type = VehicleType.Car;
            this.Wheels = (int)VehicleType.Car;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            protected set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Seats must be between 1 and 10!");
                }
                this.seats = value;
            }
        }

        public override string ToString()
        {
            return $"Seats: {this.Seats}";
        }
    }

}
