using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Loc> polygons = new List<Loc>()        
                {
                    new Loc { Lt = 24.539119, Lg = 74.239466 },
                    new Loc { Lt = 18.13749, Lg = 74.832727 },
                    new Loc { Lt = 18.949925, Lg = 83.687708 },
                    new Loc { Lt = 25.633594, Lg = 82.720911 }
                };

            Loc mylocatoin = new Loc();
            mylocatoin.Lt = 22.7196; 
            mylocatoin.Lg = 75.8577;

            bool result = IsPointInPolygon(polygons, mylocatoin);
        }

        static bool IsPointInPolygon(List<Loc> poly, Loc point)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
            {
                if ((((poly[i].Lt <= point.Lt) && (point.Lt < poly[j].Lt))
                        || ((poly[j].Lt <= point.Lt) && (point.Lt < poly[i].Lt)))
                        && (point.Lg < (poly[j].Lg - poly[i].Lg) * (point.Lt - poly[i].Lt)
                            / (poly[j].Lt - poly[i].Lt) + poly[i].Lg))
                {

                    c = !c;
                }
            }

            return c;
        }
    }

    public class Loc
    {
        private double lt;
        private double lg;

        public double Lg
        {
            get { return lg; }
            set { lg = value; }
        }

        public double Lt
        {
            get { return lt; }
            set { lt = value; }
        }

        //public Loc(double lt, double lg)
        //{
        //    this.lt = lt;
        //    this.lg = lg;
        //}
    }
}
