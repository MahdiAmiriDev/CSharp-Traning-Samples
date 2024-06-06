namespace ControllersWithViews.Models
{
    public interface IPepole
    {
        string GetName();
    }

    public class PepoleRepo : IPepole
    {
        public string GetName() => "mahdi amiri";
    }
}
