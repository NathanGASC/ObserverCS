namespace Observer
{
    public class Observer
    {
        public void Subscribe(Observable obs)
        {
            obs.Obs.Add(this);
        }
    }
}