using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/*
 BlockingCollection is a collection class which ensures thread-safety. Multiple threads can add and remove objects in BlockingCollection concurrently.

 It implements the producer-consumer pattern. In this pattern, there are two threads one is called producer and other is called consumer. 
 Both threads share a common collection class to exchange data between them. BlockingCollection can be used as the collection class. 
 Producer thread generates the data and consumer thread is consuming the data. We set the maximum limit of collection class. 
 Producer cannot add new objects more than maximum limit and consumer cannot remove data from an empty collection class.


BlockingCollection has two features which differentiate it from other concurrent classes.

- Bounding
- Blocking
Both features help us to implement producer-consumer pattern.
Bounding means we can set the maximum number of objects that we can store in the collection. When a producer thread reaches BlockingCollection maximum limit, 
it is blocked to add new objects. In the blocked stage, thread goes in the sleep mode. It will unblock when consumer thread remove item from the collection.
When collection class is empty, the consumer thread is blocked until the producer thread adds new item.

At the end, producer thread calls the CompleteAdding method. CompleteAdding set the IsCompleted property to true. 
A consumer thread monitors the IsCompleted property to know that there are no more items to add.

ConcurrentBag<T>
Thread-safe implementation of an unordered collection of elements.

ConcurrentQueue<T>
Thread-safe implementation of a FIFO (first-in, first-out) queue.

ConcurrentStack<T>
Thread-safe implementation of a LIFO (last-in, first-out) stack.

IProducerConsumerCollection<T>
The interface that a type must implement to be used in a BlockingCollection

*/
namespace OOPS.BlockingCollectionEx
{

    
    class BlockingCollectionEx
    {
        public void Performance()
        {
            BlockingCollection<int> bc = new BlockingCollection<int>(5);

            var producer = Task.Factory.StartNew(() => {
                Random r = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int t = r.Next();
                    Thread.Sleep(3000);
                    bc.Add(t);
                    Console.WriteLine($"producer : {t}");
                }
                bc.CompleteAdding();
                Console.WriteLine("producer: Completed_Adding");
            });

            var consumer = Task.Factory.StartNew(() => {
                Random r = new Random();
                foreach (var item in bc.GetConsumingEnumerable())
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"consumer :{item}");
                }
                Console.WriteLine("consumer: Completed_Enumeration");
            });

            consumer.Wait();
        }
    }

    public class Client
    {
        public static void Execute()
        {
            BlockingCollectionEx bcx = new BlockingCollectionEx();
            bcx.Performance();
        }
    }
}
