using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Delegate_Interface
{
    /*
        
    */
    public delegate void MalwareDetectionEventHandler(string status);
    public delegate void QuarantineEventHandler();
    public interface IMalwareDectection
    {
        MalwareDetectionEventHandler MalwareDectected { get; set; }
        QuarantineEventHandler Qurantined { get; set; }
    }




    public delegate void SpywareDectectionEventArgs();
    public delegate void DeletedEventArgs();
    public interface ISpywareDetection
    {
        event EventHandler<SpywareDectectionEventArgs> SpywareDetected;
        event EventHandler<DeletedEventArgs> Deleted;
    }





    public class Antivirus : IMalwareDectection, ISpywareDetection
    {
        public MalwareDetectionEventHandler MalwareDectected
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public QuarantineEventHandler Qurantined
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }



        public event EventHandler<SpywareDectectionEventArgs> SpywareDectectedEvent;
        public event EventHandler<DeletedEventArgs> DeletedEvent;

        object objectLock = new Object();

        //Explicit interface implementation required
        event EventHandler<SpywareDectectionEventArgs> ISpywareDetection.SpywareDetected
        {
            add
            { 
                lock (objectLock)
                {
                    SpywareDectectedEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    SpywareDectectedEvent -= value;
                }
            }
        }

        //Explicit interface implementation required
        event EventHandler<DeletedEventArgs> ISpywareDetection.Deleted
        {
            add
            {
                lock (objectLock)
                {
                    DeletedEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    DeletedEvent -= value;
                }
            }
        }


        public void ExecuteAction()
        {
            SpywareDectectedEvent?.Invoke(this, null);

            DeletedEvent?.Invoke(this, null);

        }
    }



   

    
}
