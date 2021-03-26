using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Indexers
{
    /*
    An indexer allows an instance of a class or struct to be indexed as an array. If the user will define an indexer for a class, then the class will behave like a virtual array.
    Array access operator i.e ([ ]) is used to access the instance of the class which uses an indexer. 
    A user can retrieve or set the indexed value without pointing an instance or a type member. 
    Indexers are almost similar to the Properties. 
    The main difference between Indexers and Properties is that the accessors of the Indexers will take parameters. 
    */

    //Single Dimensional Indexer 
    class OfficeTeam
    {
        private string[] names = new string[10];
        private int[] badge = new int[10];
        public string this[int i]
        {
            get
            {
                return names[i];
            }
            set
            {
                names[i] = value;
            }
        }
    }



    /*
     The multi-dimensional indexer is almost similar to multidimensional arrays. 
     For the efficient content-based retrieval of data, multidimensional indexers are used. 
     To create multi-dimensional indexer you have to pass at least two parameters in the argument list of indexer declaration. 
     To access a single element of a multi-dimensional indexer, use integer subscripts. Each subscript indexes a dimension like the first indexes the row dimension, 
     the second indexes the column dimension and so on. 
    */

    //Multi Dimensional Indexer 
    class MatrixData
    {
        int[,] data = new int[3, 3];

        public int this[int i, int j]
        {
            get
            {
                return data[i, j];
            }
            set
            {
                data[i, j] = value;
            }
        }
    }

    public class Client
    {
        public static void Execute()
        {
            OfficeTeam team = new OfficeTeam();
            team[0] = "Rocky";
            team[1] = "Teena";
            team[2] = "Ana";
            team[3] = "Victoria";
            team[4] = "Yani";
            team[5] = "Mary";
            team[6] = "Gomes";
            team[7] = "Arnold";
            team[8] = "Mike";
            team[9] = "Peter";

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(team[i]);
            }



            //Multi Dimensional Indexers
            MatrixData mData = new MatrixData();
            // 1st row 
            mData[0, 0] = 1;
            mData[0, 1] = 2;
            mData[0, 2] = 3;

            // 2nd row 
            mData[1, 0] = 4;
            mData[1, 1] = 5;
            mData[1, 2] = 6;

            // 3rd row 
            mData[2, 0] = 7;
            mData[2, 1] = 8;
            mData[2, 2] = 9;

            // displaying the values 
            Console.WriteLine("{0}\t{1}\t{2}\n{3}\t{4}\t{5}\n{6}\t{7}\t{8}",
                                      mData[0, 0], mData[0, 1], mData[0, 2],
                                      mData[1, 0], mData[1, 1], mData[1, 2],
                                      mData[2, 0], mData[2, 1], mData[2, 2]);
        }
    }
}
