using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GTL.Models;

namespace DBPopulator
{
    public class PopMember
    {
        public void createMembers(int amount)
        {
            for (int i = 1; i < amount + 1; i++)
            {

                Address adr = new PopAddress().createAddress(i);

                Member m = createMember(i);


            }
        }

        public Member createMember(int id)
        {

        }

        private Member insertMember(Member m)
        {

        }
    }
}
