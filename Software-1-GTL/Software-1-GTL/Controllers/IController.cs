using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.Controllers
{
    public interface IController
    {
        IModel Get(params int[] id);

        IModel Get(params string[] id);

        /// <summary>
        /// Gets a specified amount of objects.
        /// </summary>
        /// <param name="amount">Sets the maxmimum amount of items to get. 0 is unlimited.</param>
        /// <param name="offset">Sets how many items should be skipped.</param>
        /// <returns>A collection of objects. </returns>
        ICollection<IModel> GetAll(int amount, int offset);

















        /*IModel Create();
        
        void Create(IDictionary<string, object> args);

        /// <summary>
        /// Validates if the data provided is usable by the "Create" method on the controller.
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"> If an argument doesnt match.</exception>
        /// <returns>Boolean</returns>
        bool Validate(IDictionary<string, object> args, PropertyInfo[] info);

        /// <summary>
        /// Used to populat an object with a certian amount of parameters. 
        /// "Validate" method should be used to check if the arguments are valid.
        /// </summary>
        /// <typeparam name="T"> A type to be populated.</typeparam>
        /// <param name="args">Arguments to be used to populate the object.</param>
        /// <param name="item">The object to be populated.</param>
        void PopulateObject<T>(IDictionary<string, object> args, out T item);*/
    }
}
