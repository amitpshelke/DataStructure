using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.GarbageCollection
{
    /*
    The garbage collector (GC) manages the allocation and release of memory. The garbage collector serves as an automatic memory manager.

    - You do not need to know how to allocate and release memory or manage the lifetime of the objects that use that memory.

    - An allocation is made any time you declare an object with a “new” keyword or a value type is boxed. Allocations are typically very fast.

    - When there isn’t enough memory to allocate an object, the GC must collect and dispose of garbage memory to make memory available for new allocations.



    Garbage Collection occurs if at least one of multiple conditions is satisfied...

    1. If the system has low physical memory, then garbage collection is necessary.
    2. If the memory allocated to various objects in the heap memory exceeds a pre-set threshold, then garbage collection occurs.
    3. If the GC.Collect method is called, then garbage collection occurs. However, this method is only called under unusual situations as normally 
       garbage collector runs automatically


    It provides the following benefits:

    - Enables you to develop your application without having to manually free memory.
    - Allocates objects on the managed heap efficiently.
    - Reclaims objects that are no longer being used, clears their memory, and keeps the memory available for future allocations. 
      Managed objects automatically get clean content to start with, so their constructors do not have to initialize every data field.
    - Provides memory safety by making sure that an object cannot use the content of another object.

     *** As an application developer, you work only with virtual address space and never manipulate physical memory directly. 
         The garbage collector allocates and frees virtual memory for you on the managed heap.

     *** After the garbage collector is initialized by the CLR, it allocates a segment of memory to store and manage objects. 
         This memory is called the managed heap, as opposed to a native heap in the operating system.


        There are three generations of objects on the heap:

        Generation 0. => This is the youngest generation and contains short-lived objects. An example of a short-lived object is a temporary variable. 
                         Garbage collection occurs most frequently in this generation. Newly allocated objects form a new generation of objects and are 
                         implicitly generation 0 collections. However, if they are large objects, they go on the large object heap in a generation 2 collection.
                         Most objects are reclaimed for garbage collection in generation 0 and do not survive to the next generation.

        Generation 1. => This generation contains short-lived objects and serves as a buffer between short-lived objects and long-lived objects.

        Generation 2. => This generation contains long-lived objects. An example of a long-lived object is an object in a server application that contains static 
                         data that's live for the duration of the process.

        **GCs only occur when the heap is full and, until then, the managed heap is significantly faster


        ### What happens during a garbage collection?

 
         */

    //https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals
    //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/exception-handling-task-parallel-library
    //https://docs.microsoft.com/en-us/dotnet/api/system.aggregateexception?view=netframework-4.8

    public class SimpleCleanUp
    {
        //some fields that require cleanup
        private SafeHandle handle;

        //to detect redundant calls
        private bool IsDisposed = false; 

        public SimpleCleanUp()
        {
            //this.handle = /*...*/;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    if (handle != null)
                    {
                        handle.Dispose();
                    }
                }

                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }

    public class ComplexCleanupBase : IDisposable
    {
        // some fields that require cleanup
        private bool disposed = false; // to detect redundant calls

        public ComplexCleanupBase()
        {
            // allocate resources
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose-only, i.e. non-finalizable logic
                }

                // shared cleanup logic
                disposed = true;
            }
        }

        //Destrucor also called Finalize  
        ~ComplexCleanupBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class ComplexCleanupExtender : ComplexCleanupBase
    {
        // some new fields that require cleanup
        private bool disposed = false; // to detect redundant calls

        public ComplexCleanupExtender() : base()
        {
            // allocate more resources (in addition to base’s)
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose-only, i.e. non-finalizable logic
                }

                // new shared cleanup logic
                disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
