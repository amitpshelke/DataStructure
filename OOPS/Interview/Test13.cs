using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Interview
{
    public interface IReptile
    {
        ReptileEgg Lay();
    }

    public class FireDragon : IReptile
    {
        private IReptile iReptile = null;

        public FireDragon()
        {
        }

        public ReptileEgg Lay()
        {
            return new ReptileEgg(iReptile);
        }
    }

    public class ReptileEgg
    {
        private readonly Func<IReptile> _createReptile;
        private IReptile iReptile = null;
        private bool eggHatched = false;

        public ReptileEgg(Func<IReptile> createReptile)
        {
            _createReptile = createReptile;
        }

        public IReptile Hatch()
        {
            if (eggHatched)
               throw new System.InvalidOperationException();

            eggHatched = true;

            return (iReptile == null ? _createReptile() :  null);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var fireDragon = new FireDragon();
            var egg = fireDragon.Lay();
            var childFireDragon = egg.Hatch();
        }
    }
}
