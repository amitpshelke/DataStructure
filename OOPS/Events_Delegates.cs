using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OOPS.Events_Delegates
{
    /*
    Events:
        1. A mechanism for communication between objects
        2. Used in building loosely coupled application
        3. Helps in extending application

    Delegate:
        1. an agreement between a publisher and subscriber
        2. determines the signature of the event handler method in subsciber


        A delegate is an object which refers to a method or you can say it is a reference type variable that can hold a reference to the methods. 


        ***Important Points About Delegates:

            - Provides a good way to encapsulate the methods.
            - Delegates are the library class in System namespace.
            - These are the type-safe pointer of any method.
            - Delegates are mainly used in implementing the call-back methods and events.
            - Delegates can be chained together as two or more methods can be called on a single event.
            - It doesn’t care about the class of the object that it references.
            - Delegates can also be used in “anonymous methods” invocation.
            - Anonymous Methods(C# 2.0) and Lambda expressions(C# 3.0) are compiled to delegate types in certain contexts. 
              Sometimes, these features together are known as anonymous functions.
    */

    // 1. Define a delegate
    // 2. Define a event based on that delegate
    // 3. Raise the event



    public class Video
    {
        public string Title { get; set; }
    }



    public class VideoEventArgs : EventArgs
    {
        public Video xVideo { get; set; }
    }

    public class VideoEncoder
    { 
        public delegate void VideoEncodedEventHandler(object Source, EventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;

        //the above two lines can alternatively written in this format
        public event EventHandler VideoEncoded_Extn;


        public delegate void VideoDecodedEventHandler(object Source, VideoEventArgs args);
        public event VideoDecodedEventHandler VideoDecoded;

        //the above two lines can alternatively written in this format
        public event EventHandler<VideoEventArgs> VideoDecoded_Extn;

        public void Encode(Video video)
        {
            //some logic to encode video
            Console.WriteLine("Encoding Video... :" + video.Title);
            Thread.Sleep(3000);

            OnVideoEncoded();
        }


        public void Decode(Video video)
        {
            //some logic to encode video
            Console.WriteLine("Decoding Video... :" + video.Title);
            Thread.Sleep(3000);

            OnVideoDecoded(video);
        }



        protected virtual void OnVideoEncoded() //In .net there is naming convention; event publisher method should be protected and virtual
        {
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);

        }

        protected virtual void OnVideoDecoded(Video video) //In .net there is naming convention; event publisher method should be protected and virtual
        {
            if (VideoDecoded != null)
                VideoDecoded(this, new VideoEventArgs() { xVideo = video });

        }
    }


    public class MailService
    {
        public void OnVideoEncoded(object Source, EventArgs e)
        {
            Console.Write("Mail Service : Sending Email...");
            Thread.Sleep(2000);
            Console.WriteLine("Done");
        }
    }

    public class MessageService
    {
        public void OnVideoDecoded(object Source, VideoEventArgs ve)
        {
            Console.Write("Message Service : Sending SMS...");
            Thread.Sleep(3000);
            Console.WriteLine("Done");
        }
    }


    public class Client
    {
        public static void Execute()
        {
            Video video = new Video() { Title = "Garden Video" };
            VideoEncoder videoEncoder = new VideoEncoder();  //publisher


            MailService mailService = new MailService();     //subscriber
            MessageService messageService = new MessageService();//subscirber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //subscriber subscribing to publisher event.
            videoEncoder.VideoDecoded += messageService.OnVideoDecoded; //subscriber subscribing to publisher event.


            videoEncoder.Encode(video); //publisher event is executed; which eventually call the subscriber method.
            videoEncoder.Decode(video); //publisher event is executed; which eventually call the subscriber method.
        }
    }

}
