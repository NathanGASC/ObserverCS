# Observer
Observer module is an implementation for Observer design pattern. Observer design pattern is used when you have a class which should send event and other classes should
do things on those events.

## How to use
Add the dll to your dependencies. You will find it at "\bin\Debug\net6.0\observer.dll"

Here an example of use of Observer module.

```cs
namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var google = new Google();
            var analytics = new Analytics();

            analytics.Subscribe(google);
            google.Search("How to implement Observer design patern?");
            google.SetLang("en");
        }
    }

    class Google : Observer.Observable
    {
        public void Search(string search)
        {
            //OnSearch method which listen to Search event only take one parameter (the string which is searched). If your method
            //have more parameters, you have to increase the size of the array. Also, be sure that type correpond to each other or
            //you will get an error (for example if you try to pass a int to OnSearch method, an error will be fired).
            var data = new Object[1];
            data[0] = search;
            this.Notify("Search", data);
        }
        public void SetLang(string lang)
        {
            var data = new Object[1];
            data[0] = lang;
            this.Notify("SetLang", data);
        }
    }

    class Analytics : Observer.Observer
    {
        public void OnSearch(string search)
        {
            Console.WriteLine("User made a research for '" + search + "'");
        }
    }

}
```