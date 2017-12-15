using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private Role role;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.Vehicles = new List<IVehicle>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Username must be between 2 and 20 characters long!");
                }

                var pattern = @"^[A-Za-z0-9]+$";
                var match = Regex.Match(value, pattern);

                if (!match.Success)
                {
                    throw new ArgumentException("Username contains invalid symbols!");
                }

                this.username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Firstname must be between 2 and 20 characters long!");
                }
                Guard.WhenArgument(value, "First name can not be null!").IsNull().Throw();
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Lastname must be between 2 and 20 characters long!");
                }

                Guard.WhenArgument(value, "Last name can not be null!").IsNull().Throw();
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Password must be between 5 and 30 characters long!");
                }
                Guard.WhenArgument(value, "Password can not be null!").IsNull().Throw();

                var pattern = @"^[A-Za-z0-9@*_-]+$";
                var match = Regex.Match(value, pattern);

                if (!match.Success)
                {
                    throw new ArgumentException("Invalid password!");
                }

                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Role), value)) throw new ArgumentException("Invalid role type");
                this.role = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
            set
            {
                Guard.WhenArgument(value, "Vehicles can not be null!").IsNull().Throw();
                this.vehicles = value;
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            if (vehicleToAddComment != null && commentToAdd != null)
            {
                vehicleToAddComment.Comments.Add(commentToAdd);
            }
        }

        public void AddVehicle(IVehicle vehicle)
        {
            Guard.WhenArgument(vehicle, "Vehicle can not be null!").IsNull().Throw();

            if (role == Role.Admin)
            {
                throw new ArgumentException("You are an admin and therefore cannot add vehicles!");
            }
            else if (role != Role.VIP && Vehicles.Count == 5)
            {
                throw new ArgumentException("You are not VIP and cannot add more than 5 vehicles!");
            }

            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"--USER {Username}--");

            if (!Vehicles.Any())
            {
                throw new ArgumentNullException("--NO VEHICLES--");
            }

            var counter = 1;

            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine($"  {counter}. {vehicle.Type}:");
                sb.AppendLine($"  Make: {vehicle.Make}");
                sb.AppendLine($"  Model: {vehicle.Model}");
                sb.AppendLine($"  Wheels: {vehicle.Wheels}");
                sb.AppendLine($"  Price: ${vehicle.Price}");
                sb.AppendLine($"  {vehicle.ToString()}");

                if (vehicle.Comments.Count > 0)
                {
                    sb.AppendLine("    --COMMENTS--");
                    sb.AppendLine("    ----------  ");

                    foreach (var comment in vehicle.Comments)
                    {
                        sb.AppendLine($"    {comment.Content}");
                        sb.AppendLine($"      User: {comment.Author}");
                        sb.AppendLine("    ----------");
                        sb.AppendLine("    ----------");
                    }

                    sb.AppendLine("    --COMMENTS--");
                    sb.AppendLine("    ----------  ");
                }
                else
                {
                    sb.AppendLine("    --NO COMMENTS--");
                }

                counter++;
            }

            return sb.ToString().TrimEnd();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (!vehicleToRemoveComment.Comments.Any(c => c == commentToRemove))
            {
                throw new ArgumentException("Cannot remove comment! The comment does not exist!");
            }
            vehicleToRemoveComment.Comments.Remove(commentToRemove);

            if (commentToRemove.Author != Username)
            {
                throw new ArgumentException("You are not the author!");
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            Vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            return ($"Username: {Username}, FullName: {FirstName} {LastName}, Role: {Role}");
        }
    }
}
