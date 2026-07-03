using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    // Interface is a contract
    // Classes implement interfaces

    class Program
    {
        static void Main(string[] args)
        {
            List<IComputerController> controllers = new List<IComputerController>();

            Keyboard keyboard = new Keyboard();
            GameController gameController = new GameController();
            BatteryPoweredGameController battery = new BatteryPoweredGameController();
            BatteryPoweredKeyboard batteryKeyboard = new BatteryPoweredKeyboard();

            controllers.Add(keyboard);
            controllers.Add(gameController);
            controllers.Add(battery);

            foreach (IComputerController controller in controllers)
            {
                // here we can only access the methods and properties that are defined in the interface, not the unique properties of each
                controller.Connect();

                if (controller is GameController gc)
                {
                   
                }

                if (controller is IBatteryPowered powered)
                {
                    powered.BatteryLevel = 100; // can only access the properties of the interface, not the unique properties of each
                    controller.Connect(); // can access the methods of the interface
                }
            }

            using (GameController gc = new GameController())
            {

            } // after this line, the Dispose method will be called automatically (so whatever is in the memory will be cleaned up (e.g. a big picture)

            List<IBatteryPowered> powereds = new List<IBatteryPowered>();

            powereds.Add(battery);
            powereds.Add(batteryKeyboard);

            List<IRun> runningMammals = new List<IRun>();
            Person person = new Person();
            Animal animal = new Animal();

            runningMammals.Add(person);
            runningMammals.Add(animal);

            Console.ReadLine();
        }
    }

    public interface IComputerController : IDisposable // always start interface name with I, and it can also inherit other interfaces
    {
        void Connect(); // this is a signature line
        void CurrentKeyPressed();
    }

    public class Keyboard : IComputerController // looks like inheritance but it is not, it is implementation (that's why we have the capital I to distinguish)
    {
        public void Connect()
        {

        }

        public void CurrentKeyPressed()
        {

        }

        public void Dispose()
        {

        }

        public string ConnectionType { get; set; } // a unique property to keyboard
    }

    public interface IBatteryPowered
    {
        int BatteryLevel { get; set; }
    }

    public class BatteryPoweredKeyboard : Keyboard, IBatteryPowered
    {
        public int BatteryLevel { get; set; }
    }

    public class GameController : IComputerController, IDisposable
    {
        public void Connect()
        {

        }

        public void CurrentKeyPressed()
        {

        }

        public void Dispose()
        {
            // do whatever shutdown tasks needed
        }

    }

    public class BatteryPoweredGameController : GameController, IBatteryPowered // the interfaces are also inherited
    {
        public int BatteryLevel { get; set; } // a unique property to battery powered game controller
    }

    public interface IRun
    {

    }

    public class Person : IRun
    {

    }

    public class Animal : IRun
    {

    }
}