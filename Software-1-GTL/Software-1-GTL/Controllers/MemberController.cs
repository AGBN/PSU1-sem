using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.Interfaces;
using GTL.Factories;
using System.Reflection;

namespace GTL.Controllers
{
    public class MemberController : IMemberController
    {
        public IFactory Factory { get; }
        public IDataAccess DataAccess { get;}

        public MemberController(IFactory factory)
        {
            this.Factory = factory;
            this.DataAccess = Factory.CreateDataAccess("Member");
        }

        public IModel Get(int id)
        {
            Member m = null ;

            //IDataAccess db = Factory.CreateDataAccess("Member");

            m = (Member)DataAccess.Get(id);

            return m;
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public void Create()
        {

            //IDataAccess dataAccess = Factory.CreateDataAccess("member");
            Member m = (Member)Factory.CreateModelMember();

            DataAccess.Insert(m);
        }


        /*
        public void Create(IDictionary<string, object> args)
        {
            Member m = new FactoryModels().Create<Member>("Member");
            IAccess dbAccess = new FactoryAccess().Create<IAccess>("Member");
            bool valid = false;

            try
            {
                valid = Validate(args, m.GetInfoProperties());
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            if (valid)
            {
                PopulateObject<Member>(args, out m);
                dbAccess.Create<Member>(m);
            }
            else
                throw new Exception("Creation of Member failed.");
        }

        
        // TODO move this to Factory
        public bool Validate(IDictionary<string, object> args, PropertyInfo[] info)
        {
            string[] ignoreProperties = { "Loans", "Notices", "Librarian" };
            bool valid = false;

            foreach (var item in info)
            {
                if (!ignoreProperties.Contains(item.Name))
                {
                    object value;
                    if (args.TryGetValue(item.Name, out value))
                    {
                        if (item.PropertyType.Equals(value.GetType()))
                            valid = true;
                        else
                        {
                            string msg = string.Format(
                                "Provided type {0} does not match with property type {1} for the key {2}",
                                item.PropertyType, value.GetType(), item.Name);

                            throw new InvalidCastException(msg);
                        }
                    }
                    else
                    {
                        string msg = string.Format(
                                "Dictionary does not contain the expected property {0} of type {1}",
                                item.Name, item.PropertyType);

                        throw new MissingFieldException(msg);
                    }
                }
            }

            return valid;
        }

        // TODO move this to Factory
        public void PopulateObject<T>(IDictionary<string, object> args, out T item)
        {



            throw new NotImplementedException();
        }*/
    }
}
