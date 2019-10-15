using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*
Abstract factory expands on the basic factory pattern. 
Abstract factory helps us to unite similar factory pattern classes in to one unified interface. 
So basically all the common factory patterns now inherit from a common abstract factory class which unifies them in a common class. 
*/


namespace DesignPattern.Creational.AbstractFactory
{
    public interface IRender
    {
        void RenderMe();
    }

    public abstract class AbstractFactoryControls
    {
        //abstract method
        public abstract void Click(); 

        public static IRender GetUIObject(int UIObjectType)
        {
            IRender iRender = null;

            switch (UIObjectType)
            {
                case 1:
                    {
                        iRender = FactoryButton.GetButtonObject();
                        break;
                    }
                case 2:
                    {
                        iRender = FactoryTextBox.GetbTextBoxObject();
                        break;
                    }
            }

            return iRender;
        }
    }

    public class FactoryButton : AbstractFactoryControls
    {
        public override void Click()
        {
            Console.WriteLine("FactoryButton");
        }

        public static IRender GetButtonObject()
        {
            return new UIButton();
        }
    }

    public class FactoryTextBox : AbstractFactoryControls
    {
        public override void Click()
        {
            Console.WriteLine("FactoryTextBox");
        }

        public static IRender GetbTextBoxObject()
        {
            return new UITextBox();
        }
    }

    public class UIButton : IRender
    {
        public void RenderMe()
        {
            Console.WriteLine("Button Rendered");
        }
    }

    public class UITextBox : IRender
    {
        public void RenderMe()
        {
            Console.WriteLine("TextBox Rendered");
        }
    }

    public class Client
    {
        public static void Execute()
        {
            IRender iRenderClient = null;

            iRenderClient = AbstractFactoryControls.GetUIObject(1);
            iRenderClient.RenderMe();

        }
    }


}
