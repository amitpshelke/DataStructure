using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Interface_Subscribe
{


    public interface IEncoder
    {
        event EncoderCaller EncoderCalled;
    }

    public  delegate void EncoderCaller(object Source, EventArgs args);

    public class Video
    {
        public string Title { get; set; }
    }

    public class VideoEventArgs : EventArgs
    {
        public Video xVideo { get; set; }
    }


    public class DetectionAction : IEncoder
    {
        public event EncoderCaller EncoderCalled;

        public void Encode(Video video)
        {
            //some logic to encode video

            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if (EncoderCalled != null)
                EncoderCalled(this, EventArgs.Empty);

        }
    }




    public class Interface_Subscribe : IEncoder
    {
        public event EncoderCaller EncoderCalled;
    }
}
