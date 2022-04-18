namespace Observer
{
    public class Observable
    {
        public List<Observer> Obs = new List<Observer>();

        public void Notify(string e, dynamic data)
        {
            Obs.ForEach((observer) =>
            {
                var method = observer.GetType().GetMethod("On" + e);
                if (method != null)
                {
                    method.Invoke(observer, data);
                }
                else
                {
                    Console.WriteLine("Observable: " + observer + " don't listen to event " + e + ". If you want to listen it, create 'On" + e + "' method in it.");
                }
            });
        }
    }
}