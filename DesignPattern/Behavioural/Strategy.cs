using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavioural.Strategy
{

    /*
     Use the Strategy pattern when you want to use different variants of an algorithm within an object and be able to switch from one algorithm to another during runtime.
     - The Strategy pattern lets you indirectly alter the object’s behavior at runtime by associating it with different sub-objects which can perform specific sub-tasks 
       in different ways.

     Use the Strategy when you have a lot of similar classes that only differ in the way they execute some behavior.
     - The Strategy pattern lets you extract the varying behavior into a separate class hierarchy and combine the original classes into one, thereby reducing duplicate code.

     Use the pattern to isolate the business logic of a class from the implementation details of algorithms that may not be as important in the context of that logic.

     - The Strategy pattern lets you isolate the code, internal data, and dependencies of various algorithms from the rest of the code. 
       Various clients get a simple interface to execute the algorithms and switch them at runtime.

     Use the pattern when your class has a massive conditional operator that switches between different variants of the same algorithm.

     - The Strategy pattern lets you do away with such a conditional by extracting all algorithms into separate classes, all of which implement the same interface. 
       The original object delegates execution to one of these objects, instead of implementing all variants of the algorithm.

    */
    public interface ICompression
    {
        void CompressFolder(string compressedArchiveFileName);
    }

    public class RarCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is compressed using Rar approach: '" + compressedArchiveFileName + ".rar' file is created");
        }
    }

    public class ZipCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is compressed using zip approach: '" + compressedArchiveFileName + ".zip' file is created");
        }
    }

    public class CompressionContext
    {
        private ICompression Compression;

        public CompressionContext(ICompression Compression)   //while initialize we can/have to select either of these compression strategy i.e. ZIP or RAR
        {
            this.Compression = Compression;
        }
        public void ChangeStrategy(ICompression Compression)  
        {
            this.Compression = Compression;
        }
        public void CreateArchive(string compressedArchiveFileName)
        {
            Compression.CompressFolder(compressedArchiveFileName);
        }
    }

    public class Client
    {
        public static void Execute()
        {
            CompressionContext ctx = new CompressionContext(new ZipCompression());  // while initialize we have selected ZIP compression strategy
            ctx.CreateArchive("ABC");

            ctx.ChangeStrategy(new RarCompression());    //we are changing file compression strategy to RAR
            ctx.CreateArchive("ABC");
        }
    }

}
